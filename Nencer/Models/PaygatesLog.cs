using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class PaygatesLog
{
    public int Id { get; set; }

    public string? OrderCode { get; set; }

    public int? TrialPatientId3 { get; set; }

    public string? Type { get; set; }

    public double? NetAmount { get; set; }

    public double Fees { get; set; }

    public double TrialPayAmount7 { get; set; }

    public short? TrialCurrencyId8 { get; set; }

    public string? TrialCurrencyCode9 { get; set; }

    public string? TrialProvider10 { get; set; }

    public string? BankCode { get; set; }

    public string? CallbackLogs { get; set; }

    public string? TrialIp13 { get; set; }

    public string? TrialAccountNum14 { get; set; }

    public string? AccountName { get; set; }

    public string? Description { get; set; }

    public string? TrialStatus17 { get; set; }

    /// <summary>
    /// time in interger
    /// </summary>
    public string? Time { get; set; }

    public string? AccountReceiver { get; set; }

    public string? TrialTransId20 { get; set; }

    public DateTime? TransDate { get; set; }

    public DateTime? TrialCreatedAt22 { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
