using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Chi tiết thuốc, vật tư chỉ định.
/// </summary>
public partial class PrescriptionOrderItem
{
    public int Id { get; set; }

    public int PrescriptionOrderId { get; set; }

    public int ProductId { get; set; }

    /// <summary>
    /// Số lượng
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    public string? Unit { get; set; }

    /// <summary>
    /// Hướng dẫn sử dụng
    /// </summary>
    public string? UserManual { get; set; }

    /// <summary>
    /// Lời khuyên
    /// </summary>
    public string? Advice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual PrescriptionOrder PrescriptionOrder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
