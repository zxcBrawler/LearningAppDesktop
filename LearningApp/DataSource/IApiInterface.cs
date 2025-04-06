using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.Models;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;
using LearningApp.Models.Dto.Simple;
using Refit;

namespace LearningApp.DataSource;

public interface IApiInterface
{
    #region Courses/Lessons/Exercises

    [Get("/api/Courses")]
    public Task<List<Course>> GetCoursesAsync();

    [Get("/api/Courses/{courseId}")]
    public Task<Course> GetCourseByIdAsync(int courseId);

    [Get("/api/UserActions/GetUserCourses")]
    public Task<List<UserCourseSimpleDto>> GetUserCoursesAsync();

    [Post("/api/UserCourses")]
    public Task<UserCourse> PostUserCourse(UserCourse userCourse);

    [Get("/api/Lesson")]
    public Task<List<Lesson>> GetLessonsAsync();

    #endregion


    #region Authentication

    [Post("/api/Authorization/Login")]
    public Task<LoginResponse> Login([Body] LoginRequestDto loginRequestDto);

    [Post("/api/Authorization/LogOut")]
    public Task<string> LogOut();

    [Post("/api/Authorization/Register")]
    public Task<DataState<string>> RegisterAsync(RegisterRequestDto registerRequestDto);

    [Post("/api/Authorization/RefreshToken")]
    public Task<TokenResponse> RefreshToken(RefreshTokenRequestDto refreshTokenRequestDto);

    #endregion
}