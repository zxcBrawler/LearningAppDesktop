using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Factories;
using LearningApp.Factories.IFactories;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.Utils;
using LearningApp.Utils.DependencyInjection;
using LearningApp.Utils.Enum;
using LearningApp.Views;
using CourseStateService = LearningApp.Utils.StateService.CourseStateService;

namespace LearningApp.ViewModels;

public partial class CourseDetailsViewModel : PageViewModel
{
    private readonly ExerciseService? _exerciseService;

    [ObservableProperty] private CourseStateService _courseStateService;
    private readonly INavigationFactory _navigationFactory;

    [ObservableProperty] private ObservableCollection<string> _segmentColors =
    [
        "#202125",
        "#202125",
        "#202125",
        "#202125",
        "#202125"
    ];


    private readonly Func<Window> _mainWindowGetter;

    public CourseDetailsViewModel(Func<Window> mainWindowGetter, CourseStateService courseStateService,
        INavigationFactory navigationFactory, ExerciseService? exerciseService)
    {
        PageName = AppPageNames.CourseDetails;
        _mainWindowGetter = mainWindowGetter;
        _courseStateService = courseStateService;
        _navigationFactory = navigationFactory;
        _exerciseService = exerciseService;
        UpdateSegmentColors();
    }

    private void UpdateSegmentColors()
    {
        for (var i = 0; i < SegmentColors.Count; i++) SegmentColors[i] = "#202125";
        if (!LevelColors.ColorMap.TryGetValue(CourseStateService.Course.CourseLanguageLevel ?? "A1", out var color))
            return;
        var index = Array.IndexOf(LevelColors.ColorMap.Keys.ToArray(), CourseStateService.Course.CourseLanguageLevel);
        if (index >= 0) SegmentColors[index] = color;
    }

    [RelayCommand(CanExecute = nameof(IsLessonsNotNull))]
    private async Task OpenLessons(Window window)
    {
        var exerciseDetailsWindow = _navigationFactory.CreateExerciseDetailsWindow();
        window.Close();
        await exerciseDetailsWindow.ShowDialog(_mainWindowGetter());
    }

    private async Task StartCourse()
    {
        var userCourse = new UserCourse
        {
            Course = CourseStateService.Course,
            // User = User, <--- save user auth data somewhere
            IsFinished = false,
            CourseProgress = 0
        };

        await _exerciseService?.StartNewCourse(userCourse)!;
    }

    public bool IsLessonsNotNull =>
        CourseStateService.Course.Lesson != null && CourseStateService.Course.Lesson.Count != 0;
}