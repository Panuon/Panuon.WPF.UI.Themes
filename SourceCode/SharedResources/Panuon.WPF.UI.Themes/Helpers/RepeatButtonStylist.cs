using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Panuon.WPF.UI.Themes
{
    public static class RepeatButtonStylist
    {
        #region Properties

        #region Style
        public static RepeatButtonStyles GetStyle(RepeatButton repeatButton)
        {
            return (RepeatButtonStyles)repeatButton.GetValue(StyleProperty);
        }

        public static void SetStyle(RepeatButton repeatButton, RepeatButtonStyles value)
        {
            repeatButton.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(RepeatButtonStyles), typeof(RepeatButtonStylist));
        #endregion

        #endregion
    }
}
