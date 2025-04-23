using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Utils.Enum;
using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using UserStateService = LearningApp.Utils.StateService.UserStateService;

namespace LearningApp.ViewModels;

public partial class ProfileViewModel : PageViewModel
{
    private readonly IWindowFactory _windowFactory;

    [ObservableProperty] private UserStateService _userState;
    [ObservableProperty] private IEnumerable<ISeries> _series;
    [ObservableProperty] private int _currentLevelCap;


    public ProfileViewModel(UserStateService userState, IWindowFactory windowFactory)
    {
        PageName = AppPageNames.Profile;
        _userState = userState;
        _windowFactory = windowFactory;
        CurrentLevelCap = UserState.CurrentUser.Level * 4000;
        Series = InitSeries;
    }

    [RelayCommand]
    private async Task UpdateProfileData()
    {
        await _windowFactory.ShowDialog<bool>(AppWindowNames.ChangeProfileWindow);
    }

    [RelayCommand]
    private async Task UpdatePassword()
    {
        await _windowFactory.ShowDialog<bool>(AppWindowNames.ChangePasswordWindow);
    }


    #region XP Handlers

    private IEnumerable<ISeries> InitSeries =>
        GaugeGenerator.BuildSolidGauge(
            new GaugeItem(UserState.CurrentUser.CurrentXp, series =>
            {
                series.Fill = new SolidColorPaint(new SKColor(64, 69, 133));
                series.DataLabelsSize = 30;
                series.DataLabelsPaint = new SolidColorPaint(new SKColor(179, 195, 192));
                series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
                series.InnerRadius = 75;
                series.CornerRadius = 0;
            }),
            new GaugeItem(GaugeItem.Background, series =>
            {
                series.InnerRadius = 75;
                series.Fill = new SolidColorPaint(new SKColor(130, 130, 130));
            }));

    public int RemainingXp => CurrentLevelCap - UserState.CurrentUser.CurrentXp;

    #endregion
}