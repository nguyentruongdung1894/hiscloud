using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Examination.Model;

/// <summary>
/// Quản lý các phiếu chỉ định
/// </summary>
[Table("examination_tickets")]
public partial class ExaminationTicket
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("examination_id")]
    public long ExaminationId { get; set; }

    [Column("service_group_id")]
    public int? ServiceGroupId { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("init_status")]
    public int InitStatus { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("is_emergency")]
    public bool? IsEmergency { get; set; }

    [Column("room")]
    public int? Room { get; set; }

    [Column("room_code")]
    public string? RoomCode { get; set; }

    [Column("room_sample")]
    public int? RoomSample { get; set; }

    [Column("room_handle")]
    public int? RoomHandle { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("doctor_id")]
    public int? DoctorId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("order_at")]
    public DateTime? OrderAt { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("sample_status")]
    public string? SampleStatus { get; set; }

    [Column("sample_by")]
    public string? SampleBy { get; set; }

    [Column("sample_at")]
    public DateTime? SampleAt { get; set; }

    [Column("handle_status")]
    public string? HandleStatus { get; set; }

    [Column("handle_by")]
    public string? HandleBy { get; set; }

    [Column("handle_at")]
    public DateTime? HandleAt { get; set; }

    [Column("handle_return_result_at")]
    public DateTime? HandleReturnResultAt { get; set; }

    [Column("handle_return_result_by")]
    public string? HandleReturnResultBy { get; set; }

    [Column("payment_status")]
    public string? PaymentStatus { get; set; }

    [Column("product_order_id")]
    public int? ProductOrderId { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}

