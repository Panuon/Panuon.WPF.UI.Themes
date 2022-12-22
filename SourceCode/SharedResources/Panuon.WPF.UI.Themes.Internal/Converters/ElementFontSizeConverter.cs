using Panuon.WPF.UI.Configurations;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class ElementFontSizeConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var generalFeatures = (GeneralFeatures)value;

            if (generalFeatures.HasFlag(GeneralFeatures.Small))
            {
                return 10;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.Large))
            {
                return 14;
            }
            return 12;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
