using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class StylistVisibilityConverter
        : IMultiValueConverter
    {
        private static Dictionary<string, Dictionary<string, Visibility>> _cacheParameters 
            = new Dictionary<string, Dictionary<string, Visibility>>();

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
            return cacheParameter;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private void AddCacheParameter(string param)
        {
            var splitStyles = param.Split(';');

            var dictionary = new Dictionary<string, Visibility>();
            foreach (var splitStyle in splitStyles)
            {
                var spliteStyles = splitStyle.Split(':');
                var styleKey = spliteStyles[0];
                var visibility = spliteStyles[1];

                dictionary.Add(styleKey, (Visibility)Enum.Parse(typeof(Visibility), visibility));
            }

            _cacheParameters.Add(param, dictionary);
        }

    }
}
