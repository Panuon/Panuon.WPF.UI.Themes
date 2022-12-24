using Panuon.WPF.UI;
using System.Windows;

namespace Samples.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : WindowX
    {
        #region Fields
        #endregion

        #region Ctor
        public MainView()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void BtnTestMessageBoxX_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxX.Show(this, "MessageBoxX style configuration is placed in App.xaml. ", "Tips", MessageBoxIcon.Info, DefaultButton.YesOK, 5);
        }

        private void BtnTestNoticeBox_Click(object sender, RoutedEventArgs e)
        {
            var handler = NoticeBox.Show("NoticeBox style configuration is placed in App.xaml. ", "Tips", MessageBoxIcon.Info, true, 3000);
            //handler.Click += ...
        }

        private void BtnTestPendingBox_Click(object sender, RoutedEventArgs e)
        {
            var handler = PendingBox.Show(this, "PendingBox style configuration is placed in App.xaml.", "Caption", true);
            //handler.Cancelling += ...
            //handler.Close();
        }
        #endregion

        #region Functions
        #endregion

    }
}
