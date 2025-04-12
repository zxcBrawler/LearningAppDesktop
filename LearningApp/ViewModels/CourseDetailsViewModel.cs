using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.Utils.Enum;
using CourseStateService = LearningApp.Utils.StateService.CourseStateService;

namespace LearningApp.ViewModels;

public partial class CourseDetailsViewModel : PageViewModel
{
    #region Level colors

    public const string DefaultColor = "#202125";
    public string[] LevelNames { get; } = ["A1", "A2", "B1", "B2", "C1"];

    private static readonly Dictionary<string, string> LevelColorMap = new()
    {
        ["A1"] = "#007700",
        ["A2"] = "#007700",
        ["B1"] = "#eb9800",
        ["B2"] = "#eb9800",
        ["C1"] = "#b30000"
    };

    [ObservableProperty] private ObservableCollection<string> _segmentColors = new(
        Enumerable.Repeat(DefaultColor, 5).ToList()
    );

    #endregion

    private readonly ExerciseService? _exerciseService;

    [ObservableProperty] private CourseStateService _courseStateService;
    private readonly IWindowFactory _windowFactory;

    private readonly Func<Window> _mainWindowGetter;

    public CourseDetailsViewModel(Func<Window> mainWindowGetter, CourseStateService courseStateService,
        IWindowFactory windowFactory, ExerciseService? exerciseService)
    {
        PageName = AppPageNames.CourseDetails;
        _mainWindowGetter = mainWindowGetter;
        _courseStateService = courseStateService;
        _windowFactory = windowFactory;
        _exerciseService = exerciseService;
        UpdateSegmentColors();
    }

    private void UpdateSegmentColors()
    {
        for (var i = 0; i < SegmentColors.Count; i++)
        {
            SegmentColors[i] = DefaultColor;
        }

        var currentLevel = CourseStateService.Course?.CourseLanguageLevel;
        if (string.IsNullOrEmpty(currentLevel) ||
            !LevelColorMap.TryGetValue(currentLevel, out var color)) return;
        var index = Array.IndexOf(LevelNames, currentLevel);
        if (index >= 0 && index < SegmentColors.Count)
        {
            SegmentColors[index] = color;
        }
    }

    [RelayCommand(CanExecute = nameof(IsLessonsNotNull))]
    private async Task OpenLessons(Window window)
    {
        var exerciseDetailsWindow = _windowFactory.CreateExerciseDetailsWindow();
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