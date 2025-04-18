using _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Views
{
    /// <summary>
    /// Interaction logic for TrangDangKy.xaml
    /// </summary>
    public partial class TrangDangKy : Window
    {
        public TrangDangKy()
        {
            InitializeComponent();
            if (DataContext is DangNhap vm)
            {
                vm.HienThiDangNhap = () =>
                {
                    TrangDangNhap trangDangNhap = new TrangDangNhap();
                    trangDangNhap.Show();
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
