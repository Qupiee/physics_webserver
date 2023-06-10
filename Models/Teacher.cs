using System;
using System.Collections.Generic;

namespace physics_webserver.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? TeacherFullName { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual User TeacherNavigation { get; set; } = null!;
}
