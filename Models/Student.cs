using System;
using System.Collections.Generic;

namespace physics_webserver.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentFullName { get; set; }

    public string? StudentGroup { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual User StudentNavigation { get; set; } = null!;
}
