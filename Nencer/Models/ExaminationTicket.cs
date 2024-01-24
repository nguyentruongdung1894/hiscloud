using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Quản lý các phiếu chỉ định
/// </summary>
public partial class ExaminationTicket
{
    public long Id { get; set; }

    public string? Barcode { get; set; }

    public long ExaminationId { get; set; }

    /// <summary>
    /// id nhóm dịch vụ
    /// </summary>
    public int? ServiceGroupId { get; set; }

    public int PatientId { get; set; }

    /// <summary>
    /// phiếu từ nguồn nào : exam hay kho ..
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Có phải là cấp cứu ?
    /// </summary>
    public sbyte? IsEmergency { get; set; }

    /// <summary>
    /// ID phong
    /// </summary>
    public int? Room { get; set; }

    /// <summary>
    /// ID cua phong lay mau
    /// </summary>
    public int? RoomSample { get; set; }

    /// <summary>
    /// Id cua phong thuc hien
    /// </summary>
    public int? RoomHandle { get; set; }

    public int? DepartmentId { get; set; }

    public int? DoctorId { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// ngày y lệnh (thực hiện)
    /// </summary>
    public DateTime? OrderAt { get; set; }

    /// <summary>
    /// ngày tạo phiếu
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// active , inactive , delete ...
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// trạng thái lấy mẫu
    /// </summary>
    public string? SampleStatus { get; set; }

    /// <summary>
    /// người lấy mẫu
    /// </summary>
    public string? SampleBy { get; set; }

    /// <summary>
    /// thời gian lấy mẫu
    /// </summary>
    public DateTime? SampleAt { get; set; }

    /// <summary>
    /// trạng thái thực hiện
    /// </summary>
    public string? HandleStatus { get; set; }

    /// <summary>
    /// người thực hiện
    /// </summary>
    public string? HandleBy { get; set; }

    /// <summary>
    /// thực hiện lúc
    /// </summary>
    public DateTime? HandleAt { get; set; }

    /// <summary>
    /// trả kết quả lúc
    /// </summary>
    public DateTime? HandleReturnResultAt { get; set; }

    /// <summary>
    /// người trả kết quả 
    /// </summary>
    public string? HandleReturnResultBy { get; set; }

    /// <summary>
    /// trạng thái thanh toán
    /// </summary>
    public string? PaymentStatus { get; set; }

    /// <summary>
    /// order ticket id
    /// </summary>
    public int? ProductOrderId { get; set; }
}
