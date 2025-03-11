using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.Models;
using Refit;

namespace LearningApp.DataSource;

public interface IApiInterface
{
    #region Courses

    [Get("/api/Course")]
    public Task<List<Course>> GetCoursesAsync();

    [Get("/api/Course/{courseId}")]
    public Task<List<Course>> GetCourseByIdAsync(int courseId);

    [Get("/api/UserCourses/{userId}")]
    public Task<List<UserCourse>> GetUserCoursesAsync(int userId);

    #endregion

    #region Authentication

    #endregion
}