using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class UserCourse
{
    [JsonPropertyName("user_id")] public long UserId { get; set; }

    [JsonPropertyName("course_id")] public long CourseId { get; set; }
    [JsonPropertyName("user")] public User? User { get; init; }

    [JsonPropertyName("course")] public Course? Course { get; init; }

    [JsonPropertyName("is_finished")] public bool IsFinished { get; set; }

    [JsonPropertyName("course_progress")] public float CourseProgress { get; set; }
}