using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Luu thong tin file lis tu may
/// </summary>
public partial class RocheDatum
{
    public int Id { get; set; }

    public int? TicketId { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public string? FileData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Direction { get; set; }
}
