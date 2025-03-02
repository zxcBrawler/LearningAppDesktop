using Avalonia.Controls;
using Avalonia.Interactivity;
using LearningApp.ViewModels;

namespace LearningApp.Views;

public partial class LogInView : UserControl
{
    public LogInView()
    {
        InitializeComponent();
    }
    private void TogglePasswordVisibility(object sender, RoutedEventArgs e)
    {
        if (DataContext is not LogInViewModel viewModel) return;
        viewModel.IsPasswordVisible = !viewModel.IsPasswordVisible;
        PasswordField.PasswordChar = viewModel.IsPasswordVisible ? '\0' : '*';
    }
}