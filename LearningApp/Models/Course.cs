using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class Course
{
    public int Id { get; set; }

    [JsonPropertyName("course_Name")] public string? CourseName { get; set; }

    [JsonPropertyName("course_Description")]
    public string? CourseDescription { get; set; }

    [JsonPropertyName("course_Language_Level")]
    public string? CourseLanguageLevel { get; set; }

    [JsonPropertyName("is_Archived")] public bool IsArchived { get; set; }

    [JsonPropertyName("image_URL")] public string? ImageUrl { get; set; }

    [JsonPropertyName("created_At")] public DateTime CreatedAt { get; set; }

    [JsonPropertyName("lesson")] public List<Lesson>? Lesson { get; set; }
}