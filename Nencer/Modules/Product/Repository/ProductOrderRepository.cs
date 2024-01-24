using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Product.Model;
using Nencer.Modules.Product.Model.Dto;
using Nencer.Shared;
using System.Diagnostics;

namespace Nencer.Modules.Product.Repository
{

    public interface IProductOrderRepository
    {
        Task<BaseResponse<ProductOrderResult>> FindProductOrder(int orderId);
        Task<BaseResponse<ProductOrderEditDto>> UpdateProductOrder(int orderId, ProductOrderEditDto request);
    }
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public ProductOrderRepository(NencerDbContext context, IMapper mapper, IUnitRepository unitRepository, IStockRepository stockRepository, IInventoryRepository inventoryRepository)
        {
            _context = context;
            _mapper = mapper;
            _stockRepository = stockRepository;
            _inventoryRepository = inventoryRepository;
        }
        public async Task<BaseResponse<ProductOrderResult>> FindProductOrder(int orderId)
        {
            var order = await _context.StockOrders.FindAsync(orderId);
            if (order == null)
            {
                return new BaseResponse<ProductOrderResult>
                {
                    ResponseCode = "500",
                    Message = "ORDER_NOT_FOUND"
                };
            }
            var items = await _context.StockOrderItems.Where(x => x.StockOrderId == order.Id).ToListAsync();
            return new BaseResponse<ProductOrderResult>
            {
                ResponseCode = "200",
                Message = "SUCCESS",
                Data = new ProductOrderResult
                {
                    order = order,
                    items = items
                }
            };
        }
        public async Task<BaseResponse<ProductOrderEditDto>> UpdateProductOrder(int orderId, ProductOrderEditDto request)
        {
            var order = await _context.StockOrders.FindAsync(orderId);
            if (order == null || order.Status != 1)
            {
                return new BaseResponse<ProductOrderEditDto>
                {
                    Message = "ORDER_NOT_FOUND_OR_PROCESSED",
                    ResponseCode = "500",

                };
            }
            var reqOrder = request.order;
            order.SupplierId = reqOrder.SupplierId;
            order.DepartmentId = reqOrder.DepartmentId;
            order.RoomId = reqOrder.RoomId;
            order.CustomerId = reqOrder.CustomerId;
            order.Note = reqOrder.Note;
            order.Reason = reqOrder.Reason;
            order.Receiver = reqOrder.Receiver;
            order.Deliver = reqOrder.Deliver;
            order.UpdatedAt = DateTime.Now;
            _context.StockOrders.Update(order);
            _context.SaveChanges();
            var items = request.item;
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    StockOrderItem orderItem = null;
                    if (item != null && item.Id != null && item.Id > 0)
                    {
                        orderItem = _context.StockOrderItems.FirstOrDefault(x => x.Id == item.Id);
                    }
                    if (orderItem != null)
                    {
                        if (orderItem.Status == 1)
                        {
                            orderItem.Qty = item.Qty;
                            orderItem.PayAmount = orderItem.Qty * orderItem.Price;
                            orderItem.BenefitRate = item.BenefitRate;
                            orderItem.TotalAmount = orderItem.PayAmount;
                            orderItem.InsurancePay = orderItem.TotalAmount * (orderItem.BenefitRate / 100);
                            orderItem.CopayPatient = orderItem.TotalAmount - orderItem.InsurancePay;
                            if (item.PatientPaid != null)
                            {
                                orderItem.PatientPaid = item.PatientPaid;
                            }
                            orderItem.PatientInDebt = orderItem.CopayPatient - orderItem.PatientPaid;
                            orderItem.ApproveQty = item.ApproveQty;
                            _context.StockOrderItems.Update(orderItem);
                            _context.SaveChanges();
                        }
                    }
                }

            }
            var creator_id = order.CreatorId;
            var news = request.itemNews;
            if (news != null && news.Count > 0)
            {
                // import
                if (order.Type == 1)
                {
                    foreach (var newData in news)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == newData.ProductId && x.Status == 1);
                        if (product != null)
                        {
                            ProductBid productBid = null;
                            // kiểm tra gói thầu
                            if (newData.BidId != null && newData.BidId > 0)
                            {
                                productBid = await _context.ProductBids.FirstOrDefaultAsync(x => x.ProductId == product.Id && x.Id == newData.BidId);

                            }
                            if (productBid == null)
                            {
                                productBid = await _context.ProductBids.FirstOrDefaultAsync(x => x.ProductId == newData.ProductId && x.SupplierId == order.SupplierId && x.BidNumber == newData.BidNumber
                                && x.BidGroup == newData.BidGroup && x.BidPackage == newData.BidPackage && x.BidYear == newData.BidYear);
                                if (productBid == null)
                                {
                                    var newBid = new ProductBid();
                                    newBid.ProductId = product.Id;
                                    newBid.SupplierId = order.SupplierId;
                                    newBid.BidNumber = newData.BidNumber;
                                    newBid.BidGroup = newData.BidGroup;
                                    newBid.BidPackage = newData.BidPackage;
                                    newBid.BidYear = newData.BidYear;
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
                                var Qty = await _inventoryRepository.ConvertUnitProduct((int)product.Id, newData.Qty, newData.Unit);

                                decimal Price = 0;
                                decimal PriceInput = 0;
                                if (newData.Price != null && newData.Price > 0)
                                {
                                    Price = (decimal)newData.Price;
                                }
                                else
                                {
                                    Price = (decimal)product.Price;
                                }
                                if (newData.PriceInput != null && newData.PriceInput > 0)
                                {
                                    PriceInput = (decimal)newData.PriceInput;
                                }
                                else
                                {
                                    PriceInput = (decimal)product.PriceInput;
                                }
                                // tạo order_item
                                var order_item = await _stockRepository.CreateOrderItem(order.Id, (int)order.Type, product.Id, PriceInput, Qty, (decimal)newData.Tax, product.Barcode, newData.PackageCode, product.CurrencyCode, 0, 0, "", productBid.Id, (int)order.CreatorId);
                                if (order_item.Data != null)
                                {
                                    var OrderItem = order_item.Data;
                                    //inventory
                                    var inventory = await _inventoryRepository.GetOrCreateInventory((int)creator_id, (int)order.StockId, (int)OrderItem.ProductId, OrderItem.BatchCode, Price, (decimal)newData.PriceInput, (decimal)newData.PriceRequest, (decimal)newData.PriceIns, productBid.Id, newData.ExpirationDate);
                                    if (inventory != null)
                                    {
                                        if (newData.ExpirationDate.HasValue)
                                        {
                                            order_item.Data.ExpirationDate = newData.ExpirationDate.Value;
                                        }
                                        order_item.Data.InventoryId = inventory.Id;
                                        _context.StockOrderItems.Update(order_item.Data);
                                        _context.SaveChanges();
                                    }

                                }
                            }

                        }

                    }
                }
                else if (order.Type == 2)
                {
                    foreach (var newData in news)
                    {
                        var InventoryOld = _context.Inventories.FirstOrDefault(x => x.Id == newData.InventoryId);
                        if (InventoryOld != null)
                        {
                            decimal Price = 0;
                            var PriceInput = InventoryOld.PriceInput;
                            if (newData.Price != null && newData.Price > 0)
                            {
                                Price = (decimal)newData.Price;
                            }
                            else
                            {
                                Price = (decimal)InventoryOld.Price;
                            }
                            var product = _context.Products.FirstOrDefault(x => x.Id == InventoryOld.ProductId);
                            var Qty = await _inventoryRepository.ConvertUnitProduct((int)product.Id, newData.Qty, newData.Unit);
                            if (Qty > 0)
                            {
                                var orderItemImport = await _stockRepository.CreateOrderItem(order.Id, 1, product.Id, (decimal)PriceInput, Qty, 0, product.Barcode, newData.PackageCode, product.CurrencyCode, 0, 0, "", InventoryOld.BidId, (int)creator_id);
                                var orderItemExport = await _stockRepository.CreateOrderItem(order.Id, 2, product.Id, (decimal)PriceInput, Qty, 0, product.Barcode, InventoryOld.PackageCode, product.CurrencyCode, 0, 0, "", InventoryOld.BidId, (int)creator_id, InventoryOld.Id);

                                if (orderItemImport.Data != null && orderItemExport.Data != null)
                                {
                                    var OrderItem = orderItemImport.Data;

                                    //inventory
                                    var inventory = await _inventoryRepository.GetOrCreateInventory((int)creator_id, (int)order.StockId, (int)OrderItem.ProductId, OrderItem.BatchCode, Price, (decimal)InventoryOld.PriceInput, (decimal)InventoryOld.PriceRequest, (decimal)InventoryOld.PriceIns, InventoryOld.BidId, newData.ExpirationDate);
                                    if (inventory != null)
                                    {
                                        if (newData.ExpirationDate.HasValue)
                                        {
                                            OrderItem.ExpirationDate = newData.ExpirationDate.Value;
                                        }
                                        OrderItem.InventoryId = inventory.Id;
                                        _context.StockOrderItems.Update(OrderItem);
                                        _context.SaveChanges();
                                    }

                                }
                            }
                        }
                    }

                }else if(order.Type == 3)
                {
                    foreach(var newDate in news)
                    {
                        var Inventory = _context.Inventories.FirstOrDefault(x => x.Id == newDate.InventoryId);
                        if(Inventory != null)
                        {
                            var Qty = await _inventoryRepository.ConvertUnitProduct((int)Inventory.ProductId, newDate.Qty, newDate.Unit);
                            if (Qty > 0 && Inventory.Qty < Qty)
                            {
                                var product = _context.Products.FirstOrDefault(x => x.Id == Inventory.ProductId);
                                decimal Price = (decimal)Inventory.Price;

                                if (Price == null)
                                {
                                    Price = (decimal)product.Price;
                                }
                                // tạo order_item
                                var orderItemExport = await _stockRepository.CreateOrderItem(order.Id, 2, product.Id, (decimal)Inventory.PriceInput, Qty, 0, Inventory.Barcode, Inventory.PackageCode, product.CurrencyCode, 0, 0, "", Inventory.BidId, (int)creator_id, Inventory.Id);
                            }
                        }
                    }
                }
            }
            return new BaseResponse<ProductOrderEditDto>
            {
                Message = "SUCCESS",
                ResponseCode = "200"
            };
        }
    }
}
