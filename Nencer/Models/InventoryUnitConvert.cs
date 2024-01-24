using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class InventoryUnitConvert
{
    public int Id { get; set; }

    /// <summary>
    /// key
    /// </summary>
    public string FromUnit { get; set; } = null!;

    public string FromUnitName { get; set; } = null!;

    public string ToUnit { get; set; } = null!;

    public string ToUnitName { get; set; } = null!;

    /// <summary>
    /// gia tri quy doi
    /// </summary>
    public double Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
