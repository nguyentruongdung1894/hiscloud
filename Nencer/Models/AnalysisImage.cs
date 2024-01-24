using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class AnalysisImage
{
    public int? Id { get; set; }

    public int? AnalysisResultId { get; set; }

    public string? Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
