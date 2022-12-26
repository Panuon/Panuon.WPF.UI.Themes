using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class StylistCornerRadiusConverter
        : IMultiValueConverter
    {
        private static Dictionary<string, Dictionary<string, Tuple<string, int>>> _cacheParameters 
            = new Dictionary<string, Dictionary<string, Tuple<string, int>>>();

        private static CornerRadiusConverter _cornerRadiusConverter = new CornerRadiusConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var element = (FrameworkElement)values[0];
            var generalFeatures = (GeneralFeatures)values[1];
            var style = values[2].ToString();
            var actualHeight = (double)values[3];

            var param = (string)parameter;

            if (!_cacheParameters.ContainsKey(param))
            {
                AddCacheParameter(param);
            }
            var cacheParameter = _cacheParameters[param][style];
            var cornerRadius = cacheParameter.Item1;
            var type = cacheParameter.Item2; //0: null;1: value;2: half;3: auto;

            switch (type)
            {
                case 0:
                    return null;
                case 1:
                    return _cornerRadiusConverter.ConvertFromString(cornerRadius);
                case 2:
                    var corner = (CornerRadius)_cornerRadiusConverter.ConvertFromString(cornerRadius);
                    return new CornerRadius(corner.TopLeft / 2, corner.TopRight / 2, corner.BottomRight / 2, corner.BottomLeft);
                case 3:
                    if (generalFeatures.HasFlag(GeneralFeatures.Round))
                    {
                        return new CornerRadius(actualHeight / 2, actualHeight / 2, actualHeight / 2, actualHeight / 2);
                    }
                    return new CornerRadius(3);
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private void AddCacheParameter(string param)
        {
            var splitStyles = param.Split(';');

            var dictionary = new Dictionary<string, Tuple<string, int>>();
            foreach (var splitStyle in splitStyles)
            {
                var value = "0,0,0,0";
                var valueType = 0; //0: null;1: value;2: half;3: auto;

                var spliteStyles = splitStyle.Split(':');
                var styleKey = spliteStyles[0];
                var cornerRadius = spliteStyles[1];

                switch (cornerRadius)
                {
                    case "null":
                        valueType = 0;
                        break;
                    default:
                        value = cornerRadius;
                        valueType = 1;
                        break;
                    case "half":
                        valueType = 2;
                        break;
                    case "auto":
                        valueType = 3;
                        break;
                }
                dictionary.Add(styleKey, new Tuple<string, int>(value, valueType));
            }

            _cacheParameters.Add(param, dictionary);
        }

    }
}
