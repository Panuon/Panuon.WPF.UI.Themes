using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class ProgressBarStylist
    {
        #region Properties

        #region Style
        public static ProgressBarStyles GetStyle(ProgressBar progressBar)
        {
            return (ProgressBarStyles)progressBar.GetValue(StyleProperty);
        }

        public static void SetStyle(ProgressBar progressBar, ProgressBarStyles value)
        {
            progressBar.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(ProgressBarStyles), typeof(ProgressBarStylist));
        #endregion]

        #endregion
    }
}
