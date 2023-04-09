using Fateblade.Alexandria.UI.WPF.ConvertersConverters.Exceptions;
using System;
using System.Globalization;
using System.Linq;
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
                if (stringValue == string.Empty) return 0;

                return int.Parse(new string(stringValue.Where(char.IsDigit).ToArray()));
            }

            throw new ValueArgumentOfUnexpectedTypeException(value, typeof(string));
        }
    }
}
