using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BarcodeReader.Toolkit.MVVM.Converters
{
    public sealed class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var isConverted = bool.TryParse(value.ToString(), out bool isVisible);

                if (!isConverted)
                    return Visibility.Hidden;

                if (isVisible)
                    return Visibility.Visible;

                return Visibility.Hidden;
            }
            else
                return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}