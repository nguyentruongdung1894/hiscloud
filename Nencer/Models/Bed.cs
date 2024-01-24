using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Giường bệnh
/// </summary>
public partial class Bed
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string CodeBhyt { get; set; } = null!;

    public int ChamberId { get; set; }
}
