using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Nencer.Modules.Checkin.Model;
using Nencer.Modules.Checkin.Model.Dto;
using Nencer.Modules.Checkin.Repository;
using Nencer.Modules.Patient.Repository;
using Nencer.Resources;
using Nencer.Shared;

namespace Nencer.Modules.Category.Controller
{
    /**
     * Tiếp đón
     */
    [ApiController]
    [Route("api/[controller]")]
    public class CheckinController : BaseController
    {
        private readonly IPatientTypeRepository _typeRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly ICheckinRepository _checkinRepository;
        private readonly IStringLocalizer<NencerResource> _localizer;
        private readonly ICheckinOrdinalRepository _checkinOrdinalRepository;
        private readonly ICheckinDoorRepository _checkinDoorRepository;

        public CheckinController(IPatientTypeRepository typeRepository, IPatientRepository patientRepository, ICheckinRepository checkinRepository, IStringLocalizer<NencerResource> localizer, ICheckinOrdinalRepository checkinOrdinalRepository, ICheckinDoorRepository checkinDoorRepository)
        {
            _typeRepository = typeRepository;
            _patientRepository = patientRepository;
            _checkinRepository = checkinRepository;
            _localizer = localizer;
            _checkinOrdinalRepository = checkinOrdinalRepository;
            _checkinDoorRepository = checkinDoorRepository;
        }

        /// <summary>
        /// Tìm kiêm Tiếp đón
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        [HttpPost("/Checkin")]
        public async Task<List<PatientsModel>> GetCheckinAsync(SearchModel searchModel)
        {
            return await _checkinRepository.GetListPaggingAsync(searchModel);
        }

        /// <summary>
        /// Tạo mới tiếp đón
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<BaseResponse<Checkin.Model.Checkin>> Create(CheckinRequest req)
        {
            if (req == null)
            {
                return new BaseResponse<Checkin.Model.Checkin>
                {
                    Message = "Bat buoc nhap",
                    ResponseCode = "01",
                };
            }
            return await _checkinRepository.Create(req);
        }

        /// <summary>
        /// Tìm kiếm tiếp đón theo checkin id
        /// </summary>
        /// <param name="idCheckIn"></param>
        /// <returns></returns>
        [HttpGet("/GetInfoCheckInById/{idCheckIn}")]
        public async Task<CheckinRequest> GetInfoCheckInById(long idCheckIn)
        {
            return await _checkinRepository.GetInfoCheckInById(idCheckIn);
        }

        /// <summary>
        /// Cập nhật tiếp đón
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<BaseResponse<Checkin.Model.Checkin>> Update(CheckinRequest req)
        {
            try
            {
                if (req.Checkin.Id <= 0)
                {
                    return new BaseResponse<Checkin.Model.Checkin>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                if (req == null)
                {
                    return new BaseResponse<Checkin.Model.Checkin>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                return await _checkinRepository.Update(req);
            }
            catch (Exception ex)
            {

                return new BaseResponse<Checkin.Model.Checkin>
                {
                    Message = ex.Message,
                    ResponseCode = "999",
                };
            }
        }

        /// <summary>
        /// Xóa tiếp đón
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<BaseResponse<Checkin.Model.Checkin>> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new BaseResponse<Checkin.Model.Checkin>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                return await _checkinRepository.Delete(id);
            }
            catch (Exception ex)
            {

                return new BaseResponse<Checkin.Model.Checkin>
                {
                    Message = ex.Message,
                    ResponseCode = "999",
                };
            }
        }

        /// <summary>
        /// Lấy số tiếp đón
        /// </summary>
        /// <param name="takeNumber">ST/UT</param>
        /// <returns></returns>
        [HttpGet("GenerateCheckinOrdinal")]
        public async Task<BaseResponse<List<BaseCallingOrdinal>>> GenerateCheckinOrdinal(string takeNumber)
        {
            if (string.IsNullOrWhiteSpace(takeNumber))
            {
                return new BaseResponse<List<BaseCallingOrdinal>>
                {
                    Message = "Bat buoc nhap",
                    ResponseCode = "01",
                };
            }
            await _checkinOrdinalRepository.GenerateCheckinOrdinal(takeNumber);
            var rs = await _checkinOrdinalRepository.GetCheckinOrdinalNumber();

            return new BaseResponse<List<BaseCallingOrdinal>>
            {
                Message = "",
                ResponseCode = "00",
                Data = rs
            };
        }

