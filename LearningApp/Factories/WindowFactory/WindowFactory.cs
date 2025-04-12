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
        var view = new CourseDetailsView
        {
            DataContext = windowViewModelFactory.CreateCourseDetailsViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        return view;
    }

    public Window CreateExerciseDetailsWindow()
    {
        var view = new ExerciseView
        {
            DataContext = windowViewModelFactory.CreateExerciseViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        return view;
    }

    public Window CreateChangeProfileView()
    {
        var view = new ChangeProfileDataView()
        {
            DataContext = windowViewModelFactory.CreateChangeProfileDataViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        return view;
    }

    public Window CreateChangePasswordView()
    {
        var view = new ChangePasswordView()
        {
            DataContext = windowViewModelFactory.CreateChangePasswordViewModel(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        return view;
    }
}