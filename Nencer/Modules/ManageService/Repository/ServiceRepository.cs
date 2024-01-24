using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nencer.Modules.ManageService.Model;
using Nencer.Modules.ManageService.Model.Dto;
using Nencer.Modules.Product.Model.Dto;
using Nencer.Modules.Room.Model;
using Nencer.Shared;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using RoomModel = Nencer.Modules.Room.Model.Room;
namespace Nencer.Modules.ManageService.Repository
{
    public interface IServiceRepository
    {
        Task<Service> GetServiceById(int id);
        Task<List<Service>> GetServiceByServiceGroupId(int serviceGroupId, int status = 1);
        Task<List<ServiceModel>> GetServiceByServiceGroupIdDto(int serviceGroupId, int status = 1);
        Task<List<ServiceModel>> GetAllParentServiceLISAsync(string? filter = "", int page = 0, int pageSize = 20, int pack = 0);
        Task<BaseResponse<ServiceModel>> CreateServiceAsync(ServiceFormDto serviceFormDto);
        Task<BaseResponse<ServiceModel>> UpdateServiceAsync(ServiceFormDto serviceFormDto, int Id);
        Task<BaseResponse<ServiceModel>> DeleteServiceAsync(int Id);
        Task<BaseResponse<Service>> FindServiceAsync(int Id);
        Task<List<ServiceModel>> GetServiceByServiceTypeId(int serviceTypeId, int page = 0, int pageSize = 20);
        Task<List<SearchServiceModel>> SearchService(SearchServiceDto req);
        Task<List<ListServiceCate>> GetListServiceCate();
        Task<object> GetPriceByObjectService(Service service, string objectService, int? qty = 1);
    }
    public class ServiceRepository : IServiceRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;

