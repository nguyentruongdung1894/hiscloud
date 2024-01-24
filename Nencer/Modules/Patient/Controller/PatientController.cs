using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Patient.Model.Dto;
using Nencer.Modules.Patient.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Patient.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        [HttpPost("Created")]
        public async Task<BaseResponse<Model.Patient>> CreatedOrUpdatePatientAsync(PatientDto patient)
        {
            return await _patientRepository.CreatedOrUpdatePatientAsync(patient);
        }
        [HttpGet("find/{patientCode}")]
        public async Task<Model.Patient> FindPatientByCode(string patientCode)
        {
            return await _patientRepository.FindPatientByCode(patientCode);
        }

    }
}
