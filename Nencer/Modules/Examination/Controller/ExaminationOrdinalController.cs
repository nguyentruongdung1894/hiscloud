using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Checkin.Model.Dto;
using Nencer.Modules.Examination.Model.Dto;
using Nencer.Modules.Patient.Repository;
using Nencer.Modules.Room.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Examination.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExaminationOrdinalController : BaseController
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IExaminationOrdinalRepository _examinationOrdinalRepository;

        public ExaminationOrdinalController(IRoomRepository roomRepository, IExaminationOrdinalRepository examinationOrdinalRepository)
        {
            _roomRepository = roomRepository;
            _examinationOrdinalRepository = examinationOrdinalRepository;
        }

        /// <summary>
        /// Lấy thông tin số đang gọi BN KHÁM
        /// </summary>
        /// <param name="takeNumber"></param>
        /// <param name="doorId"></param>
        /// <returns></returns>
        [HttpGet("GetExamCalling")]
        public async Task<BaseResponse<BaseCallingOrdinal>> GetExamCalling(string? roomCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roomCode))
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                var x = await _roomRepository.GetByCode(roomCode);
                if (x == null)
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Khong tim thay ban ghi.",
                        ResponseCode = "02",
                    };
                }
                return new BaseResponse<BaseCallingOrdinal>
                {
                    Message = "",
                    ResponseCode = "00",
                    Data = await _examinationOrdinalRepository.GetExamByRoomId(roomCode)
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
        /// Gọi số tiếp theo khám bệnh
        /// </summary>
        /// <param name="roomCode"></param>
        /// <returns></returns>
        [HttpGet("GetExamCallNextNumber")]
        public async Task<BaseResponse<BaseCallingOrdinal>> GetExamCallNextNumber(string roomCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roomCode))
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                var x = await _roomRepository.GetByCode(roomCode);
                if (x == null)
                {
                    return new BaseResponse<BaseCallingOrdinal>
                    {
                        Message = "Khong tim thay ban ghi.",
                        ResponseCode = "02",
                    };
                }
                // todo: gui websocket
                var exam = await _examinationOrdinalRepository.GetExamCallNextNumber(roomCode);
                if (exam == null)
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
                    Data = exam
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
        /// Goi lai kham benh
        /// </summary>
        /// <param name="roomCode"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("CallBack")]
        public async Task<BaseResponse<BaseCallingOrdinal>> CallBack(string roomCode, int? number)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roomCode))
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
                var x = await _examinationOrdinalRepository.GetExamNumberAndCalling(roomCode, number.Value);
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
        /// Hiển thị bảng tv
        /// </summary>
        /// <param name="roomCode"></param>
        /// <returns></returns>
        [HttpGet("ExamWindowDisplayNumberResponse")]
        public async Task<BaseResponse<ExaminationCallingUserResponse>> ExamWindowDisplayNumberResponse(string roomCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roomCode))
                {
                    return new BaseResponse<ExaminationCallingUserResponse>
                    {
                        Message = "Bat buoc nhap",
                        ResponseCode = "01",
                    };
                }
                string[] roomCodes = roomCode.Split(';');
                var x = await _examinationOrdinalRepository.WindowExamCallingNumber(roomCodes);
                if (x == null)
                {
                    return new BaseResponse<ExaminationCallingUserResponse>
                    {
                        Message = "Het benh nhan tiep don",
                        ResponseCode = "501",
                    };
                }

                return new BaseResponse<ExaminationCallingUserResponse>
                {
                    Message = "",
                    ResponseCode = "00",
                    Data = x
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse<ExaminationCallingUserResponse>
                {
                    Message = ex.Message,
                    ResponseCode = "999",
                };
            }
        }
    }
}
