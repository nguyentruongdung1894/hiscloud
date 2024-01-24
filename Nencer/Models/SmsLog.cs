using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class SmsLog
{
    public int Id { get; set; }

    public string Phone { get; set; } = null!;

    public string Provider { get; set; } = null!;

    public string Message { get; set; } = null!;

    public int? PatientId { get; set; }

    public string? OrderCode { get; set; }

    public string? CountryCode { get; set; }

    public double? Cost { get; set; }

    public string? ProviderResponse { get; set; }

    public string? ProviderSendId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
