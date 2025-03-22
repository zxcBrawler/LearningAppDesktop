using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class Lesson
{
    public int Id { get; set; }

    [JsonPropertyName("lesson_Name")] public string? LessonName { get; set; }

    [JsonPropertyName("lesson_Description")]
    public string? LessonDescription { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string? UID { get; set; }


    public List<Exercise>? Exercises { get; set; }
}