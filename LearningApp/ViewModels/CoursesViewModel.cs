using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models;
using LearningApp.Utils;

namespace LearningApp.ViewModels;

public partial class CoursesViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<Course> _items = [];

    public CoursesViewModel()
    {
        PageName = AppPageNames.Courses;
        Items =
        [
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
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
                    }
                ]
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            },
            new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
            }
        ];
    }
}