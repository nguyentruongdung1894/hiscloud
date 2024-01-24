using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Dịch vụ
/// </summary>
namespace Nencer.Modules.ManageService;
public partial class Service
{
    public int Id { get; set; }

    [Column("parent_id")] public int? ParentId { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// Tên theo bảo hiểm y tế
    /// </summary>
    [Column("name_ins")] public string? NameIns { get; set; }

    public string? Code { get; set; }

    /// <summary>
    /// Code theo  bảo hiểm y tế
    /// </summary>
    [Column("code_ins")] public string? CodeIns { get; set; }

    public string? Description { get; set; }
    [Column("is_pack")] public int? IsPack { get; set; }
    [Column("unit_id")] public int? UnitId { get; set; }

    public string? Unit { get; set; }

    [Column("service_group_id")] public int? ServiceGroupId { get; set; }

    /// <summary>
    /// Loai dich vu
    /// </summary>
    [Column("service_type_id")] public int? ServiceTypeId { get; set; }

    /// <summary>
    /// Gia BV
    /// </summary>
    [Column("price_normal")] public double? PriceNormal { get; set; }

    /// <summary>
    /// Gia BHYT
    /// </summary>
    [Column("price_ins")] public double? PriceIns { get; set; }

    /// <summary>
    /// Gia DV
    /// </summary>
    [Column("price_service")] public double? PriceService { get; set; }

    /// <summary>
    /// Phong xu ly/ thuc hien
    /// </summary>
    [Column("room_handle_id")] public string? RoomHandleId { get; set; }

    /// <summary>
    /// Phòng khám
    /// </summary>
    [Column("room_id")] public string? RoomId { get; set; }

    /// <summary>
    /// Phòng lấy mẫu
    /// </summary>
    [Column("room_sample_id")] public string? RoomSampleId { get; set; }

    /// <summary>
    /// Gia tri binh thuong
    /// </summary>
    [Column("original_result")] public string? OriginalResult { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    /// <summary>
    /// Mã chuyên khoa(theo QĐ BYT BN khám nhiều chuyên khoa mà các chuyên khoa giống nhau thì không thu thêm tiền công khám, khác chuyên khoa thì thu thêm 30% nhưng không vượt quá tổng 2 lần khám)
    /// </summary>
    [Column("specialty_code")] public string? SpecialtyCode { get; set; }

    /// <summary>
    /// Mã tương đương(Mã do BHYT quy định)
    /// </summary>
    [Column("equivalent_code")] public string? EquivalentCode { get; set; }

    /// <summary>
    /// Thời gian tái chỉ định: Theo TT35 thì 1 số DV chỉ được phép chỉ định sau x ngày (VD: HbA1C sau 90 ngày)
    /// </summary>
    [Column("reassignment_time")] public int? ReassignmentTime { get; set; }

    /// <summary>
    /// Tỉ lệ đúng tuyến
    /// </summary>
    [Column("right_rate")] public int? RightRate { get; set; }

    /// <summary>
    /// Tỉ lệ trái tuyến
    /// </summary>
    [Column("offline_rate")] public int? OfflineRate { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }

}
