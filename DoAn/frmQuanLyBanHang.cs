using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;
using BUS;
using System.Text.RegularExpressions;
using do_an_winform;
using Guna.UI2.WinForms;

namespace DoAn
{
    public partial class frmQuanLyBanHang : Form
    {
        QuanLyBanBUS QuanLyBanBUS = new QuanLyBanBUS();
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();
        CTHD_BanBUS CTHD_BanBUS = new CTHD_BanBUS();

        //Khai báo biến toàn cục để truyền dữ liệu qua form chi tiết hóa đơn nhập
        public int MaHoaDon = -1;
        public string Ngaylap;
        public string TenNV;
        public string MaNV;
        public string TenKH;
        public string MaKH;
        public string ThanhTien;
        public string SDT;
        public string DiaChi;
        string username;

        public frmQuanLyBanHang(string username)
        {
            InitializeComponent();
            dgvThongTinQuanLyHoaDonBanHang.AutoGenerateColumns = false;
            cbbTim.SelectedIndex = 0;
            load();
            this.username = username;
            dgvThongTinQuanLyHoaDonBanHang.CurrentCell = null;
            dtpDenNgay.Value = DateTime.Now;
        }

        public void load()
        {
            dgvThongTinQuanLyHoaDonBanHang.DataSource = QuanLyBanBUS.layDSHoaDonBan();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (MaHoaDon != -1)
            {
                frmChiTietHoaDonBan frm = new frmChiTietHoaDonBan();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.layMaHD(MaHoaDon);
                frm.layMaKH(MaKH);
                frm.layNgay(Ngaylap);
                frm.layTenKH(TenKH);
                frm.layMaNV(MaNV);
                frm.layTenNV(TenNV);
                frm.layThanhTien(ThanhTien);
                frm.laySDT(SDT);
                frm.layDiaCHi(DiaChi);
                frm.Show();
                this.Hide();
            }
        }

        private void dgvThongTinQuanLyHoaDonBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MaHoaDon = (int)dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.MaHoaDon_dgv].Value;
                Ngaylap = dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.Ngaylap_dgv].Value.ToString();
                TenNV = dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.TenNV_dgv].Value.ToString();
                MaNV = dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.MaNV_dgv].Value.ToString();
                TenKH = dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.TenKH_dgv].Value.ToString();
                MaKH = dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.MaKH_dgv].Value.ToString(); ;
                ThanhTien = dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.ThanhTien_dgv].Value.ToString();
                SDT = dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.SDTn_dgv].Value.ToString();
                DiaChi = dgvThongTinQuanLyHoaDonBanHang.Rows[e.RowIndex].Cells[CONSTANTS_QUANLYHOADON.DiaChi_dgv].Value.ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvThongTinQuanLyHoaDonBanHang.SelectedRows.Count > 0)
                InHoaDon();
        }

        private void InHoaDon()
        {
            pddHoaDon.Document = pdHoaDon;
            pddHoaDon.ShowDialog();
        }

        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Lấy hóa đơn dựa vào mã hóa đơn
            var hd = QuanLyBanBUS.LayHdTheoMaHD(MaHoaDon);

            //Tạo chiều dài
            var y = 10;

            //lấy bề rộng của giấy in
            var w = pdHoaDon.DefaultPageSettings.PaperSize.Width;

            //Lấy thông tin cấu hình
            var tenCuaHang = CONSTANTS_INHOADON.tenCuaHang;
            var diaChi = CONSTANTS_INHOADON.diachi;
            var phone = CONSTANTS_INHOADON.phone;

            //Vẽ header của hóa đơn
            // Tên cửa hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.cuahang, tenCuaHang), new Font(CONSTANTS_INHOADON.kieuchu, 22, FontStyle.Bold), Brushes.Black, new Point(10,y));
            y += 40;

            //Địa chỉ
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.dc, diaChi), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10,y));
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
            e.Graphics.DrawString(CONSTANTS_INHOADON.hoadonbanhang, new Font(CONSTANTS_INHOADON.kieuchu, 22, FontStyle.Bold), Brushes.Black, new Point(280, y));
            y += 50;


            // mã hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.mahoadon, MaHoaDon.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10,y));
            y += 30;

            //In mã nhân viên 
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.manv, MaNV.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In tên nhân viên
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tennv, TenNV), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In mã khách hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.mankh, MaKH.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In tên khách hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tenkh, TenKH), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //Thời gian in hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.thoigian,hd.NgayLap.ToString(CONSTANTS_INHOADON.date)), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));

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
            var result = CTHD_BanBUS.layDSCTHDBan(MaHoaDon);

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
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tongtien, ThanhTien.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 14, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));


            y += 50;
            //Lời chúc
            e.Graphics.DrawString(CONSTANTS_INHOADON.loichuc, new Font(CONSTANTS_INHOADON.kieuchu, 16, FontStyle.Bold), Brushes.Black, new Point(300, y));

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTim.Text =string.Empty;
            load();
            xoadongduocchon();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTim.Text))
            {
                dgvThongTinQuanLyHoaDonBanHang.DataSource = null;
                return;
            }
                
            if (cbbTim.SelectedIndex == 0)//Tìm kiếm mã hóa đơn
            {
                int mahd;
                if(int.TryParse(txtTim.Text, out mahd))
                    dgvThongTinQuanLyHoaDonBanHang.DataSource= QuanLyBanBUS.TimKiemMaHoaDon(txtTim.Text);
                else
                    dgvThongTinQuanLyHoaDonBanHang.DataSource = null;
            }
            else if(cbbTim.SelectedIndex == 1)
            {
                dgvThongTinQuanLyHoaDonBanHang.DataSource = QuanLyBanBUS.TimKiemTenNhanVien(txtTim.Text);
            }
            else if(cbbTim.SelectedIndex == 2)
            {
                dgvThongTinQuanLyHoaDonBanHang.DataSource = QuanLyBanBUS.TimKiemTenKhachHang(txtTim.Text);
            }
            else
            {
                dgvThongTinQuanLyHoaDonBanHang.DataSource = null;
            }

        }

        private void cbbTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTim.Text=String.Empty;
        }

        private void frmQuanLyBanHang_Load(object sender, EventArgs e)
        {
            xoadongduocchon();
        }

        public void xoadongduocchon()
        {
            dgvThongTinQuanLyHoaDonBanHang.ClearSelection();
            dgvThongTinQuanLyHoaDonBanHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongTinQuanLyHoaDonBanHang.MultiSelect = false;
        }
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime tngay = dtpTuNgay.Value;
            DateTime dngay = dtpDenNgay.Value;
            if (tngay > dngay)
            {
                dtpTuNgay.Value = DateTime.Now;
                dtpDenNgay.Value = DateTime.Now;
            }
            dgvThongTinQuanLyHoaDonBanHang.DataSource = QuanLyBanBUS.TimKiemTheoNgay(dtpTuNgay.Value, dtpDenNgay.Value);
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime tngay = dtpTuNgay.Value;
            DateTime dngay = dtpDenNgay.Value;
            if (dngay > DateTime.Now ||dngay<tngay)
            {
                dtpDenNgay.Value = DateTime.Now;
                dtpTuNgay.Value = DateTime.Now;

            }
            dgvThongTinQuanLyHoaDonBanHang.DataSource = QuanLyBanBUS.TimKiemTheoNgay(dtpTuNgay.Value, dtpDenNgay.Value);
        }

    }
}
