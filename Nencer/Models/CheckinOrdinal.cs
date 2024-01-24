using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class CheckinOrdinal
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string? DoorCode { get; set; }

    public int? DoorId { get; set; }

    public int? Group { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
