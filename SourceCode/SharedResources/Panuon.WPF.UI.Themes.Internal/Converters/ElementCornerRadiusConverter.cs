using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class ElementCornerRadiusConverter
        : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var actualHeight = (double)values[0];
            var generalFeatures = (GeneralFeatures)values[1];

            if (generalFeatures.HasFlag(GeneralFeatures.Round))
            {
                return new CornerRadius(actualHeight / 2, actualHeight / 2, actualHeight / 2, actualHeight / 2);
            }
            return new CornerRadius(3);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
