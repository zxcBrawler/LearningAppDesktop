using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete docs
/// <summary>
/// The user course simple dto class
/// </summary>
public class UserCourseSimpleDto
{
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
}