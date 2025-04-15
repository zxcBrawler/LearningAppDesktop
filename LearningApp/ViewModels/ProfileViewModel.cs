using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
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
    [ObservableProperty] private UserStateService _userState;
    private readonly IWindowFactory _windowFactory;
    private readonly Func<Window> _mainWindowGetter;

    [ObservableProperty] private IEnumerable<ISeries> _series;
    [ObservableProperty] private int _currentLevelCap;


    public ProfileViewModel(UserStateService userState, IWindowFactory windowFactory,
        Func<Window> mainWindowGetter)
    {
        PageName = AppPageNames.Profile;
        _userState = userState;
        _windowFactory = windowFactory;
        _mainWindowGetter = mainWindowGetter;
        CurrentLevelCap = UserState.CurrentUser.Level * 2000;
        Series = GaugeGenerator.BuildSolidGauge(
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
    }

    [RelayCommand]
    private async Task UpdateProfileData()
    {
        var dialog = _windowFactory.CreateChangeProfileView();
        await dialog.ShowDialog(_mainWindowGetter());
    }

    [RelayCommand]
    private async Task UpdatePassword()
    {
        var dialog = _windowFactory.CreateChangePasswordView();
        await dialog.ShowDialog(_mainWindowGetter());
    }

    public int RemainingXp => CurrentLevelCap - UserState.CurrentUser.CurrentXp;
}