using Fateblade.Alexandria.UI.WPF.ConvertersConverters.Exceptions;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fateblade.Alexandria.UI.WPF.ConvertersConverters
{
    public enum ExistanceToVisibilityOption
    {
        DefaultValueVisible
    }

    public class ExistanceToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Hidden;

            if (GetDefault(value.GetType()) == value 
                && !(parameter is ExistanceToVisibilityOption.DefaultValueVisible 
                     || parameter?.ToString() == ExistanceToVisibilityOption.DefaultValueVisible.ToString()))
            {
                return Visibility.Hidden;
            }
            
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new IsOneWayConverterException();
        }

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
