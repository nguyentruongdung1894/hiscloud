using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Gia đình bệnh nhân
/// </summary>
public partial class PatientRelation
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    /// <summary>
    /// là bố, mẹ, giám hộ, ...
    /// </summary>
    public string? RelationType { get; set; }

    public string? FaName { get; set; }

    public string? FaIdCard { get; set; }

    public string? FaAddress { get; set; }

    public string? FaPhone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
