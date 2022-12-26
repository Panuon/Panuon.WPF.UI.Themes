using Panuon.WPF;
using Panuon.WPF.UI;
using System.ComponentModel;
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

            var itemsSource = new MachineItem[]
            {
                new MachineItem("M000001", "Working", "N/A") { Type = MachineType.UX_10 },
                new MachineItem("M000002", "Working", "N/A"),
                new MachineItem("M000003", "Working", "N/A"),
                new MachineItem("M000004", "Repairing", "N/A"),
                new MachineItem("M000005", "Repairing", "N/A"),
            };
            Dg1.ItemsSource = itemsSource;
            Dg2.ItemsSource = itemsSource;
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
    public enum MachineType
    {
        UX_01,
        UX_02,
        UX_10,
    }

    public class MachineItem
        : NotifyPropertyChangedBase
    {
        #region Ctor
        public MachineItem(string code, string state, string remark)
        {
            Code = code;
            State = state;
            Remark = remark;
        }
        #endregion

        #region Properties
        [ColumnWidth(Width = "Auto")]
        [ColumnDisplayIndex(1)]
        public string State { get => _state; set => Set(ref _state, value); }
        private string _state;


        [ColumnWidth(Width = "Auto")]
        [ColumnDisplayIndex(2)]
        public string Remark { get => _remark; set => Set(ref _remark, value); }
        private string _remark;

        [DisplayName("Machine Code")]
        [ColumnWidth(Width = "*")]
        [ColumnDisplayIndex(0)]
        public string Code { get => _code; set => Set(ref _code, value); }
        private string _code;

        [DisplayName("Machine Type")]
        [ColumnWidth(Width = "Auto")]
        [ColumnDisplayIndex(3)]
        public MachineType Type { get => _type; set => Set(ref _type, value); }
        private MachineType _type;
        #endregion
    }
}
