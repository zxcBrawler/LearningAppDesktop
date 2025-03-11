using System.Collections.Generic;

namespace LearningApp.Models;

public class TypeExercise
{
    public int Id { get; set; }

    public Utils.TypeExercise ExerciseTypeName { get; set; }

    public string? ExerciseTypeDescription { get; set; }
}