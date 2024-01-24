using Nencer.Shared;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Examination.Model.Dto;

namespace Nencer.Modules.Examination.Repository
{
    public interface IExaminationOrderRepository
    {
        Task<BaseResponse<List<OrderExaminationDto>>> CreatedTicketOrderAsync(OrderCreateDto newModel, string auth_id);
        Task<BaseResponse<List<OrderExaminationDto>>> GetListOrderService(string barcode = "", int ticketId = 0);
        Task<BaseResponse<OrderExaminationDto>> CancelOrderService(long Id);
        Task<BaseResponse<OrderExaminationDto>> UpdateOrderService(long Id, int Qty = 1, string Description = "");
        Task<BaseResponse<OrderExaminationDto>> DeleteOderService(long Id);
        Task<int> GenerateExamOrdinal(int maxNumber, string roomCode);
        Task<int> HavingOrderServicePayment(int examId, string status);
        Task<object> CreateExaminationOrder(CreateOrderExamination rq);
    }
}
