using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class ListBoxStylist
    {
        #region Properties

        #region Style
        public static ListBoxStyles GetStyle(ListBox listBox)
        {
            return (ListBoxStyles)listBox.GetValue(StyleProperty);
        }

        public static void SetStyle(ListBox listBox, ListBoxStyles value)
        {
            listBox.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(ListBoxStyles), typeof(ListBoxStylist));
        #endregion

        #endregion
    }
}
