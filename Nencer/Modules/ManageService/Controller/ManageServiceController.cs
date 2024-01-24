using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.ManageService;
using Nencer.Modules.ManageService.Model;
using Nencer.Modules.ManageService.Model.Dto;
using Nencer.Modules.ManageService.Repository;
using Nencer.Shared;
using System.Security.Claims;

namespace Nencer.Modules.Category.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManageService : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceGroupRepository _serviceGroupRepository;
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public ManageService(IServiceRepository serviceRepository, IServiceGroupRepository serviceGroupRepository, IServiceTypeRepository serviceTypeRepository)
        {
            _serviceRepository = serviceRepository;
            _serviceGroupRepository = serviceGroupRepository;
            _serviceTypeRepository = serviceTypeRepository;
        }

        [HttpGet("GetServiceByServiceGroupId/{serviceGroupId}")]
        public async Task<BaseResponse<List<ServiceModel>>> GetServiceByServiceGroupId(int serviceGroupId)
        {

            var item = await _serviceRepository.GetServiceByServiceGroupIdDto(serviceGroupId);
            return new BaseResponse<List<ServiceModel>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }
        [HttpGet("GetServiceByServiceTypeId/{serviceTypeId}")]
        public async Task<BaseResponse<List<ServiceModel>>> GetServiceByServiceTypeId(int serviceTypeId)
        {

            var item = await _serviceRepository.GetServiceByServiceTypeId(serviceTypeId);
            return new BaseResponse<List<ServiceModel>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }
        [HttpGet("List")]
        public async Task<BaseResponse<List<ServiceModel>>> GetAllParentServiceLISAsync(string? filter, int? page = 0, int? pageSize = 20, int? pack = 0)
        {

            var search = !string.IsNullOrEmpty(filter) ? filter.ToLower().Trim() : "";
            if (page >= 1)
            {
                page = (page - 1) * pageSize;
            }

            var item = await _serviceRepository.GetAllParentServiceLISAsync(search, page.GetValueOrDefault(), pageSize.GetValueOrDefault(), pack.GetValueOrDefault());

            return new BaseResponse<List<ServiceModel>>()
            {
                ResponseCode = "200",
                Message = "",
                Data = item
            };

        }
        [HttpPost("Create")]
        public async Task<BaseResponse<ServiceModel>> CreateServiceAsync(ServiceFormDto serviceFormDto)
        {
            return await _serviceRepository.CreateServiceAsync(serviceFormDto);
        }
        [HttpPut("Update/{Id}")]
        public async Task<BaseResponse<ServiceModel>> UpdateServiceAsync(ServiceFormDto serviceFormDto, int Id)
        {
            return await _serviceRepository.UpdateServiceAsync(serviceFormDto, Id);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<BaseResponse<ServiceModel>> DeleteServiceAsync(int Id)
        {
            return await _serviceRepository.DeleteServiceAsync(Id);
        }
        [HttpGet("SearchService")]
        public async Task<BaseResponse<List<SearchServiceModel>>> SearchService(SearchServiceDto rq)
        {
            return new BaseResponse<List<SearchServiceModel>>
            {
                ResponseCode = "200",
                Data = await _serviceRepository.SearchService(rq)
            };
        }
        // Service group
        [HttpGet("ServiceGroup/List")]
        public async Task<BaseResponse<List<ServiceGroup>>> GetAllServiceGroupAsync()
        {
            var item = await _serviceGroupRepository.GetAllServiceGroupAsync();
            return new BaseResponse<List<ServiceGroup>>()
            {
                ResponseCode = "200",
                Message = "",
                Data = item

            };
        }
        [HttpPost("ServiceGroup/Save")]
        public async Task<BaseResponse<ServiceGroup>> CreateServiceType(ServiceGroup request)
        {
            return await _serviceGroupRepository.CreateServiceGroup(request);
        }
        [HttpPut("ServiceGroup/Update/{id}")]
        public async Task<BaseResponse<ServiceGroup>> UpdateServiceGroup(ServiceGroup request, int Id)
        {
            return await _serviceGroupRepository.UpdateServiceGroup(request, Id);
        }
        [HttpDelete("ServiceGroup/Delete/{id}")]
        public async Task<BaseResponse<ServiceGroup>> DeleteServiceGroup(int Id)
        {
            return await _serviceGroupRepository.DeleteServiceGroup(Id);
        }
        [HttpGet("ServiceGroup/Find/{id}")]
        public async Task<BaseResponse<ServiceGroup>> FindServiceGroup(int Id)
        {
            return await _serviceGroupRepository.FindServiceGroup(Id);
        }
        // End Service group
        // Service type
        [HttpGet("ServiceType/List")]
        public async Task<BaseResponse<List<ServiceType>>> GetServiceTypeAsync(string? filter, int? page = 0, int? pageSize = 20)
        {
            var search = !string.IsNullOrEmpty(filter) ? filter.ToLower().Trim() : "";
            if (page >= 1)
            {
                page = (page - 1) * pageSize;
            }
            var item = await _serviceTypeRepository.GetServiceTypeAsync(search, page.GetValueOrDefault(), pageSize.GetValueOrDefault());
            return new BaseResponse<List<ServiceType>>()
            {
                ResponseCode = "200",
                Message = "",    
                Data = item
            };
        }
        [HttpGet("ServiceType/List/{groupId}")]
        public async Task<BaseResponse<List<ServiceType>>> GetServiceTypeByGroupAsync(int groupId, int? page = 0, int? pageSize = 20)
        {
           
            if (page >= 1)
            {
                page = (page - 1) * pageSize;
            }
            var item = await _serviceTypeRepository.GetServiceTypeByGroupAsync(groupId, page.GetValueOrDefault(), pageSize.GetValueOrDefault());
            return new BaseResponse<List<ServiceType>>()
            {
                ResponseCode = "200",
                Message = "",
                Data = item
            };
        }
        [HttpGet("ServiceType/Find/{id}")]
        public async Task<BaseResponse<ServiceType>> FindServiceType(int Id)
        {
            return await _serviceTypeRepository.FindServiceType(Id);
        }
        [HttpPost("ServiceType/Save")]
        public async Task<BaseResponse<ServiceType>> CreateServiceType(ServiceTypeDto createServiceTypeDto)
        {
            return await _serviceTypeRepository.CreateServiceType(createServiceTypeDto);
        }
        [HttpPut("ServiceType/Update/{id}")]
        public async Task<BaseResponse<ServiceType>> UpdateServiceType(ServiceTypeDto createServiceTypeDto, int Id)
        {
            return await _serviceTypeRepository.UpdateServiceType(createServiceTypeDto, Id);
        }
        [HttpDelete("ServiceType/Delete/{id}")]
        public async Task<BaseResponse<ServiceType>> DeleteServiceType(int Id)
        {
            return await _serviceTypeRepository.DeleteServiceType(Id);
        }
        // End Service Type
    }
}
