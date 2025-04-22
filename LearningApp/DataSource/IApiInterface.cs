using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.Models.Dto.Complex;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;
using LearningApp.Models.Dto.Simple;
using Refit;

namespace LearningApp.DataSource;

public interface IApiInterface
{
    #region Courses/Lessons/Exercises

    [Get("/api/Courses/{courseId}")]
    public Task<CourseComplexDto> GetCourseByIdAsync(long courseId);

    #endregion

    #region UserActions

    [Get("/api/UserActions/GetUserCourses")]
    public Task<List<UserCourseSimpleDto>> GetUserCoursesAsync();

    [Get("/api/UserActions/GetUserProfile")]
    public Task<UserSimpleDto> GetUserProfile();

    [Get("/api/UserActions/GetUserDictionaries")]
    public Task<List<DictionarySimpleDto>> GetUserDictionaries();

    [Get("/api/UserActions/GetUserDictionaryById/{dictionaryId}")]
    public Task<DictionarySimpleDto> GetUserDictionaryById(int dictionaryId);

    [Post("/api/UserActions/AddNewDictionary")]
    public Task<DictionarySimpleDto> AddNewDictionary([Body] AddDictionaryRequestDto dictionaryRequestDto);

    [Delete("/api/UserActions/DeleteDictionary/{dictionaryId}")]
    public Task<bool> DeleteDictionary(int dictionaryId);

    [Put("/api/UserActions/UpdateProfileData")]
    Task<bool> UpdateUserProfile([Body] UpdateProfileRequestDto updateProfileRequestDto);

    [Put("/api/UserActions/UpdatePassword")]
    Task<bool> UpdateUserPassword([Body] UpdatePasswordRequestDto updateProfileRequestDto);

    [Post("/api/UserActions/UpdateTokens")]
    Task<LoginResponse> UpdateAllTokens([Body] RefreshTokenRequestDto refreshTokenRequestDto);

    [Post("/api/UserActions/StartCourse/{courseId}")]
    public Task<UserCourseSimpleDto> StartCourse(long courseId);

    [Post("/api/UserActions/CompleteLesson/{courseId}")]
    public Task<UserCourseSimpleDto> CompleteLesson(long courseId, int userLifeCount);

    [Get("/api/UserActions/GetUserCourse/{courseId}")]
    public Task<UserCourseSimpleDto> GetUserCourse(long courseId);

    [Get("/api/UserActions/GetOtherCourses")]
    public Task<List<CourseComplexDto>> GetOtherCourses();

    [Get("/api/Words/GetWordFromDictionary")]
    public Task<List<MerriamWebsterResponseDto>> GetWordFromDictionary(string requestWord);

    #endregion

    #region Authentication

    [Get("/api/UserActions/LaunchApp")]
    public Task<string> LaunchApp();

    [Post("/api/Authorization/Login")]
    public Task<LoginResponse> Login([Body] LoginRequestDto loginRequestDto);

    [Post("/api/Authorization/LogOut")]
    public Task<string> LogOut();

    [Post("/api/Authorization/Register")]
    public Task<string> RegisterAsync(RegisterRequestDto registerRequestDto);

    [Post("/api/Authorization/RefreshToken")]
    public Task<TokenResponse> RefreshToken(RefreshTokenRequestDto refreshTokenRequestDto);

    #endregion
}