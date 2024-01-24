using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Cấu hình thông tin BHYT
/// </summary>
public partial class InformationInsurance
{
    public int Id { get; set; }

    /// <summary>
    /// Tháng lương tối thiểu
    /// </summary>
    public double? MinimumSalaryMonth { get; set; }

    /// <summary>
    /// Mức chi trả trái tuyến
    /// </summary>
    public int? OfflinePayment { get; set; }

    /// <summary>
    /// API BHXH
    /// </summary>
    public string? ApiSocialInsurance { get; set; }

    /// <summary>
    /// Tài khoản BHXH
    /// </summary>
    public string? AccountSocialInsurance { get; set; }

    /// <summary>
    /// Mật khẩu BHXH
    /// </summary>
    public string? PasswordSocialInsurance { get; set; }
}
