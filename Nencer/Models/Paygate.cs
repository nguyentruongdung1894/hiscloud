using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Paygate
{
    public int Id { get; set; }

    public int CurrencyId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Paygate1 { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// người quản lý
    /// </summary>
    public int? UserId { get; set; }

    public float? Balance { get; set; }

    public string? Type { get; set; }

    public short Withdraw { get; set; }

    public string? WithdrawField { get; set; }

    public short Deposit { get; set; }

    public short Payment { get; set; }

    public short? Round { get; set; }

    public string? Avatar { get; set; }

    public string? Configs { get; set; }

    public short Status { get; set; }

    public string? MidBank { get; set; }

    public string? QrBank { get; set; }

    public string? InputFixed { get; set; }

    public string? InputPercent { get; set; }

    public string? OutputFixed { get; set; }

    public string? OutputPercent { get; set; }

    public string? AllowGroups { get; set; }

    public string? DepositPaygate { get; set; }

    public string? WithdrawPaygate { get; set; }

    public int? Sort { get; set; }

    public int? CancelTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
