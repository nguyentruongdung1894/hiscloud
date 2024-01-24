using PatientModel = Nencer.Modules.Patient.Model.Patient;
namespace Nencer.Modules.Examination.Model.Dto
{
    public class ExaminationView
    {
        public Examination examination { get; set; }
        public PatientModel patient { get; set; }
        public List<Examination> history { get; set; }
        public ExaminationResult result { get; set; }
    }
}
