using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Local.Model;
using Nencer.Modules.Local.Model.Dto;
using Nencer.Modules.Local.Repository;
using Nencer.Modules.Service.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Local.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IWardRepository _wardRepository;
        private readonly IMapper _mapper;

        public LocalController(ICountryRepository countryRepository, ICityRepository cityRepository, IDistrictRepository districtRepository, IWardRepository wardRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllCountry")]
        public async Task<BaseResponse<List<LocalCountry>>> GetAllCountry()
        {

            var item = await _countryRepository.GetAllCountry();
            return new BaseResponse<List<LocalCountry>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }

        [HttpGet("GetAllCityByCountryCode/{countryCode}")]
        public async Task<BaseResponse<List<LocalCityModel>>> GetAllCityByCountryCode(string countryCode)
        {

            var item = await _cityRepository.GetAllCityByCountryCodeDto(countryCode);
            
            return new BaseResponse<List<LocalCityModel>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }

        [HttpGet("GetAllDistrictByCityCode/{cityCode}")]
        public async Task<BaseResponse<List<LocalDistrict>>> GetAllDistrictByCityCode(string cityCode)
        {

            var item = await _districtRepository.GetAllDistrictByCityCode(cityCode);
            return new BaseResponse<List<LocalDistrict>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }

        [HttpGet("GetAllWardByShortCode/{shortCode}")]
        public async Task<BaseResponse<List<LocalWard>>> GetAllWardByShortCode(string shortCode)
        {

            var item = await _wardRepository.GetAllWardByShortCode(shortCode);
            return new BaseResponse<List<LocalWard>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }

        [HttpGet("GetAllWardBy/{districtCode}/{cityCode}")]
        public async Task<BaseResponse<List<LocalWard>>> GetAllWardBy(string districtCode, string cityCode)
        {

            var item = await _wardRepository.GetAllWardBy(districtCode, cityCode);
            return new BaseResponse<List<LocalWard>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }



    }
}
