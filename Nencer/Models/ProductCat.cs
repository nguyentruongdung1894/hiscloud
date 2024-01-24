using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class ProductCat
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Area { get; set; }

    public string? Description { get; set; }

    public int? Sort { get; set; }

    public string? Image { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
