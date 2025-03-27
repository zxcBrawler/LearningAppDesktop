using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class Lesson
{
    public int Id { get; set; }

    [JsonPropertyName("lesson_name")] public string? LessonName { get; set; }

    [JsonPropertyName("lesson_description")]
    public string? LessonDescription { get; set; }

    [JsonPropertyName("created_at")] public DateTime? CreatedAt { get; set; }


    [JsonPropertyName("uid")] public string? Uid { get; set; }


    public List<Exercise>? Exercises { get; set; }
}