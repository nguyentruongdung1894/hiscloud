using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class SendmailDriver
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Driver { get; set; }

    public string? Configs { get; set; }

    public int? Status { get; set; }

    public int? Nstalled { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
