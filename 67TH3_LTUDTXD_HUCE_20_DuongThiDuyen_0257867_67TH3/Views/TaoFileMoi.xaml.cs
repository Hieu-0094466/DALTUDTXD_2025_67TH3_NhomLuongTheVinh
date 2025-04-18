using _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Views
{
    /// <summary>
    /// Interaction logic for TaoFileMoi.xaml
    /// </summary>
    public partial class TaoFileMoi : Window
    {
        public ObservableCollection<string> ChonFile { get; set; }
        public TaoFileMoi()
        {
            InitializeComponent();
            ChonFile = new ObservableCollection<string>();
            DanhSachFile.ItemsSource = ChonFile;
            if (DataContext is DangNhap vm)
            {
                vm.HienThiTrangChu = () =>
                {
                    TrangChu trangChu = new TrangChu();
                    trangChu.Show();
                };
                vm.DongCuaSoHienTai = () => this.Close();
            }
        }

        private void BtnSelectFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn tệp Access",
                Filter = "Access Database|*.mdb;*.accdb",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    if (!ChonFile.Contains(file))
                        ChonFile.Add(file);
                }
            }
        }

        private void BtnClear(object sender, RoutedEventArgs e)
        {
            if (FindName("Check") is GroupBox groupBox)
            {
                foreach (var child in ((Panel)groupBox.Content).Children)
                {
                    if (child is CheckBox checkBox)
                    {
                        checkBox.IsChecked = false;
                    }
                }
            }
        }

        private void BtnAll(object sender, RoutedEventArgs e)
        {
            if (FindName("Check") is GroupBox groupBox)
            {
                foreach (var child in ((Panel)groupBox.Content).Children)
                {
                    if (child is CheckBox checkBox)
                    {
                        checkBox.IsChecked = true;
                    }
                }
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
