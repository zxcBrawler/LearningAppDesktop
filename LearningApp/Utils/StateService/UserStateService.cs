using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;
using LearningApp.Utils.TokenManagement;

namespace LearningApp.Utils.StateService;

public partial class UserStateService(
    IProfileService profileService,
    ITokenRefreshService tokenRefreshService,
    IDictionaryService dictionaryService,
    IWordService wordService,
    ITokenStorage tokenStorage) : ObservableObject
{
    [ObservableProperty] private UserSimpleDto? _currentUser;
    [ObservableProperty] private DictionarySimpleDto? _currentUserDictionary;
    [ObservableProperty] private ObservableCollection<UserCourseSimpleDto>? _userCourses;
    [ObservableProperty] private UserCourseSimpleDto? _currentUserCourse;
    [ObservableProperty] private ObservableCollection<DictionarySimpleDto>? _userDictionaries;


    public async Task GetUserDictionaries()
    {
        var response = await dictionaryService.GetUserDictionaries();
        if (response is { IsSuccess: true, Value: not null })
            UserDictionaries = new ObservableCollection<DictionarySimpleDto>(response.Value);
    }

    public async Task GetUserDictionaryById(int dictionaryId)
    {
        var response = await dictionaryService.GetUserDictionaryById(dictionaryId);
        if (response is { IsSuccess: true })
            CurrentUserDictionary = response.Value;
    }

    public async Task AddNewDictionary(AddDictionaryRequestDto addDictionaryRequestDto)
    {
        var response = await dictionaryService.AddNewDictionary(addDictionaryRequestDto);
        if (response.IsSuccess)
        {
            await GetUserDictionaries();
        }
    }

    public async Task DeleteDictionary(int id)
    {
        var response = await dictionaryService.DeleteDictionary(id);
        if (response.IsSuccess)
        {
            await GetUserDictionaries();
        }
    }

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

    public async Task LoadUserCourse(long courseId)
    {
        var response = await profileService.GetUserCourse(courseId);
        if (response is { IsSuccess: true, Value: not null })
            CurrentUserCourse = response.Value;
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

    public async Task AddWord(MerriamWebsterResponseDto word, int dictionaryId)
    {
        var response = await wordService.AddWord(word, dictionaryId);
        if (response is { IsSuccess: true, Value: not null })
        {
            await GetUserDictionaries();
        }
    }

    public async Task DeleteWordFromDictionary(int wordId)
    {
        var response = await wordService.DeleteWordFromDictionary(CurrentUserDictionary.Id, wordId);
        if (response is { IsSuccess: true })
        {
            await GetUserDictionaries();
            await GetUserDictionaryById(CurrentUserDictionary.Id);
        }
    }

    private async Task ForceRefreshTokens()
    {
        var currentUserTokens = tokenStorage.LoadTokens();
        if (currentUserTokens != null)
        {
            var newTokens = await tokenRefreshService.UpdateTokensAsync(new RefreshTokenRequestDto
            {
                OldAccessToken = currentUserTokens.AccessToken,
                RefreshToken = currentUserTokens.RefreshToken
            });
            if (newTokens.IsSuccess)
            {
                tokenStorage.SaveTokens(newTokens.Value);
                await ReloadUserAsync();
            }
        }
    }

    public void LogOut()
    {
        CurrentUser = null;
        CurrentUserCourse = null;
        UserCourses = null;
        UserDictionaries = null;
    }
}