﻿using Avalonia.Controls;
using Avalonia.Interactivity;

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