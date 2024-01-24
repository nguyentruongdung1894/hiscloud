using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class AnalysisResult
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int RoomId { get; set; }

    public int ServiceOrderId { get; set; }

    public int? ServiceId { get; set; }

    public int? DoctorId { get; set; }

    public string? Comment { get; set; }

    public string? ActionTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
