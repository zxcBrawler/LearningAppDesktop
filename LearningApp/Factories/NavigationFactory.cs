using Avalonia.Controls;
using LearningApp.Factories.IFactories;
using LearningApp.Views;

namespace LearningApp.Factories;

public class NavigationFactory(
    ICourseViewModelFactory vmFactory,
    IExerciseViewModelFactory exerciseViewModelFactory,
    IChangeProfileViewModelFactory changeProfileViewModelFactory,
    IChangePasswordViewModelFactory changePasswordViewModelFactory)
    : INavigationFactory
{
    public Window CreateCourseDetailsWindow()
    {
        var view = new CourseDetailsView
        {
            DataContext = vmFactory.Create(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        return view;
    }

    public Window CreateExerciseDetailsWindow()
    {
        var view = new ExerciseView
        {
            DataContext = exerciseViewModelFactory.Create(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        return view;
    }

    public Window CreateChangeProfileView()
    {
        var view = new ChangeProfileDataView()
        {
            DataContext = changeProfileViewModelFactory.Create(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        return view;
    }

    public Window CreateChangePasswordView()
    {
        var view = new ChangePasswordView()
        {
            DataContext = changePasswordViewModelFactory.Create(),
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        return view;
    }
}