using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class TypeExercise
{
    public int Id { get; set; }

    [JsonPropertyName("exercise_type_name")]
    public string? ExerciseTypeName { get; set; }

    [JsonPropertyName("exercise_type_description")]

    public string? ExerciseTypeDescription { get; set; }
}