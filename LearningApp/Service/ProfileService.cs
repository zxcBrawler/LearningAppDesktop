using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;
using Refit;

namespace LearningApp.Service;

public class ProfileService(IApiInterface apiInterface) : IProfileService
{
    public async Task<DataState<UserSimpleDto>> GetUserProfile()
    {
        try
        {
            var response = await apiInterface.GetUserProfile();
            return DataState<UserSimpleDto>.Success(response, 200);
        }
        catch (ApiException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<DataState<List<UserCourseSimpleDto>>> GetUserCourses()
    {
        try
        {
            var response = await apiInterface.GetUserCoursesAsync();
            return DataState<List<UserCourseSimpleDto>>.Success(response, 200);
        }
        catch (ApiException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}