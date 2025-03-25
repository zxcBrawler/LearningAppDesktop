namespace LearningApp.Utils.Settings;

public class Settings
{
    public int SelectedThemeIndex { get; set; }
    public int SelectedLanguageIndex { get; set; }
    public int SelectedDailyGoalIndex { get; set; }
    public string? SelectedTime { get; set; }
    public bool IsDailyRemindersEnabled { get; set; }
    public bool IsStreakRemindersEnabled { get; set; }
}