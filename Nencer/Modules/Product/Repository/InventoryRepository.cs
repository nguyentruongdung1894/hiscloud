using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Product.Model;
using Nencer.Modules.Product.Model.Dto;
using Nencer.Shared;
using PatientModel = Nencer.Modules.Patient.Model.Patient;
namespace Nencer.Modules.Product.Repository
{
    public interface IInventoryRepository
    {
        Task<BaseResponse<StockOrder>> CreateTicketImport(InventoryAddDto request, int? creator_id = 1);
        Task<BaseResponse<StockOrder>> CreateTicketTransfer(InventoryTransferDto request, int? creator_id = 1);
        Task<BaseResponse<StockOrder>> CreateTicketExportPatient(InventoryExportPatient request, int? creator_id = 1);
        Task<BaseResponse<StockOrder>> CreateTicketExportCancel(InventoryExportCancel request, int? creator_id = 1);
        Task<string> ApproveInventory(int orderItemId, int approveId = 1, int? locked = 0);
        Task<BaseResponse<InventoryFindDto>> FindInventory(int inventoryId);
        Task<List<Inventory>> GetInventoryByStockAsync(int stockId, string? filter = "", int page = 0, int pageSize = 20);
        Task<List<StockInventoryModel>> GetAllInventoryAsync(StockInventorySearchModel searchModel);
        Task<int> ConvertUnitProduct(int Id, int Qty, string Unit);
        Task<Inventory> GetOrCreateInventory(int creator, int stockId, int ProductId, string PackageCode, decimal Price, decimal PriceInput, decimal? PriceRequest = 0, decimal? PriceIns = 0, int? BidId = 0, DateTime? ExpirationDate = null);
    }
    public class InventoryRepository : IInventoryRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public InventoryRepository(NencerDbContext context, IMapper mapper, IStockRepository stockRepository)
        {
            _context = context;
            _mapper = mapper;
            _stockRepository = stockRepository;
        }
        public async Task<List<Inventory>> GetInventoryByStockAsync(int stockId, string? filter = "", int page = 0, int pageSize = 20)
        {
            return await _context.Inventories.Where(x => string.IsNullOrEmpty(filter) || (EF.Functions.Like(x.ProductName, filter + "%") || EF.Functions.Like(x.Barcode, filter + "%")))
               .OrderBy(x => x.Id)
                   .Skip(page)
                   .Take(pageSize)
                   .Select(x => _mapper.Map<Inventory>(x))
               .ToListAsync();
        }
        // Tạo phiếu nhập kho
        public async Task<BaseResponse<StockOrder>> CreateTicketImport(InventoryAddDto request, int? creator_id = 1)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Status == 1 && x.Id == request.StockId);
                if (stock == null)
                {
                    return new BaseResponse<StockOrder>
                    {
                        ResponseCode = "500",
                        Message = "Kho thuốc không tồn tại hoặc bị khóa"
                    };
                }
                var supplier = await _context.ProductSuppliers.FirstOrDefaultAsync(x => x.Status == 1 && x.Id == request.SupplierId);
                if (supplier == null)
                {
                    return new BaseResponse<StockOrder>
                    {
                        ResponseCode = "500",
                        Message = "Nhà cung cấp không tồn tại hoặc bị khóa"
                    };
                }
                var check = await _context.StockOrders.FirstOrDefaultAsync(x => x.Code == request.Code);

                if (check != null)
                {
                    return new BaseResponse<StockOrder>
                    {
                        ResponseCode = "500",
                        Message = "Mã hóa đơn đã tồn tại"
                    };
                }

                var Items = request.Items;
                if (Items != null && Items.Count > 0)
                {
                    // create order stock
                    var order = new StockOrder();
                    order.Code = request.Code;
                    order.StockId = request.StockId;
                    order.Type = 1;
                    order.SupplierId = supplier.Id;
                    order.TargetStockId = null;
                    order.Note = request.Note;
                    order.Status = request.Status;
                    order.CreatorId = creator_id;
                    order.Deliver = request.Deliver;
                    order.OrderDate = request.BillDate;
                    order.CreatedAt = DateTime.Now;
                    order.UpdatedAt = DateTime.Now;
                    order.Receiver = request.Receiver;
                    order.IsDel = 1;
                    _context.StockOrders.Add(order);
                    _context.SaveChanges();
                    // kiểm tra gói thầu
                    foreach (var item in Items)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.ProductId && x.Status == 1);
                        if (product != null)
                        {
                            ProductBid productBid = null;
                            // kiểm tra gói thầu
                            if (item.BidId != null && item.BidId > 0)
                            {
                                productBid = await _context.ProductBids.FirstOrDefaultAsync(x => x.ProductId == product.Id && x.Id == item.BidId);

                            }
                            if (productBid == null)
                            {
                                productBid = await _context.ProductBids.FirstOrDefaultAsync(x => x.ProductId == item.ProductId && x.SupplierId == supplier.Id && x.BidNumber == item.BidNumber
                                && x.BidGroup == item.BidGroup && x.BidPackage == item.BidPackage && x.BidYear == item.BidYear);
                                if (productBid == null)
                                {
                                    var newBid = new ProductBid();
                                    newBid.ProductId = item.ProductId;
                                    newBid.SupplierId = supplier.Id;
                                    newBid.BidNumber = item.BidNumber;
                                    newBid.BidGroup = item.BidGroup;
                                    newBid.BidPackage = item.BidPackage;
                                    newBid.BidYear = item.BidYear;
                                    newBid.Status = 1;
                                    newBid.CreatedAt = DateTime.Now;
                                    newBid.UpdatedAt = DateTime.Now;
                                    _context.ProductBids.Add(newBid);
                                    _context.SaveChanges();
                                    productBid = newBid;
                                }

                            }
                            if (productBid != null)
                            {
                                var Qty = await ConvertUnitProduct((int)product.Id, item.Qty, item.Unit);
                                if (Qty == 0)
                                {
                                    trans.Rollback();
                                    return new BaseResponse<StockOrder>
                                    {
                                        ResponseCode = "500",
                                        Message = "Số lượng không đúng "
                                    };
                                }
                                decimal Price = 0;
                                decimal PriceInput = 0;
                                if (item.Price != null && item.Price > 0)
                                {
                                    Price = (decimal)item.Price;
                                }
                                else
                                {
                                    Price = (decimal)product.Price;
                                }
                                if (item.PriceInput != null && item.PriceInput > 0)
                                {
                                    PriceInput = (decimal)item.PriceInput;
                                }
                                else
                                {
                                    PriceInput = (decimal)product.PriceInput;
                                }
                                // tạo order_item
                                var order_item = await _stockRepository.CreateOrderItem(order.Id, (int)order.Type, product.Id, PriceInput, Qty, (decimal)item.Tax, product.Barcode, item.PackageCode, product.CurrencyCode, 0, 0, "", productBid.Id, (int)creator_id, 0, item.LotCode);
                                if (order_item.Data != null)
                                {
                                    var OrderItem = order_item.Data;

                                    //inventory
                                    var inventory = await GetOrCreateInventory((int)creator_id, (int)order.StockId, (int)OrderItem.ProductId, OrderItem.BatchCode, Price, (decimal)item.PriceInput, (decimal)item.PriceRequest, (decimal)item.PriceIns, productBid.Id, item.ExpirationDate);
                                    if (inventory == null)
                                    {
                                        trans.Rollback();
                                        return new BaseResponse<StockOrder>
                                        {
                                            ResponseCode = "500",
                                            Message = "Tạo phiếu nhập Inventory thất bại "
                                        };
                                    }
                                    if (item.ExpirationDate.HasValue)
                                    {
                                        order_item.Data.ExpirationDate = item.ExpirationDate.Value;
                                    }
                                    order_item.Data.InventoryId = inventory.Id;
                                    _context.StockOrderItems.Update(order_item.Data);
                                    _context.SaveChanges();
                                }
                                else
                                {
                                    trans.Rollback();
                                    return new BaseResponse<StockOrder>
                                    {
                                        ResponseCode = "500",
                                        Message = "Tạo phiếu nhập OrderItem thất bại "
                                    };
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                return new BaseResponse<StockOrder>
                                {
                                    ResponseCode = "500",
                                    Message = "Gói thầu không tồn tại "
                                };
                            }

                        }

                    }
                    trans.Commit();
                }
                return new BaseResponse<StockOrder>
                {
                    ResponseCode = "200",
                    Message = "Tạo phiếu nhập kho thành công"
                };
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new BaseResponse<StockOrder>
                {
                    ResponseCode = "500",
                    Message = "Tạo phiếu nhập kho thất bại " + ex.Message
                };
            }

        }
        // tạo phiếu chuyển kho
        public async Task<BaseResponse<StockOrder>> CreateTicketTransfer(InventoryTransferDto request, int? creator_id = 1)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var Stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Status == 1 && x.Id == request.StockId);
                var TargetStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Status == 1 && x.Id == request.TargetStockId);
                if (Stock == null || TargetStock == null)
                {
                    return new BaseResponse<StockOrder>
                    {
                        ResponseCode = "500",
                        Message = "Kho thuốc không tồn tại hoặc bị khóa"
                    };
                }
                var Items = request.Items;
                if (Items != null && Items.Count > 0)
                {
                    // create order stock
                    var order = new StockOrder();
                    order.Code = DateTime.Now.ToString("yyyyMMddHHmmss");
                    order.StockId = Stock.Id;
                    order.TargetStockId = TargetStock.Id;
                    order.Type = 3;
                    order.Note = request.Note;
                    order.Status = request.Status;
                    order.CreatorId = creator_id;
                    order.CreatedAt = DateTime.Now;
                    order.UpdatedAt = DateTime.Now;
                    order.IsDel = 1;
                    await _context.StockOrders.AddAsync(order);
                    await _context.SaveChangesAsync();
                    // kiểm tra gói thầu
                    foreach (var item in Items)
                    {

                        var InventoryOld = _context.Inventories.FirstOrDefault(x => x.Id == item.InventoryId);
                        if (InventoryOld == null)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Inventory không tồn tại "
                            };
                        }
                        decimal Price = 0;
                        var PriceInput = InventoryOld.PriceInput;
                        if (item.Price != null && item.Price > 0)
                        {
                            Price = (decimal)item.Price;
                        }
                        else
                        {
                            Price = (decimal)InventoryOld.Price;
                        }
                        var product = _context.Products.FirstOrDefault(x => x.Id == InventoryOld.ProductId);
                        var Qty = await ConvertUnitProduct((int)product.Id, item.Qty, item.Unit);
                        if (Qty == 0)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Số lượng không đúng "
                            };
                        }
                        // tạo order_item
                        var orderItemImport = await _stockRepository.CreateOrderItem(order.Id, 1, product.Id, (decimal)PriceInput, Qty, 0, product.Barcode, item.PackageCode, product.CurrencyCode, 0, 0, "", InventoryOld.BidId, (int)creator_id);
                        var orderItemExport = await _stockRepository.CreateOrderItem(order.Id, 2, product.Id, (decimal)PriceInput, Qty, 0, product.Barcode, InventoryOld.PackageCode, product.CurrencyCode, 0, 0, "", InventoryOld.BidId, (int)creator_id, InventoryOld.Id);

                        if (orderItemImport.Data != null && orderItemExport.Data != null)
                        {
                            var OrderItem = orderItemImport.Data;

                            //inventory
                            var inventory = await GetOrCreateInventory((int)creator_id, (int)order.StockId, (int)OrderItem.ProductId, OrderItem.BatchCode, Price, (decimal)InventoryOld.PriceInput, (decimal)InventoryOld.PriceRequest, (decimal)InventoryOld.PriceIns, InventoryOld.BidId, item.ExpirationDate);
                            if (inventory == null)
                            {
                                trans.Rollback();
                                return new BaseResponse<StockOrder>
                                {
                                    ResponseCode = "500",
                                    Message = "Tạo phiếu nhập Inventory thất bại "
                                };
                            }
                            if (item.ExpirationDate.HasValue)
                            {
                                OrderItem.ExpirationDate = item.ExpirationDate.Value;
                            }
                            OrderItem.InventoryId = inventory.Id;
                            _context.StockOrderItems.Update(OrderItem);
                            _context.SaveChanges();
                            trans.Commit();
                            // approve order status > 1
                            if (order.Status != null && order.Status > 1)
                            {

                                var result = await ApproveInventory(orderItemExport.Data.Id, (int)creator_id);
                                var resultImport = await ApproveInventory(orderItemImport.Data.Id, (int)creator_id);

                                if (result != "SUCCESS" || resultImport != "SUCCESS")
                                {

                                    return new BaseResponse<StockOrder>
                                    {
                                        ResponseCode = "500",
                                        Message = "Duyệt phiếu thất bại vui lòng kiểm tra lại! " + result
                                    };
                                }
                            }

                        }
                        else
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Tạo phiếu nhập OrderItem thất bại "
                            };
                        }
                    }
                }

                return new BaseResponse<StockOrder>
                {
                    ResponseCode = "200",
                    Message = "Tạo phiếu thành công!",
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<StockOrder>
                {
                    ResponseCode = "500",
                    Message = "Tạo phiếu thất bại!" + ex.Message,
                };
            }

        }
        // Tạo phiếu xuất kho cho khác lẻ
        public async Task<BaseResponse<StockOrder>> CreateTicketExportPatient(InventoryExportPatient request, int? creator_id = 1)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var Stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Status == 1 && x.Id == request.StockId);
                if (Stock == null)
                {
                    return new BaseResponse<StockOrder>
                    {
                        ResponseCode = "500",
                        Message = "Kho thuốc không tồn tại hoặc bị khóa"
                    };
                }

                var Items = request.Items;
                if (Items != null && Items.Count > 0)
                {
                    // create patient
                    PatientModel patient;
                    if (request.PatientNumber != null)
                    {
                        patient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientNumber == request.PatientNumber);
                        if (patient == null)
                        {
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Mã bệnh nhân không hợp lệ"
                            };
                        }
                    }
                    else
                    {
                        patient = new PatientModel();
                        patient.PatientNumber = DateTime.Now.ToString("yyyyMMddHHmmss");
                        patient.CreatedAt = DateTime.Now;
                        patient.Name = request.PatientName;
                        patient.Phone = request.Phone;
                        patient.Gender = request.Gender;
                        patient.DayBorn = request.DayBorn;
                        patient.MonthBorn = request.MonthBorn;
                        patient.YearBorn = request.YearBorn;
                        patient.CityId = request.CityId;
                        patient.DistrictId = request.DistrictId;
                        patient.WardId = request.WardId;
                        patient.UpdatedAt = DateTime.Now;
                        await _context.Patients.AddAsync(patient);
                        await _context.SaveChangesAsync();
                    }

                    // create order stock
                    var order = new StockOrder();
                    order.Code = DateTime.Now.ToString("yyyymmddhs");
                    order.StockId = Stock.Id;
                    order.Type = 2;
                    order.Note = request.Note;
                    order.Status = request.Status;
                    order.CustomerId = patient.Id;
                    order.CreatorId = creator_id;
                    order.CreatedAt = DateTime.Now;
                    order.UpdatedAt = DateTime.Now;
                    order.IsDel = 1;
                    await _context.StockOrders.AddAsync(order);
                    await _context.SaveChangesAsync();
                    foreach (var item in Items)
                    {
                        var Inventory = _context.Inventories.FirstOrDefault(x => x.Id == item.InventoryId);
                        if (Inventory == null)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Inventory không tồn tại "
                            };
                        }
                        var Qty = await ConvertUnitProduct((int)Inventory.ProductId, item.Qty, item.Unit);
                        if (Qty == 0)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Số lượng không đúng "
                            };
                        }
                        if (Inventory.Qty < Qty)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Số lượng tồn kho không đủ "
                            };
                        }
                        var product = _context.Products.FirstOrDefault(x => x.Id == Inventory.ProductId);
                        decimal Price = (decimal)Inventory.Price;

                        if (Price == null)
                        {
                            Price = (decimal)product.Price;
                        }
                        // tạo order_item
                        var orderItemExport = await _stockRepository.CreateOrderItem(order.Id, 2, product.Id, (decimal)Inventory.PriceInput, Qty, 0, Inventory.Barcode, Inventory.PackageCode, product.CurrencyCode, 0, 0, "", Inventory.BidId, (int)creator_id, Inventory.Id);
                        if (orderItemExport.Data == null)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Tạo phiếu nhập OrderItem thất bại "
                            };
                        }

                    }
                    trans.Commit();
                    // approve order status > 1
                    if (order.Status != null && order.Status > 1)
                    {

                        var orderItems = _context.StockOrderItems.Where(x => x.StockOrderId == order.Id).ToList();
                        foreach (var orderItem in orderItems)
                        {
                            var result = await ApproveInventory(orderItem.Id, (int)creator_id);
                        }
                    }
                }
                return new BaseResponse<StockOrder>
                {
                    ResponseCode = "200",
                    Message = "Thành công!",
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<StockOrder>
                {
                    ResponseCode = "500",
                    Message = "Tạo phiếu thất bại!" + ex.Message,
                };
            }

        }
        // Tạo phiếu hủy kho
        public async Task<BaseResponse<StockOrder>> CreateTicketExportCancel(InventoryExportCancel request, int? creator_id = 1)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var Stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Status == 1 && x.Id == request.StockId);
                if (Stock == null)
                {
                    return new BaseResponse<StockOrder>
                    {
                        ResponseCode = "500",
                        Message = "Kho thuốc không tồn tại hoặc bị khóa"
                    };
                }
                var Items = request.Items;
                if (Items != null && Items.Count > 0)
                {
                    // create order stock
                    var order = new StockOrder();
                    order.Code = DateTime.Now.ToString("yyyymmddhs");
                    order.StockId = Stock.Id;
                    order.Type = 2;
                    order.SupplierId = request.Supplier_id;
                    order.Receiver = request.Receiver;
                    order.Note = request.Note;
                    order.Status = request.Status;
                    order.Reason = request.Reason;
                    order.CreatorId = creator_id;
                    order.CreatedAt = DateTime.Now;
                    order.UpdatedAt = DateTime.Now;
                    order.IsDel = 1;
                    await _context.StockOrders.AddAsync(order);
                    await _context.SaveChangesAsync();
                    foreach (var item in Items)
                    {
                        var Inventory = _context.Inventories.FirstOrDefault(x => x.Id == item.InventoryId);
                        if (Inventory == null)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Inventory không tồn tại "
                            };
                        }
                        var Qty = await ConvertUnitProduct((int)Inventory.ProductId, item.Qty, item.Unit);
                        if (Qty == 0)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Số lượng không đúng "
                            };
                        }
                        if (Inventory.Qty < Qty)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Số lượng tồn kho không đủ "
                            };
                        }
                        var product = _context.Products.FirstOrDefault(x => x.Id == Inventory.ProductId);
                        decimal Price = (decimal)Inventory.Price;

                        if (Price == null)
                        {
                            Price = (decimal)product.Price;
                        }
                        // tạo order_item
                        var orderItemExport = await _stockRepository.CreateOrderItem(order.Id, 2, product.Id, (decimal)Inventory.PriceInput, Qty, 0, Inventory.Barcode, Inventory.PackageCode, product.CurrencyCode, 0, 0, "", Inventory.BidId, (int)creator_id, Inventory.Id);
                        if (orderItemExport.Data == null)
                        {
                            trans.Rollback();
                            return new BaseResponse<StockOrder>
                            {
                                ResponseCode = "500",
                                Message = "Tạo phiếu nhập OrderItem thất bại "
                            };
                        }

                    }
                    trans.Commit();
                    // approve order status > 1
                    if (order.Status != null && order.Status > 1)
                    {
                        var orderItems = _context.StockOrderItems.Where(x => x.StockOrderId == order.Id).ToList();
                        foreach (var orderItem in orderItems)
                        {
                            var result = await ApproveInventory(orderItem.Id, (int)creator_id);
                        }
                    }
                }

                return new BaseResponse<StockOrder>
                {
                    ResponseCode = "200",
                    Message = "Thành công!",
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<StockOrder>
                {
                    ResponseCode = "500",
                    Message = "Tạo phiếu thất bại!" + ex.Message,
                };
            }
        }
        public async Task<string> ApproveInventory(int orderItemId, int approveId, int? locked = 0)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                _context.ChangeTracker.Clear();
                var orderItem = await _context.StockOrderItems.FirstOrDefaultAsync(x => x.Id == orderItemId && x.Status == 1);
                if (orderItem == null)
                {
                    return "ORDER_ITEM_NOT_FOUND";
                }
                var inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.Id == (int)orderItem.InventoryId && x.Status == 1);
                if (inventory == null)
                {
                    return "INVENTORY_NOT_FOUND";
                }
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == (int)orderItem.ProductId && x.Status == 1);
                if (product == null)
                {
                    return "PRODUCT_NOT_FOUND";
                }
                int Qty = 0;
                if (orderItem.ApproveQty != null && orderItem.ApproveQty > 0)
                {
                    Qty = orderItem.Qty == null ? 0 : orderItem.Qty.Value;
                }
                else
                {
                    Qty = orderItem.Qty == null ? 0 : orderItem.Qty.Value;
                }

                if (product.Unit != orderItem.Unit)
                {
                    var OptionUnit = await _context.ProductOptionUnits.Where(x => x.ProductId == product.Id).Where(x => x.Name == orderItem.Unit || x.Key == orderItem.Unit).FirstOrDefaultAsync();
                    if (OptionUnit == null)
                    {
                        return "UNIT_INCORRECT";
                    }
                    Qty = Qty * (int)OptionUnit.Qty;
                }

                if (orderItem.Type == 1)
                {
                    inventory.Qty += Qty;
                }
                else
                {
                    if (locked == 1)
                    {
                        if (inventory.LockedQty < Qty)
                        {
                            return "QTY_INSUFFICIENT";
                        }
                        inventory.LockedQty -= Qty;
                    }
                    else
                    {
                        if (inventory.Qty < Qty)
                        {
                            return "QTY_INSUFFICIENT";
                        }
                        inventory.Qty -= Qty;
                    }

                }
                inventory.UpdaterId = approveId;
                inventory.UpdatedAt = DateTime.Now;
                _context.Inventories.Update(inventory);
                _context.SaveChanges();
                orderItem.Status = 2;
                orderItem.ApproveId = approveId;
                orderItem.ApproveDate = DateTime.Now;
                _context.StockOrderItems.Update(orderItem);
                _context.SaveChanges();
                trans.Commit();
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return "EXCEPTION " + ex.Message;
            }

        }
        public async Task<string> LockQtyInventory(int orderItemId)
        {
            _context.ChangeTracker.Clear();
            var orderItem = await _context.StockOrderItems.FirstOrDefaultAsync(x => x.Id == orderItemId && x.Status == 1);
            if (orderItem == null)
            {
                return "ORDER_ITEM_NOT_FOUND";
            }
            var inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.Id == (int)orderItem.InventoryId && x.Status == 1);
            if (inventory == null)
            {
                return "INVENTORY_NOT_FOUND";
            }
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == (int)orderItem.ProductId && x.Status == 1);
            if (product == null)
            {
                return "PRODUCT_NOT_FOUND";
            }
            var Qty = orderItem.Qty;

            if (product.Unit != orderItem.Unit)
            {
                var OptionUnit = await _context.ProductOptionUnits.Where(x => x.ProductId == product.Id).Where(x => x.Name == orderItem.Unit || x.Key == orderItem.Unit).FirstOrDefaultAsync();
                if (OptionUnit == null)
                {
                    return "UNIT_INCORRECT";
                }
                Qty = Qty * (int)OptionUnit.Qty;
            }
            if (inventory.Qty < Qty)
            {
                return "QTY_INSUFFICIENT";
            }
            inventory.Qty -= Qty;
            inventory.LockedQty += Qty;
            _context.Inventories.Update(inventory);
            _context.SaveChanges();
            return "SUCCESS";
        }
        public async Task<Inventory> GetOrCreateInventory(int creator, int stockId, int ProductId, string PackageCode, decimal Price, decimal PriceInput, decimal? PriceRequest = 0, decimal? PriceIns = 0, int? BidId = 0, DateTime? ExpirationDate = null)
        {
            try
            {
                Inventory inventory;
                if (ExpirationDate.HasValue)
                {
                    inventory = _context.Inventories.Where(x => x.StockId == stockId && x.ProductId == ProductId && x.PackageCode == PackageCode && x.Price == Price
                    && x.PriceInput == PriceInput && x.PriceRequest == PriceRequest && x.PriceIns == PriceIns && x.BidId == BidId && x.ExpirationDate.HasValue && x.ExpirationDate.Value.Date == ExpirationDate.GetValueOrDefault().Date)
                        .FirstOrDefault();
                }
                else
                {
                    inventory = _context.Inventories.Where(x => x.StockId == stockId && x.ProductId == ProductId && x.PackageCode == PackageCode && x.Price == Price
                   && x.PriceInput == PriceInput && x.PriceRequest == PriceRequest && x.PriceIns == PriceIns && x.BidId == BidId).FirstOrDefault();
                }

                if (inventory == null)
                {

                    var product = _context.Products.Find(ProductId);
                    if (product == null)
                    {
                        return null;
                    }

                    var bid = _context.ProductBids.Find(BidId);
                    inventory = new Inventory();
                    inventory.StockId = stockId;
                    inventory.ProductId = ProductId;
                    inventory.ProductName = product.Name;
                    inventory.Barcode = product.Barcode;
                    inventory.PackageCode = PackageCode;
                    inventory.BidId = BidId;
                    if (bid != null)
                    {
                        inventory.SupplierId = bid.SupplierId;
                    }
                    inventory.Qty = 0;
                    inventory.ExpirationDate = ExpirationDate;
                    inventory.Status = 1;
                    inventory.CreatorId = creator;
                    inventory.PriceInput = PriceInput;
                    inventory.Price = Price;
                    inventory.PriceRequest = PriceRequest;
                    inventory.PriceIns = PriceIns;
                    inventory.CreatedAt = DateTime.Now;
                    inventory.UpdatedAt = DateTime.Now;
                    _context.Inventories.Add(inventory);
                    _context.SaveChanges();
                }

                return inventory;
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                return null;
            }
        }
        public async Task<BaseResponse<InventoryFindDto>> FindInventory(int inventoryId)
        {
            var inventory = await _context.Inventories.FindAsync(inventoryId);
            if (inventory == null)
            {
                return new BaseResponse<InventoryFindDto>()
                {
                    Message = "Không tìm thấy dữ liệu",
                    ResponseCode = "500"

                };
            }
            var product = await _context.Products.FindAsync(inventory.ProductId);
            if (product == null)
            {
                return new BaseResponse<InventoryFindDto>()
                {
                    Message = "Không tìm thấy dữ liệu sản phẩm",
                    ResponseCode = "500"

                };
            }
            return new BaseResponse<InventoryFindDto>()
            {
                Message = "Thành công",
                ResponseCode = "200",
                Data = new InventoryFindDto
                {
                    inventory = inventory,
                    product = product
                }
            };
        }
        public async Task<int> ConvertUnitProduct(int Id, int Qty, string Unit)
        {
            int result = 0;
            var product = await _context.Products.FindAsync(Id);
            if (product != null)
            {
                if (product.Unit == Unit)
                {
                    result = Qty;
                }
                else
                {
                    var OptionUnit = await _context.ProductOptionUnits.Where(x => x.ProductId == Id).Where(x => x.Name == Unit || x.Key == Unit).FirstOrDefaultAsync();
                    if (OptionUnit != null)
                    {
                        result = Qty * (int)OptionUnit.Qty;
                    }
                }
            }
            return result;
        }


        public async Task<List<StockInventoryModel>> GetAllInventoryAsync(StockInventorySearchModel searchModel)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from inventorie in _context.Inventories

                               join stock in _context.Stocks on inventorie.StockId equals stock.Id into joinStocks
                               from stock in joinStocks.DefaultIfEmpty()

                               join productSupplier in _context.ProductSuppliers on inventorie.SupplierId equals productSupplier.Id into joinProductSuppliers
                               from productSupplier in joinProductSuppliers.DefaultIfEmpty()

                               join productBid in _context.ProductBids on inventorie.BidId equals productBid.Id into joinProductBids
                               from productBid in joinProductBids.DefaultIfEmpty()

                               select new StockInventoryModel
                               {
                                   Id = inventorie.Id,
                                   StockId = inventorie.StockId,
                                   StockName = stock.Name,
                                   ProductId = inventorie.ProductId,
                                   Barcode = inventorie.Barcode,
                                   PackageCode = inventorie.PackageCode,
                                   ProductName = inventorie.ProductName,
                                   SupplierId = inventorie.SupplierId,
                                   SupplierName = productSupplier.Name,
                                   BidId = inventorie.BidId,
                                   BidName = productBid.Name,
                                   Qty = inventorie.Qty,
                                   LockedQty = inventorie.LockedQty,
                                   CertificateCode = inventorie.CertificateCode,
                                   ProductionDate = inventorie.ProductionDate,
                                   ExpirationDate = inventorie.ExpirationDate,
                                   Position = inventorie.Position,
                                   Description = inventorie.Description,
                                   Status = inventorie.Status,
                                   CreatorId = inventorie.CreatorId,
                                   UpdaterId = inventorie.UpdaterId,
                                   PriceInput = inventorie.PriceInput,
                                   Price = inventorie.Price,
                                   PriceRequest = inventorie.PriceRequest,
                                   PriceIns = inventorie.PriceIns,
                                   UpdatedAt = inventorie.UpdatedAt,
                                   CreatedAt = inventorie.CreatedAt
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip(searchModel.SkipCount)
                               .Take(searchModel.MaxResultCount)
                               .ToList();

                if (searchModel.StockId != -1)
                {
                    lstData = lstData.Where(x => x.StockId != null && x.StockId == searchModel.StockId).ToList();
                }

                // Then, retrieve the total count separately
                int totalCount = _context.Inventories.Count();
                if (lstData.Count > 0 && lstData[0] != null)
                {
                    lstData[0].TotalCount = totalCount;
                }

                return lstData;
            }
        }
    }
}
