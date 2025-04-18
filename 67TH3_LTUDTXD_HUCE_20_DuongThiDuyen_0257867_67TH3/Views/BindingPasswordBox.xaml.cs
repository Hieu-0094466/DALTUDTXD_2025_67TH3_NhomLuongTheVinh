using System.Windows;
using System.Windows.Controls;

namespace _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Views
{
    /// <summary>
    /// Interaction logic for BindingPasswordBox.xaml
    /// </summary>
    public partial class BindingPasswordBox : UserControl
    {


        public string MatKhau
        {
            get { return (string)GetValue(MatKhauProperty); }
            set { SetValue(MatKhauProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MatKhau.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MatKhauProperty =
            DependencyProperty.Register("MatKhau", typeof(string), typeof(BindingPasswordBox), new PropertyMetadata(string.Empty));


        public BindingPasswordBox()
        {
            InitializeComponent();
        }
        private void LayMatKhau(object sender, RoutedEventArgs e)
        {
            MatKhau = passwordBox.Password;
        }
    }
}
