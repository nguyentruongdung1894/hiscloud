using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Local.Model;

[Table("local_admin_units")]
public partial class LocalAdminUnit
{
    public int Id { get; set; }

    [Column("full_name")] public string FullName { get; set; } = null!;

    [Column("full_name_en")] public string? FullNameEn { get; set; }

    [Column("short_name")] public string? ShortName { get; set; }

    [Column("short_name_en")] public string? ShortNameEn { get; set; }

    [Column("code_name")] public string? CodeName { get; set; }

    [Column("code_name_en")] public string? CodeNameEn { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
