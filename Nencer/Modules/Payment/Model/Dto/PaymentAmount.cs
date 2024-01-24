namespace Nencer.Modules.Payment.Model.Dto
{
    public class PaymentAmount
    {
        public int ExaminationId { get; set;}
        public double TotalAmount { get; set; } // tong so tien
        public double TotalAmountPaid { get; set; } // tong tien da tra
        public double TotalAmountOwed { get; set; } // Tong tien con no
        public double TotalBHYTPaidAmount { get; set; } // Tong tien bhyt tra
    }
}
