using System.Collections.Generic;

namespace Panuon.WPF.UI.Themes.Resources
{
    public static class ResourceKeys
    {
        static ResourceKeys()
        {
            var dictionary = new Dictionary<string, object>();
            foreach (var fieldInfo in typeof(ResourceKeys).GetFields())
            {
                dictionary.Add(fieldInfo.Name, fieldInfo.GetValue(null));
            }
            ResourceFields = dictionary;
        }

        internal static Dictionary<string, object> ResourceFields { get; }

        public const string WindowBackground = nameof(WindowBackground);
        public const string BodyForeground = nameof(BodyForeground);
        public const string BodyInvertedForeground = nameof(BodyInvertedForeground);
        public const string DescriptionForeground = nameof(DescriptionForeground);

        public const string InputBackground = nameof(InputBackground);
        public const string InputBorderBrush = nameof(InputBorderBrush);
        public const string InputForeground = nameof(InputForeground);
        public const string InputWatermarkForeground = nameof(InputWatermarkForeground);
        public const string InputHoverSheetBackground = nameof(InputHoverSheetBackground);
        public const string InputSelectedSheetBackground = nameof(InputSelectedSheetBackground);

        public const string DropDownBorderBrush = nameof(DropDownBorderBrush);

        public const string SeparatorBrush = nameof(SeparatorBrush);

        public const string DefaultShadowColor = nameof(DefaultShadowColor);
        public const string PrimaryColor = nameof(PrimaryColor);
        public const string DefaultColor = nameof(DefaultColor);
        public const string WarningColor = nameof(WarningColor);
        public const string DangerColor = nameof(DangerColor);
        public const string SuccessColor = nameof(SuccessColor);
        public const string InfoColor = nameof(InfoColor);

        public const string PrimaryBrush = nameof(PrimaryBrush);
        public const string DefaultBrush = nameof(DefaultBrush);
        public const string WarningBrush = nameof(WarningBrush);
        public const string DangerBrush = nameof(DangerBrush);
        public const string SuccessBrush = nameof(SuccessBrush);
        public const string InfoBrush = nameof(InfoBrush);

        public const string ShadowColor = nameof(ShadowColor);


    }
}
