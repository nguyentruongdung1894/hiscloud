using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Patient.Model.Dto;
using Nencer.Shared;

namespace Nencer.Modules.Patient.Repository
{


    public class PatientRepository : IPatientRepository
    {
        private readonly NencerDbContext _context;

        public PatientRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<Model.Patient> GetPatialById(int id)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Model.Patient> GetPatialByPatientNumber(string patientNumber)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(x => x.PatientNumber == patientNumber);
        }
        public async Task<BaseResponse<Model.Patient>> CreatedOrUpdatePatientAsync(PatientDto request)
        {
            if (request.Name == null)
            {
                return new BaseResponse<Model.Patient>
                {
                    Status = "500",
                    Message = "Dữ liệu không hợp lệ",
                    Data = null
                };
            }
            var patientNumber = request.PatientNumber;
            if (request.PatientNumber == null)
            {
                patientNumber = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientNumber == patientNumber);
            if (patient == null)
            {
                patient = new Model.Patient();
                patient.PatientNumber = patientNumber;
                patient.CreatedAt = DateTime.Now;
            }
            patient.Name = request.Name;
            patient.Phone = request.Phone;
            patient.Email = request.Email;
            patient.IdCardType = request.IdCardType;
            patient.IdCard = request.IdCard;
            patient.Gender = request.Gender;
            patient.DayBorn = request.DayBorn;
            patient.MonthBorn = request.MonthBorn;
            patient.YearBorn = request.YearBorn;
            patient.CityId = request.CityId;
            patient.DistrictId = request.DistrictId;
            patient.WardId = request.WardId;
            patient.PartnerId = request.PartnerId;
            patient.Address = request.Address;
            patient.CountryCode = request.CountryCode;
            patient.Nationality = request.Nationality;
            patient.Ethnic = request.Ethnic;
            patient.DetailObject = request.DetailObject;
            patient.JobTitle = request.JobTitle;
            patient.UpdatedAt = DateTime.Now;
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            if (patient.Id > 0)
            {
                patient.PatientNumber = DateTime.Now.ToString("yyyy") + patient.Id;
                await _context.SaveChangesAsync();
            }
            return new BaseResponse<Model.Patient>
            {
                Status = "200",
                Message = "Thêm mới thành công!",
                Data = patient
            };
        }
        public async Task<Model.Patient> FindPatientByCode(string patientCode)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.PatientNumber == patientCode);
        }
    }
}
