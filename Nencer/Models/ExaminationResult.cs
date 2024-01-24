using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Xử trí khám bệnh
/// </summary>
public partial class ExaminationResult
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public long ExaminationId { get; set; }

    /// <summary>
    /// Cấp cứu?
    /// </summary>
    public int? Emergency { get; set; }

    /// <summary>
    /// Lý do khám
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Dị ứng
    /// </summary>
    public int? Allergy { get; set; }

    /// <summary>
    /// Dị ứng note
    /// </summary>
    public string? AllergyNote { get; set; }

    /// <summary>
    /// Triệu chứng
    /// </summary>
    public string? Symptom { get; set; }

    /// <summary>
    /// Quá trình bệnh lý
    /// </summary>
    public string? PathologicalProcess { get; set; }

    /// <summary>
    /// Tiền sử bản thân
    /// </summary>
    public string? SelfMedicalHistory { get; set; }

    /// <summary>
    /// Tiền sử gia đình
    /// </summary>
    public string? FamilyMedicalHistory { get; set; }

    /// <summary>
    /// Khám bệnh
    /// </summary>
    public string? ExamNote { get; set; }

    /// <summary>
    /// Khám bộ phận
    /// </summary>
    public string? ExamPart { get; set; }

    /// <summary>
    /// Ly do sua
    /// </summary>
    public string? ReasonEdit { get; set; }

    /// <summary>
    /// Hướng xử lý
    /// </summary>
    public string? ResolveMethod { get; set; }

    /// <summary>
    /// Mạch
    /// </summary>
    public string? Pulse { get; set; }

    /// <summary>
    /// Nhịp thở
    /// </summary>
    public string? Respiration { get; set; }

    /// <summary>
    /// Nhiệt độ
    /// </summary>
    public string? Temperature { get; set; }

    /// <summary>
    /// Huyết áp
    /// </summary>
    public string? PressureMin { get; set; }

    public string? PressureMax { get; set; }

    /// <summary>
    /// Chiều cao
    /// </summary>
    public string? Height { get; set; }

    /// <summary>
    /// Cân nặng
    /// </summary>
    public string? Weight { get; set; }

    /// <summary>
    /// SpO2
    /// </summary>
    public string? SpO2 { get; set; }

    /// <summary>
    /// Tỉ lệ cân nặng/chiều cao
    /// </summary>
    public string? Bmi { get; set; }

    /// <summary>
    /// Kết luận tóm tắt
    /// </summary>
    public string? InitiallyResult { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Examination Examination { get; set; } = null!;
}
