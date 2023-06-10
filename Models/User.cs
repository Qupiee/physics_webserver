using System;
using System.Collections.Generic;

namespace physics_webserver.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserRole { get; set; }

    public string? UserLogin { get; set; }

    public string? UserPassword { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
