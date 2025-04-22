using Avalonia.Controls;
using LearningApp.Factories.WindowViewModelFactoryImpl;
using LearningApp.Views;

namespace LearningApp.Factories.WindowFactory;

public class WindowFactory(
    IWindowViewModelFactory windowViewModelFactory)
    : IWindowFactory
{
    public Window CreateCourseDetailsWindow()
    {
        return new CourseDetailsView
        {
            DataContext = windowViewModelFactory.CreateCourseDetailsViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
    }

    public Window CreateExerciseDetailsWindow()
    {
        return new ExerciseView
        {
            DataContext = windowViewModelFactory.CreateExerciseViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
    }

    public Window CreateChangeProfileView()
    {
        return new ChangeProfileDataView
        {
            DataContext = windowViewModelFactory.CreateChangeProfileDataViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
    }

    public Window CreateChangePasswordView()
    {
        return new ChangePasswordView
        {
            DataContext = windowViewModelFactory.CreateChangePasswordViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
    }

    public Window CreateAddDictionaryView()
    {
        return new AddDictionaryView
        {
            DataContext = windowViewModelFactory.CreateAddDictionaryViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
    }

    public Window CreateWordDetailsWindow()
    {
        return new WordDetailsView
        {
            DataContext = windowViewModelFactory.CreateWordDetailsViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
    }
}