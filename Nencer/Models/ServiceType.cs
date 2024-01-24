using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Loại dịch vụ
/// </summary>
public partial class ServiceType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameArray { get; set; }

    public int? ServiceGroupId { get; set; }

    public string? Code { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
