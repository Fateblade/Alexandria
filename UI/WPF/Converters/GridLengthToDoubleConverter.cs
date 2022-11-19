using Fateblade.Alexandria.UI.WPF.ConvertersConverters.Exceptions;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fateblade.Alexandria.UI.WPF.ConvertersConverters
{
    public class GridLengthToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is GridLength gridLength)
            {
                return gridLength.Value;
            }

            throw new ValueArgumentOfUnexpectedTypeException(value, typeof(GridLength));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new IsOneWayConverterException();
        }
    }
}
