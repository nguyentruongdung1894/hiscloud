using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Phiếu xuất nhập kho
/// </summary>
public partial class ProductStockOrder
{
    public int Id { get; set; }

    /// <summary>
    /// Mã phiếu
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Loại phiếu (import/export/transfer/return)
    /// </summary>
    public int? Type { get; set; }

    /// <summary>
    /// id nha cc
    /// </summary>
    public int? SupplierId { get; set; }

    public int? BidId { get; set; }

    /// <summary>
    /// so qd trung thau
    /// </summary>
    public string? BidNumber { get; set; }

    /// <summary>
    /// nhom thau
    /// </summary>
    public string? BidGroup { get; set; }

    /// <summary>
    /// goi thau
    /// </summary>
    public string? BidPackage { get; set; }

    /// <summary>
    /// ngay trung thau
    /// </summary>
    public DateOnly? BidDate { get; set; }

    /// <summary>
    /// nam thau
    /// </summary>
    public string? BidYear { get; set; }

    /// <summary>
    /// id kho lấy hàng
    /// </summary>
    public int? StockId { get; set; }

    /// <summary>
    /// id kho nhận hàng
    /// </summary>
    public int? TargetStockId { get; set; }

    public int? DepartmentId { get; set; }

    /// <summary>
    /// id khoa/ phong
    /// </summary>
    public int? RoomId { get; set; }

    /// <summary>
    /// id benh nhan
    /// </summary>
    public int? CustomerId { get; set; }

    /// <summary>
    /// Tách nhóm
    /// </summary>
    public string? Group { get; set; }

    public string? Barcode { get; set; }

    public string? PackageCode { get; set; }

    public string? BatchCode { get; set; }

    /// <summary>
    /// Đối tượng thanh toán
    /// </summary>
    public string? CustomerType { get; set; }

    /// <summary>
    /// Giá dịch vụ
    /// </summary>
    public decimal? Price { get; set; }

    public decimal? TaxAmount { get; set; }

    /// <summary>
    /// %
    /// </summary>
    public decimal? TaxRate { get; set; }

    /// <summary>
    /// Số còn lại phải thanh toán
    /// </summary>
    public decimal? PayAmount { get; set; }

    public string? CurrencyCode { get; set; }

    public int? ApproveId { get; set; }

    /// <summary>
    /// thời gian duyệt
    /// </summary>
    public DateOnly? ApproveDate { get; set; }

    /// <summary>
    /// thơi gian xuat kho
    /// </summary>
    public DateOnly? ExportDate { get; set; }

    /// <summary>
    /// thoi gian nhap kho
    /// </summary>
    public DateOnly? ImportDate { get; set; }

    /// <summary>
    /// ghi chu
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// ly do
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// trang thai ban ghi
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// nguoi tao
    /// </summary>
    public int? CreatorId { get; set; }

    /// <summary>
    /// nguoi cap nhat
    /// </summary>
    public string? UpdaterId { get; set; }

    /// <summary>
    /// Yêu cầu phải thanh toán
    /// </summary>
    public int? RequirePayment { get; set; }

    /// <summary>
    /// Người nhận
    /// </summary>
    public string? Receiver { get; set; }

    /// <summary>
    /// Người giao
    /// </summary>
    public string? Deliver { get; set; }

    /// <summary>
    /// Ngày hóa đơn
    /// </summary>
    public DateOnly? OrderDate { get; set; }

    /// <summary>
    /// Tk nhận tiền
    /// </summary>
    public int? PaygateId { get; set; }

    /// <summary>
    /// thoi gian tao ban ghi
    /// </summary>
    public DateOnly? CreatedAt { get; set; }

    /// <summary>
    /// thoi tian cap nhat ban ghi
    /// </summary>
    public DateOnly? UpdatedAt { get; set; }

    public virtual ICollection<ProductStockOrderItem> ProductStockOrderItems { get; set; } = new List<ProductStockOrderItem>();
}
