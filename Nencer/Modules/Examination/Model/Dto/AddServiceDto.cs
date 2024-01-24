namespace Nencer.Modules.Examination.Model.Dto
{
    public class AddServiceDto
    {
        public int ExaminationId { get; set; }
        public DateTime OrderAt { get; set; }
        public string? Description { get; set; }
        public int? Emergency { get; set; }
        public List<AddServiceItem>? services { get;set; }


    }
    public class AddServiceItem
    {
        public string Code { get; set; }
        public int Qty { get; set; }
        public string ObjectService { get; set; }
        public int? RoomSample { get; set; }
        public int? RoomHandle { get; set; }
    }
}
