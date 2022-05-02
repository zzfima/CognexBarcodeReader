using System;
using System.Globalization;
using System.Windows.Data;

namespace BarcodeReader.Toolkit.MVVM.Converters
{
    public sealed class IsConnectedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var isParsed = bool.TryParse(value.ToString(), out bool isConnected);
                if (!isParsed)
                    return string.Empty;
                return isConnected ? "Is Connected" : "Is Disconnected";
            }
            else
                return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}