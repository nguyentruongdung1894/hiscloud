namespace Nencer.Modules.Room.Model.Dto
{
    public class RoomFormDto
    {
        public string Name { get; set; }
        public string? NameArray { get; set; }
        public string? Code { get; set; }
        public int? RoomType { get; set; }
        public int? DepartmentId { get; set; }
        public int? Status { get; set; }
        public int? Sort { get; set; }
        public int? HospitalId { get; set; }
        public int? LocationId { get; set; }
        public int? AcceptInsurance { get; set; }
        public int? Polyclinic { get; set; }
        public int? BigClinic { get; set; }
    }
}
