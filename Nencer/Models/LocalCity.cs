using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Thành phố
/// </summary>
public partial class LocalCity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string Code { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string? Region { get; set; }

    public string? Type { get; set; }

    public int Featured { get; set; }

    public int? Sort { get; set; }

    public int Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual LocalCountry CountryCodeNavigation { get; set; } = null!;
}
