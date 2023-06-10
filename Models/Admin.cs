using System;
using System.Collections.Generic;

namespace physics_webserver.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminFullName { get; set; }

    public virtual User AdminNavigation { get; set; } = null!;
}
