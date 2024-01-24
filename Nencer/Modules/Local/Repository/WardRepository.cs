using Nencer.Modules.Local.Model;
using Microsoft.EntityFrameworkCore;

namespace Nencer.Modules.Local.Repository
{
    public interface IWardRepository
    {
        Task<List<LocalWard>> GetAllWardBy(string districtCode, string cityCode, int status = 1);
        Task<List<LocalWard>> GetAllWardByShortCode(string shortCode, int status = 1);
    }

    public class WardRepository : IWardRepository
    {
        private readonly NencerDbContext _context;

        public WardRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocalWard>> GetAllWardBy(string districtCode, string cityCode, int status = 1)
        {
            return await _context.LocalWards.Where(x => x.Status == status
            && x.DistrictCode == districtCode
            && x.CityCode == cityCode).ToListAsync();
        }

        public async Task<List<LocalWard>> GetAllWardByShortCode(string shortCode, int status = 1)
        {
            return await _context.LocalWards.Where(x => x.Status == status && x.ShortCode == shortCode).ToListAsync();
        }
    }
}
