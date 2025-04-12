using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LearningApp.Views;

public partial class ChangeProfileDataView : Window
{
    public ChangeProfileDataView()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}