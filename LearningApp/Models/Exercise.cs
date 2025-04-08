using System;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class Exercise
{
    public int Id { get; set; }
    [JsonPropertyName("question_name")] public string? QuestionName { get; set; }

    [JsonPropertyName("question_description")]
    public string? QuestionText { get; set; }

    [JsonPropertyName("xp_reward")] public int XpReward { get; set; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

    [JsonPropertyName("type_exercise")] public TypeExercise? TypeExercise { get; set; }

    [JsonPropertyName("multiple_choice_exercise")]
    public MultipleChoiceExercise? MultipleChoiceExercise { get; set; }

    [JsonPropertyName("text_answer_exercise")]
    public TextAnswerExercise? TextAnswerExercise { get; set; }

    [JsonPropertyName("true_false_exercise")]
    public TrueFalseExercise? TrueFalseExercise { get; set; }
}