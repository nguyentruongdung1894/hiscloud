using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Loại bệnh nhân (Nhân dân, Bộ đội, .....)
/// </summary>
public partial class PatientType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string Code { get; set; } = null!;

    public int? Sort { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
