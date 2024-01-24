using Nencer.Modules.Local.Model;
using Microsoft.EntityFrameworkCore;

namespace Nencer.Modules.Local.Repository
{
    public interface IDistrictRepository
    {
        Task<List<LocalDistrict>> GetAllDistrictByCityCode(string cityCode, int status = 1);
    }
    public class DistrictRepository : IDistrictRepository
    {
        private readonly NencerDbContext _context;

        public DistrictRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocalDistrict>> GetAllDistrictByCityCode(string cityCode, int status = 1)
        {
            return await _context.LocalDistricts.Where(x => x.ProvinceCode == cityCode && x.Status == status).ToListAsync();
        }
    }
}
