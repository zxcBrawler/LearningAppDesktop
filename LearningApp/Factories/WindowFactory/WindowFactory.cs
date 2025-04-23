using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using LearningApp.Utils.Enum;
using LearningApp.ViewModels;

namespace LearningApp.Factories.WindowFactory;

public class WindowFactory(
    Func<AppWindowNames, Window> windowFactory,
    Func<AppWindowNames, ViewModelBase> viewModelFactory)
    : IWindowFactory
{
    public void Show(AppWindowNames windowName)
    {
        var window = windowFactory(windowName);
        window.DataContext = viewModelFactory(windowName);
        window.Show();
    }

    public async Task<TResult> ShowDialog<TResult>(AppWindowNames windowName)
    {
        var window = windowFactory(windowName);
        window.DataContext = viewModelFactory(windowName);
        window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        return await window.ShowDialog<TResult>(GetActiveWindow());
    }

    private static Window GetActiveWindow() =>
        (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
}