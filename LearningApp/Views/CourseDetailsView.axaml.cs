using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace LearningApp.Views;

public partial class CourseDetailsView : Window
{
    public CourseDetailsView()
    {
        InitializeComponent();
    }

    private void Go_Back(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}