using Microsoft.EntityFrameworkCore;

namespace Nencer.Modules.Patient.Repository
{
    public interface IPatientTypeRepository
    {
        // truy van danh sach doi tuong
        Task<List<PatientType>> GetAllPatientType(int status = 1);
    }
    public class PatientTypeRepository : IPatientTypeRepository
    {
        private readonly NencerDbContext _context;

        public PatientTypeRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<List<PatientType>> GetAllPatientType(int status = 1)
        {
            return await _context.PatientTypes.Where(x => x.Status == status).ToListAsync();
        }
    }
}
