﻿using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.DataSource;
using LearningApp.Factories;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;
using LearningApp.Utils.TokenManagement;

namespace LearningApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IRecipient<NavigateToPageMessage>
{
    private readonly PageFactory _pageFactory;


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsLogInPageActive))]
    [NotifyPropertyChangedFor(nameof(IsSignUpPageActive))]
    private PageViewModel _currentView;

    public bool IsLogInPageActive => CurrentView.PageName == AppPageNames.LogIn;
    public bool IsSignUpPageActive => CurrentView.PageName == AppPageNames.SignUp;

    public MainWindowViewModel(PageFactory pageFactory, ITokenStorage tokenStorage, IApiInterface apiInterface)
    {
        _pageFactory = pageFactory;
        IsActive = true;

        Task.Run(async () => await apiInterface.LaunchApp());
        //Task.Delay(2000);
        var tokens = tokenStorage.ValidateTokens();

        CurrentView = _pageFactory.GetPageViewModel(tokens ? AppPageNames.MainApp : AppPageNames.LogIn);
    }

    public void Receive(NavigateToPageMessage message)
    {
        CurrentView = _pageFactory.GetPageViewModel(message.PageName);
    }
}

public record NavigateToPageMessage(AppPageNames PageName);