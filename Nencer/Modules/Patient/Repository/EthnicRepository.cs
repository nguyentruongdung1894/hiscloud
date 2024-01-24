using Microsoft.EntityFrameworkCore;

namespace Nencer.Modules.Patient.Repository
{
    public interface IEthnicRepository
    {
        Task<List<Ethnic>> GetAllEthnic();
    }

    public class EthnicRepository : IEthnicRepository
    {
        private readonly NencerDbContext _context;

        public EthnicRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ethnic>> GetAllEthnic()
        {
            return await _context.Ethnics.ToListAsync();
        }
    }
}
