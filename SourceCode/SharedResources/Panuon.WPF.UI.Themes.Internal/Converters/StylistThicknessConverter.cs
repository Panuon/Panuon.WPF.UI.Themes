using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class StylistThicknessConverter
        : IMultiValueConverter
    {
        private static Dictionary<string, Dictionary<string, Tuple<string, int>>> _cacheParameters 
            = new Dictionary<string, Dictionary<string, Tuple<string, int>>>();

        private static ThicknessConverter _thicknessConverter = new ThicknessConverter();

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
            var thickness = cacheParameter.Item1;
            var type = cacheParameter.Item2; //0: null;1: value;

            switch (type)
            {
                case 0:
                    return null;
                case 1:
                    return (Thickness)_thicknessConverter.ConvertFromString(thickness);
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
                var valueType = 0; //0: null;1: value;

                var spliteStyles = splitStyle.Split(':');
                var styleKey = spliteStyles[0];
                var thickness = spliteStyles[1];

                switch (thickness)
                {
                    case "null":
                        valueType = 0;
                        break;
                    default:
                        value = thickness;
                        valueType = 1;
                        break;
                }
                dictionary.Add(styleKey, new Tuple<string, int>(value, valueType));
            }

            _cacheParameters.Add(param, dictionary);
        }

    }
}
