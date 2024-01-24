using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Invoice.Model;

[Table("invoices")]
public partial class Invoice
{
    public int Id { get; set; }

    [Column("invoice_code")] public string? InvoiceCode { get; set; }

    /// <summary>
    /// thanh toán , tạm ứng ....
    /// </summary>
    [Column("invoice_type")] public string InvoiceType { get; set; } = null!;

    /// <summary>
    /// Mô tả cho thanh toán
    /// </summary>
    public string? Description { get; set; }

    public string? Module { get; set; }

    [Column("checkin_id")] public int? CheckinId { get; set; }

    [Column("payer_name")] public string? PayerName { get; set; }

    [Column("payer_phone")] public string? PayerPhone { get; set; }

    [Column("currency_code")] public string? CurrencyCode { get; set; }

    [Column("currency_rate")] public double? CurrencyRate { get; set; }

    /// <summary>
    /// Tổng tiền đã gồm tiền hàng, thuế, phí
    /// </summary>
    [Column("net_amount")] public double NetAmount { get; set; }

    /// <summary>
    /// Số tiền được giảm
    /// </summary>
    public double? Discount { get; set; }

    public double? Tax { get; set; }

    [Column("pay_amount")] public double PayAmount { get; set; }

    /// <summary>
    /// Phí của cổng thanh toán
    /// </summary>
    [Column("payment_fees")] public double? PaymentFees { get; set; }

    /// <summary>
    /// cash
    /// </summary>
    [Column("payment_method")] public string? PaymentMethod { get; set; }

    [Column("paygate_code")] public string? PaygateCode { get; set; }

    /// <summary>
    /// ex: tiền mặt ..
    /// </summary>
    public string? Paygate { get; set; }

    [Column("bank_info")] public string? BankInfo { get; set; }

    /// <summary>
    /// trạng thái  thanh toan
    /// </summary>
    public string? Status { get; set; }

    [Column("transfer_id")] public string? TransferId { get; set; }

    [Column("admin_note")] public string? AdminNote { get; set; }

    /// <summary>
    /// Mã đối chiếu, chính là charging ID
    /// </summary>
    public string? Reference { get; set; }

    public int? Approved { get; set; }

    public int? Locked { get; set; }

    /// <summary>
    /// Hoa hồng
    /// </summary>
    [Column("affilate_id")] public int? AffilateId { get; set; }

    /// <summary>
    /// Kế toán viên
    /// </summary>
    [Column("accountant_id")] public int? AccountantId { get; set; }

    /// <summary>
    /// Kế toán nào hủy phiếu
    /// </summary>
    [Column("accountant_id_cancell")] public int? AccountantIdCancell { get; set; }

    /// <summary>
    /// Tài khoản nhận
    /// </summary>
     [Column("fund_id")] public int? FundId { get; set; }

    [Column("cancelled_reason")] public string? CancelledReason { get; set; }

    /// <summary>
    /// hủy từ invoice nào / hủy bởi invoice nào
    /// </summary>
    [Column("reference_invoice_id")] public long? ReferenceInvoiceId { get; set; }

    /// <summary>
    /// chuỗi json chi tiết thanh toán bị hủy
    /// </summary>
    [Column("cancell_orders")] public string? CancellOrders { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
