using Nencer.Modules.Local.Model;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Local.Model.Dto;
using AutoMapper;

namespace Nencer.Modules.Local.Repository
{
    public interface ICityRepository
    {
        Task<List<LocalCity>> GetAllCityByCountryCode(string countryCode = "VN", int status = 1);
        Task<List<LocalCityModel>> GetAllCityByCountryCodeDto(string countryCode = "VN", int status = 1);
    }
    public class CityRepository : ICityRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(NencerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LocalCity>> GetAllCityByCountryCode(string countryCode = "VN", int status = 1)
        {
            return await _context.LocalCities.Where(x => x.Status == status && x.CountryCode == countryCode).ToListAsync();
        }

        public async Task<List<LocalCityModel>> GetAllCityByCountryCodeDto(string countryCode = "VN", int status = 1)
        {
            return await _context.LocalCities.Where(x => x.Status == status && x.CountryCode == countryCode)
                                             .Select(x => _mapper.Map<LocalCityModel>(x))
                                             .ToListAsync();
        }
    }
}
