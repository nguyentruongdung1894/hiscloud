using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Người dùng
/// </summary>
public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? JobTitle { get; set; }

    public string? CountryCode { get; set; }

    public string? Gender { get; set; }

    public string? Avatar { get; set; }

    public int? GroupId { get; set; }

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    /// <summary>
    /// Xác thực ngón tay
    /// </summary>
    public string? Finger { get; set; }

    public short? Status { get; set; }

    public string? CurrencyCode { get; set; }

    public string? Language { get; set; }

    public string? Twofactor { get; set; }

    public string? TwofactorSecret { get; set; }

    public string? LastLoginIp { get; set; }

    /// <summary>
    /// Số lần đăng nhập sai
    /// </summary>
    public short? Failed { get; set; }

    public string? FailedReason { get; set; }

    public string? Certificate { get; set; }

    public string? VerifyFailReason { get; set; }

    public DateOnly? Birthday { get; set; }

    /// <summary>
    /// Chứng chỉ hành nghề
    /// </summary>
    public string? PractisingCertificate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
