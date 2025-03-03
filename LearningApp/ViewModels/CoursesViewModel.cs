using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models;
using LearningApp.Utils;

namespace LearningApp.ViewModels;

public partial class CoursesViewModel : PageViewModel
{
    
    [ObservableProperty]
    private ObservableCollection<Course> _items = [];
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
                ImageUrl = "/Assets/Images/grammar_course.png",
               
            }, new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
                ImageUrl = "/Assets/Images/grammar_course.png",
               
            }, new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
                ImageUrl = "/Assets/Images/grammar_course.png",
               
            }, new Course
            {
                CourseName = "English Grammar for Beginners",
                CourseDescription = "A comprehensive course covering basic English grammar rules.",
                CourseLanguageLevel = "Beginner",
                ImageUrl = "/Assets/Images/grammar_course.png",
               
            },
            new Course
            {
                CourseName = "Conversational English",
                CourseDescription = "Improve your spoken English skills with interactive exercises.",
                CourseLanguageLevel = "Intermediate",
                ImageUrl = "/Assets/Images/speaking_course.png",
               
            }
        ];
    }
}