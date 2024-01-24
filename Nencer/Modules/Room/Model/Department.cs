using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Room.Model;
[Table("departments")]
public partial class Department
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Column("name_eng")] public string? NameEng { get; set; }
    [Column("name_byt")] public string? NameByt { get; set; }
    [Required] public string Code { get; set; }
    public string? Description { get; set; }
    public string? Manager { get; set; }
    public string? Image { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public int? Sort { get; set; }
    public int? Status { get; set; }
    [Column("created_at")] public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")] public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}
