using ServiceModel = Nencer.Modules.ManageService.Service;
namespace Nencer.Modules.Examination.Model.Dto
{
    public class CreateOrderExamination
    {
        public ExaminationTicket examinationTicket { get; set; }
        public ServiceModel service { get; set; }
        public int? InvoiceId { get; set; } = null;
        public int? Qty { get; set; } = 1;
        public string? ServiceObject { get; set; }
        public string? PaymentStatus { get; set; } = "UNPAID";
        public string? Status { get; set; } = "PENDING";
        public string? Description { get; set; }
        public int? RoomSampleId { get; set; }
        public int? RoomId { get; set; }
        public int? RoomHandleId { get; set; }
        public int? ParentId { get; set; } = 0;
    }
}
