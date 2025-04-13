using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Complex;
using LearningApp.Models.Dto.Response;
using LearningApp.Service.Interface;
using Refit;

namespace LearningApp.Service;

public class CourseService(IApiInterface apiInterface) : ICourseService
{
    public async Task<DataState<CourseComplexDto>> GetCourse(long courseId)
    {
        try
        {
            var response =  await apiInterface.GetCourseByIdAsync(courseId);
            return DataState<CourseComplexDto>.Success(response, 200);
        }
        catch (ApiException e)
        {
           return DataState<CourseComplexDto>.Failure(e.Content, 404);
        }
        
    }

    public async Task<DataState<List<CourseComplexDto>>> GetOtherCourses()
    {
        try
        {
            var response = await apiInterface.GetOtherCourses();
            return DataState<List<CourseComplexDto>>.Success(response, 200);
        }
        catch (ApiException e)
        {
            return DataState<List<CourseComplexDto>>.Failure(e.Content, 404);
        }
    }
}