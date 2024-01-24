using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Quản lý kho hàng hóa
/// </summary>
public partial class Inventory
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int ProductId { get; set; }

    public int? TakePrice { get; set; }

    public string? Sku { get; set; }

    public string? Barcode { get; set; }

    /// <summary>
    /// Mã lô hoặc serial
    /// </summary>
    public string PackageCode { get; set; } = null!;

    public sbyte StockId { get; set; }

    public uint Status { get; set; }

    /// <summary>
    /// Số hàng tồn
    /// </summary>
    public uint Quantity { get; set; }

    /// <summary>
    /// số hàng đang tạm giữ
    /// </summary>
    public uint Locked { get; set; }

    /// <summary>
    /// Đơn vị tính
    /// </summary>
    public string Unit { get; set; } = null!;

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Area { get; set; }

    public DateOnly? ProductionDate { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
