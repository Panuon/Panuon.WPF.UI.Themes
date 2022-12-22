using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class RingProgressBarStylist
    {
        #region Properties

        #region Style
        public static RingProgressBarStyles GetStyle(RingProgressBar progressBar)
        {
            return (RingProgressBarStyles)progressBar.GetValue(StyleProperty);
        }

        public static void SetStyle(RingProgressBar progressBar, RingProgressBarStyles value)
        {
            progressBar.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(RingProgressBarStyles), typeof(RingProgressBarStylist));
        #endregion]

        #endregion
    }
}
