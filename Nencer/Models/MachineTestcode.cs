using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class MachineTestcode
{
    public int Id { get; set; }

    public string MachineCode { get; set; } = null!;

    public string TestCode { get; set; } = null!;

    public string? ServiceCode { get; set; }
}
