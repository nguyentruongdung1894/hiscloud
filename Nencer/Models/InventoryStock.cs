using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Kho
/// </summary>
public partial class InventoryStock
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Key { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Address { get; set; }

    public double? ContactPhone { get; set; }

    public string? ContactName { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
