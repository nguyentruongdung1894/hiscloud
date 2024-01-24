using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// dân tộc
/// </summary>
public partial class Ethnic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;
}
