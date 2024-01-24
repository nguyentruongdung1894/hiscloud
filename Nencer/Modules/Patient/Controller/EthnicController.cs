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
    public class EthnicController : ControllerBase
    {
        private readonly IEthnicRepository _ethnicRepository;

        public EthnicController(IEthnicRepository ethnicRepository)
        {
            _ethnicRepository = ethnicRepository;
        }

        [HttpGet("GetAllEthnic")]
        public async Task<BaseResponse<List<Ethnic>>> GetAllCountry()
        {

            var item = await _ethnicRepository.GetAllEthnic();
            return new BaseResponse<List<Ethnic>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }
    }
}
