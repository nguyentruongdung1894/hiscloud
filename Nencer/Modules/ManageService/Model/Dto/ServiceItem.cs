using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.ManageService.Model.Dto;
[Table("services_items")]
public partial class ServiceItem
{
    public int Id { get; set; }
    [Column("service_id")] public int ServiceId { get; set; }
    [Column("item_id")] public int ItemId { get; set; }

}
