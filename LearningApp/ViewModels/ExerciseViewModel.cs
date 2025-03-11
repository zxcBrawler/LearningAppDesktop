using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.DataSource;
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

    #region UserExerciseAnswers

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SubmitAnswerCommand))]
    private string? _userTextAnswer;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SubmitMultipleAnswerCommand))]
    private int? _selectedAnswerIndex;

    [ObservableProperty] private bool _selectedTrueFalseAnswer;

    #endregion


    public ExerciseViewModel(ExerciseViewFactory exerciseViewFactory, ExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
        _exerciseViewFactory = exerciseViewFactory;
        IsActive = true;
        Items =
        [
            new Lesson
            {
                LessonName = "Beginners",
                LessonDescription = "Beginners course covering basic grammar rules.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UID = "0000000001",
                Exercises =
                [
                    new Exercise
                    {
                        QuestionName = "What is the english translation for russian word КОШКА?",
                        QuestionText = "What is the english translation for russian word КОШКА?",
                        TypeExercise = new Models.TypeExercise
                        {
                            ExerciseTypeName = TypeExercise.TextAnswer
                        },
                        TextAnswerExercise = new TextAnswerExercise
                        {
                            CaseSensitive = false,
                            ExpectedAnswer = "cat",
                            Hint = "мяу"
                        }
                    },
                    new Exercise
                    {
                        QuestionName = "Define if current statement is True/False",
                        QuestionText = "Does CAT means КОШКА?",
                        TypeExercise = new Models.TypeExercise
                        {
                            ExerciseTypeName = TypeExercise.TrueFalse
                        },
                        TrueFalseExercise = new TrueFalseExercise
                        {
                            IsTrue = true
                        }
                    },
                    new Exercise
                    {
                        QuestionName = "What is the right translation for word CAT?",
                        QuestionText = "What is the right translation for word CAT?",
                        TypeExercise = new Models.TypeExercise
                        {
                            ExerciseTypeName = TypeExercise.MultipleChoice
                        },
                        MultipleChoiceExercise = new MultipleChoiceExercise
                        {
                            CorrectAnswerIndex = 1,
                            Options =
                            [
                                new Option
                                {
                                    Text = "СОБАКА"
                                },
                                new Option
                                {
                                    Text = "КОШКА"
                                },
                                new Option
                                {
                                    Text = "КРЫСА"
                                },
                                new Option
                                {
                                    Text = "МЫШЬ"
                                }
                            ]
                        }
                    }
                ]
            }
        ];
        CurrentLesson = Items[0];
        CurrentExercise = Items[0].Exercises?[0];
        TotalExercises = Items[0].Exercises.Count;
        UpdateCurrentExerciseView();
    }

    private void UpdateCurrentExerciseView()
    {
        if (CurrentExercise.TypeExercise != null)
            CurrentExerciseView =
                _exerciseViewFactory.CurrentExerciseView(CurrentExercise.TypeExercise.ExerciseTypeName);
    }


    public async Task LoadLessonsWithExercises()
    {
        var lessonsWithExercises = await _exerciseService.GetLessonsWithExercisesAsync();
    }

    #region ExercisesControl

    private bool CanSubmit => !string.IsNullOrEmpty(UserTextAnswer);

    private bool CanSubmitMultipleAnswer => SelectedAnswerIndex >= 0;


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


    [RelayCommand(CanExecute = nameof(CanSubmitMultipleAnswer))]
    private void SubmitMultipleAnswer()
    {
        SubmitAnswer();
    }


    [RelayCommand]
    private void TryAgain()
    {
    }


    private bool CheckAnswer()
    {
        var currentExerciseType = CurrentExercise.TypeExercise.ExerciseTypeName;
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
        return UserTextAnswer == CurrentExercise.TextAnswerExercise.ExpectedAnswer &&
               !CurrentExercise.TextAnswerExercise.CaseSensitive;
    }

    private bool CheckTrueFalseExercise(string exerciseTypeName)
    {
        if (exerciseTypeName != TypeExercise.TrueFalse.ToString()) return false;
        return SelectedTrueFalseAnswer == CurrentExercise.TrueFalseExercise.IsTrue;
    }

    private bool CheckMultipleChoiceExercise(string exerciseTypeName)
    {
        if (exerciseTypeName != TypeExercise.MultipleChoice.ToString()) return false;
        return SelectedAnswerIndex == CurrentExercise.MultipleChoiceExercise.CorrectAnswerIndex;
    }

    [RelayCommand]
    private void GoToNextExercise()
    {
        var currentIndex = CurrentLesson.Exercises.IndexOf(CurrentExercise);
        if (currentIndex < CurrentLesson.Exercises.Count - 1)
        {
            CurrentExercise = CurrentLesson.Exercises[currentIndex + 1];
            UpdateCurrentExerciseView();
        }
        else
        {
        }
    }

    #endregion
}