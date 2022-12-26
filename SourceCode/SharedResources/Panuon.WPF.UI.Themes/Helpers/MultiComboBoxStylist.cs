using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class MultiComboBoxStylist
    {
        #region Properties

        #region Style
        public static MultiComboBoxStyles GetStyle(MultiComboBox comboBox)
        {
            return (MultiComboBoxStyles)comboBox.GetValue(StyleProperty);
        }

        public static void SetStyle(MultiComboBox comboBox, MultiComboBoxStyles value)
        {
            comboBox.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(MultiComboBoxStyles), typeof(MultiComboBoxStylist), new PropertyMetadata(MultiComboBoxStyles.Border));
        #endregion

        #endregion
    }
}
