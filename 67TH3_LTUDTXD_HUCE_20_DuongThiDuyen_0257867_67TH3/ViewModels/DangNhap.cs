using _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Models;
using _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace _67TH3_LTUDTXD_HUCE_20_DuongThiDuyen_0257867_67TH3.ViewModels
{
    public class DangNhap : INotifyPropertyChanged
    {
        private NguoiDung nguoiDung;
        public Action DongCuaSoHienTai { get; set; }
        public Action HienThiDangKy { get; set; }
        public Action HienThiDangNhap { get; set; }
        public Action HienThiThemFileMoi { get; set; }
        public Action HienThiTrangChu { get; set; }
        public Action HienThiTrangChonVL { get; set; }
        public Action HienThiTrangKetQua { get; set; }
        public Action HienThiTrangThayDoiThongSo { get; set; }
        public ICommand DangNhapTaiKhoan { get; }
        public ICommand DangKyTaiKhoan { get; }
        public ICommand ChuyenDenTrangDangKy { get; }
        public ICommand ChuyenDenTrangDangNhap { get; }
        public ICommand ChuyenDenTaoFileMoi { get; }
        public ICommand ChuyenDenTrangChu { get; }
        public ICommand ChuyenDenTrangChonVL { get; }
        public ICommand ChuyenDenTrangKetQua { get; }
        public ICommand ChinhSuaThongSo { get; }

        public ObservableCollection<NguoiDung> ds { get; set; }
        public ObservableCollection<MauDuLieuBang> dsm { get; set; }

        public List<string> DanhSachBeTong { get; } = new() { "B25", "B30", "B40" };
        public List<string> DanhSachCotThepDoc { get; } = new() { "CB300-V", "CB400-V", "CB500-V" };
        public MauDuLieuBang ChonThongSo { get; set; }
        public DangNhap()
        {
            nguoiDung = new NguoiDung();
            ds = DanhSachNguoiDung.DanhSach;
            DangNhapTaiKhoan = new RelayCommand(KiemTraDangNhap);
            DangKyTaiKhoan = new RelayCommand(DangKy);
            ChuyenDenTrangDangKy = new RelayCommand(ChuyenDenDangKy);
            ChuyenDenTrangDangNhap = new RelayCommand(VeTrangDangNhap);
            ChuyenDenTaoFileMoi = new RelayCommand(TaoFileMoi);
            ChuyenDenTrangChu = new RelayCommand(MoTrangChu);
            ChuyenDenTrangChonVL = new RelayCommand(MoTrangChonVL);
            ChuyenDenTrangKetQua = new RelayCommand(MoTrangKetQua);

            ChinhSuaThongSo = new RelayCommand(LuuThayDoi);

            dsm = new ObservableCollection<MauDuLieuBang>
        {
            new MauDuLieuBang { STT = 1, MatBang = "F_01", BeTong = "B30", CotThepDoc = "CB400-V" },
            new MauDuLieuBang { STT = 2, MatBang = "F_02", BeTong = "B30", CotThepDoc = "CB400-V" },
            new MauDuLieuBang { STT = 3, MatBang = "F_03", BeTong = "B30", CotThepDoc = "CB400-V" },
            new MauDuLieuBang { STT = 4, MatBang = "F_04", BeTong = "B25", CotThepDoc = "CB400-V" },
            new MauDuLieuBang { STT = 5, MatBang = "DH-1", BeTong = "B25", CotThepDoc = "CB400-V" }
        };
        }

        
        public string TaiKhoan
        {
            get => nguoiDung.TaiKhoan;
            set
            {
                nguoiDung.TaiKhoan = value;
                OnPropertyChanged(nameof(TaiKhoan));
            }
        }
        public string MatKhau
        {
            get => nguoiDung.MatKhau;
            set
            {
                nguoiDung.MatKhau = value;
                OnPropertyChanged(nameof(MatKhau));

            }
        }
        private void DangKy()
        {
            if (string.IsNullOrWhiteSpace(nguoiDung.TaiKhoan) || string.IsNullOrWhiteSpace(nguoiDung.MatKhau))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu");
                return;
            }
            if (DanhSachNguoiDung.DanhSach.Any(a => a.TaiKhoan == nguoiDung.TaiKhoan))
            {
                MessageBox.Show("Tài khoản đã tồn tại");
            }
            DanhSachNguoiDung.DanhSach.Add(new NguoiDung { TaiKhoan = nguoiDung.TaiKhoan, MatKhau = nguoiDung.MatKhau });
            OnPropertyChanged(nameof(ds));
            MessageBox.Show("Đăng ký thành công");
            TrangDangNhap trangDangNhap = new TrangDangNhap();
            trangDangNhap.Show();
            DongCuaSoHienTai?.Invoke();
        }

        public string BeTong
        {
            get => ChonThongSo?.BeTong;
            set
            {
                if (ChonThongSo != null && ChonThongSo.BeTong != value)
                {
                    ChonThongSo.BeTong = value;
                    OnPropertyChanged(nameof(BeTong));
                    OnPropertyChanged(nameof(ChonThongSo));
                }
            }
        }

        public string CotThepDoc
        {
            get => ChonThongSo?.CotThepDoc;
            set
            {
                if (ChonThongSo != null && ChonThongSo.CotThepDoc != value)
                {
                    ChonThongSo.CotThepDoc = value;
                    OnPropertyChanged(nameof(CotThepDoc));
                    OnPropertyChanged(nameof(ChonThongSo));
                }
            }
        }

        private void LuuThayDoi()
        {
            if (ChonThongSo != null)
            {
                // Tìm vị trí của vật liệu đang chỉnh sửa
                var index = dsm.IndexOf(dsm.FirstOrDefault(v => v.STT == ChonThongSo.STT));
                if (index != -1)
                {
                    // Thay thế phần tử tại vị trí cũ bằng bản sao mới của ChonThongSo
                    dsm[index] = new MauDuLieuBang
                    {
                        STT = ChonThongSo.STT,
                        MatBang = ChonThongSo.MatBang,
                        BeTong = ChonThongSo.BeTong,
                        CotThepDoc = ChonThongSo.CotThepDoc
                    };
                }
                OnPropertyChanged(nameof(dsm)); // Cập nhật giao diện
                
            }
            DongCuaSoHienTai?.Invoke();
        }

        private void MoTrangChu()
        {
            HienThiTrangChu?.Invoke();
            DongCuaSoHienTai?.Invoke();
        }

        private void MoTrangKetQua()
        {
            HienThiTrangKetQua?.Invoke();
            DongCuaSoHienTai?.Invoke();
        }
        private void MoTrangChonVL()
        {
            HienThiTrangChonVL?.Invoke();
        }
        private void ChuyenDenDangKy()
        {
            HienThiDangKy?.Invoke();
            DongCuaSoHienTai?.Invoke();
        }
        private void VeTrangDangNhap()
        {
            HienThiDangNhap?.Invoke();
            DongCuaSoHienTai?.Invoke();
        }

        private void TaoFileMoi()
        {
            HienThiThemFileMoi?.Invoke();
            DongCuaSoHienTai?.Invoke();
        }
        private void KiemTraDangNhap()
        {
            if (DanhSachNguoiDung.DanhSach.Any(a => a.TaiKhoan == nguoiDung.TaiKhoan && a.MatKhau == nguoiDung.MatKhau))
            {
                MessageBox.Show("Đăng nhập thành công");
                HienThi hienThi = new HienThi();
                hienThi.Show();
                DongCuaSoHienTai?.Invoke();
            }
            else
            {
                MessageBox.Show("Sai tài khoản mật khẩu");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
