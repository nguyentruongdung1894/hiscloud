using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Examination.Model.Dto;
using Nencer.Modules.Examination.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Examination.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExaminationController : BaseController
    {
        private readonly IExaminationOrderRepository _examinationOrderRepository;
        private readonly IExaminationRepository _examinationRepository;
        private readonly IExaminationTicketRepository _examinationTicketRepository;
        private readonly IDiagnosticRepository _diagnosticRepository;

        public ExaminationController(IExaminationOrderRepository examinationOrderRepository, IExaminationRepository examinationRepository, IDiagnosticRepository diagnosticRepository, IExaminationTicketRepository examinationTicketRepository)
        {
            _examinationOrderRepository = examinationOrderRepository;
            _examinationRepository = examinationRepository;
            _diagnosticRepository = diagnosticRepository;
            _examinationTicketRepository = examinationTicketRepository;
        }
        [HttpPost("Created/ExaminationOrder")]

        public async Task<BaseResponse<List<OrderExaminationDto>>> CreatedTicketOrderAsync(OrderCreateDto orderCreateDto)
        {
            var auth = User.Claims.FirstOrDefault(s => s.Type == "UserName")?.Value;
            return await _examinationOrderRepository.CreatedTicketOrderAsync(orderCreateDto, auth);
        }
        [HttpGet("Get/ExaminationOrder")]
        public async Task<BaseResponse<List<OrderExaminationDto>>> GetListOrderService(string? barcode, int? ticketId = 0)
        {
            return await _examinationOrderRepository.GetListOrderService(barcode, ticketId.GetValueOrDefault());
        }
        [HttpPost("ExaminationOrder/Cancel")]
        public async Task<BaseResponse<OrderExaminationDto>> CancelOrderService(long Id)
        {
            return await _examinationOrderRepository.CancelOrderService(Id);
        }
        [HttpPost("ExaminationOrder/Update")]
        public async Task<BaseResponse<OrderExaminationDto>> UpdateOrderService(long Id, int? Qty = 1, string? Description = "")
        {
            return await _examinationOrderRepository.UpdateOrderService(Id, (int)Qty, Description);
        }
        [HttpGet("ExaminationOrder/Delete/{id}")]
        public async Task<BaseResponse<OrderExaminationDto>> DeleteOderService(long Id)
        {
            return await _examinationOrderRepository.DeleteOderService(Id);
        }

        [HttpPost("GetList")]
        public async Task<List<ListExaminationModel>> GetListExamination(SearchExamination request)
        {
            return await _examinationRepository.GetListExamination(request);
        }

        [HttpPost("SearchDiagnostic")]
        public async Task<BaseResponse<List<CatelogDiagnostic>>> SearchDiagnostic(string Code)
        {
            return new BaseResponse<List<CatelogDiagnostic>>
            {
                ResponseCode = "200",
                Data = await _diagnosticRepository.SearchDiagnostic(Code)
            };
        }
        [HttpDelete("DeleteTicketById/{id}")]
        public async Task<BaseResponse<ExaminationTicket>> DeleteTicketById(int id)
        {
            return await _examinationTicketRepository.DeleteTicketById(id);
        }
        [HttpPost("SaveExamninationService")]
        public async Task<BaseResponse<ExaminationTicket>> SaveExamninationService(AddServiceDto rq)
        {
            return await _examinationRepository.SaveExamninationService(rq);
        }
        [HttpGet("GetServiceGroupOrderByExam/{id}")]
        public async Task<BaseResponse<List<ListServiceGroupOrder>>> GetServiceGroupOrderByExam(int id)
        {
            return new BaseResponse<List<ListServiceGroupOrder>>
            {
                ResponseCode = "200",
                Data = await _examinationRepository.GetServiceGroupOrderByExam(id)
            };
        }
    }
}
