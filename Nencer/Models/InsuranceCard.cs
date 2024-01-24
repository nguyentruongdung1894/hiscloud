using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Nhóm BHYT
/// </summary>
public partial class InsuranceCard
{
    public int Id { get; set; }

    public string? InsuranceCode { get; set; }

    public string? BenefitCode { get; set; }

    public int? BenefitRate { get; set; }

    public string? InsuranceName { get; set; }
}
