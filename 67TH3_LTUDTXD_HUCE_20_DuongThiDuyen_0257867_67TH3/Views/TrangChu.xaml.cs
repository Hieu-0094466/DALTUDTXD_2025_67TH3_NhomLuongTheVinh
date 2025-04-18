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
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : Window
    {
        public TrangChu()
        {
            InitializeComponent();
            if (DataContext is DangNhap vm)
            {
                vm.HienThiTrangChonVL = () =>
                {
                    ChonVatLieu chonVatLieu = new ChonVatLieu();
                    chonVatLieu.Show();
                };
                vm.DongCuaSoHienTai = () => this.Close();
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save button clicked!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open button clicked!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add button clicked!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit button clicked!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete button clicked!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
