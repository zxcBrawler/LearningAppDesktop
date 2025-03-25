using System;
using Avalonia.Controls;
using LearningApp.Utils;
using LearningApp.Utils.Enum;

namespace LearningApp.Factories;

public class ExerciseViewFactory(Func<TypeExercise, UserControl> factory)
{
    public UserControl CurrentExerciseView(TypeExercise typeExercise)
    {
        return factory.Invoke(typeExercise);
    }
}