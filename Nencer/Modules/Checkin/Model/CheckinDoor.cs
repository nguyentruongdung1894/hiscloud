using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Checkin.Model;

[Table("checkin_door")]
public partial class CheckinDoor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("name_en")] public string? NameEn { get; set; }

    /// <summary>
    /// Cùng nhóm sẽ chung số gọi
    /// </summary>
    public int? Group { get; set; }

    public string? Description { get; set; }
}
