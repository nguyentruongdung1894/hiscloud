using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.ManageService.Model.Dto;
using Nencer.Shared;

namespace Nencer.Modules.ManageService.Repository
{
    public interface IServiceTypeRepository
    {
        Task<List<ServiceType>> GetServiceTypeAsync(string? filter = "", int page = 0, int pageSize = 20);
        Task<List<ServiceType>> GetServiceTypeByGroupAsync(int groupId, int page = 0, int pageSize = 20);
        Task<BaseResponse<ServiceType>> CreateServiceType(ServiceTypeDto createServiceTypeDto);
        Task<BaseResponse<ServiceType>> FindServiceType(int Id);
        Task<BaseResponse<ServiceType>> UpdateServiceType(ServiceTypeDto createServiceTypeDto, int Id);
        Task<BaseResponse<ServiceType>> DeleteServiceType(int Id);
    }
    public class ServiceTypeRepository: IServiceTypeRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;

        public ServiceTypeRepository(NencerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ServiceType>> GetServiceTypeAsync(string? filter = "", int page = 0, int pageSize = 20)
        {
            var items = await _context.ServiceTypes
                .Where(x => string.IsNullOrEmpty(filter) || (x.Name.Contains(filter) || x.Code.Contains(filter)))
                .OrderBy(x => x.Id)
                    .Skip(page)
                    .Take(pageSize)
                    .Select(x => _mapper.Map<ServiceType>(x))
               .ToListAsync();
            return items;
        }
        public async Task<List<ServiceType>> GetServiceTypeByGroupAsync(int groupId, int page = 0, int pageSize = 20)
        {
            var items = await _context.ServiceTypes
                .Where(x => x.ServiceGroupId == groupId)
                .OrderBy(x => x.Id)
                    .Skip(page)
                    .Take(pageSize)
                    .Select(x => _mapper.Map<ServiceType>(x))
               .ToListAsync();
            return items;
        }
        public async Task<BaseResponse<ServiceType>> CreateServiceType(ServiceTypeDto request)
        {
            var serviceType = _context.ServiceTypes.FirstOrDefaultAsync(x => x.Code == request.Code).Result;
            
            if (serviceType != null)
            {
                return new BaseResponse<ServiceType>
                {
                    ResponseCode = "500",
                    Message = "Mã Code đã tồn tại trong hệ thống!",
                   
                };
            }
            var type = new ServiceType();
            type.Name = request.Name;
            type.NameArray = request.NameArray;
            type.ServiceGroupId = request.ServiceGroupId;
            type.Code = request.Code;
            type.Sort = request.Sort;
            type.Status = 1;
            type.CreatedAt = DateTime.Now;
            type.UpdatedAt = DateTime.Now;
            await _context.ServiceTypes.AddAsync(type);
            await _context.SaveChangesAsync();
            return new BaseResponse<ServiceType>
            {
                ResponseCode = "200",
                Message = "Thêm dữ liệu thành công",
                Data = type
            };
        }

        public async Task<BaseResponse<ServiceType>> FindServiceType(int Id)
        {
            if(Id <= 0)
            {
                return new BaseResponse<ServiceType>
                {
                    ResponseCode = "500",
                    Message = "Dữ liệu ID không hợp lệ",
                    Data = null
                };
            }
            var type = await _context.ServiceTypes.FindAsync(Id);
            if(type != null)
            {
                return new BaseResponse<ServiceType>
                {
                    ResponseCode = "200",
                    Message = "Lấy dữ liệu thành công",
                    Data = type
                };
            }
            return new BaseResponse<ServiceType>
            {
                ResponseCode = "500",
                Message = "Dữ liệu không tồn tại trong hệ thống",
                Data = null
            };
        }

        public async Task<BaseResponse<ServiceType>> UpdateServiceType(ServiceTypeDto request, int Id)
        {
            var type = await _context.ServiceTypes.FindAsync(Id);
            if (type == null)
            {
                return new BaseResponse<ServiceType>
                {
                    ResponseCode = "500",
                    Message = "Loại dịch vụ không tồn tại!",
                };
            }
            type.Name = request.Name;
            type.NameArray = request.NameArray;
            type.ServiceGroupId = request.ServiceGroupId;
            type.Sort = request.Sort;
            type.Status = request.Status;
            type.UpdatedAt = DateTime.Now;
             _context.ServiceTypes.Update(type);
            _context.SaveChanges();
            return new BaseResponse<ServiceType>
            {
                ResponseCode = "200",
                Message = "Cập dữ liệu thành công",
                Data = type
            };
        }

        public async Task<BaseResponse<ServiceType>> DeleteServiceType(int Id)
        {
            var type = await _context.ServiceTypes.FindAsync(Id);
            if (type == null)
            {
                return new BaseResponse<ServiceType>
                {
                    ResponseCode = "500",
                    Message = "Loại dịch vụ không tồn tại!",
                };
            }
            var serivces = await _context.Services.Where(x => x.ServiceTypeId == Id).ToListAsync();
            if(serivces != null && serivces.Count > 0)
            {
                foreach(var service in serivces)
                {
                    _context.Services.Remove(service);
                    _context.SaveChanges();
                }
            }
            _context.ServiceTypes.Remove(type);
            _context.SaveChanges();
            return new BaseResponse<ServiceType>
            {
                ResponseCode = "200",
                Message = "Xóa dữ liệu thành công",
            };
        }
        

    }
}
