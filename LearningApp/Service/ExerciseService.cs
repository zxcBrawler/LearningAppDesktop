using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models;

namespace LearningApp.Service;

public class ExerciseService(IApiInterface apiInterface)
{
    public async Task<List<Lesson>> GetLessonsWithExercisesAsync()
    {
        return await apiInterface.GetLessonsAsync();
    }
}