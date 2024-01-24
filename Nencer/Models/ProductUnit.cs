using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Đơn vị 
/// </summary>
public partial class ProductUnit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string? Type { get; set; }

    public string? Description { get; set; }

    public int? Default { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
