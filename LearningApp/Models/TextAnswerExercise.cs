using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class TextAnswerExercise
{
    [JsonPropertyName("expected_answer")] public string? ExpectedAnswer { get; set; }
    [JsonPropertyName("case_sensitive")] public bool CaseSensitive { get; set; }

    [JsonPropertyName("hint")] public string? Hint { get; set; }
}