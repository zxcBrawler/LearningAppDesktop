using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.Utils;
using LearningApp.Utils.DependencyInjection;
using LearningApp.Views;

namespace LearningApp.ViewModels;

public partial class CourseDetailsViewModel : ViewModelBase
{
    private readonly ExerciseService? _exerciseService;
    [ObservableProperty] private Course _course;

    [ObservableProperty] private ObservableCollection<string> _segmentColors =
    [
        "#202125",
        "#202125",
        "#202125",
        "#202125",
        "#202125"
    ];


    private readonly Func<Window> _mainWindowGetter;

    public CourseDetailsViewModel(Course course, Func<Window> mainWindowGetter)
    {
        _mainWindowGetter = mainWindowGetter;
        _course = course;
        Course = _course;
        _exerciseService = ServiceLocator.GetService<ExerciseService>();
        UpdateSegmentColors();
    }

    private void UpdateSegmentColors()
    {
        for (var i = 0; i < SegmentColors.Count; i++) SegmentColors[i] = "#202125";
        if (!LevelColors.ColorMap.TryGetValue(Course.CourseLanguageLevel ?? "A1", out var color)) return;
        var index = Array.IndexOf(LevelColors.ColorMap.Keys.ToArray(), Course.CourseLanguageLevel);
        if (index >= 0) SegmentColors[index] = color;
    }

    [RelayCommand(CanExecute = nameof(IsLessonsNotNull))]
    private async Task OpenLessons(Window window)
    {
        var exerciseViewFactory = ServiceLocator.GetService<ExerciseViewFactory>();

        var exerciseViewModel = new ExerciseViewModel(exerciseViewFactory, _exerciseService,
            new ObservableCollection<Lesson>(Course.Lesson!));
        var courseDetailsView = new ExerciseView
        {
            DataContext = exerciseViewModel
        };
        // await StartCourse();
        window.Close();
        await courseDetailsView.ShowDialog(_mainWindowGetter());
    }

    private async Task StartCourse()
    {
        var userCourse = new UserCourse
        {
            Course = Course,
            // User = User, <--- save user auth data somewhere
            IsFinished = false,
            CourseProgress = 0
        };

        await _exerciseService?.StartNewCourse(userCourse)!;
    }


    public bool IsLessonsNotNull => Course.Lesson != null && Course.Lesson.Count != 0;
}