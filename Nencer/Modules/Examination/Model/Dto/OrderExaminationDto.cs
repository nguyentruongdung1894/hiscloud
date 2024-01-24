namespace Nencer.Modules.Examination.Model.Dto
{
    public class OrderExaminationDto
    {
        public long Id { get; set; }
        public int? PatientId { get; set; }
        public int? ServiceId { get; set; }
        public string? ServiceCode { get; set; }
        public string? ServiceName { get; set; }
        public int? Qty { get; set; }
        public double? Price { get; set; }
        public double? TotalAmount { get; set; }
        public long? TicketId { get; set; }
        public int? ServiceGroupId { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
