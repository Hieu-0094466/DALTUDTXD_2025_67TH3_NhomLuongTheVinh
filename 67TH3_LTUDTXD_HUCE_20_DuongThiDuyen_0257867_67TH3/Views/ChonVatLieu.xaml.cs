using _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Models;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Views
{
    /// <summary>
    /// Interaction logic for ChonVatLieu.xaml
    /// </summary>
    public partial class ChonVatLieu : Window
    {
        public ChonVatLieu()
        {
            InitializeComponent();
            if (DataContext is DangNhap vm)
            {
                vm.HienThiTrangKetQua = () =>
                {
                    TrangKetQua trangKetQua = new TrangKetQua();
                    trangKetQua.Show();
                };
                vm.HienThiTrangChu = () =>
                {
                    TrangChu trangChu = new TrangChu();
                    trangChu.Show();
                };
                vm.DongCuaSoHienTai = () => this.Close();
            }
        }

        private void MoTrangThongSo(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is DangNhap viewModel && viewModel.ChonThongSo != null)
            {
                ThayDoiThongSo window = new ThayDoiThongSo
                {
                    DataContext = viewModel
                };
                if (window.DataContext is DangNhap vm)
                {
                    vm.DongCuaSoHienTai = () => window.Close(); // Gán hành động đóng cửa sổ
                }
                window.ShowDialog(); // Chờ cửa sổ đóng
            }
        }
    }
}
