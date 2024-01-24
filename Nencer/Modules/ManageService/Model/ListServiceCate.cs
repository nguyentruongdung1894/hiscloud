namespace Nencer.Modules.ManageService.Model
{
    public class ListServiceCate
    {
        public int? Total { get; set; } = 0;
        public List<ServiceGroupItem> ServiceGroups { get; set; }
    }
    public class ServiceGroupItem
    {
        public int? Total { get; set; } = 0;
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get;set; }
        public List<ServiceGroupItem> ServiceTypeItems { get; set; }

    }
}
