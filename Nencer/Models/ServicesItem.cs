using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Dịch vụ
/// </summary>
public partial class ServicesItem
{
    public int Id { get; set; }

    /// <summary>
    /// Chi vuj cha
    /// </summary>
    public int ServiceId { get; set; }

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

    /// <summary>
    /// Phong xu ly/ thuc hien
    /// </summary>
    public string? RoomHandleId { get; set; }

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

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Service Service { get; set; } = null!;
}
