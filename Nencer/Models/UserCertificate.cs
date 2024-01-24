using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Chứng chỉ
/// </summary>
public partial class UserCertificate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public string? Image { get; set; }

    public string? Type { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public string? IssueBy { get; set; }

    public int? Status { get; set; }

    public TimeOnly? CreatedAt { get; set; }

    public TimeOnly? UpdatedAt { get; set; }
}
