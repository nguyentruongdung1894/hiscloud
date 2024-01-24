using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Users.Model;


/// <summary>
/// Người dùng
/// </summary>
public partial class User
{
    public long Id { get; set; }

    public string? Username { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    [Column("job_title")]
    public int? JobTitle { get; set; }
    [Column("country_code")]
    public string? CountryCode { get; set; }

    public string? Gender { get; set; }

    public string? Avatar { get; set; }

    //public int? Group { get; set; }

    public string Password { get; set; } = null!;
    [Column("remember_token")]
    public string? RememberToken { get; set; }

    /// <summary>
    /// Xác thực ngón tay
    /// </summary>
    public string? Finger { get; set; }

    public sbyte? Status { get; set; }

    [Column("currency_code")]
    public string? CurrencyCode { get; set; }


    public string? Language { get; set; }

    public string? Twofactor { get; set; }
    [Column("twofactor_secret")]
    public string? TwofactorSecret { get; set; }

    [Column("last_login_ip")]
    public string? LastLoginIp { get; set; }

    /// <summary>
    /// Số lần đăng nhập sai
    /// </summary>
    public sbyte? Failed { get; set; }
    [Column("failed_reason")]
    public string? FailedReason { get; set; }

    public string? Certificate { get; set; }
    [Column("verify_fail_reason")]
    public string? VerifyFailReason { get; set; }

    public DateOnly? Birthday { get; set; }
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Chứng chỉ hành nghề
    /// </summary>
    /// 
    [Column("practising_certificate")]
    public string? PractisingCertificate { get; set; }

    public virtual List<Role> Roles { get; set; } = new List<Role>();
    public virtual List<Group> Groups { get; set; } = new List<Group>();
}