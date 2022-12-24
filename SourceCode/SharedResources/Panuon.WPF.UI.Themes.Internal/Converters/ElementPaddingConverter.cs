using Panuon.WPF.UI.Configurations;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class ElementPaddingConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var generalFeatures = (GeneralFeatures)value;

            if (generalFeatures.HasFlag(GeneralFeatures.Small))
            {
                return new Thickness(12, 0, 12, 0);
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.Large))
            {
                return new Thickness(20, 0, 20, 0);
            }
            return new Thickness(15, 0, 15, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
