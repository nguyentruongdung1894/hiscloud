using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Phiếu thu tiền
/// </summary>
public partial class FundLog
{
    public int FundLogId { get; set; }

    public string? Code { get; set; }

    public int? CheckinId { get; set; }

    public string? CurrencyCode { get; set; }

    public string? Description { get; set; }

    public int? Creator { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CustomerId { get; set; }

    public string? Status { get; set; }

    public string? OrderType { get; set; }

    public double? NetAmount { get; set; }

    public double? Fees { get; set; }

    public double? Discount { get; set; }

    public double? PayAmount { get; set; }

    public string? Paygate { get; set; }

    public string? Note { get; set; }

    /// <summary>
    /// Số quyển
    /// </summary>
    public string? BookNumber { get; set; }

    public int? OrderId { get; set; }

    /// <summary>
    /// Đối tượng thanh toán
    /// </summary>
    public string? ServiceObject { get; set; }

    /// <summary>
    /// Mức hưởng bhyt
    /// </summary>
    public int? BenefitRate { get; set; }

    /// <summary>
    /// Bệnh nhân cùng chi trả
    /// </summary>
    public double? CopayPatient { get; set; }

    /// <summary>
    /// Bệnh nhân đã trả
    /// </summary>
    public double? PatientsPaid { get; set; }

    /// <summary>
    /// Bệnh nhân còn nợ
    /// </summary>
    public double? PatientsInDebt { get; set; }

    public string? FundLogChannel { get; set; }
}
