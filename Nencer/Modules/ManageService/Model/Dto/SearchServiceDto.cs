using Nencer.Modules.Room.Model;

namespace Nencer.Modules.ManageService.Model.Dto
{
    public class SearchServiceDto
    {
        public string? Keyword { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ServiceGroupId { get; set;}
        public int? Page { get; set; } = 1;
        public int? pageSize { get; set; } = 5;
             

    }
}
