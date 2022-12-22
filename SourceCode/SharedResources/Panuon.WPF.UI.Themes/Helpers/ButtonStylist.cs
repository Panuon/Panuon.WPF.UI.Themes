using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class ButtonStylist
    {
        #region Properties

        #region Style
        public static ButtonStyles GetStyle(Button button)
        {
            return (ButtonStyles)button.GetValue(StyleProperty);
        }

        public static void SetStyle(Button button, ButtonStyles value)
        {
            button.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(ButtonStyles), typeof(ButtonStylist));
        #endregion

        #endregion
    }
}
