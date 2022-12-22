using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class CheckBoxStylist
    {
        #region Properties

        #region Style
        public static CheckBoxStyles GetStyle(CheckBox checkBox)
        {
            return (CheckBoxStyles)checkBox.GetValue(StyleProperty);
        }

        public static void SetStyle(CheckBox checkBox, CheckBoxStyles value)
        {
            checkBox.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(CheckBoxStyles), typeof(CheckBoxStylist));
        #endregion

        #endregion
    }
}
