using System;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Loại bệnh nhân (Nhân dân, Bộ đội, .....)
/// </summary>
[Table("patient_types")]
public partial class PatientType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
    [Column("name_en")] public string? NameEn { get; set; }

    public string Code { get; set; } = null!;

    public int? Sort { get; set; }
    public int? Status { get; set; } = 1;

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
