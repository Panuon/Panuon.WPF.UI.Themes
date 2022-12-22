using System;

namespace Panuon.WPF.UI.Themes
{
    [Flags]
    public enum GeneralFeatures
        : long
    {
        PrimaryColor = 1,
        DefaultColor = 2,
        InfoColor = 4,
        SuccessColor = 8,
        WarningColor = 16,
        DangerColor = 32,

        Round = 128,

        IconText = 256,

        Small = 1024,
        Large = 2048,

        Thin = 4096,
        Light = 8192,
        SemiBold = 16384,
        Bold = 32768,
        Black = 65536,
    }
}
