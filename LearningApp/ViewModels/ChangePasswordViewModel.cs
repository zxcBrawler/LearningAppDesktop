using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models.Dto.Request;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class ChangePasswordViewModel : ViewModelBase
{
    [ObservableProperty] private UserStateService _userState;
    [ObservableProperty] private string? _oldPassword;
    [ObservableProperty] private string? _newPassword;

    public ChangePasswordViewModel(UserStateService userState)
    {
        _userState = userState;
    }

    [RelayCommand]
    private async Task UpdatePassword()
    {
        await UserState.UpdateUserPassword(new UpdatePasswordRequestDto()
        {
            OldPassword = OldPassword,
            NewPassword = NewPassword
        });
    }
}