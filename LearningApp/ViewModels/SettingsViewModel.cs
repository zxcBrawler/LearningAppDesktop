using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Utils.DependencyInjection;
using LearningApp.Utils.Enum;
using LearningApp.Utils.Settings;

namespace LearningApp.ViewModels;

public partial class SettingsViewModel : PageViewModel
{
    [ObservableProperty] private Settings? _settings;
    [ObservableProperty] private bool _isDailyRemindersEnabled;
    [ObservableProperty] private bool _isStreakRemindersEnabled;

    public SettingsViewModel()
    {
        PageName = AppPageNames.Settings;
        LoadSettings();
    }


    private void LoadSettings()
    {
        Settings = SettingsManager.LoadSettings();
        if (Settings == null) return;
        IsDailyRemindersEnabled = Settings.IsDailyRemindersEnabled;
        IsStreakRemindersEnabled = Settings.IsStreakRemindersEnabled;
    }

    [RelayCommand]
    private void SaveSettings()
    {
        if (Settings == null) return;
        Settings.IsDailyRemindersEnabled = IsDailyRemindersEnabled;
        Settings.IsStreakRemindersEnabled = IsStreakRemindersEnabled;
        SettingsManager.SaveSettings(Settings);
        Settings = SettingsManager.LoadSettings();
    }

    [RelayCommand]
    private void ResetSettings()
    {
        SettingsManager.ResetSettings();
        LoadSettings();
    }

    [RelayCommand]
    private void OpenPrivacyPolicy()
    {
        Process.Start(new ProcessStartInfo { FileName = "https://www.google.com", UseShellExecute = true });
    }

    [RelayCommand]
    private void OpenTermsOfService()
    {
        Process.Start(new ProcessStartInfo { FileName = "https://docs.avaloniaui.net", UseShellExecute = true });
    }
}