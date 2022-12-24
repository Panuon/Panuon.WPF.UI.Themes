using Panuon.WPF.UI.Themes.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml.Linq;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class StylistBrushConverter
        : IMultiValueConverter
    {
        private static Dictionary<string, Dictionary<string, Tuple<string, int, double, double>>> _cacheParameters 
            = new Dictionary<string, Dictionary<string, Tuple<string, int, double, double>>>();

        private static BrushConverter _brushConverter = new BrushConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var element = (FrameworkElement)values[0];
            var generalFeatures = (GeneralFeatures)values[1];
            var style = values[2].ToString();
            var param = (string)parameter;

            if (!_cacheParameters.ContainsKey(param))
            {
                AddCacheParameter(param);
            }
            var cacheParameter = _cacheParameters[param][style];
            var key = cacheParameter.Item1;
            var type = cacheParameter.Item2; //0: ThemeColor;1: null;2: system colors;3: resource;
            var percent = cacheParameter.Item3;
            var opacity = cacheParameter.Item4;
            Brush result = null;
            switch (type)
            {
                case 0:
                    result = GetBrush(element, generalFeatures);
                    break;
                case 1:
                    result = null;
                    break;
                case 2:
                    result = _brushConverter.ConvertFromString(key) as Brush;
                    break;
                case 3:
                    result = element.FindResource(ResourceKeys.ResourceFields[key]) as Brush;
                    break;
            }

            return percent == 1
                ? GetTransparentBrush(result, opacity)
                : GetLightenBrush(result, percent);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private void AddCacheParameter(string param)
        {
            var splitStyles = param.Split(';');

            var dictionary = new Dictionary<string, Tuple<string, int, double, double>>();
            foreach (var splitStyle in splitStyles)
            {
                var valueKey = "";
                var valueType = 0; //0: ThemeColor;1: null;2: system colors;3: resource;
                var percent = 1d;
                var opacity = 1d;
                var spliteStyles = splitStyle.Split(':');
                var styleKey = spliteStyles[0];
                var color = spliteStyles[1];

                if (color.Contains(","))
                {
                    var colorSplits = color.Split(',');
                    color = colorSplits[0];
                    var value = colorSplits[1];
                    if (value.EndsWith("p"))
                    {
                        opacity = double.Parse(value.Remove(value.Length - 1));
                    }
                    else
                    {
                        percent = double.Parse(colorSplits[1]);
                    }
                }

                switch (color)
                {
                    case "":
                        break;
                    case "null":
                        valueType = 1;
                        break;
                    default:
                        if (color.StartsWith("["))
                        {
                            valueKey = color.Remove(0, 1).Remove(color.Length - 2, 1);
                            valueType = 2;
                        }
                        else
                        {
                            valueKey = color;
                            valueType = 3;
                        }
                        break;
                }
                dictionary.Add(styleKey, new Tuple<string, int, double, double>(valueKey, valueType, percent, opacity));
            }

            _cacheParameters.Add(param, dictionary);
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

        public static Brush GetTransparentBrush(Brush value,
            double opacity)
        {
            var brush = value as SolidColorBrush;
            if (brush == null
                || opacity == 1)
            {
                return value;
            }
            var newBrush = brush.CloneCurrentValue();
            newBrush.Opacity = opacity;
            return newBrush;
        }

        public static Brush GetLightenBrush(Brush value,
            double percent)
        {
            var brush = value as SolidColorBrush;
            if (brush == null
                || percent == 1)
            {
                return value;
            }
            if (percent == 0)
            {
                percent = 1;
            }
            var color = brush.Color;
            if (color.A == 0)
            {
                return null;
            }
            double a1 = 255 / 255.0, r1 = 255 / 255.0, g1 = 255 / 255.0, b1 = 255 / 255.0;
            double a2 = color.A / 255.0, r2 = color.R / 255.0, g2 = color.G / 255.0, b2 = color.B / 255.0;

            byte a = System.Convert.ToByte(Math.Min(255, Math.Max(0, (a1 + (a2 - a1) * percent) * 255)));
            byte r = System.Convert.ToByte(Math.Min(255, Math.Max(0, (r1 + (r2 - r1) * percent) * 255)));
            byte g = System.Convert.ToByte(Math.Min(255, Math.Max(0, (g1 + (g2 - g1) * percent) * 255)));
            byte b = System.Convert.ToByte(Math.Min(255, Math.Max(0, (b1 + (b2 - b1) * percent) * 255)));
            var newColor = Color.FromArgb(a, r, g, b);
            var newBrush = brush.CloneCurrentValue();
            newBrush.Color = newColor;
            return newBrush;
        }

    }
}
