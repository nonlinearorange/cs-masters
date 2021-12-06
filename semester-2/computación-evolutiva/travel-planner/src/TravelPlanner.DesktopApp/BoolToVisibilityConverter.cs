using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TravelPlanner.DesktopApp
{
    internal class BoolToVisibilityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool status = (bool)value;
            return !status ? Visibility.Visible : (object)Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            return visibility == Visibility.Visible;
        }
    }
}
