using BUS;
using do_an_winform;
//using Đơn_Nhập.Ban_Hang;
//using Đơn_Nhập.Nhap_Hang;
using Fut;
using Fut.KhachHang;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmTrangChu : Form
    {
        Form currentForm = null;
        frmDangNhap frmDangNhap;
        string hoTen, chucVu, username;
        bool isDropdownNV = true;
        bool isDropdownHD = true;
        bool isDropdownKH = true;
        bool isDropdownNCC = true;
        

        public static frmTrangChu Instance;

        // Tạo một phương thức khởi tạo để gán thể hiện của Form trang chủ cho biến Instance
        public frmTrangChu()
        {
            InitializeComponent();
            Instance = this;
        }

        public frmTrangChu(string hoTen, string chucVu,string username, frmDangNhap frmDangNhap)
        {
            InitializeComponent();
            this.hoTen = hoTen;
            this.chucVu = chucVu;
            this.username = username;
            this.frmDangNhap = frmDangNhap;
            this.KeyPreview = true;
        }

        


        private void Form1_Load(object sender, EventArgs e)
        {
            pnlNhanVien.Size = pnlNhanVien.MinimumSize;
            pnlHoaDon.Size = pnlHoaDon.MinimumSize;
            pnlKhachHang.Size = pnlKhachHang.MinimumSize;
            pnlNCC.Size = pnlNCC.MinimumSize;
            lblHoTen.Text = hoTen;
            lblChucVu.Text = chucVu;
            loadPhanQuyen();
        }

        private void loadPhanQuyen()
        {
            if (chucVu == CONSTANTS_TRANGCHU.NVKHO_ROLE)
            {
                pnlNhanVien.Visible = false;
                pnlKhachHang.Visible = false;
                btnThongKe.Visible = false;
                btnLog.Visible = false;
                btnHoaDonXuat.Visible = false;
                btnThemHDXuat.Visible = false;
                pnlHoaDon.MaximumSize = new Size(227, 124);
            }

            else if (chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE)
            {
                btnSanPham.Visible = false;
                pnlNhanVien.Visible = false;
                pnlNCC.Visible = false;
                btnThongKe.Visible = false;
                btnLog.Visible = false;
                btnHoaDonNhap.Visible = false;
                btnThemHDNhap.Visible = false;
                pnlHoaDon.MaximumSize = new Size(227, 124);
            }
        }

        private void btnHoaDon2_Click(object sender, EventArgs e)
        {
            pnlHoaDon.Size = isDropdownHD ? pnlHoaDon.MaximumSize : pnlHoaDon.MinimumSize;
            isDropdownHD = !isDropdownHD;
            btnHoaDon.Image = isDropdownHD ? Properties.Resources.icons8_down_button_24 : Properties.Resources.icons8_slide_up_48;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pnlNhanVien.Size = isDropdownNV ? pnlNhanVien.MaximumSize : pnlNhanVien.MinimumSize;
            isDropdownNV = !isDropdownNV;
            btnNhanVien.Image = isDropdownNV ? Properties.Resources.icons8_down_button_24 : Properties.Resources.icons8_slide_up_48;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnlKhachHang.Size = isDropdownKH ? pnlKhachHang.MaximumSize : pnlKhachHang.MinimumSize;
            isDropdownKH = !isDropdownKH;
            btnKhachHang.Image = isDropdownKH ? Properties.Resources.icons8_down_button_24 : Properties.Resources.icons8_slide_up_48;
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            pnlNCC.Size = isDropdownNCC ? pnlNCC.MaximumSize : pnlNCC.MinimumSize;
            isDropdownNCC = !isDropdownNCC;
            btnNCC.Image = isDropdownNCC ? Properties.Resources.icons8_down_button_24 : Properties.Resources.icons8_slide_up_48;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(CONSTANTS_TRANGCHU.LOGOUT_CONF, CONSTANTS_TRANGCHU.CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LogBUS.themLog(username, CONSTANTS_TRANGCHU.LOGOUT);
                frmDangNhap.Show();
                Close();
            }
        }

        private void btnDSNV_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmNhanVien)
                {
                    return;
                }

                currentForm.Close();
            }
            frmNhanVien frm = new frmNhanVien(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmTaiKhoan)
                {
                    return;
                }

                currentForm.Close();
            }
            frmTaiKhoan frm = new frmTaiKhoan(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmSanPham)
                {
                    return;
                }

                currentForm.Close();
            }
            frmSanPham frm = new frmSanPham(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmQuanLyNhapHang)
                {
                    return;
                }

                currentForm.Close();
            }
            frmQuanLyNhapHang frm = new frmQuanLyNhapHang(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnHoaDonXuat_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmQuanLyBanHang)
                {
                    return;
                }

                currentForm.Close();
            }
            frmQuanLyBanHang frm = new frmQuanLyBanHang(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnDSKH_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmThong_Tin_Khach_Hang)
                {
                    return;
                }

                currentForm.Close();
            }
            frmThong_Tin_Khach_Hang frm = new frmThong_Tin_Khach_Hang(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmKhach_Hang)
                {
                    return;
                }

                currentForm.Close();
            }
            frmKhach_Hang frm = new frmKhach_Hang(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnDSNCC_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmThong_Tin_NCC)
                {
                    return;
                }

                currentForm.Close();
            }
            frmThong_Tin_NCC frm = new frmThong_Tin_NCC(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnQLNCC_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmNha_Cung_Cap)
                {
                    return;
                }

                currentForm.Close();
            }
            frmNha_Cung_Cap frm = new frmNha_Cung_Cap(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmThongKe)
                {
                    return;
                }

                currentForm.Close();
            }
            frmThongKe frm = new frmThongKe(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmLog)
                {
                    return;
                }

                currentForm.Close();
            }
            frmLog frm = new frmLog();
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnThemHDXuat_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmThemHoaDonBan)
                {
                    return;
                }

                currentForm.Close();
            }
            frmThemHoaDonBan frm = new frmThemHoaDonBan(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnThemHDNhap_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmThemHoaDonNhap)
                {
                    return;
                }

                currentForm.Close();
            }
            frmThemHoaDonNhap frm = new frmThemHoaDonNhap(username);
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnCTHDNhap_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmChiTietHoaDonNhap)
                {
                    return;
                }

                currentForm.Close();
            }
            frmChiTietHoaDonNhap frm = new frmChiTietHoaDonNhap();
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnCTHDXuat_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                if (currentForm is frmChiTietHoaDonBan)
                {
                    return;
                }

                currentForm.Close();
            }
            frmChiTietHoaDonBan frm = new frmChiTietHoaDonBan();
            currentForm = frm;
            frm.MdiParent = this;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void frmTrangChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVKHO_ROLE || chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE ) { return; }
                btnDSNV_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVKHO_ROLE || chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE) { return; }
                btnQLTK_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE)
                {
                    return;
                }
                btnSanPham_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVKHO_ROLE)
                {
                    return;
                }
                btnDSKH_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVKHO_ROLE)
                {
                    return;
                }
                btnQLKH_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE)
                {
                    return;
                }
                btnDSNCC_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F7)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE)
                {
                    return;
                }
                btnQLNCC_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                if ( chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE) { return; }
                btnHoaDonNhap_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVKHO_ROLE) { return; }
                btnHoaDonXuat_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVKHO_ROLE || chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE) { return; }
                btnThongKe_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
            {
                if (chucVu == CONSTANTS_TRANGCHU.NVKHO_ROLE || chucVu == CONSTANTS_TRANGCHU.NVBANHANG_ROLE) { return; }
                btnLog_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnDangXuat_Click(sender, e);
            }
        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
        public Guna2Panel GetPanel()
        {
            return pnlMain;
        }

    }
}
