﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories;
using LearningApp.Models.Dto.Complex;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;
using LearningApp.Utils.StateService;
using CourseStateService = LearningApp.Utils.StateService.CourseStateService;
using TypeExercise = LearningApp.Utils.Enum.TypeExercise;

namespace LearningApp.ViewModels;

public partial class ExerciseViewModel : ViewModelBase
{
    private readonly ExerciseViewFactory _exerciseViewFactory;
    private readonly IExerciseService _exerciseService;
    [ObservableProperty] private ObservableCollection<LessonComplexDto> _items = [];
    [ObservableProperty] private LessonComplexDto _currentLesson;
    [ObservableProperty] private ExerciseComplexDto _currentExercise;
    [ObservableProperty] private UserControl _currentExerciseView;
    [ObservableProperty] private CourseStateService _courseStateService;
    [ObservableProperty] private UserStateService _userStateService;

    #region Current Lesson Props

    [ObservableProperty] private int _totalExercises;
    [ObservableProperty] private int _completedExercises;
    [ObservableProperty] private int _userAttempts = 3;
    [ObservableProperty] private bool _isUserFailed;

    #endregion

    #region User Exercise Answers

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SubmitAnswerCommand))]
    private string _userTextAnswer = string.Empty;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SubmitAnswerCommand))]
    private int _selectedAnswerIndex = -1;

    [ObservableProperty] private bool _selectedTrueFalseAnswer;

    #endregion

    public ExerciseViewModel(ExerciseViewFactory exerciseViewFactory, IExerciseService exerciseService,
        CourseStateService courseStateService, UserStateService userStateService)
    {
        _exerciseService = exerciseService;
        _courseStateService = courseStateService;
        _userStateService = userStateService;
        _exerciseViewFactory = exerciseViewFactory;
        IsActive = true;
    }

    #region ExercisesControl

    [RelayCommand]
    private void WindowLoaded()
    {
        Items = new ObservableCollection<LessonComplexDto>(CourseStateService.Course.Lesson);
        CurrentLesson = Items[UserStateService.CurrentUserCourse.CurrentLesson - 1];
        CurrentExercise = CurrentLesson.Exercises[0];
        TotalExercises = CurrentLesson.Exercises.Count;
        CurrentExerciseView = UpdateCurrentExerciseView();
    }

    [RelayCommand]
    private void SelectAnswer(OptionSimpleDto option)
    {
        SelectedAnswerIndex = CurrentExercise.MultipleChoiceExercise.Options.IndexOf(option);
        foreach (var opt in CurrentExercise.MultipleChoiceExercise.Options)
        {
            opt.IsSelected = (opt == option);
        }
    }

    [RelayCommand(CanExecute = nameof(CanSubmit))]
    private async Task SubmitAnswer()
    {
        if (CheckAnswer())
        {
            await GoToNextExercise();
            CompletedExercises++;
        }
        else
        {
            TryAgain();
        }
    }

    [RelayCommand]
    private async Task SubmitTrueAnswer()
    {
        SelectedTrueFalseAnswer = true;
        await SubmitAnswer();
    }

    [RelayCommand]
    private async Task SubmitFalseAnswer()
    {
        SelectedTrueFalseAnswer = false;
        await SubmitAnswer();
    }

    [RelayCommand]
    private void TryAgain()
    {
        if (UserAttempts > 0)
            UserAttempts--;
        if (UserAttempts == 0)
        {
            IsUserFailed = true;
        }

        Console.WriteLine(@"Try again");
    }

    [RelayCommand]
    private async Task GoToNextExercise()
    {
        var currentIndex = CurrentLesson.Exercises.IndexOf(CurrentExercise);
        if (currentIndex < CurrentLesson.Exercises.Count - 1)
        {
            CurrentExercise = CurrentLesson.Exercises[currentIndex + 1];
            CurrentExerciseView = UpdateCurrentExerciseView();
        }
        else
        {
            await _exerciseService.CompleteLesson(CourseStateService.Course.Id, UserAttempts);
            UserStateService.CurrentUserCourse = null;
            CourseStateService.Course = null;
            await UserStateService.LoadUserCourses();
            await UserStateService.ReloadUserAsync();
        }
    }

    #endregion


    #region Answers Handling

    private bool CheckAnswer()
    {
        var currentExerciseType = CurrentExercise.TypeExercise.ExerciseTypeName;
        return currentExerciseType switch
        {
            "MultipleChoice" => CheckMultipleChoiceExercise(currentExerciseType),
            "TrueFalse" => CheckTrueFalseExercise(currentExerciseType),
            "Text" => CheckTextAnswerExercise(currentExerciseType),
            _ => false
        };
    }

    private bool CheckTextAnswerExercise(string exerciseTypeName)
    {
        if (exerciseTypeName != TypeExercise.Text.ToString()) return false;

        if (CurrentExercise.TextAnswerExercise!.CaseSensitive)
        {
            if (UserTextAnswer != CurrentExercise.TextAnswerExercise.ExpectedAnswer) return false;
        }
        else if (!string.Equals(UserTextAnswer, CurrentExercise.TextAnswerExercise.ExpectedAnswer,
                     StringComparison.CurrentCultureIgnoreCase))

        {
            return false;
        }

        UserTextAnswer = string.Empty;
        return true;
    }

    private bool CheckTrueFalseExercise(string exerciseTypeName)
    {
        if (exerciseTypeName != TypeExercise.TrueFalse.ToString()) return false;
        return SelectedTrueFalseAnswer == CurrentExercise.TrueFalseExercise!.AnswerValue;
    }

    private bool CheckMultipleChoiceExercise(string exerciseTypeName)
    {
        if (exerciseTypeName != TypeExercise.MultipleChoice.ToString()) return false;
        if (SelectedAnswerIndex != CurrentExercise.MultipleChoiceExercise!.CorrectAnswerIndex) return false;
        SelectedAnswerIndex = -1;
        return true;
    }

    #endregion


    #region View Controls

    private UserControl UpdateCurrentExerciseView()
    {
        return _exerciseViewFactory.CurrentExerciseView(CurrentExercise.TypeExercise.ExerciseTypeName);
    }

    #endregion


    #region Command Handlers

    private bool CanSubmit => !string.IsNullOrEmpty(UserTextAnswer) || SelectedAnswerIndex >= 0;

    #endregion
}