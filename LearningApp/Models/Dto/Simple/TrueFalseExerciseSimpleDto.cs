using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete docs
/// <summary>
/// The true false exercise simple dto class
/// </summary>
public class TrueFalseExerciseSimpleDto
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("answer_value")]
    public bool AnswerValue { get; set; }
}