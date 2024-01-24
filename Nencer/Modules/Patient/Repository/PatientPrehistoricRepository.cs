using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Patient.Model;

namespace Nencer.Modules.Patient.Repository
{
    public interface IPatientPrehistoricRepository
    {
        Task<List<PatientPrehistoric>> GetByPatientId(int? pId);
    }
    public class PatientPrehistoricRepository : IPatientPrehistoricRepository
    {
        private readonly NencerDbContext _context;

        public PatientPrehistoricRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<List<PatientPrehistoric>> GetByPatientId(int? pId)
        {
            return await _context.PatientPrehistorics.Where(x => x.PatientId == pId).ToListAsync();
        }
    }
}
