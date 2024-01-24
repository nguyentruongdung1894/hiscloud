namespace Nencer.Modules.ManageService.Model
{
    using RoomModel = Nencer.Modules.Room.Model.Room;
    public class SearchServiceModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? NameIns { get; set; }
        public string? Code { get; set; }
        public double? PriceIns { get; set; }
        public double? PriceNormal { get; set; }
        public double? PriceService { get; set; }
        public string? GroupName { get; set; }
        public List<RoomModel>? RoomHandle { get; set; }
        public List<RoomModel>? RoomSample { get; set; }
    }
}
