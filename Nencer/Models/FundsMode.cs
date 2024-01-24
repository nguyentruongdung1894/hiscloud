using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Các hình thức thanh toán quỹ
/// </summary>
public partial class FundsMode
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Loại thu, chi
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// 113
    /// </summary>
    public string? TaxAcc { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
