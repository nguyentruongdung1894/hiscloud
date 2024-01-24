namespace Nencer.Modules.Examination.Model
{
    public class ListExaminationModel
    {
        public long? Id { get; set; }
        public string NameAge { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public string PatientNumber { get; set; }
        public int Priority { get; set; }
        public int TotalCount { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
