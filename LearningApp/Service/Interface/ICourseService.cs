using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Complex;

namespace LearningApp.Service.Interface;

public interface ICourseService
{
    Task<DataState<List<CourseComplexDto>>> GetOtherCourses();
    Task<DataState<CourseComplexDto>> GetCourse(long courseId);
}