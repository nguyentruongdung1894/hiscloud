using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Machine
{
    public int Id { get; set; }

    public string MachineCode { get; set; } = null!;

    public string? MachineName { get; set; }

    public string? ConnectionType { get; set; }

    public string? Type { get; set; }

    public int? SupplierId { get; set; }

    public int? Status { get; set; }

    /// <summary>
    /// ex: SH / HH / CL / MRI
    /// </summary>
    public string? ServiceTypeIns { get; set; }
}
