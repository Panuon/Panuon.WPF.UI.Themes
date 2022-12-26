using System.Windows;

namespace Panuon.WPF.UI.Themes
{
    public static class BreadcrumbStylist
    {
        #region Properties

        #region Style
        public static BreadcrumbStyles GetStyle(Breadcrumb breadcrumb)
        {
            return (BreadcrumbStyles)breadcrumb.GetValue(StyleProperty);
        }

        public static void SetStyle(Breadcrumb breadcrumb, BreadcrumbStyles value)
        {
            breadcrumb.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(BreadcrumbStyles), typeof(BreadcrumbStylist), new PropertyMetadata(BreadcrumbStyles.Text));
        #endregion

        #endregion
    }
}
