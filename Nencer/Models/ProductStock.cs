using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class ProductStock
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    /// <summary>
    /// Loại kho (Nội trú, ngoại trú)
    /// </summary>
    public int Type { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int? DepartmentId { get; set; }

    /// <summary>
    /// các thủ quỹ
    /// </summary>
    public string? OwnerId { get; set; }

    /// <summary>
    /// co thanh toan ko
    /// </summary>
    public int? PaymentRequire { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public virtual ICollection<PrescriptionOrder> PrescriptionOrders { get; set; } = new List<PrescriptionOrder>();

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
}
