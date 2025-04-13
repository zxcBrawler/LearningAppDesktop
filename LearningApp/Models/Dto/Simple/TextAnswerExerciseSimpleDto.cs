using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete docs
/// <summary>
/// The text answer exercise simple dto class
/// </summary>
public class TextAnswerExerciseSimpleDto
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("expected_answer")]
    public required string ExpectedAnswer { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("case_sensitive")]
    public bool CaseSensitive { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("hint")]
    public string? Hint { get; init; }
}