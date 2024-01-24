using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class SampleDevice
{
    public int Id { get; set; }

    public int? ServiceId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public ulong? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
