using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

/// <summary>
/// Role người dùng
/// </summary>
[Table("roles")]
public partial class Role
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
    [Column("guard_name")]
    [JsonPropertyName("guard_name")]
    public string GuardName { get; set; } = null!;

    public string? Description { get; set; }

    [Column("created_at")]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
