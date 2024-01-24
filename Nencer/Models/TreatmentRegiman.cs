using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Phác đồ điều trị
/// </summary>
public partial class TreatmentRegiman
{
    public int Id { get; set; }

    /// <summary>
    /// Tên phác đồ
    /// </summary>
    public string? RegimenName { get; set; }

    /// <summary>
    /// Chọn ICD10
    /// 
    /// </summary>
    public string? DiagnosticCode { get; set; }

    /// <summary>
    /// Dịch vụ kỹ thuật
    /// </summary>
    public string? ServiceId { get; set; }

    /// <summary>
    /// Hoạt chất
    /// </summary>
    public string? DrugIngredient { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
