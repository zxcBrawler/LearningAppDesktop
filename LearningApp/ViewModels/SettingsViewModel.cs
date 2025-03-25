using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class SettingsViewModel : PageViewModel
{
    [ObservableProperty] private int _selectedThemeIndex;
    [ObservableProperty] private int _selectedLanguageIndex;
    [ObservableProperty] private string _selectedTime;
    [ObservableProperty] private bool _isDailyRemindersEnabled;
    [ObservableProperty] private bool _isStreakRemindersEnabled;

    public SettingsViewModel()
    {
        PageName = AppPageNames.Settings;
        SelectedThemeIndex = 0;
        SelectedLanguageIndex = 0;
        SelectedTime = "00:00";
        IsDailyRemindersEnabled = false;
        IsStreakRemindersEnabled = false;
    }
}