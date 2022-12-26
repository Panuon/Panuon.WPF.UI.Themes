using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class ContextMenuStylist
    {
        #region Properties

        #region Style
        public static ContextMenuStyles GetStyle(ContextMenu contextMenu)
        {
            return (ContextMenuStyles)contextMenu.GetValue(StyleProperty);
        }

        public static void SetStyle(ContextMenu contextMenu, ContextMenuStyles value)
        {
            contextMenu.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(ContextMenuStyles), typeof(ContextMenuStylist), new PropertyMetadata(ContextMenuStyles.Solid));
        #endregion

        #endregion
    }
}
