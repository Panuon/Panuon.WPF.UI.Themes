using Panuon.WPF.UI.Configurations;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class ElementFontFamilyConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var generalFeatures = (GeneralFeatures)value;

            if (generalFeatures.HasFlag(GeneralFeatures.IconText))
            {
                return new Binding()
                {
                    Source = GlobalSettings.Setting,
                    Path = new PropertyPath(GlobalSetting.IconFontFamilyProperty),
                };
            }
            return new Binding()
            {
                Source = GlobalSettings.Setting,
                Path = new PropertyPath(GlobalSetting.FontFamilyProperty),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
