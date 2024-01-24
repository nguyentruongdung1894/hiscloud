using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// thiết bị máy móc
/// </summary>
public partial class MachineDevice
{
    public int Id { get; set; }

    /// <summary>
    /// mã model
    /// </summary>
    public string MachineCode { get; set; } = null!;

    /// <summary>
    /// serial máy ; gồm 6 số cuối hoặc thêm 0 vào đầu cho đủ 6 số
    /// </summary>
    public string DeviceNumber { get; set; } = null!;

    /// <summary>
    /// 1: ngân sách nhà nước ; 2: xã hội hóa ; 3: khác
    /// </summary>
    public int FundingSource { get; set; }

    public int? RoomId { get; set; }
}
