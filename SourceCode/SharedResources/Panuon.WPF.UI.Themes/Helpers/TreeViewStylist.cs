using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class TreeViewStylist
    {
        #region Properties

        #region Style
        public static TreeViewStyles GetStyle(TreeView treeView)
        {
            return (TreeViewStyles)treeView.GetValue(StyleProperty);
        }

        public static void SetStyle(TreeView treeView, TreeViewStyles value)
        {
            treeView.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(TreeViewStyles), typeof(TreeViewStylist));
        #endregion

        #endregion
    }
}
