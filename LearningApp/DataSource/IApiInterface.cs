using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.Models;
using Refit;

namespace LearningApp.DataSource;

public interface IApiInterface
{
    #region Courses/Lessons/Exercises

    [Get("/api/Courses")]
    public Task<List<Course>> GetCoursesAsync();

    [Get("/api/Courses/{courseId}")]
    public Task<Course> GetCourseByIdAsync(int courseId);

    [Get("/api/UserCourses/{userId}")]
    public Task<List<UserCourse>> GetUserCoursesAsync(int userId);

    [Post("/api/UserCourses")]
    public Task<UserCourse> PostUserCourse(UserCourse userCourse);

    [Get("/api/Lesson")]
    public Task<List<Lesson>> GetLessonsAsync();

    #endregion


    #region Authentication

    #endregion
}