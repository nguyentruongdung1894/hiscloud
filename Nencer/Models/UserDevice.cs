using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Thiết bị của user
/// </summary>
public partial class UserDevice
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string DeviceId { get; set; } = null!;

    public string? DeviceName { get; set; }

    public string? Platform { get; set; }

    public string? Version { get; set; }

    public string? UserAgent { get; set; }

    public int? Verified { get; set; }

    public string? Token { get; set; }

    public string? SessionId { get; set; }

    public DateTime? VerifiedAt { get; set; }

    public TimeOnly? CreatedAt { get; set; }

    public TimeOnly? UpdatedAt { get; set; }
}
