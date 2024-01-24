using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Các mã code của tiền tệ trên thế giới
/// </summary>
public partial class CurrencyCode
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
