using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class PasswordBoxStylist
    {
        #region Properties

        #region Style
        public static PasswordBoxStyles GetStyle(PasswordBox passwordBox)
        {
            return (PasswordBoxStyles)passwordBox.GetValue(StyleProperty);
        }

        public static void SetStyle(PasswordBox passwordBox, PasswordBoxStyles value)
        {
            passwordBox.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(PasswordBoxStyles), typeof(PasswordBoxStylist), new PropertyMetadata(PasswordBoxStyles.Border));
        #endregion

        #endregion
    }
}
