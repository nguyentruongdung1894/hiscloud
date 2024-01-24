using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class SendmailSetting
{
    public int Id { get; set; }

    public string FromEmail { get; set; } = null!;

    public string FromName { get; set; } = null!;

    public string Driver { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
