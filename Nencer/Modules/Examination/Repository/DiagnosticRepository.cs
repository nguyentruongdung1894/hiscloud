using AutoMapper;
using Nencer.Shared;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Examination.Model;
using System.Data.Entity;

namespace Nencer.Modules.Examination.Repository
{
    public interface IDiagnosticRepository
    {
        Task<List<CatelogDiagnostic>> SearchDiagnostic(string Code);
        Task<string> SaveExaminationDiagnostic(int objectId, string diagnosticCode, string type, int? primary = 0);
    }
    public class DiagnosticRepository : IDiagnosticRepository
    {
        
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;
        public DiagnosticRepository(NencerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CatelogDiagnostic>> SearchDiagnostic(string Code)
        {
            return await _context.CatelogDiagnostics.Where(x => (EF.Functions.Like(x.Code, Code + "%"))).Take(5).ToListAsync();
        }
        public async Task<string> SaveExaminationDiagnostic(int objectId , string diagnosticCode, string type, int? primary = 0)
        {
            try
            {
                var diagnostic = await _context.CatelogDiagnostics.FirstOrDefaultAsync(x => x.Code == diagnosticCode);
                if (diagnostic == null)
                {
                    return "DIAGNOSTIC_NOT_FOUND";
                }
                var exdiagnostic = await _context.ExaminationDiagnostics.FirstOrDefaultAsync(x => x.DiagnosticId == diagnostic.Id && x.Type == type && x.ObjectId == objectId);
                if (exdiagnostic != null)
                {
                    exdiagnostic.IsPrimary = primary.GetValueOrDefault();
                    _context.ExaminationDiagnostics.Update(exdiagnostic);
                    _context.SaveChanges();
                }
                else
                {
                    exdiagnostic = new ExaminationDiagnostic();
                    exdiagnostic.Type = type;
                    exdiagnostic.DiagnosticId = diagnostic.Id;
                    exdiagnostic.ObjectId = objectId;
                    exdiagnostic.IsPrimary = primary.GetValueOrDefault();
                    await _context.ExaminationDiagnostics.AddAsync(exdiagnostic);
                    await _context.SaveChangesAsync();
                }
                return "SUCCESS";
            }
            catch(Exception ex)
            {
                return "FALSE";
            }
            
        }
    }
}
