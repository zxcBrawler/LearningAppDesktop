using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using LearningApp.ViewModels;

namespace LearningApp.Utils.Converter;

public class LevelToColorConverter : IMultiValueConverter
{
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count < 2 ||
            values[0] is not string levelName ||
            values[1] is not CourseDetailsViewModel vm)
            return new SolidColorBrush(Color.Parse(CourseDetailsViewModel.DefaultColor));
        var index = Array.IndexOf(vm.LevelNames, levelName);
        if (index >= 0 && index < vm.SegmentColors.Count)
        {
            return new SolidColorBrush(Color.Parse(vm.SegmentColors[index]));
        }

        return new SolidColorBrush(Color.Parse(CourseDetailsViewModel.DefaultColor));
    }
}