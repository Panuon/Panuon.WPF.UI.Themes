using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class ComboBoxStylist
    {
        #region Properties

        #region Style
        public static ComboBoxStyles GetStyle(ComboBox comboBox)
        {
            return (ComboBoxStyles)comboBox.GetValue(StyleProperty);
        }

        public static void SetStyle(ComboBox comboBox, ComboBoxStyles value)
        {
            comboBox.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(ComboBoxStyles), typeof(ComboBoxStylist), new PropertyMetadata(ComboBoxStyles.Border));
        #endregion

        #endregion
    }
}
