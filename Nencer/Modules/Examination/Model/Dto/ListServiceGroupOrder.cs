namespace Nencer.Modules.Examination.Model.Dto
{
    public class ListServiceGroupOrder
    {
        public string? Name { get;set; }
        public int? Code { get; set; }
        public string? CodeName { get; set; }
        public List<ExaminationOrderByTicket> Tickets { get; set; }

    }
   public class ExaminationOrderByTicket()
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Barcode { get; set; }
        public string? Doctor { get; set; }
        public string? Roomcode { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? OrderAt { get; set; }
        public List<ExaminationOrder> Orders { get; set; }   

    }
}
