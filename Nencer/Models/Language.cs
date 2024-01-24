using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Ngôn ngữ
/// </summary>
public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Flag { get; set; }

    public string? Hreflang { get; set; }

    public string? Charset { get; set; }

    public short Default { get; set; }

    public short Status { get; set; }

    public short Installed { get; set; }

    public short Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
