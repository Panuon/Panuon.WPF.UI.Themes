using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class DataGridStylist
    {
        #region Properties

        #region Style
        public static DataGridStyles GetStyle(DataGrid dataGrid)
        {
            return (DataGridStyles)dataGrid.GetValue(StyleProperty);
        }

        public static void SetStyle(DataGrid button, DataGridStyles value)
        {
            button.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(DataGridStyles), typeof(DataGridStylist));
        #endregion

        #endregion
    }
}
