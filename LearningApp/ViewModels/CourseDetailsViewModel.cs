using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models;
using LearningApp.Utils;

namespace LearningApp.ViewModels;

public partial class CourseDetailsViewModel : ViewModelBase
{
    [ObservableProperty] private Course _course;

    [ObservableProperty] private ObservableCollection<string> _segmentColors =
    [
        "#202125",
        "#202125",
        "#202125",
        "#202125",
        "#202125"
    ];

    public CourseDetailsViewModel(Course course)
    {
        _course = course;
        Course = _course;
        UpdateSegmentColors();
    }

    private void UpdateSegmentColors()
    {
        for (var i = 0; i < SegmentColors.Count; i++) SegmentColors[i] = "#202125";
        if (!LevelColors.ColorMap.TryGetValue(Course.CourseLanguageLevel ?? "A1", out var color)) return;
        var index = Array.IndexOf(LevelColors.ColorMap.Keys.ToArray(), Course.CourseLanguageLevel);
        if (index >= 0) SegmentColors[index] = color;
    }
}