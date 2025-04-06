using System;
using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete doc
/// <summary>
/// 
/// </summary>
public class CourseSimpleDto
{
    /// <summary>
    /// 
    /// </summary>
    public long Id { get; init; }


    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("course_name")]
    public string? CourseName { get; init; }


    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("course_description")]
    public string? CourseDescription { get; init; }


    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("course_language_level")]
    public string? CourseLanguageLevel { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("is_archived")]
    public bool IsArchived { get; init; }

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }
}