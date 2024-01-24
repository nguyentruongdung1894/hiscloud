using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Phòng
/// </summary>
public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameArray { get; set; }

    public string? Code { get; set; }

    public int? RoomType { get; set; }

    public int? DepartmentId { get; set; }

    public int? HospitalId { get; set; }

    public int? LocationId { get; set; }

    public int? AcceptInsurance { get; set; }

    public int? Polyclinic { get; set; }

    public int? BigClinic { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Số phòng
    /// </summary>
    public string? RoomNumber { get; set; }

    /// <summary>
    /// Cho phép user nhìn thấy
    /// </summary>
    public string? AllowUsers { get; set; }

    /// <summary>
    /// Tên phiếu in
    /// </summary>
    public string? TitlePrintName { get; set; }

    /// <summary>
    /// Máy thực hiện CDHA
    /// </summary>
    public string? RisDevice { get; set; }
}
