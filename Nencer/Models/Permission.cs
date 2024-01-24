using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Permission
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Code { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public int? Menu { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
