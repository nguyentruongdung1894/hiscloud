using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Phường/Xã
/// </summary>
public partial class LocalWard
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public string? NameEn { get; set; }

    public string? FullName { get; set; }

    public string? FullNameEn { get; set; }

    public string? CodeName { get; set; }

    public string? DistrictCode { get; set; }

    public string? CityCode { get; set; }

    /// <summary>
    /// go tat
    /// </summary>
    public string? ShortCode { get; set; }

    public int? AdministrativeUnitId { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
