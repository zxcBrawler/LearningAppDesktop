using System;

namespace LearningApp.Models;

public class Exercise
{
    public int Id { get; set; }
    public string? QuestionName { get; set; }

    public string? QuestionText { get; set; }

    public int XPReward { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public TypeExercise? TypeExercise { get; set; }
    public MultipleChoiceExercise? MultipleChoiceExercise { get; set; }
    public TextAnswerExercise? TextAnswerExercise { get; set; }
    public TrueFalseExercise? TrueFalseExercise { get; set; }
}