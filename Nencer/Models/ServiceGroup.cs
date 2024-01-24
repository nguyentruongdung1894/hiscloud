using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Nhóm dịch vụ- fix khong dc thay doi
/// </summary>
public partial class ServiceGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// tach phieu
    /// </summary>
    public int? Code { get; set; }

    /// <summary>
    /// tach phieu
    /// </summary>
    public string CodeName { get; set; } = null!;

    public int? Status { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
