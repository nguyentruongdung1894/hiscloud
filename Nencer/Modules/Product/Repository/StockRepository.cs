using AutoMapper;
using Nencer.Modules.Product.Model;
using Nencer.Shared;
namespace Nencer.Modules.Product.Repository;
using Microsoft.EntityFrameworkCore;

public interface IStockRepository
{
    Task<List<StockModel>> GetAllStockAync(SearchStockModel searchModel);
    Task<List<StockModel>> GetAllStockOutputAync(SearchStockModel searchModel);
    Task<BaseResponse<Stock>> CreateStockAync(Stock stock);
    Task<Stock> FindStockAync(int Id);
    Task<BaseResponse<Stock>> UpdateStockAync(Stock stock);
    Task<BaseResponse<Stock>> DeleteStockAync(int Id);
    Task<BaseResponse<StockOrderItem>> CreateOrderItem(int orderId, int type, int productId, decimal price, int qty, decimal tax_rate, string? barcode = "", string? batch_code = "", string currency_code = "VND", decimal insurancePay = 0, decimal patientPaid = 0, string? service_object = "", int? bidId = 0, int creator_id = 1, int inventory_id = 0, string? lotCode = "");

}
public class StockRepository : IStockRepository
{
    private readonly NencerDbContext _context;
    private readonly IMapper _mapper;

