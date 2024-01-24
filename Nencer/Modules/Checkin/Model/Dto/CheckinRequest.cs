using System.ComponentModel.DataAnnotations;

namespace Nencer.Modules.Checkin.Model.Dto
{

    public class CheckinRequest
    {
        [Required]
        public Checkin Checkin { get; set; }
        [Required]
        public Patient.Model.Patient Patient { get; set; }
        [Required]
        public PatientDetail PatientDetail { get; set; } // Chi tiết bệnh nhân
        public PatientInsuranceCard? PatientInsuranceCard { get; set; } // BHYT ứng với bệnh nhân
        public List<PatientPrehistoric>? PatientPrehistoric { get; set; } //Tiền sử bệnh
        public List<PatientRelation>? PatientRelation { get; set; } //Gia đình bệnh nhân
    }
}
