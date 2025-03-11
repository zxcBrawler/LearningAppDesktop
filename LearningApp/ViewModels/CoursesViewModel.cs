using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.Utils;
using LearningApp.Views;
using Avalonia.VisualTree;
using LearningApp.Factories;

namespace LearningApp.ViewModels;

public partial class CoursesViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<Course> _items = [];
    private readonly Func<Window> _mainWindowGetter;

    public CoursesViewModel(Func<Window> mainWindowGetter)
    {
        _mainWindowGetter = mainWindowGetter;
        PageName = AppPageNames.Courses;
        Items =
        [
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "A1",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg",
                Lesson =
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
                                QuestionName = "Select correct words",
                                QuestionText = "Select correct words",
                                TypeExercise = new TypeExercise
                                {
                                    ExerciseTypeName = "TextExercise"
                                },
                                TextAnswerExercise = new TextAnswerExercise
                                {
                                    CaseSensitive = false,
                                    ExpectedAnswer = "123",
                                    Hint = "1 ... 3"
                                }
                            }
                        ]
                    },
                    new Lesson
                    {
                        LessonName = "Beginners",
                        LessonDescription = "Beginners course covering basic grammar rules.",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UID = "0000000002",
                        Exercises =
                        [
                            new Exercise
                            {
                                QuestionName = "Select correct words",
                                QuestionText = "Select correct words",
                                TypeExercise = new TypeExercise
                                {
                                    ExerciseTypeName = "TextExercise"
                                },
                                TextAnswerExercise = new TextAnswerExercise
                                {
                                    CaseSensitive = false,
                                    ExpectedAnswer = "123",
                                    Hint = "1 ... 3"
                                }
                            }
                        ]
                    },
                    new Lesson
                    {
                        LessonName = "Beginners",
                        LessonDescription = "Beginners course covering basic grammar rules.",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UID = "0000000003",
                        Exercises =
                        [
                            new Exercise
                            {
                                QuestionName = "Select correct words",
                                QuestionText = "Select correct words",
                                TypeExercise = new TypeExercise
                                {
                                    ExerciseTypeName = "TextExercise"
                                },
                                TextAnswerExercise = new TextAnswerExercise
                                {
                                    CaseSensitive = false,
                                    ExpectedAnswer = "123",
                                    Hint = "1 ... 3"
                                }
                            }
                        ]
                    }
                ]
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "A2",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "B1",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "B2",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "C1",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "C1",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            }
        ];
    }

    [RelayCommand]
    private async Task OpenPopUpCourseDetails(Course course)
    {
        var courseDetailsViewModel = new CourseDetailsViewModel(course);
        var courseDetailsView = new CourseDetailsView
        {
            DataContext = courseDetailsViewModel
        };

        await courseDetailsView.ShowDialog(_mainWindowGetter());
    }
}