using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories;
using LearningApp.Models;
using LearningApp.Service;
using TypeExercise = LearningApp.Utils.TypeExercise;

namespace LearningApp.ViewModels;

public partial class ExerciseViewModel : ViewModelBase
{
    private readonly ExerciseViewFactory _exerciseViewFactory;
    private readonly ExerciseService _exerciseService;
    [ObservableProperty] private ObservableCollection<Lesson> _items = [];
    [ObservableProperty] private Lesson _currentLesson;
    [ObservableProperty] private Exercise _currentExercise;
    [ObservableProperty] private UserControl _currentExerciseView;
    [ObservableProperty] private int _totalExercises;
    [ObservableProperty] private int _completedExercises;
    [ObservableProperty] private int _userAttempts;

    #region UserExerciseAnswers

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SubmitAnswerCommand))]
    private string? _userTextAnswer;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SubmitAnswerCommand))]
    private int? _selectedAnswerIndex;

    [ObservableProperty] private bool _selectedTrueFalseAnswer;

    #endregion

    public ExerciseViewModel(ExerciseViewFactory exerciseViewFactory, ExerciseService exerciseService,
        ObservableCollection<Lesson> lesson)
    {
        _exerciseService = exerciseService;
        _exerciseViewFactory = exerciseViewFactory;
        IsActive = true;
        Items = lesson;
        CurrentLesson = Items[0];
        CurrentExercise = Items[0].Exercises![0];
        TotalExercises = Items[0].Exercises!.Count;

        CurrentExerciseView = UpdateCurrentExerciseView();
    }


    #region ExercisesControl

    [RelayCommand(CanExecute = nameof(CanSubmit))]
    private void SubmitAnswer()
    {
        if (CheckAnswer())
        {
            GoToNextExercise();
            CompletedExercises++;
        }
        else
        {
            TryAgain();
        }
    }

    [RelayCommand]
    private void SubmitTrueAnswer()
    {
        SelectedTrueFalseAnswer = true;
        SubmitAnswer();
    }

    [RelayCommand]
    private void SubmitFalseAnswer()
    {
        SelectedTrueFalseAnswer = false;
        SubmitAnswer();
    }


    [RelayCommand]
    private void TryAgain()
    {
        Console.WriteLine("Try again");
    }


    private bool CheckAnswer()
    {
        var currentExerciseType = CurrentExercise.TypeExercise!.ExerciseTypeName;
        return currentExerciseType switch
        {
            TypeExercise.MultipleChoice => CheckMultipleChoiceExercise(currentExerciseType.ToString()),
            TypeExercise.TrueFalse => CheckTrueFalseExercise(currentExerciseType.ToString()),
            TypeExercise.TextAnswer => CheckTextAnswerExercise(currentExerciseType.ToString()),
            _ => false
        };
    }

    private bool CheckTextAnswerExercise(string exerciseTypeName)
    {
        if (exerciseTypeName != TypeExercise.TextAnswer.ToString()) return false;

        if (CurrentExercise.TextAnswerExercise!.CaseSensitive)
        {
            if (UserTextAnswer != CurrentExercise.TextAnswerExercise.ExpectedAnswer) return false;
        }
        else if (!string.Equals(UserTextAnswer, CurrentExercise.TextAnswerExercise.ExpectedAnswer,
                     StringComparison.CurrentCultureIgnoreCase))

        {
            return false;
        }

        UserTextAnswer = null;
        return true;
    }

    private bool CheckTrueFalseExercise(string exerciseTypeName)
    {
        if (exerciseTypeName != TypeExercise.TrueFalse.ToString()) return false;
        return SelectedTrueFalseAnswer == CurrentExercise.TrueFalseExercise!.IsTrue;
    }

    private bool CheckMultipleChoiceExercise(string exerciseTypeName)
    {
        if (exerciseTypeName != TypeExercise.MultipleChoice.ToString()) return false;
        if (SelectedAnswerIndex != CurrentExercise.MultipleChoiceExercise!.CorrectAnswerIndex) return false;
        SelectedAnswerIndex = -1;
        return true;
    }

    [RelayCommand]
    private void GoToNextExercise()
    {
        var currentIndex = CurrentLesson.Exercises!.IndexOf(CurrentExercise);
        if (currentIndex < CurrentLesson.Exercises.Count - 1)
        {
            CurrentExercise = CurrentLesson.Exercises[currentIndex + 1];
            CurrentExerciseView = UpdateCurrentExerciseView();
        }
        else
        {
        }
    }

    // TODO

    [RelayCommand]
    private void StopLesson()
    {
    }

    #endregion


    #region View Controls

    private UserControl UpdateCurrentExerciseView()
    {
        return CurrentExercise.TypeExercise != null
            ? _exerciseViewFactory.CurrentExerciseView(CurrentExercise.TypeExercise.ExerciseTypeName)
            : throw new NotImplementedException();
    }

    #endregion


    #region Command Handlers

    private bool CanSubmit => !string.IsNullOrEmpty(UserTextAnswer) || SelectedAnswerIndex >= 0;

    #endregion
}