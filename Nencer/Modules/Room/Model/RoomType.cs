using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Room.Model;

/// <summary>
/// Loại phòng
/// </summary>
[Table("room_types")]
public partial class RoomType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("name_array")] public string? NameArray { get; set; }

    /// <summary>
    /// slug
    /// </summary>
    public string? Code { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
