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

namespace _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Views
{
    /// <summary>
    /// Interaction logic for ThayDoiThongSo.xaml
    /// </summary>
    public partial class ThayDoiThongSo : Window
    {
        public ThayDoiThongSo()
        {
            InitializeComponent();
            if (DataContext is DangNhap vm)
            {
                vm.DongCuaSoHienTai = () => this.Close();
            }
        }

    }
}
