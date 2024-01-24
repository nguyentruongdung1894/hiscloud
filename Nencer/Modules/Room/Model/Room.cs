using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Room.Model;

/// <summary>
/// Phòng
/// </summary>
[Table("rooms")]
public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("name_array")] public string? NameArray { get; set; }

    public string? Code { get; set; }

    [Column("room_type")] public int? RoomType { get; set; }

    [Column("department_id")] public int? DepartmentId { get; set; }

    [Column("hospital_id")] public int? HospitalId { get; set; }

    [Column("location_id")] public int? LocationId { get; set; }

    [Column("accept_insurance")] public int? AcceptInsurance { get; set; }

    public int? Polyclinic { get; set; }

    [Column("big_clinic")] public int? BigClinic { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }= DateTime.Now;

    /// <summary>
    /// Số phòng
    /// </summary>
    [Column("room_number")] public string? RoomNumber { get; set; }

    /// <summary>
    /// Cho phép user nhìn thấy
    /// </summary>
    [Column("allow_users")] public string? AllowUsers { get; set; }

    /// <summary>
    /// Tên phiếu in
    /// </summary>
    [Column("title_print_name")] public string? TitlePrintName { get; set; }

    /// <summary>
    /// Máy thực hiện CDHA
    /// </summary>
    [Column("ris_device")] public string? RisDevice { get; set; }
}
