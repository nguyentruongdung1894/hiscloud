using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Quận/Huyện
/// </summary>
public partial class LocalDistrict
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string? FullName { get; set; }

    public string? FullNameEn { get; set; }

    public string? CodeName { get; set; }

    public string? ProvinceCode { get; set; }

    public int? AdministrativeUnitId { get; set; }

    public int? Sort { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
