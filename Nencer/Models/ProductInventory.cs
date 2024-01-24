using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class ProductInventory
{
    public int Id { get; set; }

    /// <summary>
    /// Kho
    /// </summary>
    public int? StockId { get; set; }

    /// <summary>
    /// san pham
    /// </summary>
    public int? ProductId { get; set; }

    public string? Barcode { get; set; }

    /// <summary>
    /// Mã lô
    /// </summary>
    public string? PackageCode { get; set; }

    public int? SupplierId { get; set; }

    public int? BidId { get; set; }

    public uint? Qty { get; set; }

    public uint? LockedQty { get; set; }

    /// <summary>
    /// Mã chứng nhận
    /// </summary>
    public string? CertificateCode { get; set; }

    public DateTime? ProductionDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// Vùng/ chỗ để
    /// </summary>
    public string? Position { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public string? CreatorId { get; set; }

    public string? UpdaterId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ProductStock? Stock { get; set; }
}
