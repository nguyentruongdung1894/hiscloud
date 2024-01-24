using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Gia đình bệnh nhân
/// </summary>
[Table("patient_relations")]
public partial class PatientRelation
{
    public int Id { get; set; }

    [Column("patient_id")] public int? PatientId { get; set; }

    /// <summary>
    /// là bố, mẹ, giám hộ, ...
    /// </summary>
    [Column("relation_type")] public string? RelationType { get; set; }

    [Column("fa_name")] public string? FaName { get; set; }

    [Column("fa_id_card")] public string? FaIdCard { get; set; }

    [Column("fa_address")] public string? FaAddress { get; set; }

    [Column("fa_phone")] public string? FaPhone { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
