using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class PasswordBoxStylist
    {
        #region Properties

        #region Style
        public static TextBoxStyles GetStyle(PasswordBox passwordBox)
        {
            return (TextBoxStyles)passwordBox.GetValue(StyleProperty);
        }

        public static void SetStyle(PasswordBox passwordBox, TextBoxStyles value)
        {
            passwordBox.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(TextBoxStyles), typeof(PasswordBoxStylist), new PropertyMetadata(TextBoxStyles.Border));
        #endregion

        #endregion
    }
}
