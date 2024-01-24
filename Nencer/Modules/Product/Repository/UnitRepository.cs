using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Product.Model;
using Nencer.Shared;
namespace Nencer.Modules.Product.Repository
{
    public interface IUnitRepository
    {
        Task<List<ProductUnitModel>> GetAllProductUnit(SearchProductUnitModel searchModel);
        Task<BaseResponse<ProductUnit>> CreateProductUnit(ProductUnit req);
        Task<BaseResponse<ProductUnit>> FindProductUnit(int Id);
        Task<BaseResponse<ProductUnit>> UpdateProductUnit(ProductUnit req, int Id);
        Task<BaseResponse<ProductUnit>> DeleteProductUnit(int Id);
        Task<ProductUnit> GetUnitByKeyOrName(string Code);
    }
    public class UnitRepository : IUnitRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;

        public UnitRepository(NencerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductUnitModel>> GetAllProductUnit(SearchProductUnitModel searchModel)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from productUnit in _context.ProductUnits
                               select new ProductUnitModel
                               {
                                   Id = productUnit.Id,
                                   Name = productUnit.Name,
                                   Key = productUnit.Key,
                                   Type = productUnit.Type,
                                   Description = productUnit.Description,
                                   Default = productUnit.Default,
                                   CreatedAt = productUnit.CreatedAt
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip(searchModel.SkipCount)
                               .Take(searchModel.MaxResultCount)
                               .ToList();

                if (!string.IsNullOrEmpty(searchModel.Name))
                {
                    lstData = lstData.Where(x => x.Name != null && x.Name.ToLower().Contains(searchModel.Name.ToLower())).ToList();
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
        public async Task<BaseResponse<ProductUnit>> CreateProductUnit(ProductUnit request)
        {
            var old = await _context.ProductUnits.FirstOrDefaultAsync(x => x.Key == request.Key.ToUpper());
            if (old != null)
            {
                return new BaseResponse<ProductUnit>
                {
                    ResponseCode = "500",
                    Message = "Mã dịch vụ đã tồn tại trong hệ thống!"
                };
            }
            var nc = new ProductUnit();
            nc.Name = request.Name;
            nc.Key = request.Key.ToUpper();
            nc.Type = request.Type;
            nc.Description = request.Description;
            nc.Default = request.Default;

            nc.CreatedAt = DateTime.Now;
            nc.UpdatedAt = DateTime.Now;
            await _context.ProductUnits.AddAsync(nc);
            await _context.SaveChangesAsync();
            return new BaseResponse<ProductUnit>
            {
                ResponseCode = "200",
                Message = "Thêm mới thành công",
                Data = nc
            };
        }
        public async Task<BaseResponse<ProductUnit>> UpdateProductUnit(ProductUnit request, int Id)
        {
            var nc = await _context.ProductUnits.FindAsync(Id);
            if (nc == null)
            {
                return new BaseResponse<ProductUnit>
                {
                    ResponseCode = "500",
                    Message = "Dữ liệu không tồn tại trong hệ thống!"
                };
            }
            nc.Name = request.Name;
            nc.Type = request.Type;
            nc.Description = request.Description;
            nc.Default = request.Default;
            nc.UpdatedAt = DateTime.Now;
            _context.ProductUnits.Update(nc);
            _context.SaveChanges();
            return new BaseResponse<ProductUnit>
            {
                ResponseCode = "200",
                Message = "Cập nhập thành công",
                Data = nc
            };
        }
        public async Task<BaseResponse<ProductUnit>> FindProductUnit(int Id)
        {
            var nc = await _context.ProductUnits.FindAsync(Id);
            if (nc == null)
            {
                return new BaseResponse<ProductUnit>
                {
                    ResponseCode = "500",
                    Message = "Dữ liệu không tồn tại trong hệ thống!"
                };
            }
            return new BaseResponse<ProductUnit>
            {
                ResponseCode = "200",
                Message = "",
                Data = nc
            };
        }
        public async Task<BaseResponse<ProductUnit>> DeleteProductUnit(int Id)
        {
            var nc = await _context.ProductUnits.FindAsync(Id);
            if (nc == null)
            {
                return new BaseResponse<ProductUnit>
                {
                    ResponseCode = "500",
                    Message = "Dữ liệu không tồn tại trong hệ thống!"
                };
            }
            _context.ProductUnits.Remove(nc);
            _context.SaveChanges();
            return new BaseResponse<ProductUnit>
            {
                ResponseCode = "200",
                Message = "Xóa thành công!",

            };
        }
        public async Task<ProductUnit> GetUnitByKeyOrName(string Code)
        {
            var acb = _context.ProductUnits.FirstOrDefault(x => x.Key == Code);
            return acb;
        }
    }
}
