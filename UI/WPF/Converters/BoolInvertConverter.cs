using System;
using System.Globalization;
using System.Windows.Data;

namespace Fateblade.Alexandria.UI.WPF.ConvertersConverters
{
    public class BoolInvertConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Boolean b)
            {
                return !b;
            }

            throw new ArgumentException("Is not of type boolean", nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Boolean b)
            {
                return !b;
            }

            throw new ArgumentException("Is not of type boolean", nameof(value));
        }
    }
}
