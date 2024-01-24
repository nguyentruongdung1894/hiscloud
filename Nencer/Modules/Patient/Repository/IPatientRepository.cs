using Nencer.Modules.Patient.Model.Dto;
using Nencer.Shared;

namespace Nencer.Modules.Patient.Repository
{
    public interface IPatientRepository
    {
        Task<BaseResponse<Model.Patient>> CreatedOrUpdatePatientAsync(PatientDto patientDto);
        Task<Model.Patient> FindPatientByCode(string patientCode);
        Task<Model.Patient> GetPatialById(int id);
        Task<Model.Patient> GetPatialByPatientNumber(string patientNumber);
    }
}
