using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// khám bệnh
/// </summary>
public partial class Examination
{
    /// <summary>
    /// --medicalrecordID ( benh an id, ban ghi lai lich su dieu tri )
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// mã đón tiếp
    /// </summary>
    public long CheckinId { get; set; }

    public int PatientId { get; set; }

    public int? PatientRelationId { get; set; }

    /// <summary>
    /// Đối tượng khách hàng : fee , bhyt..
    /// </summary>
    public int? PatientType { get; set; }

    /// <summary>
    /// Loại khám
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// id exam ngay trước nó
    /// </summary>
    public int? ExamIdBefore { get; set; }

    /// <summary>
    /// stt khám
    /// </summary>
    public int? ExaminationNumber { get; set; }

    /// <summary>
    /// Ngày khám
    /// </summary>
    public DateTime? ExaminationDate { get; set; }

    /// <summary>
    /// Giờ bắt đầu khám
    /// </summary>
    public DateTime? ExaminationStartAt { get; set; }

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
    /// Giờ checkin
    /// </summary>
    public DateTime? CheckinTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Checkin Checkin { get; set; } = null!;

    public virtual ICollection<ExaminationAction> ExaminationActions { get; set; } = new List<ExaminationAction>();

    public virtual ICollection<ExaminationOrder> ExaminationOrders { get; set; } = new List<ExaminationOrder>();

    public virtual ICollection<ExaminationResult> ExaminationResults { get; set; } = new List<ExaminationResult>();

    public virtual ICollection<PrescriptionOrder> PrescriptionOrders { get; set; } = new List<PrescriptionOrder>();
}
