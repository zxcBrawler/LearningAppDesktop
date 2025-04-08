using Avalonia.Controls;
using LearningApp.Models;

namespace LearningApp.Factories;

public interface INavigationFactory
{
    Window CreateCourseDetailsWindow();
    Window CreateExerciseDetailsWindow();
}