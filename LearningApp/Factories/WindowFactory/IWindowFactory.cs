using Avalonia.Controls;

namespace LearningApp.Factories.WindowFactory;

public interface IWindowFactory
{
    Window CreateCourseDetailsWindow();
    Window CreateExerciseDetailsWindow();

    Window CreateChangeProfileView();
    Window CreateChangePasswordView();

    Window CreateAddDictionaryView();
}