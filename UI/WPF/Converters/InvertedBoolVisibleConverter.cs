using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Fateblade.Alexandria.UI.WPF.ConvertersConverters.Exceptions;

namespace Fateblade.Alexandria.UI.WPF.ConvertersConverters
{
    public class InvertedBoolVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Boolean b)
            {
                return b ? Visibility.Collapsed : Visibility.Visible;
            }

            throw new ValueArgumentOfUnexpectedTypeException(value, typeof(Boolean));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Collapsed;
            }

            throw new ValueArgumentOfUnexpectedTypeException(value, typeof(Visibility));
        }
    }
}