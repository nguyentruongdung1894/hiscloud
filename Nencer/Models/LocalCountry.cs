using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Quốc tịch
/// </summary>
public partial class LocalCountry
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string Code { get; set; } = null!;

    public string? DialCode { get; set; }

    public string? Lang { get; set; }

    public int Featured { get; set; }

    public int? Sort { get; set; }

    public int Status { get; set; }

    public string? Area { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<LocalCity> LocalCities { get; set; } = new List<LocalCity>();
}