        public ServiceRepository(NencerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Service> GetServiceById(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Service>> GetServiceByServiceGroupId(int serviceGroupId, int status = 1)
        {
            return await _context.Services.Where(x => x.Status == status && x.ServiceGroupId == serviceGroupId).ToListAsync();
        }

        public async Task<List<ServiceModel>> GetServiceByServiceGroupIdDto(int serviceGroupId, int status = 1)
        {
            return await _context.Services
                .Where(x => x.Status == status && x.ServiceGroupId == serviceGroupId)
                .Select(x => _mapper.Map<ServiceModel>(x))
                .ToListAsync();
        }
        public async Task<List<ServiceModel>> GetAllParentServiceLISAsync(string? filter = "", int page = 0, int pageSize = 20, int pack = 0)
        {
            return await _context.Services
                .Where(x => x.IsPack == pack)
                .Where(x => string.IsNullOrEmpty(filter) || (EF.Functions.Like(x.Name, "%" + filter + "%")) || (EF.Functions.Like(x.Code, "%" + filter + "%")))
                .OrderBy(x => x.Id)
                    .Skip(page)
                    .Take(pageSize)
                    .Select(x => _mapper.Map<ServiceModel>(x))
                .ToListAsync();
        }
        public async Task<BaseResponse<ServiceModel>> CreateServiceAsync(ServiceFormDto req)
        {
            if (req.Code == null || req.Code == "")
            {
                return new BaseResponse<ServiceModel>
                {
                    ResponseCode = "500",
                    Message = "Mã code không được để trống."
                };
            }
            var Code = req.Code.ToUpper();
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Code == Code);
            if (service != null)
            {
                return new BaseResponse<ServiceModel>
                {
                    ResponseCode = "500",
                    Message = "Mã dịch vụ đã tồn tại trong hệ thống."
                };
            }
            try
            {

                var ServiceGroupId = req.ServiceGroupId;
                var ServiceTypeId = req.ServiceTypeId;

                if (ServiceGroupId != null && ServiceGroupId > 0)
                {
                    var serviceGroup = _context.ServiceGroups.Find(ServiceGroupId);
                    if (serviceGroup == null)
                    {
                        return new BaseResponse<ServiceModel>
                        {
                            ResponseCode = "500",
                            Message = "ServiceGroupId không tồn tại trong hệ thống."
                        };
                    }
                    if (ServiceTypeId != null && ServiceTypeId > 0)
                    {
                        var serviceType = _context.ServiceTypes.Where(x => x.ServiceGroupId == ServiceGroupId && x.Id == ServiceTypeId).FirstOrDefault();
                        if (serviceType == null)
                        {
                            return new BaseResponse<ServiceModel>
                            {
                                ResponseCode = "500",
                                Message = "ServiceTypeId không tồn tại trong hệ thống."
                            };
                        }
                    }
                }


                var rs = new Service();
                rs.Name = req.Name;
                rs.NameIns = req.NameIns;
                rs.IsPack = req.IsPack;
                rs.Code = req.Code;
                rs.CodeIns = req.CodeIns;
                rs.Description = req.Description;
                rs.UnitId = req.UnitId;
                rs.Unit = req.Unit;
                rs.ServiceGroupId = ServiceGroupId;
                rs.ServiceTypeId = ServiceTypeId;
                rs.PriceNormal = req.PriceNormal;
                rs.PriceIns = req.PriceIns;
                rs.PriceService = req.PriceService;
                rs.RoomId = req.RoomId;
                rs.RoomSampleId = req.RoomSampleId;
                rs.OriginalResult = req.OriginalResult;
                rs.Status = req.Status;
                rs.Sort = req.Sort;
                rs.EquivalentCode = req.EquivalentCode;
                rs.SpecialtyCode = req.SpecialtyCode;
                rs.ReassignmentTime = req.ReassignmentTime;
                rs.RightRate = req.RightRate;
                rs.OfflineRate = req.OfflineRate;
                rs.CreatedAt = DateTime.Now;
                rs.UpdatedAt = DateTime.Now;
                await _context.Services.AddAsync(rs);
                await _context.SaveChangesAsync();
                // add service items
                if (req.IsPack == 1 && req.Item != null && req.Item.Length > 0)
                {
                    foreach (var item in req.Item)
                    {
                        if (item != null && (int)item > 0)
                        {
                            var check = await _context.ServiceItems.FirstOrDefaultAsync(x => x.ServiceId == rs.Id && x.ItemId == (int)item);
                            if (check == null)
                            {
                                var nc = new ServiceItem();
                                nc.ServiceId = rs.Id;
                                nc.ItemId = (int)item;
                                _context.ServiceItems.Add(nc);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
                return new BaseResponse<ServiceModel>
                {
                    ResponseCode = "200",
                    Message = "Thêm mới thành công",
                    Data = _mapper.Map<ServiceModel>(rs)

                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ServiceModel>
                {
                    ResponseCode = "500",
                    Message = "Thêm mới thất bại! " + ex.Message,
                };
            }

        }

        public async Task<BaseResponse<ServiceModel>> UpdateServiceAsync(ServiceFormDto req, int Id)
        {

            var service = await _context.Services.FindAsync(Id);
            if (service == null)
            {
                return new BaseResponse<ServiceModel>
                {
                    ResponseCode = "500",
                    Message = "Dịch vụ không tồn tại trong hệ thống."
                };
            }
            try
            {

                var ServiceGroupId = req.ServiceGroupId;
                var ServiceTypeId = req.ServiceTypeId;


                if (ServiceGroupId != null && ServiceGroupId > 0)
                {
                    var serviceGroup = _context.ServiceGroups.Find(ServiceGroupId);
                    if (serviceGroup == null)
                    {
                        return new BaseResponse<ServiceModel>
                        {
                            ResponseCode = "500",
                            Message = "ServiceGroupId không tồn tại trong hệ thống."
                        };
                    }
                    if (ServiceTypeId != null && ServiceTypeId > 0)
                    {
                        var serviceType = _context.ServiceTypes.Where(x => x.ServiceGroupId == ServiceGroupId && x.Id == ServiceTypeId).FirstOrDefault();
                        if (serviceType == null)
                        {
                            return new BaseResponse<ServiceModel>
                            {
                                ResponseCode = "500",
                                Message = "ServiceTypeId không tồn tại trong hệ thống."
                            };
                        }
                    }
                }

                service.Name = req.Name;
                service.NameIns = req.NameIns;
                service.IsPack = req.IsPack;
                service.CodeIns = req.CodeIns;
                service.Description = req.Description;
                service.UnitId = req.UnitId;
                service.Unit = req.Unit;
                service.ServiceGroupId = ServiceGroupId;
                service.ServiceTypeId = ServiceTypeId;
                service.PriceNormal = req.PriceNormal;
                service.PriceIns = req.PriceIns;
                service.PriceService = req.PriceService;
                service.RoomId = req.RoomId;
                service.RoomSampleId = req.RoomSampleId;
                service.OriginalResult = req.OriginalResult;
                service.Status = req.Status;
                service.Sort = req.Sort;
                service.EquivalentCode = req.EquivalentCode;
                service.SpecialtyCode = req.SpecialtyCode;
                service.ReassignmentTime = req.ReassignmentTime;
                service.RightRate = req.RightRate;
                service.OfflineRate = req.OfflineRate;
                service.UpdatedAt = DateTime.Now;
                _context.Services.Update(service);
                _context.SaveChanges();

                if (req.IsPack == 1)
                {
                    if (req.Item != null && req.Item.Length > 0)
                    {
                        // delete service Item
                        int[] items = (int[])req.Item;
                        await _context.ServiceItems.Where(x => x.ServiceId == service.Id).Where(x => !items.Contains(x.ItemId)).ExecuteDeleteAsync();

                        foreach (var item in req.Item)
                        {
                            if (item != null && (int)item > 0)
                            {
                                var check = await _context.ServiceItems.FirstOrDefaultAsync(x => x.ServiceId == service.Id && x.ItemId == (int)item);
                                if (check == null)
                                {
                                    var nc = new ServiceItem();
                                    nc.ServiceId = service.Id;
                                    nc.ItemId = (int)item;
                                    _context.ServiceItems.Add(nc);
                                    _context.SaveChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        await _context.ServiceItems.Where(x => x.ServiceId == service.Id).ExecuteDeleteAsync();
                    }

                }
                return new BaseResponse<ServiceModel>
                {
                    ResponseCode = "200",
                    Message = "Cập nhập thành công",
                    Data = _mapper.Map<ServiceModel>(service)

                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ServiceModel>
                {
                    ResponseCode = "500",
                    Message = "Cập nhập thất bại! " + ex.Message,
                };
            }

        }

        public async Task<BaseResponse<ServiceModel>> DeleteServiceAsync(int Id)
        {
            var service = await _context.Services.FindAsync(Id);
            if (service == null)
            {
                return new BaseResponse<ServiceModel>
                {
                    ResponseCode = "500",
                    Message = "Dịch vụ không tồn tại."
                };
            }
            _context.Services.Remove(service);
            _context.SaveChanges();
            return new BaseResponse<ServiceModel>
            {
                ResponseCode = "200",
                Message = "Xóa dịch vụ thành công"
            };
        }
        public async Task<BaseResponse<Service>> FindServiceAsync(int Id)
        {
            var service = await _context.Services.FindAsync(Id);
            if (service == null)
            {
                return new BaseResponse<Service>
                {
                    ResponseCode = "500",
                    Message = "Dịch vụ không tồn tại."
                };
            }

            return new BaseResponse<Service>
            {
                ResponseCode = "200",
                Message = "",
                Data = service
            };
        }
        public async Task<List<ServiceModel>> GetServiceByServiceTypeId(int ServiceTypeId, int page = 0, int pageSize = 20)
        {
            return await _context.Services
                .Where(x => x.ServiceTypeId == ServiceTypeId && x.Status == 1)
                .OrderBy(x => x.Id)
                    .Skip(page)
                    .Take(pageSize)
                    .Select(x => _mapper.Map<ServiceModel>(x))
                .ToListAsync();
        }
        public async Task<List<SearchServiceModel>> SearchService(SearchServiceDto req)
        {
            var page = req.Page.GetValueOrDefault();
            var pageSize = req.pageSize.GetValueOrDefault();
            var skip = 0;
            if (page > 1)
            {
                skip = (page - 1) * pageSize;
            }
            var services = await _context.Services.Where(x => x.Status == 1 && x.IsPack == 1 && (!req.ServiceGroupId.HasValue || req.ServiceGroupId > 0 || req.ServiceGroupId == x.ServiceGroupId)
            && (!req.ServiceTypeId.HasValue || req.ServiceTypeId > 0 || req.ServiceTypeId == x.ServiceTypeId)
            && (string.IsNullOrEmpty(req.Keyword) || (EF.Functions.Like(x.Name, req.Keyword + "%")) || (EF.Functions.Like(x.Code, req.Keyword + "%"))))
                .OrderByDescending(c => c.CreatedAt)
                .Skip(skip).Take(pageSize)
                .ToListAsync();
            if (services.Count > 0)
            {
                var result = services.Select(x => new SearchServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameIns = x.NameIns,
                    Code = x.Code,
                    PriceIns = x.PriceIns,
                    PriceNormal = x.PriceNormal,
                    PriceService = x.PriceService,
                    GroupName = GetServiceGroupName(x.ServiceGroupId).Result,
                    RoomSample = GetRoomByListId(x.RoomSampleId).Result,
                    RoomHandle = GetRoomByListId(x.RoomHandleId).Result,
                }).ToList();
                return result;
            }

            return null;
        }
        public async Task<string> GetServiceGroupName(int? Id)
        {
            if (Id.HasValue)
            {
                var group = await _context.ServiceGroups.FindAsync(Id);
                if (group != null)
                {
                    return group.Name;
                }
            }
            return null;
        }
        public async Task<List<RoomModel>> GetRoomByListId(string? listId)
        {
            if (!string.IsNullOrEmpty(listId))
            {
                int[] arrayId = listId.Split(';').Select(int.Parse).ToArray();
                if (arrayId.Length > 0)
                {
                    return await _context.Rooms.Where(x => arrayId.Contains(x.Id)).ToListAsync();
                }
            }
            return null;
        }
        public async Task<List<ListServiceCate>> GetListServiceCate()
        {
            var ServiceGroups = await _context.ServiceGroups.Where(x => x.Status == 1).OrderBy(x => x.Sort).ToListAsync();
            var ServiceGroup = ServiceGroups.Select(x => new ServiceGroupItem
            {
                Code = x.CodeName,
                Name = x.Name,
                Id = x.Id,
                Total = _context.Services.Where(y => y.Status == 1 && y.ServiceGroupId == x.Id).Count(),
                ServiceTypeItems = GetListServiceType(x.Id).Result
            });
            var data = new ListServiceCate
            {
                Total = await _context.Services.Where(x => x.Status == 1).CountAsync(),

            };
            return null;
        }
        public async Task<List<ServiceGroupItem>> GetListServiceType(int? GroupId)
        {
            if (GroupId.HasValue)
            {
                var ServiceTypes = await _context.ServiceTypes.Where(x => x.Status == 1 && x.ServiceGroupId == GroupId).OrderBy(x => x.Sort).ToListAsync();
                if (ServiceTypes.Count > 0)
                {
                    var serviceType = ServiceTypes.Select(x => new ServiceGroupItem
                    {
                        Code = x.Code,
                        Name = x.Name,
                        Id = x.Id,
                        Total = _context.Services.Count(y => y.Status == 1 && y.ServiceGroupId == GroupId && y.ServiceTypeId == x.Id),
                    }).ToList();
                    return serviceType;
                };

            }
            return null;
        }

        public async Task<dynamic> GetPriceByObjectService(Service service, string objectService, int? qty = 1 )
        {
            double? price = 0;
            double? total = 0;
            double? priceIns = 0;
           
            if (objectService == "FREE")
            {
                price = 0;
                total = 0;
                priceIns = 0;
            }else if(objectService == "INSURANCE")
            {
                price = service.PriceNormal;
                total = price * qty;
                priceIns = service.PriceIns * qty;
            }else if(objectService == "REQUEST")
            {
                price = service.PriceService;
                total = price * qty;
                priceIns = 0;
            }
            else
            {
                price = service.PriceNormal;
                total = price * qty;
                priceIns = 0;
            }
            var listprice = new { price = price, total = total, priceIns = priceIns };
            return listprice;
           
        }

    }
}
