using BUS;
using DoAn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace do_an_winform
{
    public partial class frmChiTietHoaDonBan : Form
    {
        CTHD_BanBUS CTHD_BanBUS = new CTHD_BanBUS();
        string username;
        public frmChiTietHoaDonBan()
        {
            InitializeComponent();
            dgvChiTietHoaDonBan.AutoGenerateColumns = false;
        }

        public frmChiTietHoaDonBan(string username)
        {
            InitializeComponent();
            dgvChiTietHoaDonBan.AutoGenerateColumns = false;
            this.username = username;
        }

        public void layMaHD(int mahd)
        {
            txtMaHoaDon.Text = mahd.ToString();
            dgvChiTietHoaDonBan.DataSource = CTHD_BanBUS.layDSCTHDBan(mahd);
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

        public void layTenKH(string tennkh)
        {
            txtTenKhachHang.Text = tennkh;
        }

        public void layMaKH(string makh)
        {
            txtMaKhachHang.Text = makh;
        }

        public void layThanhTien(string thanhtien)
        {
            txtTongTien.Text = thanhtien;
        }

        public void laySDT(string SDT)
        {
            txtSDT.Text = SDT;
        }

        public void layDiaCHi(string diachi)
        {
            txtDiaChi.Text = diachi;
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(CONSTANTS_CHITIETHOADON.MES_OUT_CONFIRM, CONSTANTS_CHITIETHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form frm = Application.OpenForms[CONSTANTS_CHITIETHOADON.frmQuanLyBanHang];
                frm.Show();
                this.Close();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
