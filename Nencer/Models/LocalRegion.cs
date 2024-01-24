using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Vùng/Miền
/// </summary>
public partial class LocalRegion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string? CodeName { get; set; }

    public string? CodeNameEn { get; set; }

    public int? Sort { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
