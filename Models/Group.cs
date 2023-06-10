using System;
using System.Collections.Generic;

namespace physics_webserver.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public int? GroupLabel { get; set; }

    public int? GroupStudentId { get; set; }

    public virtual Student? GroupStudent { get; set; }
}
