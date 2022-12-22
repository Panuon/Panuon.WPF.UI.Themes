using Panuon.WPF.UI.Themes.Resources;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml.Linq;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class ThemeBrushConverter
        : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var element = (FrameworkElement)values[0];
            var generalFeatures = (GeneralFeatures)values[1];

            return GetBrush(element, generalFeatures);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static Brush GetBrush(FrameworkElement element,
            GeneralFeatures generalFeatures)
        {
            if (generalFeatures.HasFlag(GeneralFeatures.PrimaryColor))
            {
                return element.FindResource(ResourceKeys.PrimaryBrush) as Brush;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.DefaultColor))
            {
                return element.FindResource(ResourceKeys.DefaultBrush) as Brush;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.InfoColor))
            {
                return element.FindResource(ResourceKeys.InfoBrush) as Brush;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.SuccessColor))
            {
                return element.FindResource(ResourceKeys.SuccessBrush) as Brush;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.WarningColor))
            {
                return element.FindResource(ResourceKeys.WarningBrush) as Brush;
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.DangerColor))
            {
                return element.FindResource(ResourceKeys.DangerBrush) as Brush;
            }
            return element.FindResource(ResourceKeys.PrimaryBrush) as Brush;
        }
    }
}
