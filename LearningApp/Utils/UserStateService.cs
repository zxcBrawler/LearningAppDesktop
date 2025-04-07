using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;

namespace LearningApp.Utils;

public partial class UserStateService(IProfileService profileService) : ObservableObject
{
    [ObservableProperty] private UserSimpleDto? _currentUser;
    [ObservableProperty] private ObservableCollection<UserCourseSimpleDto>? _userCourses;

    public async Task ReloadUserAsync()
    {
        var response = await profileService.GetUserProfile();
        if (response is { IsSuccess: true, Value: not null }) CurrentUser = response.Value;
    }

    public async Task LoadUserCourses()
    {
        var response = await profileService.GetUserCourses();
        if (response is { IsSuccess: true, Value: not null })
            UserCourses = new ObservableCollection<UserCourseSimpleDto>(response.Value);
    }

    public void LogOut()
    {
        CurrentUser = null;
        UserCourses = null;
    }
}