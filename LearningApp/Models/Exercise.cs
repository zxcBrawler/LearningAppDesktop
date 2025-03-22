using System;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class Exercise
{
    public int Id { get; set; }
    [JsonPropertyName("question_Name")] public string? QuestionName { get; set; }

    [JsonPropertyName("question_Text")] public string? QuestionText { get; set; }

    public int XPReward { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("typeExercise")] public TypeExercise? TypeExercise { get; set; }
    public MultipleChoiceExercise? MultipleChoiceExercise { get; set; }
    public TextAnswerExercise? TextAnswerExercise { get; set; }
    public TrueFalseExercise? TrueFalseExercise { get; set; }
}