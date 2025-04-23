using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;
using LearningApp.Utils.StateService;
using CourseStateService = LearningApp.Utils.StateService.CourseStateService;

namespace LearningApp.ViewModels;

public partial class CourseDetailsViewModel : ViewModelBase
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

    private readonly IExerciseService _exerciseService;

    [ObservableProperty] private CourseStateService _courseStateService;
    [ObservableProperty] private UserStateService _userStateService;
    private readonly IWindowFactory _windowFactory;

    public CourseDetailsViewModel(CourseStateService courseStateService,
        IWindowFactory windowFactory, IExerciseService exerciseService, UserStateService userStateService)
    {
        _courseStateService = courseStateService;
        _windowFactory = windowFactory;
        _exerciseService = exerciseService;
        _userStateService = userStateService;
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
        await StartCourse();
        await UserStateService.LoadUserCourses();
        await CourseStateService.LoadCourses();
        window.Close();
        _windowFactory.Show(AppWindowNames.ExerciseWindow);
    }

    private async Task StartCourse()
    {
        await _exerciseService.StartNewCourse(CourseStateService.Course.Id);
        await UserStateService.LoadUserCourse(CourseStateService.Course.Id);
    }

    public bool IsLessonsNotNull =>
        CourseStateService.Course.Lesson != null && CourseStateService.Course.Lesson.Count != 0;
}