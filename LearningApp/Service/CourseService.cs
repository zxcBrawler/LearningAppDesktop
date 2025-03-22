using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models;

namespace LearningApp.Service;

public class CourseService(IApiInterface apiInterface)
{
    public async Task<List<UserCourse>> GetUserCourses(int userId)
    {
        return await apiInterface.GetUserCoursesAsync(userId);
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