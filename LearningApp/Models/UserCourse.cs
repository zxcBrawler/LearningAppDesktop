using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class UserCourse
{
    [JsonPropertyName("user")] public User? User { get; set; }

    [JsonPropertyName("course")] public Course? Course { get; init; }

    [JsonPropertyName("is_finished")] public bool IsFinished { get; set; }

    [JsonPropertyName("course_progress")] public float CourseProgress { get; set; }
}