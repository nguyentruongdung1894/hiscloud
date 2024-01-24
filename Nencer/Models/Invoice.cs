using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public string? InvoiceCode { get; set; }

    /// <summary>
    /// thanh toán , tạm ứng ....
    /// </summary>
    public string InvoiceType { get; set; } = null!;

    /// <summary>
    /// Mô tả cho thanh toán
    /// </summary>
    public string? Description { get; set; }

    public string? Module { get; set; }

    public int? CheckinId { get; set; }

    public string? PayerName { get; set; }

    public string? PayerPhone { get; set; }

    public string? CurrencyCode { get; set; }

    public double? CurrencyRate { get; set; }

    /// <summary>
    /// Tổng tiền đã gồm tiền hàng, thuế, phí
    /// </summary>
    public double NetAmount { get; set; }

    /// <summary>
    /// Số tiền được giảm
    /// </summary>
    public double? Discount { get; set; }

    public double? Tax { get; set; }

    public double PayAmount { get; set; }

    /// <summary>
    /// Phí của cổng thanh toán
    /// </summary>
    public double? PaymentFees { get; set; }

    /// <summary>
    /// cash
    /// </summary>
    public string? PaymentMethod { get; set; }

    public string? PaygateCode { get; set; }

    /// <summary>
    /// ex: tiền mặt ..
    /// </summary>
    public string? Paygate { get; set; }

    public string? BankInfo { get; set; }

    /// <summary>
    /// trạng thái  thanh toan
    /// </summary>
    public string? Status { get; set; }

    public string? TransferId { get; set; }

    public string? AdminNote { get; set; }

    /// <summary>
    /// Mã đối chiếu, chính là charging ID
    /// </summary>
    public string? Reference { get; set; }

    public int? Approved { get; set; }

    public int? Locked { get; set; }

    /// <summary>
    /// Hoa hồng
    /// </summary>
    public int? AffilateId { get; set; }

    /// <summary>
    /// Kế toán viên
    /// </summary>
    public int? AccountantId { get; set; }

    /// <summary>
    /// Kế toán nào hủy phiếu
    /// </summary>
    public int? AccountantIdCancell { get; set; }

    /// <summary>
    /// Tài khoản nhận
    /// </summary>
    public int? FundId { get; set; }

    public string? CancelledReason { get; set; }

    /// <summary>
    /// hủy từ invoice nào / hủy bởi invoice nào
    /// </summary>
    public long? ReferenceInvoiceId { get; set; }

    /// <summary>
    /// chuỗi json chi tiết thanh toán bị hủy
    /// </summary>
    public string? CancellOrders { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
