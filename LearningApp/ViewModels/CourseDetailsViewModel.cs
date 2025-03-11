using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.Utils;
using LearningApp.Views;

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


    private readonly Func<Window> _mainWindowGetter;

    public CourseDetailsViewModel(Course course, Func<Window> mainWindowGetter)
    {
        _mainWindowGetter = mainWindowGetter;
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

    [RelayCommand]
    private async Task OpenLessons(Window window)
    {
        var exerciseViewFactory = ServiceLocator.GetService<ExerciseViewFactory>();
        var exerciseService = ServiceLocator.GetService<ExerciseService>();
        var exerciseViewModel = new ExerciseViewModel(exerciseViewFactory, exerciseService);
        var courseDetailsView = new ExerciseView
        {
            DataContext = exerciseViewModel
        }; 
        window.Close();
        await courseDetailsView.ShowDialog(_mainWindowGetter());
        
    }
}