using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Product.Model;
using Nencer.Shared;
namespace Nencer.Modules.Product.Repository
{
    public interface IProductSupplierRepository
    {
        Task<BaseResponse<ProductSupplier>> CreateProductSupplier(ProductSupplier request);
        Task<ProductSupplier> FindProductSupplier(long supplierID);
        Task<BaseResponse<ProductSupplier>> UpdateProductSupplier(ProductSupplier request);
        Task<BaseResponse<ProductSupplier>> DeleteProductSupplier(int Id);
        Task<List<SupplierModel>> GetAllProductSupplier(SearchSupplierModel searchModel);
    }
    public class ProductSupplierRepository : IProductSupplierRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;

        public ProductSupplierRepository(NencerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SupplierModel>> GetAllProductSupplier(SearchSupplierModel searchModel)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from productSupplier in _context.ProductSuppliers
                               where productSupplier.Status == 1
                               select new SupplierModel
                               {
                                   ID = productSupplier.Id,
                                   Code = productSupplier.Code,
                                   Name = productSupplier.Name,
                                   Address = productSupplier.Address,
                                   ContactPhone = productSupplier.ContactPhone,
                                   ContactEmail = productSupplier.ContactEmail,
                                   Description = productSupplier.Description,
                                   CreatedAt = productSupplier.CreatedAt
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip(searchModel.SkipCount)
                               .Take(searchModel.MaxResultCount)
                               .ToList();

                if (!string.IsNullOrEmpty(searchModel.Code))
                {
                    lstData = lstData.Where(x => x.Code != null && x.Code.ToLower().Contains(searchModel.Code.ToLower())).ToList();
                }

                // Then, retrieve the total count separately
                int totalCount = _context.ProductSuppliers.Count();
                if (lstData.Count > 0 && lstData[0] != null)
                {
                    lstData[0].TotalCount = totalCount;
                }

                return lstData;
            }
        }
        public async Task<BaseResponse<ProductSupplier>> CreateProductSupplier(ProductSupplier request)
        {
            var old = await _context.ProductSuppliers.FirstOrDefaultAsync(x => x.Code == request.Code.ToUpper());
            if (old != null)
            {
                return new BaseResponse<ProductSupplier>
                {
                    ResponseCode = "500",
                    Message = "Mã dịch vụ đã tồn tại trong hệ thống!"
                };
            }
            var nc = new ProductSupplier();
            nc.Name = request.Name;
            nc.Code = request.Code.ToUpper();
            nc.Address = request.Address;
            nc.ContactPhone = request.ContactPhone;
            nc.ContactEmail = request.ContactEmail;
            nc.Description = request.Description;
            nc.Status = request.Status;
            nc.CreatedAt = DateTime.Now;
            nc.UpdatedAt = DateTime.Now;
            await _context.ProductSuppliers.AddAsync(nc);
            await _context.SaveChangesAsync();
            return new BaseResponse<ProductSupplier>
            {
                ResponseCode = "200",
                Message = "Thêm mới thành công",
                Data = nc
            };
        }
        public async Task<BaseResponse<ProductSupplier>> UpdateProductSupplier(ProductSupplier request)
        {
            var nc = await _context.ProductSuppliers.FindAsync(request.Id);
            if (nc == null)
            {
                return new BaseResponse<ProductSupplier>
                {
                    ResponseCode = "500",
                    Message = "Dữ liệu không tồn tại trong hệ thống!"
                };
            }
            nc.Code = request.Code;
            nc.Name = request.Name;
            nc.Address = request.Address;
            nc.ContactPhone = request.ContactPhone;
            nc.ContactEmail = request.ContactEmail;
            nc.Description = request.Description;
            nc.Status = request.Status;
            nc.UpdatedAt = DateTime.Now;
            _context.ProductSuppliers.Update(nc);
            _context.SaveChanges();
            return new BaseResponse<ProductSupplier>
            {
                ResponseCode = "200",
                Message = "Cập nhập thành công",
                Data = nc
            };
        }
        public async Task<ProductSupplier> FindProductSupplier(long supplierID)
        {
            using (var _context = new NencerDbContext())
            {
                var productSupplier = await _context.ProductSuppliers
                    .Where(ps => ps.Status == 1 && ps.Id == supplierID)
                    .FirstOrDefaultAsync();

                return productSupplier;
            }
        }
        public async Task<BaseResponse<ProductSupplier>> DeleteProductSupplier(int Id)
        {
            var nc = await _context.ProductSuppliers.FindAsync(Id);
            if (nc == null)
            {
                return new BaseResponse<ProductSupplier>
                {
                    ResponseCode = "500",
                    Message = "Dữ liệu không tồn tại trong hệ thống!"
                };
            }
            _context.ProductSuppliers.Remove(nc);
            _context.SaveChanges();
            return new BaseResponse<ProductSupplier>
            {
                ResponseCode = "200",
                Message = "Xóa thành công!",

            };
        }
    }
}
