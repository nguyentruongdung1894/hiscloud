using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Khoa
/// </summary>
public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameEng { get; set; }

    public string? NameByt { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Manager { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? Sort { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
