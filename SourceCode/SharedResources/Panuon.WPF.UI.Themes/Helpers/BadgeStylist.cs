using System.Windows;

namespace Panuon.WPF.UI.Themes
{
    public static class BadgeStylist
    {
        #region Properties

        #region Style
        public static BadgeStyles GetStyle(Badge badge)
        {
            return (BadgeStyles)badge.GetValue(StyleProperty);
        }

        public static void SetStyle(Badge badge, BadgeStyles value)
        {
            badge.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.RegisterAttached("Style", typeof(BadgeStyles), typeof(BadgeStylist));
        #endregion

        #endregion
    }
}
