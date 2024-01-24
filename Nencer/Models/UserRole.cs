using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class UserRole
{
    public long RoleId { get; set; }

    public long UserId { get; set; }
}
