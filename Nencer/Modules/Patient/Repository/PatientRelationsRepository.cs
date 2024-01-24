using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Patient.Model;

namespace Nencer.Modules.Patient.Repository
{
    public interface IPatientRelationsRepository
    {
        Task<List<PatientRelation>> GetByPatientId(int? pId);
    }
    public class PatientRelationsRepository : IPatientRelationsRepository
    {
        private readonly NencerDbContext _context;

        public PatientRelationsRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<List<PatientRelation>> GetByPatientId(int? pId)
        {
            return await _context.PatientRelations.Where(x => x.PatientId == pId).ToListAsync();
        }
    }
}
