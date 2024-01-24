using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Product.Model;
using Nencer.Shared;

namespace Nencer.Modules.Product.Repository
{
    public interface IProductBidRepository
    {
        Task<List<ProductBidsModel>> GetAllProductBidAsync(ProductBidsSearchModel searchModel);
        Task<BaseResponse<ProductBid>> CreateProductBid(ProductBid req);
    }
    public class ProductBidRepository : IProductBidRepository
    {
        private readonly NencerDbContext _context;

        public ProductBidRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<ProductBid>> CreateProductBid(ProductBid request)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var check = await _context.ProductBids.FirstOrDefaultAsync(x => x.Code == request.Code);

                if (check != null)
                {
                    return new BaseResponse<ProductBid>
                    {
                        ResponseCode = "500",
                        Message = "Mã gói thầu đã tồn tại"
                    };
                }

                request.CreatedAt = DateTime.Now;
                request.UpdatedAt = DateTime.Now;

                _context.ProductBids.Add(request);
                _context.SaveChanges();

                // kiểm tra gói thầu
                foreach (var item in request.Items)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.ProductId && x.Status == 1);
                    if (product != null)
                    {
                        item.BidId = request.Id;
                        item.CreatedAt = DateTime.Now;
                        item.UpdatedAt = DateTime.Now;

                        _context.ProductBidsItems.Add(item);
                        _context.SaveChanges();
                    }
                    else
                    {
                        trans.Rollback();
                        return new BaseResponse<ProductBid>
                        {
                            ResponseCode = "500",
                            Message = "Không có sản phẩm tương ứng."
                        };
                    }
                }

                trans.Commit();

                return new BaseResponse<ProductBid>
                {
                    ResponseCode = "200",
                    Message = "Tạo gói thầu thành công"
                };
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new BaseResponse<ProductBid>
                {
                    ResponseCode = "500",
                    Message = "Tạo gói thầu thất bại " + ex.Message
                };
            }
        }

        public async Task<List<ProductBidsModel>> GetAllProductBidAsync(ProductBidsSearchModel searchModel)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from productBid in _context.ProductBids
                               join productSupplier in _context.ProductSuppliers on productBid.SupplierId equals productSupplier.Id into joinProductSuppliers
                               from productSupplier in joinProductSuppliers.DefaultIfEmpty()
                               where productBid.Status == 1
                               select new ProductBidsModel
                               {
                                   Id = productBid.Id,
                                   ProductId = productBid.ProductId,
                                   SupplierId = productBid.SupplierId,
                                   SupplierName = productSupplier.Name,
                                   Code = productBid.Code,
                                   Name = productBid.Name,
                                   BidNumber = productBid.BidNumber,
                                   BidGroup = productBid.BidGroup,
                                   BidPackage = productBid.BidPackage,
                                   BidDate = productBid.BidDate,
                                   BidYear = productBid.BidYear,
                                   Description = productBid.Description,
                                   Status = productBid.Status,
                                   CreatorId = productBid.CreatorId,
                                   UpdaterId = productBid.UpdaterId,
                                   CreatedAt = productBid.CreatedAt,
                                   UpdatedAt = productBid.UpdatedAt,
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip(searchModel.SkipCount)
                               .Take(searchModel.MaxResultCount)
                               .ToList();


                // Then, retrieve the total count separately
                int totalCount = _context.ProductBids.Count();
                if (lstData.Count > 0 && lstData[0] != null)
                {
                    lstData[0].TotalCount = totalCount;
                }

                return lstData;
            }
        }
    }
}
