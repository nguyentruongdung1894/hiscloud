﻿using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class LocalAdminUnit
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? FullNameEn { get; set; }

    public string? ShortName { get; set; }

    public string? ShortNameEn { get; set; }

    public string? CodeName { get; set; }

    public string? CodeNameEn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
