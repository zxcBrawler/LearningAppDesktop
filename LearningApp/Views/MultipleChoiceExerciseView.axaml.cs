using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using LearningApp.Models;
using LearningApp.ViewModels;

namespace LearningApp.Views;

public partial class MultipleChoiceExerciseView : UserControl
{
    public MultipleChoiceExerciseView()
    {
        InitializeComponent();
    }

    private void ToggleButton_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is not RadioButton radioButton) return;
        if (DataContext is not ExerciseViewModel viewModel) return;
        var selectedOption = (Option)radioButton.DataContext;
        if (selectedOption == null || radioButton.IsChecked != true) return;

        viewModel.SelectedAnswerIndex =
            viewModel.CurrentExercise.MultipleChoiceExercise.Options.IndexOf(selectedOption);
        Console.WriteLine(viewModel.SelectedAnswerIndex);
    }
}