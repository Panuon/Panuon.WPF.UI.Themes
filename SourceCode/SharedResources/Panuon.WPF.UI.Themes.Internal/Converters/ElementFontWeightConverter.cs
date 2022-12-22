using Panuon.WPF.UI.Configurations;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class ElementFontWeightsConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var generalFeatures = (GeneralFeatures)value;

            if (generalFeatures.HasFlag(GeneralFeatures.Thin))
            {
                return FontWeights.Thin;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.Light))
            {
                return FontWeights.Light;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.SemiBold))
            {
                return FontWeights.SemiBold;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.Bold))
            {
                return FontWeights.Bold;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.Black))
            {
                return FontWeights.Black;
            }
            return FontWeights.Regular;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
