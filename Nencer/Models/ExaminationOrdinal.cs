using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Số thứ tự chờ tiếp đón
/// </summary>
public partial class ExaminationOrdinal
{
    public int Id { get; set; }

    /// <summary>
    /// So tt
    /// </summary>
    public int? Number { get; set; }

    public string? RoomCode { get; set; }

    public long? ExaminationId { get; set; }

    public DateOnly? DateTime { get; set; }

    public int? CallingNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
