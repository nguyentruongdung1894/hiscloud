using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// đón tiếp
/// </summary>
public partial class Checkin
{
    public long Id { get; set; }

    public int PatientId { get; set; }

    /// <summary>
    /// mã bệnh nhân
    /// </summary>
    public string? PatientNumber { get; set; }

    /// <summary>
    /// Đối tượng khách hàng : fee , bhyt..
    /// </summary>
    public int? PatientType { get; set; }

    /// <summary>
    /// Loại khám : cấp cứu hay khám bệnh
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// stt tiep don
    /// </summary>
    public int? CheckinNumber { get; set; }

    public int? Priority { get; set; }

    /// <summary>
    /// Phong
    /// </summary>
    public int? RoomId { get; set; }

    /// <summary>
    /// khoa
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// Bac si phu trach
    /// </summary>
    public int? DoctorId { get; set; }

    /// <summary>
    /// BS dieu trị
    /// </summary>
    public string? DoctorName { get; set; }

    /// <summary>
    /// Lý do khám
    /// </summary>
    public string? Reason { get; set; }

    public string? Status { get; set; }

    public int? ChamberId { get; set; }

    public int? BedId { get; set; }

    /// <summary>
    /// Dịch vụ ban đầu 
    /// </summary>
    public int? ServiceId { get; set; }

    /// <summary>
    /// Giờ checkin
    /// </summary>
    public DateTime? CheckinTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Examination2023> Examination2023s { get; set; } = new List<Examination2023>();

    public virtual ICollection<Examination> Examinations { get; set; } = new List<Examination>();

    public virtual Patient Patient { get; set; } = null!;
}
