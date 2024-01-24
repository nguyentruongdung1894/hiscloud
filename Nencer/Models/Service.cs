using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Dịch vụ
/// </summary>
public partial class Service
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// Tên theo bảo hiểm y tế
    /// </summary>
    public string? NameIns { get; set; }

    public string? Code { get; set; }

    /// <summary>
    /// Code theo  bảo hiểm y tế
    /// </summary>
    public string? CodeIns { get; set; }

    public string? Description { get; set; }

    public int? UnitId { get; set; }

    public string? Unit { get; set; }

    public int? ServiceGroupId { get; set; }

    /// <summary>
    /// Loai dich vu
    /// </summary>
    public int? ServiceTypeId { get; set; }

    /// <summary>
    /// Gia BV
    /// </summary>
    public double? PriceNormal { get; set; }

    /// <summary>
    /// Gia BHYT
    /// </summary>
    public double? PriceIns { get; set; }

    /// <summary>
    /// Gia DV
    /// </summary>
    public double? PriceService { get; set; }

    /// <summary>
    /// Phong xu ly/ thuc hien
    /// </summary>
    public string? RoomHandleId { get; set; }

    /// <summary>
    /// Phòng khám
    /// </summary>
    public string? RoomId { get; set; }

    /// <summary>
    /// Phòng lấy mẫu
    /// </summary>
    public string? RoomSampleId { get; set; }

    /// <summary>
    /// Gia tri binh thuong
    /// </summary>
    public string? OriginalResult { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    /// <summary>
    /// Mã chuyên khoa(theo QĐ BYT BN khám nhiều chuyên khoa mà các chuyên khoa giống nhau thì không thu thêm tiền công khám, khác chuyên khoa thì thu thêm 30% nhưng không vượt quá tổng 2 lần khám)
    /// </summary>
    public string? SpecialtyCode { get; set; }

    /// <summary>
    /// Mã tương đương(Mã do BHYT quy định)
    /// </summary>
    public string? EquivalentCode { get; set; }

    /// <summary>
    /// Thời gian tái chỉ định: Theo TT35 thì 1 số DV chỉ được phép chỉ định sau x ngày (VD: HbA1C sau 90 ngày)
    /// </summary>
    public int? ReassignmentTime { get; set; }

    /// <summary>
    /// Tỉ lệ đúng tuyến
    /// </summary>
    public int? RightRate { get; set; }

    /// <summary>
    /// Tỉ lệ trái tuyến
    /// </summary>
    public int? OfflineRate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ServicesItem> ServicesItems { get; set; } = new List<ServicesItem>();
}
