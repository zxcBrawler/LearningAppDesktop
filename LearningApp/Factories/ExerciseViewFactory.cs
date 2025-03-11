using System;
using Avalonia.Controls;
using LearningApp.Utils;

namespace LearningApp.Factories;

public class ExerciseViewFactory(Func<TypeExercise, UserControl> factory)
{
    public UserControl CurrentExerciseView(TypeExercise typeExercise)
    {
        return factory.Invoke(typeExercise);
    }
}