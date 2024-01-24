using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Loại dịch vụ
/// </summary>
[Table("service_types")]
public partial class ServiceType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("name_array")] public string? NameArray { get; set; }

    [Column("service_group_id")] public int? ServiceGroupId { get; set; }

    public string? Code { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
