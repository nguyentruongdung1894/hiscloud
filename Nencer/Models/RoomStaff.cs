using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Danh sách bác sỹ và nhân viên phục vụ
/// </summary>
public partial class RoomStaff
{
    public int Id { get; set; }

    public string? JobType { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// bác sỹ hoặc nhân viên
    /// </summary>
    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public string? Status { get; set; }

    public DateTime? CheckinAt { get; set; }

    public DateTime? CheckoutAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
