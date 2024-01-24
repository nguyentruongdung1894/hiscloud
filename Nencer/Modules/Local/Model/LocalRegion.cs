using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Local.Model;

/// <summary>
/// Vùng/Miền
/// </summary>
[Table("local_regions")]
public partial class LocalRegion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("name_en")] public string? NameEn { get; set; }

    [Column("code_name")] public string? CodeName { get; set; }

    [Column("code_name_en")] public string? CodeNameEn { get; set; }

    public int? Sort { get; set; }

    public int? Status { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
