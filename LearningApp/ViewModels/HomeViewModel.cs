using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models.Dto.Simple;
using LearningApp.Utils.Enum;
using UserStateService = LearningApp.Utils.StateService.UserStateService;

namespace LearningApp.ViewModels;

public partial class HomeViewModel : PageViewModel
{
    #region ObservableProperties

    [ObservableProperty] private ObservableCollection<UserCourseSimpleDto>? _userCourses;
    [ObservableProperty] private bool _isLoading;

    #endregion

    private readonly UserStateService _userStateService;

    public HomeViewModel(UserStateService userStateService)
    {
        PageName = AppPageNames.Home;
        _userStateService = userStateService;
        if (_userStateService.UserCourses == null)
            Task.Run(async () => await GetCoursesAsync());
        else
            UserCourses = _userStateService.UserCourses;
    }

    private async Task GetCoursesAsync()
    {
        IsLoading = true;
        Task.Delay(2000).Wait();
        await _userStateService.LoadUserCourses();
        UserCourses = _userStateService.UserCourses;
        IsLoading = false;
    }
}