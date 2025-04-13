using System;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;
using Refit;

namespace LearningApp.Service;

public class ExerciseService(IApiInterface apiInterface) : IExerciseService
{
    public async Task<DataState<UserCourseSimpleDto>> StartNewCourse(long courseId)
    {
        try
        {
            var response = await apiInterface.StartCourse(courseId);
            return DataState<UserCourseSimpleDto>.Success(response, 201);
        }
        catch (ApiException e)
        {
            return DataState<UserCourseSimpleDto>.Failure(e.Content, 404);
        }
    }

    public async Task<DataState<UserCourseSimpleDto>> CompleteLesson(long courseId)
    {
        try
        {
            var response = await apiInterface.CompleteLesson(courseId);
            return DataState<UserCourseSimpleDto>.Success(response, 200);
        }
        catch (ApiException e)
        {
            return DataState<UserCourseSimpleDto>.Failure(e.Content, 404);
        }
    }
}