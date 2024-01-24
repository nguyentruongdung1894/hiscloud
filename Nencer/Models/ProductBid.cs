using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Gói thầu
/// </summary>
public partial class ProductBid
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int? SupplierId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? BidNumber { get; set; }

    public string? BidGroup { get; set; }

    public string? BidPackage { get; set; }

    public DateOnly? BidDate { get; set; }

    public string? BidYear { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public string? CreatorId { get; set; }

    public string? UpdaterId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductBidItem> ProductBidItems { get; set; } = new List<ProductBidItem>();
}
