using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models;

namespace LearningApp.Service;

public class ExerciseService(IApiInterface apiInterface)
{
    public async Task<UserCourse> StartNewCourse(UserCourse userCourse)
    {
        return await apiInterface.PostUserCourse(userCourse);
    }
}