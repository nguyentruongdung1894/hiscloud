using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Chỉ định dịch vụ
/// </summary>
public partial class ExaminationOrder
{
    public long Id { get; set; }

    public long ExaminationId { get; set; }

    /// <summary>
    /// thuộc ticket nào
    /// </summary>
    public long? TicketId { get; set; }

    public long? ParentId { get; set; }

    public int PatientId { get; set; }

    public int ServiceId { get; set; }

    public string ServiceCode { get; set; } = null!;

    public string ServiceName { get; set; } = null!;

    /// <summary>
    /// Tách theo nhóm
    /// </summary>
    public int? ServiceGroupId { get; set; }

    /// <summary>
    /// thuộc invoice nào
    /// </summary>
    public int? InvoiceId { get; set; }

    public int? Qty { get; set; }

    /// <summary>
    /// đơn vị
    /// </summary>
    public string? Unit { get; set; }

    public double? Price { get; set; }

    /// <summary>
    /// tổng số phải trả : giá * sl
    /// </summary>
    public double? TotalAmount { get; set; }

    /// <summary>
    /// đối tượng thanh toán
    /// </summary>
    public string? ServiceObject { get; set; }

    /// <summary>
    /// mức hưởng bhyt
    /// </summary>
    public int? BenefitRate { get; set; }

    /// <summary>
    /// bảo hiểm chi trả
    /// </summary>
    public double? InsurancePay { get; set; }

    /// <summary>
    /// bệnh nhân cùng chi trả
    /// </summary>
    public double? CopayPatient { get; set; }

    /// <summary>
    /// bệnh nhân đã trả
    /// </summary>
    public double? PatientPaid { get; set; }

    /// <summary>
    /// bệnh nhân còn nợ
    /// </summary>
    public double? PatientInDebt { get; set; }

    public string? PaymentStatus { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// Kết quả nhập tay và dùng làm kq trả về
    /// </summary>
    public string? Result { get; set; }

    /// <summary>
    /// kết quả update từ máy xét nghiệm
    /// </summary>
    public string? ResultByMachine { get; set; }

    /// <summary>
    /// thời gian nhận được kq từ máy
    /// </summary>
    public DateTime? ResultByMachineAt { get; set; }

    public string? TestCode { get; set; }

    public string? ResultNote { get; set; }

    public string? ResultUnit { get; set; }

    /// <summary>
    /// Ngày làm dịch vụ
    /// </summary>
    public DateTime? ServiceDate { get; set; }

    /// <summary>
    /// phòng lấy mẫu
    /// </summary>
    public int? RoomSampleId { get; set; }

    /// <summary>
    /// Phòng chỉ định
    /// </summary>
    public int? RoomId { get; set; }

    /// <summary>
    /// phòng xét nghiệm / thực hiện
    /// </summary>
    public int? RoomHandleId { get; set; }

    /// <summary>
    /// Trang thai xn
    /// </summary>
    public string? RoomHandleStatus { get; set; }

    /// <summary>
    /// Nguoi xn
    /// </summary>
    public string? RoomHandleBy { get; set; }

    /// <summary>
    /// Thoi gian xn
    /// </summary>
    public DateTime? RoomHandleDate { get; set; }

    /// <summary>
    /// Thoi gian trả kq xn
    /// </summary>
    public DateTime? RoomHandleResultDate { get; set; }

    /// <summary>
    /// Nguoi trả kết quả xn
    /// </summary>
    public string? RoomHandleResultBy { get; set; }

    /// <summary>
    /// Cho phep xoa lay mau
    /// </summary>
    public int? IsDeleteSample { get; set; }

    /// <summary>
    /// Cho phep hien thi lay mau
    /// </summary>
    public int? IsShowSample { get; set; }

    public int? IsDeleteHandle { get; set; }

    public int? IsShowHandle { get; set; }

    /// <summary>
    /// thiết bị thực hiện ris
    /// </summary>
    public string? RisDevice { get; set; }

    /// <summary>
    /// nội dung ris
    /// </summary>
    public string? RisResult { get; set; }

    /// <summary>
    /// kết luận
    /// </summary>
    public string? RisFinish { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// người updated cuối cùng
    /// </summary>
    public string? LastUpdatedBy { get; set; }

    public virtual Examination Examination { get; set; } = null!;
}
