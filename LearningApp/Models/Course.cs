using System;
using System.Collections.Generic;

namespace LearningApp.Models;

public class Course
{
    public int Id { get; set; }
    public string? CourseName { get; set; }
    public string? CourseDescription { get; set; }
    public string? CourseLanguageLevel { get; set; }
    public bool IsArchived { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Lesson>? Lesson { get; set; }
}