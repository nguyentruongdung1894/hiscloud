using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.ManageService.Model.Dto;
using Nencer.Shared;

namespace Nencer.Modules.ManageService.Repository
{
    public interface IServiceGroupRepository
    {
        Task<List<ServiceGroup>> GetAllServiceGroupAsync();
        Task<BaseResponse<ServiceGroup>> CreateServiceGroup(ServiceGroup serviceGroup);
        Task<BaseResponse<ServiceGroup>> UpdateServiceGroup(ServiceGroup serviceGroup, int Id);
        Task<BaseResponse<ServiceGroup>> DeleteServiceGroup(int Id);
        Task<BaseResponse<ServiceGroup>> FindServiceGroup(int Id);
    }
    public class ServiceGroupRepository : IServiceGroupRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;
        public ServiceGroupRepository(NencerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ServiceGroup>> GetAllServiceGroupAsync()
        {
            var items = await _context.ServiceGroups
                .OrderBy(x => x.Id).Select(x => _mapper.Map<ServiceGroup>(x))
                .ToListAsync();
            return items;
        }
        
        public async Task<BaseResponse<ServiceGroup>> CreateServiceGroup(ServiceGroup request)
        {
            var req = await _context.ServiceGroups.FirstOrDefaultAsync(x => x.Code == request.Code || x.CodeName == request.CodeName);
            if(req != null)
            {
                return new BaseResponse<ServiceGroup>
                {
                    ResponseCode = "500",
                    Message = "Mã nhóm dịch vụ đã tồn tại trong hệ thống !"
                };
            }
            var data = new ServiceGroup();
            data.Code = request.Code;
            data.Name = request.Name;
            data.CodeName = request.CodeName;
            data.Status = request.Status;
            data.Sort = request.Sort; 
            data.CreatedAt = DateTime.Now;
            data.UpdatedAt = DateTime.Now;
            await _context.ServiceGroups.AddAsync(data);
            await _context.SaveChangesAsync();
            return new BaseResponse<ServiceGroup>
            {
                ResponseCode = "200",
                Message = "Thêm mới thành công",
                Data = data
            };
        }
        public async Task<BaseResponse<ServiceGroup>> UpdateServiceGroup(ServiceGroup request, int Id)
        {
            var req = await _context.ServiceGroups.FindAsync(Id);
            if (req == null)
            {
                return new BaseResponse<ServiceGroup>
                {
                    ResponseCode = "500",
                    Message = "Mã nhóm dịch vụ không tồn tại trong hệ thống !"
                };
            }

            req.Name = request.Name;
            req.Status = request.Status;
            req.Sort = request.Sort;
            req.UpdatedAt = DateTime.Now;
            _context.ServiceGroups.Update(req);
            await _context.SaveChangesAsync();
            return new BaseResponse<ServiceGroup>
            {
                ResponseCode = "200",
                Message = "Cập nhập thành công",
                Data = req
            };
        }

        public async Task<BaseResponse<ServiceGroup>> DeleteServiceGroup(int Id)
        {
            try
            {
                var group = await _context.ServiceGroups.FindAsync(Id);
                if (group == null)
                {
                    return new BaseResponse<ServiceGroup>
                    {
                        ResponseCode = "500",
                        Message = "Mã nhóm dịch vụ không tồn tại trong hệ thống !"
                    };
                }
                 await _context.ServiceTypes.Where(x => x.ServiceGroupId == Id).ExecuteDeleteAsync();
                 await _context.Services.Where(x => x.ServiceGroupId == Id).ExecuteDeleteAsync();
                _context.ServiceGroups.Remove(group);
                _context.SaveChanges();
                return new BaseResponse<ServiceGroup>
                {
                    ResponseCode = "200",
                    Message = "Xóa thành công",

                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ServiceGroup>
                {
                    ResponseCode = "500",
                    Message = "Xóa thất bại!"+ ex.Message,

                };
            }
            
        }
        public async Task<BaseResponse<ServiceGroup>> FindServiceGroup(int Id)
        {
            var group = await _context.ServiceGroups.FindAsync(Id);
            if (group == null)
            {
                return new BaseResponse<ServiceGroup>
                {
                    ResponseCode = "500",
                    Message = "Mã nhóm dịch vụ không tồn tại trong hệ thống !"
                };
            }
            return new BaseResponse<ServiceGroup>
            {
                ResponseCode = "200",
                Message = "",
                Data = group,

            };

        }

        
    }
}
