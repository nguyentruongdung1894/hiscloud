using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class TemplateService
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public string? ServiceId { get; set; }

    public string? CreatorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
