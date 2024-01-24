using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Patient.Model;

namespace Nencer.Modules.Patient.Repository
{
    public interface IPatientDetailsRepository
    {
        Task<PatientDetail> GetByPatientId(int? id);
    }
    public class PatientDetailsRepository : IPatientDetailsRepository
    {
        private readonly NencerDbContext _context;

        public PatientDetailsRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<PatientDetail> GetByPatientId(int? id)
        {
            return await _context.PatientDetails.FirstOrDefaultAsync(x => x.PatientId == id);
        }
    }
}
