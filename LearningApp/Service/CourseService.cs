using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Service;

public class CourseService(IApiInterface apiInterface)
{
    public async Task<DataState<List<UserCourseSimpleDto>>> GetUserCourses()
    {
        try
        {
            var response = await apiInterface.GetUserCoursesAsync();

            return DataState<List<UserCourseSimpleDto>>.Success(response, 200);
        }
        catch (Exception e)
        {
            return DataState<List<UserCourseSimpleDto>>.Failure(
                "An unexpected error occurred during the login process.",
                500);
        }
    }

    public async Task<List<Course>> GetCourses()
    {
        return await apiInterface.GetCoursesAsync();
    }

    public async Task<Course> GetCourse(int courseId)
    {
        return await apiInterface.GetCourseByIdAsync(courseId);
    }
}