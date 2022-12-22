using System.Windows;
using System.Windows.Controls;

namespace Panuon.WPF.UI.Themes
{
    public static class GeneralStylist
    {
        #region Properties

        #region Feature
        public static GeneralFeatures GetFeature(FrameworkElement element)
        {
            return (GeneralFeatures)element.GetValue(FeatureProperty);
        }

        public static void SetFeature(FrameworkElement element, GeneralFeatures value)
        {
            element.SetValue(FeatureProperty, value);
        }

        public static readonly DependencyProperty FeatureProperty =
            DependencyProperty.RegisterAttached("Feature", typeof(GeneralFeatures), typeof(GeneralStylist), new FrameworkPropertyMetadata(GeneralFeatures.PrimaryColor, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #endregion
    }
}
