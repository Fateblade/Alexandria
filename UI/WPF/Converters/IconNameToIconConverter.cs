using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Fateblade.Alexandria.UI.WPF.Base.Interfaces;
using Fateblade.Alexandria.UI.WPF.ConvertersConverters.Exceptions;
using Prism.Ioc;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fateblade.Alexandria.UI.WPF.ConvertersConverters
{
    internal class IconNameToIconConverter : IValueConverter
    {
        private readonly IIconNameToIconResolver _resolver;

        public IconNameToIconConverter()
        {
            _resolver = ((IContainerApp)Application.Current).Container.Resolve<IIconNameToIconResolver>();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            if (!(value is string iconName)) throw new ValueArgumentOfUnexpectedTypeException(value, typeof(string));
           
            return _resolver.Resolve(iconName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new IsOneWayConverterException();
        }
    }
}
