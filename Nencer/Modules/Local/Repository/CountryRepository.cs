using Nencer.Modules.Local.Model;
using Microsoft.EntityFrameworkCore;

namespace Nencer.Modules.Local.Repository
{
    public interface ICountryRepository
    {
        Task<List<LocalCountry>> GetAllCountry(int status = 1);
    }
    public class CountryRepository : ICountryRepository
    {
        private readonly NencerDbContext _context;

        public CountryRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocalCountry>> GetAllCountry(int status = 1)
        {
            // TODO get from redis
            return await _context.LocalCountries.Where(x => x.Status == status).ToListAsync();
        }
    }
}
