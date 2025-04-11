using Avalonia.Controls;
using LearningApp.Factories.IFactories;
using LearningApp.Views;

namespace LearningApp.Factories;

public class NavigationFactory(
    ICourseViewModelFactory vmFactory,
    IExerciseViewModelFactory exerciseViewModelFactory,
    IChangeProfileViewModelFactory changeProfileViewModelFactory)
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
}