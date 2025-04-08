using Avalonia.Controls;
using LearningApp.Views;

namespace LearningApp.Factories;

public class NavigationFactory(
    ICourseViewModelFactory vmFactory,
    IExerciseViewModelFactory exerciseViewModelFactory)
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
}