using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class SwitchStylist
    {
        #region Properties

        #region Style
        public static SwitchStyles GetStyle(Switch @switch)
        {
            return (SwitchStyles)@switch.GetValue(StyleProperty);
        }

        public static void SetStyle(Switch @switch, SwitchStyles value)
        {
            @switch.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(SwitchStyles), typeof(SwitchStylist));
        #endregion

        #endregion
    }
}
