using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Setting
{
    public int Id { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }

    public string? ValueArr { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
