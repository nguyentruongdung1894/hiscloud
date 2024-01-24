using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Local.Model;

/// <summary>
/// Quốc tịch
/// </summary>
[Table("local_countries")]
public partial class LocalCountry
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("name_en")] public string? NameEn { get; set; }

    public string Code { get; set; } = null!;

    [Column("dial_code")] public string? DialCode { get; set; }

    public string? Lang { get; set; }

    public int Featured { get; set; }

    public int? Sort { get; set; }

    public int Status { get; set; }

    public string? Area { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; } 
}
