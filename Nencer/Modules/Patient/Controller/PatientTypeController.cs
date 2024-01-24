using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Local.Model;
using Nencer.Modules.Patient.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Category.Controller
{
    /**
     * Đối tượng khách hàng
     */
    [ApiController]
    [Route("api/[controller]")]
    public class PatientTypeController : ControllerBase
    {
        private readonly IPatientTypeRepository _patientTypeRepository;

        public PatientTypeController(IPatientTypeRepository patientTypeRepository)
        {
            _patientTypeRepository = patientTypeRepository;
        }

        [HttpGet("GetAllPatientType")]
        public async Task<BaseResponse<List<PatientType>>> GetAllPatientType()
        {

            var item = await _patientTypeRepository.GetAllPatientType();
            return new BaseResponse<List<PatientType>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }
    }
}
