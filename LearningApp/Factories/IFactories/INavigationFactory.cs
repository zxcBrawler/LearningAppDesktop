using Avalonia.Controls;

namespace LearningApp.Factories.IFactories;

public interface INavigationFactory
{
    Window CreateCourseDetailsWindow();
    Window CreateExerciseDetailsWindow();

    Window CreateChangeProfileView();
    Window CreateChangePasswordView();
}