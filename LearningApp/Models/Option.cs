namespace LearningApp.Models;

public class Option
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public MultipleChoiceExercise? MultipleChoiceExercise { get; set; }
}