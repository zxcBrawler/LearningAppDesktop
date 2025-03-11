using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LearningApp.Models;
using Microsoft.Extensions.Logging;
using Refit;

namespace LearningApp.DataSource;

public class ApiService(HttpClient httpClient, ILogger<ApiService> logger) : IApiInterface
{
    private readonly IApiInterface _apiClient = RestService.For<IApiInterface>(httpClient);

    public async Task<List<Course>> GetCoursesAsync()
    {
        logger.LogInformation("Fetching all courses");
        return await _apiClient.GetCoursesAsync();
    }

    public async Task<List<Course>> GetCourseByIdAsync(int courseId)
    {
        logger.LogInformation("Fetching course by id");
        return await _apiClient.GetCourseByIdAsync(courseId);
    }

    public async Task<List<UserCourse>> GetUserCoursesAsync(int userId)
    {
        logger.LogInformation("Fetching user's courses");
        return await _apiClient.GetUserCoursesAsync(userId);
    }

    public async Task<List<Lesson>> GetLessonsAsync()
    {
        return await _apiClient.GetLessonsAsync();
    }
}