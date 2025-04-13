using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models;
using LearningApp.Models.Dto.Request;
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

    public async Task<DataState<bool>> UpdateUserProfile(UpdateProfileRequestDto updateProfileRequestDto)
    {
        try
        {
            var response = await apiInterface.UpdateUserProfile(updateProfileRequestDto);
            return DataState<bool>.Success(response, 200);
        }
        catch (ApiException e)
        {
            return DataState<bool>.Failure(e.Content, 400);
        }
    }

    public async Task<DataState<bool>> UpdateUserPassword(UpdatePasswordRequestDto updatePasswordRequestDto)
    {
        try
        {
            var response = await apiInterface.UpdateUserPassword(updatePasswordRequestDto);
            return DataState<bool>.Success(response, 200);
        }
        catch (ApiException e)
        {
            return DataState<bool>.Failure(e.Content, 400);
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

    public async Task<DataState<UserCourseSimpleDto>> GetUserCourse(long courseId)
    {
        try
        {
            var response = await apiInterface.GetUserCourse(courseId);
            return DataState<UserCourseSimpleDto>.Success(response, 200);
        }
        catch (ApiException e)
        {
            return DataState<UserCourseSimpleDto>.Failure(e.Content, 400);
        }
    }
}