    public StockRepository(NencerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<StockModel>> GetAllStockAync(SearchStockModel searchModel)
    {
        using (var _context = new NencerDbContext())
        {
            var lstData = (from stock in _context.Stocks

                           join department in _context.Departments on stock.DepartmentId equals department.Id into joinDepartments
                           from department in joinDepartments.DefaultIfEmpty()

                           where stock.Status == 1
                           select new StockModel
                           {
                               Id = stock.Id,
                               Code = stock.Code,
                               Type = stock.Type,
                               TypeName = stock.Type == 0 ? "Kho nội trú" : "Kho ngoại trú",
                               Name = stock.Name,
                               Address = stock.Address,
                               Phone = stock.Phone,
                               DepartmentId = stock.DepartmentId,
                               DepartmentName = department.Name,
                               OwnerId = stock.OwnerId,
                               Description = stock.Description,
                               PaymentRequire = stock.PaymentRequire,
                               Status = stock.Status,
                               CreatedAt = stock.CreatedAt
                           })
                           .OrderByDescending(c => c.CreatedAt)
                           .Skip(searchModel.SkipCount)
                           .Take(searchModel.MaxResultCount)
                           .ToList();

            if (!string.IsNullOrEmpty(searchModel.Code))
            {
                lstData = lstData.Where(x => x.Code != null && x.Code.ToLower().Contains(searchModel.Code.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                lstData = lstData.Where(x => x.Name != null && x.Name.ToLower().Contains(searchModel.Name.ToLower())).ToList();
            }

            // Then, retrieve the total count separately
            int totalCount = _context.Stocks.Count();
            if (lstData.Count > 0 && lstData[0] != null)
            {
                lstData[0].TotalCount = totalCount;
            }

            return lstData;
        }
    }
    public async Task<List<StockModel>> GetAllStockOutputAync(SearchStockModel searchModel)
    {
        using (var _context = new NencerDbContext())
        {
            var lstData = (from inventorie in _context.Inventories
                           join stock in _context.Stocks on inventorie.StockId equals stock.Id into joinedStocks
                           from stock in joinedStocks.DefaultIfEmpty()
                           where inventorie.Qty > 0 && stock.Status == 1
                           group new StockModel
                           {
                               Id = stock.Id,
                               Code = inventorie.StockId.ToString(),
                               Name = stock.Name,
                               CreatedAt = stock.CreatedAt
                           } by new { stock.Code, stock.Name } into groupedStocks
                           select groupedStocks.OrderByDescending(c => c.CreatedAt).FirstOrDefault())
                           .Skip(searchModel.SkipCount)
                           .Take(searchModel.MaxResultCount)
                           .ToList();

            return lstData;
        }
    }
    public async Task<BaseResponse<Stock>> CreateStockAync(Stock rq)
    {
        var old = await _context.Stocks.FirstOrDefaultAsync(x => x.Code == rq.Code.ToUpper());
        if (old != null)
        {
            return new BaseResponse<Stock>
            {
                ResponseCode = "500",
                Message = "Mã Code đã tồn tại trong hệ thống!"
            };
        }
        if (rq.DepartmentId != null)
        {
            var department = await _context.Departments.FindAsync(rq.DepartmentId);
            if (department == null)
            {
                return new BaseResponse<Stock>
                {
                    ResponseCode = "500",
                    Message = "Mã khoa không tồn tại trong hệ thống!"
                };
            }
        }
        var nc = new Stock();
        nc.Name = rq.Name;
        nc.Code = rq.Code.ToUpper();
        nc.Type = rq.Type;
        nc.Address = rq.Address;
        nc.Phone = rq.Phone;
        nc.DepartmentId = rq.DepartmentId;
        nc.OwnerId = rq.OwnerId;
        if (rq.PaymentRequire != null && rq.PaymentRequire == 1)
        {
            nc.PaymentRequire = 1;
        }
        else
        {
            nc.PaymentRequire = 0;
        }
        nc.Description = rq.Description;
        nc.Status = rq.Status;
        nc.CreatedAt = DateTime.Now;
        nc.UpdatedAt = DateTime.Now;
        await _context.Stocks.AddAsync(nc);
        await _context.SaveChangesAsync();
        return new BaseResponse<Stock>
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công",
            Data = nc
        };

    }
    public async Task<BaseResponse<Stock>> UpdateStockAync(Stock rq)
    {
        var nc = await _context.Stocks.FindAsync(rq.Id);
        if (nc == null)
        {
            return new BaseResponse<Stock>
            {
                ResponseCode = "500",
                Message = "Mã kho tồn tại trong hệ thống!"
            };
        }
        if (rq.DepartmentId != null)
        {
            var department = await _context.Departments.FindAsync(rq.DepartmentId);
            if (department == null)
            {
                return new BaseResponse<Stock>
                {
                    ResponseCode = "200",
                    Message = "Mã khoa không tồn tại trong hệ thống!"
                };
            }
        }
        nc.Name = rq.Name;
        nc.Type = rq.Type;
        nc.Address = rq.Address;
        nc.Phone = rq.Phone;
        nc.DepartmentId = rq.DepartmentId;
        nc.OwnerId = rq.OwnerId;
        if (rq.PaymentRequire != null && rq.PaymentRequire == 1)
        {
            nc.PaymentRequire = 1;
        }
        else
        {
            nc.PaymentRequire = 0;
        }
        nc.Description = rq.Description;
        nc.Status = rq.Status;
        nc.UpdatedAt = DateTime.Now;

        _context.Stocks.Update(nc);
        _context.SaveChanges();
        return new BaseResponse<Stock>
        {
            ResponseCode = "200",
            Message = "Cập nhập thành công",
            Data = nc
        };

    }

    public async Task<Stock> FindStockAync(int Id)
    {
        using (var _context = new NencerDbContext())
        {
            var stock = await _context.Stocks
                .Where(pc => pc.Status == 1 && pc.Id == Id)
                .FirstOrDefaultAsync();

            return stock;
        }
    }
    public async Task<BaseResponse<Stock>> DeleteStockAync(int Id)
    {
        var stock = await _context.Stocks.FindAsync(Id);
        if (stock == null)
        {
            return new BaseResponse<Stock>
            {
                ResponseCode = "500",
                Message = "Mã kho tồn tại trong hệ thống!"
            };
        }
        var invetory = await _context.Inventories.FirstOrDefaultAsync(x => x.StockId == stock.Id && x.Qty > 0);
        if (invetory != null)
        {
            return new BaseResponse<Stock>
            {
                ResponseCode = "500",
                Message = "Xóa kho thất bại. Vui lòng xuất hết hàng trong kho!"
            };
        }
        _context.Stocks.Remove(stock);
        _context.SaveChanges();
        await _context.Inventories.Where(x => x.StockId == Id).ExecuteDeleteAsync();
        return new BaseResponse<Stock>
        {
            ResponseCode = "200",
            Message = "Xóa kho thành công",

        };
    }
    public async Task<BaseResponse<StockOrderItem>> CreateOrderItem(int orderId, int type, int productId, decimal price, int qty, decimal tax_rate, string? barcode = "", string? batch_code = "", string currency_code = "VND", decimal insurancePay = 0, decimal patientPaid = 0, string? service_object = "", int? bidId = 0, int creator_id = 1, int inventory_id = 0, string? lotCode = "")
    {
        try
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return new BaseResponse<StockOrderItem>
                {
                    Message = "Product không tồn tại. ",
                    ResponseCode = "500"
                };

            }
            if (type != 1)
            {
                var inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.ProductId == product.Id && x.PackageCode == batch_code && x.Qty >= qty);
                if (inventory == null)
                {
                    return new BaseResponse<StockOrderItem>
                    {
                        Message = "Kho không tồn tại hoặc không đủ số lượng. ",
                        ResponseCode = "500"
                    };
                }
            }

            decimal tax_amount = 0;
            var item = new StockOrderItem();
            item.StockOrderId = orderId;
            item.Type = type;
            item.ServiceObject = service_object;
            item.ProductId = product.Id;
            item.ProductName = product.Name;
            item.Price = price;
            item.Qty = qty;
            item.ApproveQty = qty;
            item.Status = 1;
            item.Unit = product.Unit;
            item.Barcode = barcode;
            item.BatchCode = batch_code;
            item.CurrencyCode = currency_code;
            item.BidId = bidId;
            item.CreatorId = creator_id;
            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;
            item.TaxRate = (decimal)tax_rate;
            item.PayAmount = price * qty;
            if (tax_rate > 0)
            {
                tax_amount = (decimal)item.PayAmount * (tax_rate / 100);
            }
            item.TaxAmount = tax_amount;
            item.TotalAmount = item.PayAmount;
            item.InsurancePay = insurancePay;
            item.PatientPaid = patientPaid;
            item.CopayPatient = item.TotalAmount - insurancePay;
            item.PatientInDebt = item.CopayPatient - patientPaid;
            item.InventoryId = inventory_id;
            item.LotCode = lotCode;

            await _context.StockOrderItems.AddAsync(item);
            await _context.SaveChangesAsync();

            return new BaseResponse<StockOrderItem>
            {
                Message = "Thành công",
                ResponseCode = "200",
                Data = item
            };

        }
        catch (Exception ex)
        {
            return new BaseResponse<StockOrderItem>
            {
                Message = "Lỗi exception. " + ex.Message,
                ResponseCode = "500"
            };
        }

    }



}
