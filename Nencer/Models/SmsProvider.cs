using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class SmsProvider
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Brandname { get; set; }

    public string Provider { get; set; } = null!;

    public string? Configs { get; set; }

    public string? Balance { get; set; }

    public int Status { get; set; }

    public int Installed { get; set; }
}
