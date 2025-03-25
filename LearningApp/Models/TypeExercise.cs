using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class TypeExercise
{
    public int Id { get; set; }

    [JsonPropertyName("exercise_Type_Name")]
    public Utils.Enum.TypeExercise ExerciseTypeName { get; set; }

    [JsonPropertyName("exercise_Type_Description")]

    public string? ExerciseTypeDescription { get; set; }
}