using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Tiền sử bệnh
/// </summary>
[Table("patient_prehistoric")]
public partial class PatientPrehistoric
{
    public int Id { get; set; }

    [Column("disease_id")] public int DiseaseId { get; set; }

    [Column("patient_id")] public int PatientId { get; set; }

    public string? Description { get; set; }

    [Column("from_date")] public DateTime? FromDate { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }

}
