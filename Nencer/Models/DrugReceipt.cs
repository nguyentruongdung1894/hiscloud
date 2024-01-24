using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Toa thuốc
/// </summary>
public partial class DrugReceipt
{
    public int Id { get; set; }

    public string? OrderCode { get; set; }

    public int CheckinId { get; set; }

    public int CustomerId { get; set; }

    public int DrugId { get; set; }

    public string? DrugCode { get; set; }

    public string? DrugName { get; set; }

    public int? TotalDay { get; set; }

    public int? Qty { get; set; }

    public string? Unit { get; set; }

    public double? Price { get; set; }

    public double? PayAmount { get; set; }

    public string? CurrencyCode { get; set; }

    public string? Note { get; set; }

    public string? Status { get; set; }

    public string? CreatorId { get; set; }

    public int? StockId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
