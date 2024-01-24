using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Tương tác thuốc theo hoạt chất
/// </summary>
public partial class DrugIngredientInteraction
{
    public int Id { get; set; }

    /// <summary>
    /// Mã hoạt chất
    /// </summary>
    public string? CodeIngredient { get; set; }

    /// <summary>
    /// Tên hoạt chất
    /// </summary>
    public string? NameIngredient { get; set; }

    /// <summary>
    /// Mức độ
    /// </summary>
    public string? Degree { get; set; }

    /// <summary>
    /// hậu quả
    /// </summary>
    public string? Consequence { get; set; }

    /// <summary>
    /// cách xử lý
    /// </summary>
    public string? Handle { get; set; }

    public string? Note { get; set; }

    public string? Bibliography { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
