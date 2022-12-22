using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class RadioButtonStylist
    {
        #region Properties

        #region Style
        public static RadioButtonStyles GetStyle(RadioButton radioButton)
        {
            return (RadioButtonStyles)radioButton.GetValue(StyleProperty);
        }

        public static void SetStyle(RadioButton radioButton, RadioButtonStyles value)
        {
            radioButton.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(RadioButtonStyles), typeof(RadioButtonStylist));
        #endregion

        #endregion
    }
}
