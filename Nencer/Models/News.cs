using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class News
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Image { get; set; }

    public int? Views { get; set; }

    public short Status { get; set; }

    public int? CatId { get; set; }

    public TimeOnly? CreatedAt { get; set; }

    public TimeOnly? UpdatedAt { get; set; }
}
