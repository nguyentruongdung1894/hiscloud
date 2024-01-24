using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Group
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Status { get; set; }

    public int Hideit { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
