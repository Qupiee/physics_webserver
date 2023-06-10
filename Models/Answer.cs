using System;
using System.Collections.Generic;

namespace physics_webserver.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string? AnswerCorrect { get; set; }

    public string? AnswerStudent { get; set; }

    public string? AnswerText { get; set; }

    public int? AnswerStudentId { get; set; }

    public int? AnswerTaskId { get; set; }

    public virtual Student? AnswerStudentNavigation { get; set; }

    public virtual Task? AnswerTask { get; set; }
}
