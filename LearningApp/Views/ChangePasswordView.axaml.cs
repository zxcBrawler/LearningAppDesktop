using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LearningApp.Views;

public partial class ChangePasswordView : Window
{
    public ChangePasswordView()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}