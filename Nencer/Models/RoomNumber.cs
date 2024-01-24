using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class RoomNumber
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Number { get; set; } = null!;

    public int RoomId { get; set; }

    public int RoomTypeId { get; set; }

    public string? RoomTypeCode { get; set; }

    public string? Note { get; set; }

    public string? AllowUsers { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
