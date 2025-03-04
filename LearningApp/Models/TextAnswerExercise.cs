namespace LearningApp.Models;

public class TextAnswerExercise
{
    public string? ExpectedAnswer { get; set; }
    public bool CaseSensitive { get; set; }
    public string? Hint { get; set; }
}