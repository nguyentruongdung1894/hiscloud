using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// ICD10(Chuẩn đoán)
/// </summary>
public partial class CatalogDiagnostic
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// Tên thường gọi
    /// </summary>
    public string? NameEn { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ExaminationDiagnostic> ExaminationDiagnostics { get; set; } = new List<ExaminationDiagnostic>();

    public virtual ICollection<PrescriptionOrder> PrescriptionOrderAccomDiagnostics { get; set; } = new List<PrescriptionOrder>();

    public virtual ICollection<PrescriptionOrder> PrescriptionOrderPriDiagnostics { get; set; } = new List<PrescriptionOrder>();
}
