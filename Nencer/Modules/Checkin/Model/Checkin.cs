using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Checkin.Model;

/// <summary>
/// đón tiếp
/// </summary>
[Table("checkin")]
public partial class Checkin
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("patient_number")]
    public string? PatientNumber { get; set; }

    [Column("service_object")]
    public string? ServiceObject { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("checkin_number")]
    public int? CheckinNumber { get; set; }

    [Column("priority")]
    public int? Priority { get; set; }

    [Column("room_id")]
    public int? RoomId { get; set; }

    [Column("room_code")]
    public string? RoomCode { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("doctor_id")]
    public int? DoctorId { get; set; }

    [Column("doctor_name")]
    public string? DoctorName { get; set; }

    [Column("reason")]
    public string? Reason { get; set; }

    [Column("status")]
    public string? Status { get; set; }

    [Column("chamber_id")]
    public int? ChamberId { get; set; }

    [Column("bed_id")]
    public int? BedId { get; set; }

    [Column("service_Id")]
    public int? ServiceId { get; set; }

    [Column("checkin_time")]
    public DateTime? CheckinTime { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
