using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Backend.Model.Setting;

public partial class Setting
{
    public int Id { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }
    [Column("value_arr")]
    public string? ValueArr { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public int? Status { get; set; }
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}