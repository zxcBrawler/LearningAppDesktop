using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using LearningApp.Factories;
using LearningApp.Utils;
using LearningApp.Views;

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

    public MainWindowViewModel(PageFactory pageFactory)
    {
      _pageFactory = pageFactory;
      IsActive = true; 
      CurrentView = _pageFactory.GetPageViewModel(AppPageNames.LogIn);
    }

    public MainWindowViewModel()
    {
        throw new System.NotImplementedException();
    }

    public void Receive(NavigateToPageMessage message)
    {
        CurrentView = _pageFactory.GetPageViewModel(message.PageName);
    }

}
public record NavigateToPageMessage(AppPageNames PageName);