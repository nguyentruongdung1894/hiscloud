using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class ExaminationDiagnostic
{
    public long Id { get; set; }

    public long ObjectId { get; set; }

    public int DiagnosticId { get; set; }

    public int? IsPrimary { get; set; }

    public string? Type { get; set; }

    public virtual CatalogDiagnostic Diagnostic { get; set; } = null!;
}
