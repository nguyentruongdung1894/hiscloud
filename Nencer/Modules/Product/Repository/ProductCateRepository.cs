using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Product.Model;
using Nencer.Shared;

namespace Nencer.Modules.Product.Repository;
public interface IProductCateRepository
{
    Task<BaseResponse<ProductCate>> CreateProductCate(ProductCate productCate);
    Task<ProductCate> FindProductCate(long categoryID);
    Task<BaseResponse<ProductCate>> UpdateProductCate(ProductCate productCate);
    Task<BaseResponse<ProductCate>> DeleteProductCate(int Id);
    Task<List<CategoryModel>> GetAllProductCate(SearchCategoryModel searchModel);
}
public class ProductCateRepository : IProductCateRepository
{
    private readonly NencerDbContext _context;
    private readonly IMapper _mapper;

    public ProductCateRepository(NencerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<BaseResponse<ProductCate>> CreateProductCate(ProductCate rq)
    {
        var old = await _context.ProductCates.FirstOrDefaultAsync(x => x.Slug == rq.Slug.ToUpper());
        if (old != null)
        {
            return new BaseResponse<ProductCate>
            {
                ResponseCode = "500",
                Message = "Danh mục đã tồn tại trong hệ thống!"
            };
        }
        var nc = new ProductCate();
        nc.Name = rq.Name;
        nc.Slug = rq.Slug.ToUpper();
        nc.Area = rq.Area;
        nc.Description = rq.Description;
        nc.Sort = rq.Sort;
        nc.Image = string.Empty;
        nc.Status = rq.Status;
        nc.CreatedAt = DateTime.Now;
        nc.UpdatedAt = DateTime.Now;
        await _context.ProductCates.AddAsync(nc);
        await _context.SaveChangesAsync();
        return new BaseResponse<ProductCate>
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = nc
        };
    }
    public async Task<ProductCate> FindProductCate(long categoryID)
    {
        using (var _context = new NencerDbContext())
        {
            var productCate = await _context.ProductCates
                .Where(pc => pc.Status == 1 && pc.Id == categoryID)
                .FirstOrDefaultAsync();

            return productCate;
        }
    }
    public async Task<BaseResponse<ProductCate>> UpdateProductCate(ProductCate rq)
    {
        var cate = await _context.ProductCates.FindAsync(rq.Id);
        if (cate == null)
        {
            return new BaseResponse<ProductCate>
            {
                ResponseCode = "500",
                Message = "Không tìm thấy danh mục trên hệ thống",
            };
        }
        cate.Name = rq.Name;
        cate.Slug = rq.Slug.ToUpper();
        cate.Area = rq.Area;
        cate.Description = rq.Description;
        cate.Sort = rq.Sort;
        cate.Image = rq.Image;
        cate.Status = rq.Status;
        cate.UpdatedAt = DateTime.Now;

        _context.ProductCates.Update(cate);
        _context.SaveChanges();
        return new BaseResponse<ProductCate>
        {
            ResponseCode = "200",
            Message = "Cập nhập thành công!",
            Data = cate
        };
    }

    public async Task<BaseResponse<ProductCate>> DeleteProductCate(int Id)
    {
        var cate = await _context.ProductCates.FindAsync(Id);
        if (cate == null)
        {
            return new BaseResponse<ProductCate>
            {
                ResponseCode = "500",
                Message = "Không tìm thấy danh mục trên hệ thống",
            };
        }
        _context.ProductCates.Remove(cate);
        _context.SaveChanges();
        return new BaseResponse<ProductCate>
        {
            ResponseCode = "200",
            Message = "Xóa thành công!"
        };
    }

    public async Task<List<CategoryModel>> GetAllProductCate(SearchCategoryModel searchModel)
    {
        using (var _context = new NencerDbContext())
        {
            var lstData = (from productCate in _context.ProductCates
                           where productCate.Status == 1
                           select new CategoryModel
                           {
                               ID = productCate.Id,
                               Slug = productCate.Slug,
                               Name = productCate.Name,
                               Area = productCate.Area,
                               Description = productCate.Description,
                               CreatedAt = productCate.CreatedAt
                           })
                           .OrderByDescending(c => c.CreatedAt)
                           .Skip(searchModel.SkipCount)
                           .Take(searchModel.MaxResultCount)
                           .ToList();

            if (!string.IsNullOrEmpty(searchModel.Slug))
            {
                lstData = lstData.Where(x => x.Slug != null && x.Slug.ToLower().Contains(searchModel.Slug.ToLower())).ToList();
            }

            // Then, retrieve the total count separately
            int totalCount = _context.ProductCates.Count();
            if (lstData.Count > 0 && lstData[0] != null)
            {
                lstData[0].TotalCount = totalCount;
            }

            return lstData;
        }
    }
}
