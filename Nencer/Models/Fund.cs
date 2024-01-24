using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Fund
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Loại
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// 113
    /// </summary>
    public string? TaxAcc { get; set; }

    public string? AccName { get; set; }

    public string? AccNumber { get; set; }

    public string? AccBranch { get; set; }

    public double? Balance { get; set; }

    public string? CurrencyCode { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
