using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Quản lý trần đơn thuốc
/// </summary>
public partial class PrescriptionCeiling
{
    public int Id { get; set; }

    /// <summary>
    /// ICD10
    /// </summary>
    public string? DiagnosticCode { get; set; }

    /// <summary>
    /// Trần BHYT(Nếu nhập trần BHYT và trần tổng chi &lt;= 100 hiểu là %, &gt; 100 hiểu là số tiền)
    /// </summary>
    public string? HealthInsuranceCeiling { get; set; }

    /// <summary>
    /// Trần tổng chi(Nếu nhập trần BHYT và trần tổng chi &lt;= 100 hiểu là %, &gt; 100 hiểu là số tiền)
    /// </summary>
    public string? CeilingTotalExpenditure { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
