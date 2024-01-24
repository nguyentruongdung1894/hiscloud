using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Checkin.Model;

[Table("checkin_ordinal")]
public partial class CheckinOrdinal
{
    public int Id { get; set; }

    public int Number { get; set; }

    [Column("door_code")] public string? DoorCode { get; set; }

    [Column("door_id")] public int? DoorId { get; set; }

    public int? Group { get; set; }

    public int? Status { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }

    [Column("date_time")] public string DateTime { get;set; }
    [Column("calling_number")] public int CallingNumber { get;set; }
}
