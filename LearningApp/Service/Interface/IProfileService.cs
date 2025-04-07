using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Service.Interface;

public interface IProfileService
{
    Task<DataState<UserSimpleDto>> GetUserProfile();
    Task<DataState<List<UserCourseSimpleDto>>> GetUserCourses();
}