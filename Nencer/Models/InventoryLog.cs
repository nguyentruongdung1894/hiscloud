using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Lịch sử xuất nhập kho
/// </summary>
public partial class InventoryLog
{
    public int Id { get; set; }

    /// <summary>
    /// - hoặc +
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// kho chịu tác động
    /// </summary>
    public int StockId { get; set; }

    public int? InventoryId { get; set; }

    public string? PackageCode { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Số lượng mua
    /// </summary>
    public float? Amount { get; set; }

    public float? BeforeAmount { get; set; }

    public float? AfterAmount { get; set; }

    public string Unit { get; set; } = null!;

    /// <summary>
    /// khách hàng
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// người tạo
    /// </summary>
    public int? CreatorId { get; set; }

    /// <summary>
    /// Mã đơn hàng
    /// </summary>
    public string? OrderCode { get; set; }

    public string? Reason { get; set; }

    public string? Description { get; set; }

    public string? Logs { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
