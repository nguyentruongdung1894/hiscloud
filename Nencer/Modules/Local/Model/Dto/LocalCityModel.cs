namespace Nencer.Modules.Local.Model.Dto
{
    public class LocalCityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? NameEn { get; set; }
    }
}
