using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Buồng bệnh
/// </summary>
public partial class Chamber
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int RoomId { get; set; }

    public string RoomName { get; set; } = null!;
}
