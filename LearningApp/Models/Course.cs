using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class Course
{
    public int Id { get; set; }

    [JsonPropertyName("course_name")] public string? CourseName { get; set; }

    [JsonPropertyName("course_description")]
    public string? CourseDescription { get; set; }

    [JsonPropertyName("course_language_level")]
    public string? CourseLanguageLevel { get; set; }

    [JsonPropertyName("is_archived")] public bool IsArchived { get; set; }

    [JsonPropertyName("image_url")] public string? ImageUrl { get; set; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

    [JsonPropertyName("lesson")] public List<Lesson>? Lesson { get; set; }
}