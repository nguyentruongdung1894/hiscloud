using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Loại phòng
/// </summary>
public partial class RoomType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameArray { get; set; }

    /// <summary>
    /// slug
    /// </summary>
    public string? Code { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
