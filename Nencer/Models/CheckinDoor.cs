using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class CheckinDoor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    /// <summary>
    /// Cùng nhóm sẽ chung số gọi
    /// </summary>
    public int? Group { get; set; }

    public string? Description { get; set; }
}
