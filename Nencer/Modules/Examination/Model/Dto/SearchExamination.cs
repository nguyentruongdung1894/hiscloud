namespace Nencer.Modules.Examination.Model.Dto
{
    public class SearchExamination
    {
        public string? RoomCode { get; set; }
        public string? PatientNumber { get; set; }
        public string? PatientName { get; set; }
        public string? ServiceObject { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;

    }
}
