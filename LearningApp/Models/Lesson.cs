using System;
using System.Collections.Generic;

namespace LearningApp.Models;

public class Lesson
{
    public int Id { get; set; }

    public string? LessonName { get; set; }

    public string? LessonDescription { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string? UID { get; set; }

    public List<Exercise>? Exercises { get; set; }
}