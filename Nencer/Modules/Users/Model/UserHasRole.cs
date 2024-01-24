using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("user_has_roles")]
public partial class UserHasRole
{
    [Column("role_id")]
    public uint RoleId { get; set; }

    [Column("model_type")]
    public string ModelType { get; set; } = null!;

    [Column("usr_uid")]
    public ulong UsrUid { get; set; }
}
