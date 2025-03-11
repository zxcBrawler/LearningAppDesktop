using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class UserCourse
{
    public User? User { get; set; }

    public Course? Course { get; set; }

    [JsonPropertyName("isFinished")] public bool IsFinished { get; set; }

    [JsonPropertyName("course_Progress")] public float CourseProgress { get; set; }
}