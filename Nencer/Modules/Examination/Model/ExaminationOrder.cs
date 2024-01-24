using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Examination.Model;

/// <summary>
/// Chỉ định dịch vụ
/// </summary>
[Table("examination_orders")]
public partial class ExaminationOrder
{
    public long Id { get; set; }

    [Column("examination_id")] public long ExaminationId { get; set; }

    /// <summary>
    /// thuộc ticket nào
    /// </summary>
    [Column("ticket_id")] public long? TicketId { get; set; }

    [Column("parent_id")] public int? ParentId { get; set; }

    [Column("patient_id")] public int PatientId { get; set; }

    [Column("service_id")] public int ServiceId { get; set; }

    [Column("service_code")] public string ServiceCode { get; set; } = null!;

    [Column("service_name")] public string ServiceName { get; set; } = null!;

    /// <summary>
    /// Tách theo nhóm
    /// </summary>
    [Column("service_group_id")] public int? ServiceGroupId { get; set; }

    /// <summary>
    /// thuộc invoice nào
    /// </summary>
    [Column("invoice_id")] public int? InvoiceId { get; set; }

    public int? Qty { get; set; }

    /// <summary>
    /// đơn vị
    /// </summary>
    public string? Unit { get; set; }

    public double? Price { get; set; }

    /// <summary>
    /// tổng số phải trả : giá * sl
    /// </summary>
    [Column("total_amount")] public double? TotalAmount { get; set; }

    /// <summary>
    /// đối tượng thanh toán
    /// </summary>
    [Column("service_object")] public string? ServiceObject { get; set; }

    /// <summary>
    /// mức hưởng bhyt
    /// </summary>
    [Column("benefit_rate")] public int? BenefitRate { get; set; }

    /// <summary>
    /// bảo hiểm chi trả
    /// </summary>
    [Column("insurance_pay")] public double? InsurancePay { get; set; }

    /// <summary>
    /// bệnh nhân cùng chi trả
    /// </summary>
    [Column("copay_patient")] public double? CopayPatient { get; set; }

    /// <summary>
    /// bệnh nhân đã trả
    /// </summary>
    [Column("patient_paid")] public double? PatientPaid { get; set; }

    /// <summary>
    /// bệnh nhân còn nợ
    /// </summary>
    [Column("patient_in_debt")] public double? PatientInDebt { get; set; }

    [Column("payment_status")] public string? PaymentStatus { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// Kết quả nhập tay và dùng làm kq trả về
    /// </summary>
    public string? Result { get; set; }

    /// <summary>
    /// kết quả update từ máy xét nghiệm
    /// </summary>
    [Column("result_by_machine")] public string? ResultByMachine { get; set; }

    /// <summary>
    /// thời gian nhận được kq từ máy
    /// </summary>
    [Column("result_by_machine_at")] public DateTime? ResultByMachineAt { get; set; } = null;

    [Column("test_code")] public string? TestCode { get; set; }

    [Column("result_note")] public string? ResultNote { get; set; }

    [Column("result_unit")] public string? ResultUnit { get; set; }

    /// <summary>
    /// Ngày làm dịch vụ
    /// </summary>
    [Column("service_date")] public DateTime? ServiceDate { get; set; } = DateTime.Now;

    /// <summary>
    /// phòng lấy mẫu
    /// </summary>
    [Column("room_sample_id")] public int? RoomSampleId { get; set; }

    /// <summary>
    /// Phòng chỉ định
    /// </summary>
    [Column("room_id")] public int? RoomId { get; set; }

    /// <summary>
    /// phòng xét nghiệm / thực hiện
    /// </summary>
    [Column("room_handle_id")] public int? RoomHandleId { get; set; }

    /// <summary>
    /// Trang thai xn
    /// </summary>
    [Column("room_handle_status")] public string? RoomHandleStatus { get; set; }

    /// <summary>
    /// Nguoi xn
    /// </summary>
    [Column("room_handle_by")] public string? RoomHandleBy { get; set; }

    /// <summary>
    /// Thoi gian xn
    /// </summary>
    [Column("room_handle_date")] public DateTime? RoomHandleDate { get; set; } = null;

    /// <summary>
    /// Thoi gian trả kq xn
    /// </summary>
    [Column("room_handle_result_date")] public DateTime? RoomHandleResultDate { get; set; } = null; 

    /// <summary>
    /// Nguoi trả kết quả xn
    /// </summary>
    [Column("room_handle_result_by")] public string? RoomHandleResultBy { get; set; }

    /// <summary>
    /// Cho phep xoa lay mau
    /// </summary>
    [Column("is_delete_sample")] public int? IsDeleteSample { get; set; }

    /// <summary>
    /// Cho phep hien thi lay mau
    /// </summary>
    [Column("is_show_sample")] public int? IsShowSample { get; set; }

    [Column("is_delete_handle")] public int? IsDeleteHandle { get; set; }

    [Column("is_show_handle")] public int? IsShowHandle { get; set; }

    /// <summary>
    /// thiết bị thực hiện ris
    /// </summary>
    [Column("ris_device")] public string? RisDevice { get; set; }

    /// <summary>
    /// nội dung ris
    /// </summary>
    [Column("ris_result")] public string? RisResult { get; set; }

    /// <summary>
    /// kết luận
    /// </summary>
    [Column("ris_finish")] public string? RisFinish { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// người updated cuối cùng
    /// </summary>
    [Column("last_updated_by")] public string? LastUpdatedBy { get; set; }

}
