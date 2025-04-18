using _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for HienThi.xaml
    /// </summary>
    public partial class HienThi : Window
    {
        public HienThi()
        {
            InitializeComponent();
            if (DataContext is DangNhap vm)
            {
                vm.HienThiThemFileMoi = () =>
                {
                    TaoFileMoi taoFileMoi = new TaoFileMoi();
                    taoFileMoi.Show();
                };
                vm.HienThiTrangChu = () =>
                {
                    TrangChu trangChu = new TrangChu();
                    trangChu.Show();
                };
                vm.DongCuaSoHienTai = () => this.Close();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
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
