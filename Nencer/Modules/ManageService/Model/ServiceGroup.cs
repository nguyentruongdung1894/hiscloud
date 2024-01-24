using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 

/// <summary>
/// Nhóm dịch vụ- fix khong dc thay doi
/// </summary>
[Table("service_groups")]
public partial class ServiceGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// tach phieu
    /// </summary>
    public int? Code { get; set; }

    /// <summary>
    /// tach phieu
    /// </summary>
    [Column("code_name")] public string CodeName { get; set; } = null!;

    public int? Status { get; set; }

    public int? Sort { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
