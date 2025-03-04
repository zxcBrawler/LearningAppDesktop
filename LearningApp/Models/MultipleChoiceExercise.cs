using System.Collections.Generic;

namespace LearningApp.Models;

public class MultipleChoiceExercise
{
    public List<Option>? Options { get; set; }
    public int CorrectAnswerIndex { get; set; }
}