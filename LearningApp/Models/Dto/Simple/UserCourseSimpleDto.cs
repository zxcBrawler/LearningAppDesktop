using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete docs
/// <summary>
/// The user course simple dto class
/// </summary>
public class UserCourseSimpleDto
{
    [JsonPropertyName("user_id")] public long UserId { get; init; }

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("course_id")]
    public long CourseId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("course")]
    public CourseSimpleDto? Course { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("is_finished")]
    public bool IsFinished { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("course_progress")]
    public float CourseProgress { get; set; }

    [JsonPropertyName("total_lessons")] public int TotalLessons { get; set; }
    [JsonPropertyName("current_lesson")] public int CurrentLesson { get; set; }
}