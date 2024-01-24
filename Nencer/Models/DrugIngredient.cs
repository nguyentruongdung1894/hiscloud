using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Hoạt chất
/// </summary>
public partial class DrugIngredient
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
