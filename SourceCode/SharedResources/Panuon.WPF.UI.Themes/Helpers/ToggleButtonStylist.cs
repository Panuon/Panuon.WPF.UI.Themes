using System.Windows;
using System.Windows.Controls.Primitives;

namespace Panuon.WPF.UI.Themes
{
    public static class ToggleButtonStylist
    {
        #region Properties

        #region Style
        public static ToggleButtonStyles GetStyle(ToggleButton toggleButton)
        {
            return (ToggleButtonStyles)toggleButton.GetValue(StyleProperty);
        }

        public static void SetStyle(ToggleButton toggleButton, ToggleButtonStyles value)
        {
            toggleButton.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(ToggleButtonStyles), typeof(ToggleButtonStylist));
        #endregion

        #endregion
    }
}
