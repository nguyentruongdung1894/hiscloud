using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class ProductBidItem
{
    public int Id { get; set; }

    public int BidId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Vat { get; set; }

    public string Unit { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal PriceIns { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ProductBid Bid { get; set; } = null!;
}
