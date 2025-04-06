using System;
using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete docs
/// <summary>
/// The lesson simple dto class
/// </summary>
public class LessonSimpleDto
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("lesson_name")]
    public string? LessonName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("lesson_description")]
    public string? LessonDescription { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; init; }
}