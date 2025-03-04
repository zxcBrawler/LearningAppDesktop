using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models;
using LearningApp.Utils;

namespace LearningApp.ViewModels;

public partial class HomeViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<UserCourse> _userCourses;

    public HomeViewModel()
    {
        PageName = AppPageNames.Home;
        UserCourses =
        [
            new UserCourse
            {
                Course = new Course
                {
                    CourseName = "English Grammar for Beginners",
                    CourseDescription = "A comprehensive course covering basic English grammar rules.",
                    CourseLanguageLevel = "Beginner",
                    ImageUrl =
                        "https://t4.ftcdn.net/jpg/02/25/31/89/360_F_225318919_klpkRFyiJjxWdwLptzfeCX2Bo6QsBndm.jpg"
                },
                CourseProgress = 90,
                IsFinished = false
            },
            new UserCourse
            {
                Course = new Course
                {
                    CourseName = "English Grammar for Beginners",
                    CourseDescription = "A comprehensive course covering basic English grammar rules.",
                    CourseLanguageLevel = "Beginner",
                    ImageUrl =
                        "https://images.unsplash.com/photo-1565022536102-f7645c84354a?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8ZW5nbGlzaCUyMGJvb2tzfGVufDB8fDB8fHww"
                },
                CourseProgress = 5,
                IsFinished = false
            }
        ];
    }
}