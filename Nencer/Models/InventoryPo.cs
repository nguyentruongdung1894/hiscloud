using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class InventoryPo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Address { get; set; }

    public string? DeviceId { get; set; }

    public string? Seller { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public string? Type { get; set; }

    public string? Stock { get; set; }

    public int? Stadium { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
