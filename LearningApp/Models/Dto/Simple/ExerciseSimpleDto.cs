using System;
using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete doc
/// <summary>
/// The exercise simple dto class
/// </summary>
public class ExerciseSimpleDto
{
    /// <summary>
    /// Gets or sets the value of the id
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("question_name")]
    public string? QuestionName { get; init; }

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("question_description")]
    public string? QuestionDescription { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("xp_reward")]
    public int XpReward { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("type_exercise")]
    public TypeExerciseSimpleDto? TypeExercise { get; init; }
}