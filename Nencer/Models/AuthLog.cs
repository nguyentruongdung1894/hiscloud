using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class AuthLog
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public string? Ip { get; set; }

    public string? Twofactor { get; set; }

    public string? Cookie { get; set; }

    public string? UserAgent { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
