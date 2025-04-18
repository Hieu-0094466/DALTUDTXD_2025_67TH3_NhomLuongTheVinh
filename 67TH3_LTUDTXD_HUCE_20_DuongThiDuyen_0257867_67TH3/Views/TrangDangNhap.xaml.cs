using _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Views
{
    /// <summary>
    /// Interaction logic for TrangDangNhap.xaml
    /// </summary>
    public partial class TrangDangNhap : Window
    {
        public TrangDangNhap()
        {
            InitializeComponent();

            if (DataContext is DangNhap vm)
            {
                vm.HienThiDangKy = () =>
                {
                    TrangDangKy trangDangKy = new TrangDangKy();
                    trangDangKy.Show();
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

        private void btnDangnhap_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
