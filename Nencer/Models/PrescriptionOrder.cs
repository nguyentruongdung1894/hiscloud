using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Chỉ định thuốc, vật tư
/// </summary>
public partial class PrescriptionOrder
{
    public int Id { get; set; }

    public long ExaminationId { get; set; }

    public long TicketId { get; set; }

    public string? Code { get; set; }

    public int? StockId { get; set; }

    /// <summary>
    /// Chuẩn đoán
    /// </summary>
    public int? PriDiagnosticId { get; set; }

    /// <summary>
    /// Chuẩn đoán kèm theo
    /// </summary>
    public int? AccomDiagnosticId { get; set; }

    /// <summary>
    /// Ngày y lệnh
    /// </summary>
    public DateTime? OrderDate { get; set; }

    public string? Barcode { get; set; }

    public string? Status { get; set; }

    /// <summary>
    /// Người chỉ định
    /// </summary>
    public int? AppointmentUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CatalogDiagnostic? AccomDiagnostic { get; set; }

    public virtual Examination Examination { get; set; } = null!;

    public virtual ICollection<PrescriptionOrderItem> PrescriptionOrderItems { get; set; } = new List<PrescriptionOrderItem>();

    public virtual CatalogDiagnostic? PriDiagnostic { get; set; }

    public virtual ProductStock? Stock { get; set; }
}
