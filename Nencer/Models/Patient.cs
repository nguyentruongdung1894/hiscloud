using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Thông tin bệnh nhân
/// </summary>
public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    /// <summary>
    /// cccd, cmnd, passport
    /// </summary>
    public string? IdCardType { get; set; }

    public string? PatientNumber { get; set; }

    /// <summary>
    /// Số tiền cọc
    /// </summary>
    public decimal? Credit { get; set; }

    public string? Image { get; set; }

    public string? IdCard { get; set; }

    public DateTime? IssueDate { get; set; }

    /// <summary>
    /// adult, child, infant
    /// </summary>
    public string? Type { get; set; }

    public string? Gender { get; set; }

    public string? DayBorn { get; set; }

    public string? MonthBorn { get; set; }

    public string? YearBorn { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Lang { get; set; }

    public int? CityId { get; set; }

    public int? DistrictId { get; set; }

    /// <summary>
    /// Thôn xóm
    /// </summary>
    public uint? WardId { get; set; }

    public string? Address { get; set; }

    public string? CountryCode { get; set; }

    public string? Nationality { get; set; }

    public string? PostCode { get; set; }

    /// <summary>
    /// Dân tộc
    /// </summary>
    public string? Ethnic { get; set; }

    /// <summary>
    /// Đối tượng chi tiết
    /// </summary>
    public string? DetailObject { get; set; }

    public string? JobTitle { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Checkin> Checkins { get; set; } = new List<Checkin>();

    public virtual ICollection<PatientDetail> PatientDetails { get; set; } = new List<PatientDetail>();

    public virtual ICollection<PatientInsuranceCard> PatientInsuranceCards { get; set; } = new List<PatientInsuranceCard>();

    public virtual ICollection<PatientPrehistoric> PatientPrehistorics { get; set; } = new List<PatientPrehistoric>();
}
