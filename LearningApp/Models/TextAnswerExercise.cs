using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class TextAnswerExercise
{
    [JsonPropertyName("expected_Answer")] public string? ExpectedAnswer { get; set; }

    [JsonPropertyName("case_Sensitive")] public bool CaseSensitive { get; set; }
    public string? Hint { get; set; }
}