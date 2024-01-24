using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Phiếu xuất nhập kho
/// </summary>
public partial class ProductStockOrderItem
{
    public int Id { get; set; }

    /// <summary>
    /// Order cha
    /// </summary>
    public int StockOrderId { get; set; }

    public int? ProductId { get; set; }

    public string? Barcode { get; set; }

    public string? BatchCode { get; set; }

    public int? Qty { get; set; }

    /// <summary>
    /// Số lượng duyệt
    /// </summary>
    public int? ApproveQty { get; set; }

    /// <summary>
    /// Giá dịch vụ
    /// </summary>
    public decimal? Price { get; set; }

    public string Unit { get; set; } = null!;

    public decimal? TaxAmount { get; set; }

    /// <summary>
    /// %
    /// </summary>
    public decimal? TaxRate { get; set; }

    public string? CurrencyCode { get; set; }

    public int? ApproveId { get; set; }

    /// <summary>
    /// thời gian duyệt
    /// </summary>
    public DateOnly? ApproveDate { get; set; }

    /// <summary>
    /// nguoi tao
    /// </summary>
    public int? CreatorId { get; set; }

    public DateTime? ProductionDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// thoi gian tao ban ghi
    /// </summary>
    public DateOnly? CreatedAt { get; set; }

    /// <summary>
    /// thoi tian cap nhat ban ghi
    /// </summary>
    public DateOnly? UpdatedAt { get; set; }

    public virtual ProductStockOrder StockOrder { get; set; } = null!;
}
