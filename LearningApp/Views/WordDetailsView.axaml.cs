using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LearningApp.Views;

public partial class WordDetailsView : Window
{
    public WordDetailsView()
    {
        InitializeComponent();
    }

    private void Go_Back(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}