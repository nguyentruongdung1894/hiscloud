using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Xử trí khám bệnh
/// </summary>
public partial class ExaminationAction
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public long ExaminationId { get; set; }

    /// <summary>
    /// Chuẩn đoán xác định
    /// </summary>
    public string? ExaminationDetermination { get; set; }

    /// <summary>
    /// Loi dan bac sy
    /// </summary>
    public string? Advice { get; set; }

    /// <summary>
    /// Cap toa cho ve
    /// </summary>
    public string? DeliveryOfPrescription { get; set; }

    /// <summary>
    /// chuyen phong kham
    /// </summary>
    public string? SwitchClinic { get; set; }

    /// <summary>
    /// Nhap vien
    /// </summary>
    public string? Hospitalization { get; set; }

    /// <summary>
    /// Bo kham
    /// </summary>
    public string? Uncheck { get; set; }

    /// <summary>
    /// het dot dieu tri
    /// </summary>
    public string? OfflineTreatmentEnds { get; set; }

    /// <summary>
    /// Chuyen tuyen
    /// </summary>
    public string? Transition { get; set; }

    /// <summary>
    /// Tu vong
    /// </summary>
    public string? Death { get; set; }

    /// <summary>
    /// Điều trị ngoại trú
    /// </summary>
    public string? OutpatientTreatment { get; set; }

    /// <summary>
    /// Ly do sua
    /// </summary>
    public string? ReasonEdit { get; set; }

    /// <summary>
    /// Ket qua dieu tri
    /// </summary>
    public string? ExamResult { get; set; }

    /// <summary>
    /// Hinh thuc xt
    /// </summary>
    public string? TreatmentMethod { get; set; }

    /// <summary>
    /// Thời gian xử trí
    /// </summary>
    public DateTime? ActionAt { get; set; }

    public int? CreatorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Examination Examination { get; set; } = null!;
}
