using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Mapping giữa service code và machine code
/// </summary>
public partial class ServiceCodeMapping
{
    public int Id { get; set; }

    public string ServiceCode { get; set; } = null!;

    public string? MachineTestCode { get; set; }

    public string? MachineCode { get; set; }
}
