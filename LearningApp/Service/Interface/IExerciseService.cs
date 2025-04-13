using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Service.Interface;

public interface IExerciseService
{
    Task<DataState<UserCourseSimpleDto>> StartNewCourse(long courseId);
}