        /// <summary>
        /// Ds cửa tiếp đón
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCheckinDoor")]
        public async Task<BaseResponse<List<CheckinDoor>>> GetCheckinDoor()
        {
            return new BaseResponse<List<CheckinDoor>>
            {
                Message = "",
                ResponseCode = "00",
                Data = await _checkinDoorRepository.GetAllCheckInDoor()
            };
        }

        /// <summary>
        /// Lấy số đang gọi
        /// </summary>
        /// <param name="takeNumber"></param>
        /// <param name="doorId"></param>
        /// <returns></returns>
        [HttpGet("GetCheckinCalling")]
        public async Task<BaseResponse<BaseCallingOrdinal>> GetCheckinCalling(string takeNumber, int? doorId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(takeNumber))
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                if (doorId == null)
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }

                return new BaseResponse<BaseCallingOrdinal>
                {
                    Message = "",
                    ResponseCode = "00",
                    Data = await _checkinOrdinalRepository.ChekinCalling(takeNumber, doorId.Value)
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse<BaseCallingOrdinal>
                {
                    Message = ex.Message,
                    ResponseCode = "999",
                };
            }
        }

        /// <summary>
        /// Gọ số tiếp theo
        /// </summary>
        /// <param name="takeNumber"></param>
        /// <param name="doorId"></param>
        /// <returns></returns>
        [HttpGet("GetCheckinCallNextNumber")]
        public async Task<BaseResponse<BaseCallingOrdinal>> GetCheckinCallNextNumber(string takeNumber, int? doorId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(takeNumber))
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                if (doorId == null)
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                var x = await _checkinOrdinalRepository.GetChekinCallNextNumber(takeNumber, doorId.Value);
                if (x == null)
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Het benh nhan tiep don",
                        ResponseCode = "501",
                    };
                }
                // todo: gui websocket

                return new BaseResponse<BaseCallingOrdinal>
                {
                    Message = "",
                    ResponseCode = "00",
                    Data = x
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse<BaseCallingOrdinal>
                {
                    Message = ex.Message,
                    ResponseCode = "999",
                };
            }
        }

        /// <summary>
        /// Gọi lại số
        /// </summary>
        /// <param name="takeNumber"></param>
        /// <param name="doorId"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("CallBack")]
        public async Task<BaseResponse<BaseCallingOrdinal>> CallBack(string takeNumber, int? number)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(takeNumber))
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                if (number == null)
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                var x = await _checkinOrdinalRepository.GetCheckinNumberAndCalling(takeNumber, number.Value);
                if (x == null)
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Het benh nhan tiep don",
                        ResponseCode = "501",
                    };
                }

                return new BaseResponse<BaseCallingOrdinal>
                {
                    Message = "",
                    ResponseCode = "00",
                    Data = x
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse<BaseCallingOrdinal>
                {
                    Message = ex.Message,
                    ResponseCode = "999",
                };
            }
        }

        /// <summary>
        /// Hiển thị màn hình gọi số tiếp đón
        /// </summary>
        /// <param name="doorId"></param>
        /// <returns></returns>
        [HttpGet("CheckinWindowDisplayNumberResponse")]
        public async Task<BaseResponse<List<BaseWindowDisplayNumberResponse>>> CheckinWindowDisplayNumberResponse(string doorCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(doorCode))
                {
                    return new BaseResponse<List<BaseWindowDisplayNumberResponse>>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                string[] doors = doorCode.Split(';');
                var x = await _checkinOrdinalRepository.WindowCheckinCallingNumber(doors);
                if (x == null)
                {
                    return new BaseResponse<List<BaseWindowDisplayNumberResponse>>
                    {
                        Message = "Het benh nhan tiep don",
                        ResponseCode = "501",
                    };
                }

                return new BaseResponse<List<BaseWindowDisplayNumberResponse>>
                {
                    Message = "",
                    ResponseCode = "00",
                    Data = x
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse<List<BaseWindowDisplayNumberResponse>>
                {
                    Message = ex.Message,
                    ResponseCode = "999",
                };
            }
        }
    }
}
