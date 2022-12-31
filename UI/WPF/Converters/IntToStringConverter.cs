using Fateblade.Alexandria.UI.WPF.ConvertersConverters.Exceptions;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Fateblade.Alexandria.UI.WPF.ConvertersConverters
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue.ToString();
            }

            throw new ValueArgumentOfUnexpectedTypeException(value, typeof(int));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return int.Parse(stringValue);
            }

            throw new ValueArgumentOfUnexpectedTypeException(value, typeof(string));
        }
    }
}
