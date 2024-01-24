using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class CheckinGroup
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int MaxNumber { get; set; }

    public string? Description { get; set; }
}
