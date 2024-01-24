using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Currency
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Mã tiền tệ
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// 1 USD bằng bao nhiêu tiền này
    /// </summary>
    public double Value { get; set; }

    public string? SymbolLeft { get; set; }

    public string? SymbolRight { get; set; }

    public string Seperator { get; set; } = null!;

    public short Decimal { get; set; }

    public short Status { get; set; }

    public short Default { get; set; }

    public short Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
