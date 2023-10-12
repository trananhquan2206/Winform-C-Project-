using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using BUS;
using DTO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Globalization;
using DoAn;
using Guna.UI2.WinForms;

namespace do_an_winform
{
    public partial class frmQuanLyNhapHang : Form
    {
        QuanLyNhapBUS QuanLyNhapBUS=new QuanLyNhapBUS();
        ThemHDNhapBUS ThemHDNhapBUS = new ThemHDNhapBUS();
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();
        CTHD_NhapBUS CTHD_NhapBUS = new CTHD_NhapBUS();
        //Khai báo biến toàn cục để truyền dữ liệu qua form chi tiết hóa đơn nhập
        public int MaHoaDon=-1;
        public string Ngaylap;
        public string TenNV;
        public string MaNV;
        public string TenNCC;
        public string MaNCC;
        public string ThanhTien;
        string username;

        public frmQuanLyNhapHang(string username)
        {
            InitializeComponent();
            dgvQuanLyThongTinHoaDonNhapHang.AutoGenerateColumns = false;
            cbbTim.SelectedIndex = 0;
            loadData();
            dtpDenNgay.Value = DateTime.Now;

            this.username = username;
        }

        //Hàm dùng để load dữ liệu từ CSDL lên form
        public void loadData()
        {
            dgvQuanLyThongTinHoaDonNhapHang.DataSource= QuanLyNhapBUS.layDSHoaDonNhap();
        }


        private void dgvQuanLyThongTinHoaDonNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MaHoaDon = (int)dgvQuanLyThongTinHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.colMaHD_dgv].Value;
                Ngaylap = dgvQuanLyThongTinHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.colNgaylap_dgv].Value.ToString();
                TenNV = dgvQuanLyThongTinHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.colTenNV_dgv].Value.ToString() ;
                MaNV= dgvQuanLyThongTinHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.colMaNV_dgv].Value.ToString();
                TenNCC= dgvQuanLyThongTinHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.colTenNCC_dgv].Value.ToString();
                MaNCC= dgvQuanLyThongTinHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.colMaNCC_dgv].Value.ToString(); ;
                ThanhTien= dgvQuanLyThongTinHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.colThanhTien_dgv].Value.ToString();
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (MaHoaDon != -1)
            {
                frmChiTietHoaDonNhap frmChiTietHoaDonNhap = new frmChiTietHoaDonNhap();
                frmChiTietHoaDonNhap.StartPosition = FormStartPosition.CenterScreen;
                frmChiTietHoaDonNhap.layMaHD(MaHoaDon);
                frmChiTietHoaDonNhap.layMaNCC(MaNCC);
                frmChiTietHoaDonNhap.layNgay(Ngaylap);
                frmChiTietHoaDonNhap.layTenNCC(TenNCC);
                frmChiTietHoaDonNhap.layMaNV(MaNV);
                frmChiTietHoaDonNhap.layTenNV(TenNV);
                frmChiTietHoaDonNhap.layThanhTien(ThanhTien);
                frmChiTietHoaDonNhap.Show();
                this.Hide();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvQuanLyThongTinHoaDonNhapHang.SelectedRows.Count > 0)
                InHoaDon();
        }

        private void InHoaDon()
        {
            pddHoaDon.Document = pdHoaDon;
            pddHoaDon.ShowDialog();
        }

        private void pdHoaDon_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Lấy hóa đơn dựa vào mã hóa đơn
            var hd = QuanLyNhapBUS.LayHdTheoMaHD( MaHoaDon);

            //Lấy thông tin cấu hình
            var tenCuaHang = CONSTANTS_INHOADON.tenCuaHang;
            var diaChi = CONSTANTS_INHOADON.diachi;
            var phone = CONSTANTS_INHOADON.phone;

            //Tạo chiều dài
            var y = 10;

            //lấy bề rộng của giấy in
            var w = pdHoaDon.DefaultPageSettings.PaperSize.Width;


            //Vẽ header của hóa đơn
            // Tên cửa hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.cuahang, tenCuaHang), new Font(CONSTANTS_INHOADON.kieuchu, 22, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 40;

            //Địa chỉ
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.dc, diaChi), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //Số điện thoại
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.sdt, phone), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //Định dạng bút vẽ
            Pen blackPen = new Pen(Color.Black, 1);

            //Tọa độ theo chiều dọc
            y += 20;

            //Định nghĩa 2 điểm để vẽ đường thẳng
            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);

            //Kẻ đường thẳng thứ nhất
            e.Graphics.DrawLine(blackPen, p1, p2);
            y += 30;

            //Hóa đơn bán hàng
            e.Graphics.DrawString(CONSTANTS_INHOADON.hoadonnhaphang, new Font(CONSTANTS_INHOADON.kieuchu, 22, FontStyle.Bold), Brushes.Black, new Point(280, y));
            y += 50;


            // mã hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.mahoadon, hd.MaHD.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In mã nhân viên 
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.manv, hd.MaNV.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In tên nhân viên
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tennv, TenNV), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In mã khách hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.mancc, MaNCC.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In tên khách hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tenncc, TenNCC), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //Thời gian in hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.thoigian, hd.NgayLap.ToString(CONSTANTS_INHOADON.date)), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));

            y += 40;
            //Kẻ đường thẳng thứ hai
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            //Định dạng các cột
            y += 35;

            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tensanpham), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.soluong), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(280, y));
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.dongia), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 20, y));
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.giamgia), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 110, y));
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.thanhtien), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            //Lấy dữ liệu CTHD_Nhap
            var result = CTHD_NhapBUS.layDSCTHDNhap(hd.MaHD);

            //Lặp các phần tử
            //Mỗi phần từ là một hàng trên hóa đơn
            int i = 1;
            y += 40;
            foreach (var l in result)
            {
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.TenSP), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.SoLuong.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(280, y));
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.DonGia.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 20, y));
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.ChietKhau.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 110, y));
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.ThanhTien.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
                y += 30;
            }

            //Kẻ đường thẳng thứ ba
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            y += 35;
            //Tổng tiền của hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tongtien, hd.ThanhTien.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 14, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));


            y += 50;
            //Lời chúc
            e.Graphics.DrawString(CONSTANTS_INHOADON.loichuc, new Font(CONSTANTS_INHOADON.kieuchu, 16, FontStyle.Bold), Brushes.Black, new Point(300, y));

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTim.Text = String.Empty;
            loadData();
            XoaDongDuocChon();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTim.Text))
            {
                dgvQuanLyThongTinHoaDonNhapHang.DataSource = null;
                return;
            }

            if (cbbTim.SelectedIndex == 0)//Tìm kiếm mã hóa đơn
            {
                int mahd;
                if (int.TryParse(txtTim.Text, out mahd))
                    dgvQuanLyThongTinHoaDonNhapHang.DataSource = QuanLyNhapBUS.TimKiemMaHoaDon(txtTim.Text);
                else
                    dgvQuanLyThongTinHoaDonNhapHang.DataSource = null;
            }
            else if (cbbTim.SelectedIndex == 1)//Tìm kiếm theo tên nhân viên
            {
                dgvQuanLyThongTinHoaDonNhapHang.DataSource = QuanLyNhapBUS.TimKiemTenNhanVien(txtTim.Text);
            }
            else if (cbbTim.SelectedIndex == 2)//Tìm kiếm theo tên nhà cung cấp
            {
                dgvQuanLyThongTinHoaDonNhapHang.DataSource = QuanLyNhapBUS.TimKiemTenNhaCungCap(txtTim.Text);
            }
            else
            {
                dgvQuanLyThongTinHoaDonNhapHang.DataSource = null;
            }
        }

        private void cbbTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTim.Text = String.Empty;
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime tngay = dtpTuNgay.Value;
            DateTime dngay = dtpDenNgay.Value;
            if (tngay >dngay )
            {
                dtpTuNgay.Value = DateTime.Now;
                dtpDenNgay.Value = DateTime.Now;
            }
            dgvQuanLyThongTinHoaDonNhapHang.DataSource = QuanLyNhapBUS.TimKiemTheoNgay(dtpTuNgay.Value, dtpDenNgay.Value);
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime tngay = dtpTuNgay.Value;
            DateTime dngay = dtpDenNgay.Value;
            if (dngay > DateTime.Now|| dngay<tngay)
            {
                dtpTuNgay.Value = DateTime.Now;
                dtpDenNgay.Value = DateTime.Now;
            }
            dgvQuanLyThongTinHoaDonNhapHang.DataSource = QuanLyNhapBUS.TimKiemTheoNgay(dtpTuNgay.Value, dtpDenNgay.Value);
        }

        private void frmQuanLyNhapHang_Load(object sender, EventArgs e)
        {
            XoaDongDuocChon();
        }

        //Dùng để xóa dòng được chọn khi khởi động form trong datagridview
        public void XoaDongDuocChon()
        {
            dgvQuanLyThongTinHoaDonNhapHang.ClearSelection();
            dgvQuanLyThongTinHoaDonNhapHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuanLyThongTinHoaDonNhapHang.MultiSelect = false;
        }
    }
}
