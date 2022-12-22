using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class TextBoxStylist
    {
        #region Properties

        #region Style
        public static TextBoxStyles GetStyle(TextBox textBox)
        {
            return (TextBoxStyles)textBox.GetValue(StyleProperty);
        }

        public static void SetStyle(TextBox textBox, TextBoxStyles value)
        {
            textBox.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(TextBoxStyles), typeof(TextBoxStylist), new PropertyMetadata(TextBoxStyles.Border));
        #endregion

        #endregion
    }
}
