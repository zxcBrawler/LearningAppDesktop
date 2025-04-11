using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;
using LearningApp.Utils.TokenManagement;

namespace LearningApp.Utils.StateService;

public partial class UserStateService(
    IProfileService profileService,
    ITokenRefreshService tokenRefreshService,
    ITokenStorage tokenStorage) : ObservableObject
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

    public async Task ChangeProfileData(UpdateProfileRequestDto updateProfileRequestDto)
    {
        var response = await profileService.UpdateUserProfile(updateProfileRequestDto);
        if (response.IsSuccess)
        {
            await ForceRefreshTokens();
            await ReloadUserAsync();
        }
    }

    public async Task UpdateUserPassword(UpdatePasswordRequestDto updatePasswordRequestDto)
    {
        var response = await profileService.UpdateUserPassword(updatePasswordRequestDto);
        if (response.IsSuccess)
        {
            await ForceRefreshTokens();
            await ReloadUserAsync();
        }
    }

    public void LogOut()
    {
        CurrentUser = null;
        UserCourses = null;
    }

    private async Task ForceRefreshTokens()
    {
        var currentUserTokens = tokenStorage.LoadTokens();
        var newTokens = await tokenRefreshService.UpdateTokensAsync(new RefreshTokenRequestDto()
        {
            OldAccessToken = currentUserTokens.AccessToken,
            RefreshToken = currentUserTokens.RefreshToken,
        });
        if (newTokens.IsSuccess)
        {
            tokenStorage.SaveTokens(newTokens.Value);
            await ReloadUserAsync();
        }
    }
}