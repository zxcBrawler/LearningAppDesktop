using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class TrueFalseExercise
{
    [JsonPropertyName("answer_value")] public bool AnswerValue { get; set; }
}