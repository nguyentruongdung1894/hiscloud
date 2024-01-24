using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Local.Model;

/// <summary>
/// Phường/Xã
/// </summary>
[Table("local_wards")]
public partial class LocalWard
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    [Column("name_en")] public string? NameEn { get; set; }

    [Column("full_name")] public string? FullName { get; set; }

    [Column("full_name_en")] public string? FullNameEn { get; set; }

    [Column("code_name")] public string? CodeName { get; set; }

    [Column("district_code")] public string? DistrictCode { get; set; }

    [Column("city_code")] public string? CityCode { get; set; }

    /// <summary>
    /// go tat
    /// </summary>
    [Column("short_code")] public string? ShortCode { get; set; }

    [Column("administrative_unit_id")] public int? AdministrativeUnitId { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
