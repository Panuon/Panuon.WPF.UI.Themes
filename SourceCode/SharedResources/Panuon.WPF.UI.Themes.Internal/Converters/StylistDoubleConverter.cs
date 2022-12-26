using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.WPF.UI.Themes.Internal.Converters
{
    internal class StylistDoubleConverter
        : IMultiValueConverter
    {
        private static Dictionary<string, Dictionary<string, double>> _cacheParameters 
            = new Dictionary<string, Dictionary<string, double>>();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var element = (FrameworkElement)values[0];
            var generalFeatures = (GeneralFeatures)values[1];
            var style = values[2]?.ToString();

            var param = (string)parameter;

            if (!_cacheParameters.ContainsKey(param))
            {
                AddCacheParameter(param);
            }
            var cacheParam = _cacheParameters[param];

            if (generalFeatures.HasFlag(GeneralFeatures.Large))
            {
                var combineKey = $"{nameof(GeneralFeatures.Large)}-{style}";
                return cacheParam.ContainsKey(combineKey)
                    ? cacheParam[combineKey]
                    : cacheParam[nameof(GeneralFeatures.Large)];
            }
            else if (generalFeatures.HasFlag(GeneralFeatures.Small))
            {
                var combineKey = $"{nameof(GeneralFeatures.Small)}-{style}";
                return cacheParam.ContainsKey(combineKey)
                     ? cacheParam[combineKey]
                     : cacheParam[nameof(GeneralFeatures.Small)];
            }
            var normalCombineKey = $"Normal-{style}";
            return cacheParam.ContainsKey(normalCombineKey)
                ? cacheParam[normalCombineKey]
                : cacheParam["Normal"];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private void AddCacheParameter(string param)
        {
            var splitStyles = param.Split(';');

            var dictionary = new Dictionary<string, double>();
            foreach (var splitStyle in splitStyles)
            {
                var spliteStyles = splitStyle.Split(':');
                var styleKey = spliteStyles[0];
                var @double = spliteStyles[1];

                var value = double.Parse(@double);
                dictionary.Add(styleKey, value);
            }

            _cacheParameters.Add(param, dictionary);
        }

    }
}
