using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// BHYT ứng với bệnh nhân
/// </summary>
public partial class PatientInsuranceCard
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    /// <summary>
    /// Số FULL
    /// </summary>
    public string? FullNumber { get; set; }

    /// <summary>
    /// Mã đối tượng
    /// </summary>
    public string SubjectCode { get; set; } = null!;

    public string BenifitCode { get; set; } = null!;

    public string CityCode { get; set; } = null!;

    /// <summary>
    /// Nơi sống: K1,K2,K3
    /// </summary>
    public string? Region { get; set; }

    /// <summary>
    /// Địa chỉ thẻ
    /// </summary>
    public string? InsuranceAddress { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    /// <summary>
    /// Quyền lợi hưởng mặc định
    /// </summary>
    public int? BenefitRate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Patient? Patient { get; set; }
}
