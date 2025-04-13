using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models.Dto.Simple;
using LearningApp.Utils.Enum;
using UserStateService = LearningApp.Utils.StateService.UserStateService;

namespace LearningApp.ViewModels;

public partial class HomeViewModel : PageViewModel
{

    [ObservableProperty] private UserStateService _userStateService;

    public HomeViewModel(UserStateService userStateService)
    {
        PageName = AppPageNames.Home;
        _userStateService = userStateService;
        Task.Run(async () => await GetCoursesAsync());
    }

    private async Task GetCoursesAsync()
    {
        await UserStateService.LoadUserCourses();
    }
}