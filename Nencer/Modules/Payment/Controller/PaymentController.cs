using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Checkin.Model.Dto;
using Nencer.Modules.Checkin.Repository;
using Nencer.Modules.Payment.Model.Dto;
using Nencer.Modules.Payment.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Payment.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : BaseController
    {
        private readonly ICheckinRepository _checkinRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(ICheckinRepository checkinRepository, IPaymentRepository paymentRepository)
        {
            _checkinRepository = checkinRepository;
            _paymentRepository = paymentRepository;
        }
        /// <summary>
        /// Danh sách tiếp đón thanh toán: Gọi hàm checkin
        /// </summary>

        // todo: 
        // danh sach phiếu
        [HttpGet("/GetExamOrder/{examId}")]
        public async Task<BaseResponse<PaymentOrderResponse>> GetExamOrder(int? examId)
        {
            if (examId == null)
            {
                return new BaseResponse<PaymentOrderResponse>
                {
                    Message = "Bat buoc nhap",
                    ResponseCode = "01",
                };
            }

            return new BaseResponse<PaymentOrderResponse>
            {
                Message = "",
                ResponseCode = "00",
                Data = await _paymentRepository.GetExamOrder(examId.Value)
            };
        }
        // Số tiền tổng chi phí, đã thu, còn nợ
        [HttpGet("/GetPaymentAmount/{examId}")]
        public async Task<BaseResponse<PaymentAmount>> GetPaymentAmount(int? examId)
        {
            if (examId == null)
            {
                return new BaseResponse<PaymentAmount>
                {
                    Message = "Bat buoc nhap",
                    ResponseCode = "01",
                };
            }

            return new BaseResponse<PaymentAmount>
            {
                Message = "",
                ResponseCode = "00",
                Data = await _paymentRepository.GetPaymentAmount(examId.Value)
            };
        }
        // phieu da thanh toan
        [HttpGet("/GetPaymentInvoice/{checkinId}")]
        public async Task<BaseResponse<PaymentAmount>> GetPaymentInvoice(int? checkinId)
        {
            if (checkinId == null)
            {
                return new BaseResponse<PaymentAmount>
                {
                    Message = "Bat buoc nhap",
                    ResponseCode = "01",
                };
            }

            return new BaseResponse<PaymentAmount>
            {
                Message = "",
                ResponseCode = "00",
              //  Data = await _paymentRepository.GetPaymentInvoice(checkinId.Value)
            };
        }
        // tao phieu
    }
}
