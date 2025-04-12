using System;
using Avalonia.Controls;

namespace LearningApp.Factories;

public class ExerciseViewFactory(Func<string, UserControl> factory)
{
    public UserControl CurrentExerciseView(string typeExercise)
    {
        return factory.Invoke(typeExercise);
    }
}