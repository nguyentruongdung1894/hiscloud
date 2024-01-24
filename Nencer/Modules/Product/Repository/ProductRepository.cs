using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Product.Model;
using Nencer.Shared;

namespace Nencer.Modules.Product.Repository
{
    public interface IProductRepository
    {
        Task<BaseResponse<Model.Product>> CreateProductAsync(Model.Product request);
        Task<BaseResponse<Model.Product>> UpdateProductAsync(Model.Product request);
        Task<BaseResponse<Model.Product>> DeleteProductAsync(int Id);
        Task<Model.Product> FindProductAsync(int productID);
        Task<ProductModel> FindByInventorieId(int productID);
        Task<List<ProductModel>> GetAllProductAsync(SearchProductModel searchModel);
        Task<List<ProductModel>> GetAllProductByStockIdAsync(int stockId);
        Task<List<ProductModel>> GetAllProductByStockIdAndSupplierIdAsync(int stockId, int supplierId);
        Task<List<Model.Product>> GetProductByCateAsync(int cat_id, int page = 0, int pageSize = 20);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitRepository _unitRepository;

        public ProductRepository(NencerDbContext context, IMapper mapper, IUnitRepository unitRepository)
        {
            _context = context;
            _mapper = mapper;
            _unitRepository = unitRepository;
        }
        public async Task<List<ProductModel>> GetAllProductAsync(SearchProductModel searchModel)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from product in _context.Products
                               join productUnit in _context.ProductUnits on product.Unit equals productUnit.Key into joinedProductUnits
                               from productUnit in joinedProductUnits.DefaultIfEmpty()
                               where product.Status == 1
                               select new ProductModel
                               {
                                   ID = product.Id,
                                   Sku = product.Sku,
                                   Name = product.Name,
                                   Barcode = product.Barcode,
                                   CatId = product.CatId.ToString(),
                                   ActiveIngredient = product.ActiveIngredient,
                                   Concentration = product.Concentration,
                                   Content = product.Content,
                                   Usage = product.Usage,
                                   CountryCode = product.CountryCode,
                                   Manufacturer = product.Manufacturer.ToString(),
                                   Packing = product.Packing,
                                   Unit = productUnit.Name,
                                   PriceInput = product.PriceInput,
                                   Price = product.Price,
                                   PriceRequest = product.PriceRequest,
                                   PriceIns = product.PriceIns,
                                   Description = product.Description,
                                   UsageIns = product.UsageIns.ToString(),
                                   Status = product.Status.ToString(),
                                   CreatedAt = product.CreatedAt
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip(searchModel.SkipCount)
                               .Take(searchModel.MaxResultCount)
                               .ToList();

                if (!string.IsNullOrEmpty(searchModel.Sku))
                {
                    lstData = lstData.Where(x => x.Sku != null && x.Sku.ToLower().Contains(searchModel.Sku.ToLower())).ToList();
                }

                // Then, retrieve the total count separately
                int totalCount = _context.Products.Count();
                if (lstData.Count > 0 && lstData[0] != null)
                {
                    lstData[0].TotalCount = totalCount;
                }

                return lstData;
            }
        }
        public async Task<List<ProductModel>> GetAllProductByStockIdAsync(int stockId)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from inventorie in _context.Inventories
                               where inventorie.StockId == stockId && inventorie.Qty > 0
                               select new ProductModel
                               {
                                   ID = inventorie.Id,
                                   Name = inventorie.ProductName,
                                   CreatedAt = inventorie.CreatedAt,
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .ToList();

                return lstData;
            }
        }
        public async Task<List<ProductModel>> GetAllProductByStockIdAndSupplierIdAsync(int stockId, int supplierId)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from inventorie in _context.Inventories
                               where inventorie.StockId == stockId && inventorie.SupplierId == supplierId && inventorie.Qty > 0
                               select new ProductModel
                               {
                                   ID = inventorie.Id,
                                   Name = inventorie.ProductName,
                                   CreatedAt = inventorie.CreatedAt,
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .ToList();

                return lstData;
            }
        }
        public async Task<List<Model.Product>> GetProductByCateAsync(int cat_id, int page = 0, int pageSize = 20)
        {
            return await _context.Products.Where(x => x.CatId == cat_id)
               .OrderBy(x => x.Id)
                   .Skip(page)
                   .Take(pageSize)
                   .Select(x => _mapper.Map<Model.Product>(x))
               .ToListAsync();
        }
        public async Task<Model.Product> FindProductAsync(int productID)
        {
            using (var _context = new NencerDbContext())
            {
                var product = await _context.Products
                    .Where(ps => ps.Status == 1 && ps.Id == productID)
                    .FirstOrDefaultAsync();

                return product;
            }
        }
        public async Task<ProductModel> FindByInventorieId(int productID)
        {
            using (var _context = new NencerDbContext())
            {
                var inventory = await _context.Inventories.Where(x => x.Id == productID).FirstOrDefaultAsync();
                var productModel = new ProductModel();
                if (inventory != null)
                {
                    productModel = (from stockOrder in _context.StockOrders
                                    join stockOrderItem in _context.StockOrderItems on stockOrder.Id equals stockOrderItem.StockOrderId into joinStockOrderItems
                                    from stockOrderItem in joinStockOrderItems.DefaultIfEmpty()
                                    join product in _context.Products on stockOrderItem.ProductId equals product.Id into joinProducts
                                    from product in joinProducts.DefaultIfEmpty()
                                    join productBid in _context.ProductBids on stockOrderItem.BidId equals productBid.Id into joinProductBids
                                    from productBid in joinProductBids.DefaultIfEmpty()
                                    where stockOrder.StockId == inventory.StockId && stockOrderItem.ProductId == inventory.ProductId
                                    select new ProductModel
                                    {
                                        ID = stockOrder.Id,
                                        Sku = product.Sku,
                                        Concentration = product.Concentration,
                                        Content = product.Content,
                                        CatId = product.CatId.ToString(),
                                        LotCode = stockOrderItem.LotCode,

                                        CountryCode = product.CountryCode,
                                        Manufacturer = product.Manufacturer,
                                        RegistrationNumber = product.RegistrationNumber,
                                        Unit = product.Unit,
                                        Usage = product.Usage,
                                        ExpirationDate = stockOrderItem.ExpirationDate,

                                        Qty = stockOrderItem.Qty,
                                        PriceInput = inventory.PriceInput,
                                        TaxRate = stockOrderItem.TaxRate,
                                        Price = stockOrderItem.Price,
                                        TotalAmount = stockOrderItem.TotalAmount,
                                        PriceIns = inventory.PriceIns,

                                        PriceRequest = inventory.PriceRequest,
                                        BidId = stockOrderItem.BidId,
                                        BidGroup = productBid.BidGroup,
                                        BidNumber = productBid.BidNumber,
                                        BidYear = productBid.BidYear,
                                    })
                              .FirstOrDefault();
                }

                return productModel;
            }
        }
        public async Task<BaseResponse<Model.Product>> DeleteProductAsync(int Id)
        {
            var nc = await _context.Products.FindAsync(Id);
            if (nc == null)
            {
                return new BaseResponse<Model.Product>
                {
                    ResponseCode = "500",
                    Message = "Sản phẩm không tồn tại trong hệ thống!",
                };
            }
            _context.Products.Remove(nc);
            _context.SaveChanges();
            return new BaseResponse<Model.Product>
            {
                ResponseCode = "200",
                Message = "Xóa thành công",

            };
        }
        public async Task<BaseResponse<Model.Product>> CreateProductAsync(Model.Product request)
        {
            var old = _context.Products.FirstOrDefault(x => x.Sku == request.Sku.ToUpper());
            if (old != null)
            {
                return new BaseResponse<Model.Product>
                {
                    ResponseCode = "500",
                    Message = "Mã Sku đã tồn tại trong hệ thống!",
                };
            }
            if (request.Barcode != null)
            {
                var check = _context.Products.FirstOrDefault(x => x.Barcode == request.Barcode);
                if (check != null)
                {
                    return new BaseResponse<Model.Product>
                    {
                        ResponseCode = "500",
                        Message = "Mã Barcode đã tồn tại trong hệ thống!",
                    };
                }
            }

            request.CreatedAt = DateTime.Now;
            request.UpdatedAt = DateTime.Now;
            _context.Products.Add(request);
            _context.SaveChanges();

            return new BaseResponse<Model.Product>
            {
                ResponseCode = "200",
                Message = "Thêm mới thành công",
                Data = request
            };
        }
        public async Task<BaseResponse<Model.Product>> UpdateProductAsync(Model.Product request)
        {
            var productRp = await _context.Products.FindAsync(request.Id);
            if (productRp == null)
            {
                return new BaseResponse<Model.Product>
                {
                    ResponseCode = "500",
                    Message = "Sản phẩm không tồn tại trong hệ thống!",
                };
            }
            if (request.Sku != null && request.Sku != productRp.Sku)
            {
                var check = await _context.Products.Where(x => x.Id != request.Id && x.Sku == request.Sku).FirstOrDefaultAsync();
                if (check != null)
                {
                    return new BaseResponse<Model.Product>
                    {
                        ResponseCode = "500",
                        Message = "Mã Sku đã tồn tại trong hệ thống!",
                    };
                }
            }
            if (request.Barcode != null && request.Barcode != productRp.Barcode)
            {
                var check = await _context.Products.Where(x => x.Id != request.Id && x.Barcode == request.Barcode).FirstOrDefaultAsync();
                if (check != null)
                {
                    return new BaseResponse<Model.Product>
                    {
                        ResponseCode = "500",
                        Message = "Mã Barcode đã tồn tại trong hệ thống!",
                    };
                }
            }

            request.UpdatedAt = DateTime.Now;
            _context.Products.Update(request);
            _context.SaveChanges();
            return new BaseResponse<Model.Product>
            {
                ResponseCode = "200",
                Message = "Cập nhật thành công",
                Data = request
            };
        }
    }
}
