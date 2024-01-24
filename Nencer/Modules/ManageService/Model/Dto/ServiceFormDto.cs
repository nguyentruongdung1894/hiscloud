namespace Nencer.Modules.ManageService.Model.Dto
{
    public class ServiceFormDto
    {
        public string? Name { get; set; }
        public string? NameIns { get; set; }
        public int? IsPack { get; set; }
        public string? Code { get; set; }
        public string? CodeIns { get; set; }
        public string? Description { get; set; }
        public int? UnitId { get; set; }
        public string? Unit { get; set; }
        public int? ServiceGroupId { get; set; }
        public int? ServiceTypeId { get; set; }
        public double? PriceNormal { get; set; }
        public double? PriceIns { get; set; }
        public double? PriceService { get; set; }
        public string? RoomHandleId { get; set; }
        public string? RoomId { get; set; }
        public string? RoomSampleId { get; set; }
        public string? OriginalResult { get; set; }
        public int? Status { get; set; }
        public int? Sort { get; set; }
        public string? EquivalentCode { get; set; }
        public string? SpecialtyCode { get; set; }
        public int? ReassignmentTime { get; set; }
        public int? RightRate { get; set; }
        public int? OfflineRate { get; set; }
        public int[]? Item { get; set; }

    }
}
