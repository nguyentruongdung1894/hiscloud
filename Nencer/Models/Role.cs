using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Role người dùng
/// </summary>
public partial class Role
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string GuardName { get; set; } = null!;

    public string? Description { get; set; }

    public TimeOnly? CreatedAt { get; set; }

    public TimeOnly? UpdatedAt { get; set; }
}
