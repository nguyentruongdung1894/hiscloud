using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Local.Model;

/// <summary>
/// Thành phố
/// </summary>
[Table("local_cities")]
public partial class LocalCity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("name_en")] public string? NameEn { get; set; }

    public string Code { get; set; } = null!;

    [Column("country_code")] public string CountryCode { get; set; } = null!;

    public string? Region { get; set; }

    public string? Type { get; set; }

    public int Featured { get; set; }

    public int? Sort { get; set; }

    public int Status { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; } 
}
