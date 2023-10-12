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
using DoAn;

namespace do_an_winform
{
    public partial class frmChiTietHoaDonNhap : Form
    {
        string username;
        CTHD_NhapBUS CTHD_NhapBUS = new CTHD_NhapBUS(); 

        public frmChiTietHoaDonNhap()
        {
            InitializeComponent();
            dgvChiTietThongTinHoaDonNhapHang.AutoGenerateColumns = false;
        }

        public frmChiTietHoaDonNhap(string username)
        {
            InitializeComponent();
            dgvChiTietThongTinHoaDonNhapHang.AutoGenerateColumns = false;
            this.username = username;
        }

        public void layMaHD(int mahd)
        {
            txtMaHoaDon.Text = mahd.ToString();
            dgvChiTietThongTinHoaDonNhapHang.DataSource = CTHD_NhapBUS.layDSCTHDNhap(mahd);
        }

        public void layNgay(string ngay)
        {
            dtpNgayLap.Text = ngay;
        }
        public void layTenNV(string tennv)
        {
            txtTenNhanVien.Text = tennv;
        }

        public void layMaNV(string manv)
        {
            txtMaNhanVien.Text = manv;
        }

        public void layTenNCC(string tenncc)
        {
            txtTenNhaCungCap.Text = tenncc;
        }

        public void layMaNCC(string mancc)
        {
            txtMaNhaCungCap.Text = mancc;
        }

        public void layThanhTien(string thanhtien)
        {
            txtTongTien.Text = thanhtien;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(CONSTANTS_CHITIETHOADON.MES_OUT_CONFIRM, CONSTANTS_CHITIETHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form frm = Application.OpenForms[CONSTANTS_CHITIETHOADON.frmQuanLyNhapHang];
                frm.Show();
                this.Close();
            }
        }
    }
}
