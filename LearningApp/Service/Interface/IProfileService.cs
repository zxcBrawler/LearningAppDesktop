using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Service.Interface;

public interface IProfileService
{
    Task<DataState<UserSimpleDto>> GetUserProfile();
    Task<DataState<bool>> UpdateUserProfile(UpdateProfileRequestDto updateProfileRequestDto);
    Task<DataState<bool>> UpdateUserPassword(UpdatePasswordRequestDto updatePasswordRequestDto);
    Task<DataState<List<UserCourseSimpleDto>>> GetUserCourses();
}