using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class MultipleChoiceExercise
{
    public List<Option>? Options { get; set; }

    [JsonPropertyName("correct_answer_index")]
    public int CorrectAnswerIndex { get; set; }
}