using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Chi tiết bệnh nhân
/// </summary>
public partial class PatientDetail
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string? Address { get; set; }

    /// <summary>
    /// địa chỉ nơi làm việc
    /// </summary>
    public string? AddressWorkplace { get; set; }

    public int? Married { get; set; }

    public int? Children { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    /// <summary>
    /// Nghề nghiệp
    /// </summary>
    public string? JobTitle { get; set; }

    public string? Company { get; set; }

    /// <summary>
    /// Học vấn
    /// </summary>
    public string? Education { get; set; }

    /// <summary>
    /// Tiền sử bệnh, Array
    /// </summary>
    public string? Prehistoric { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
