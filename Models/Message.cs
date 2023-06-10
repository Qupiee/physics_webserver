using System;
using System.Collections.Generic;

namespace physics_webserver.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public string? MessageText { get; set; }

    public int? MessageUserId { get; set; }

    public virtual User? MessageUser { get; set; }
}
