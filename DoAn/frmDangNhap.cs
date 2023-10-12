using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmDangNhap : Form
    {
        bool isShowPass = false;
        public frmDangNhap()
        {
            InitializeComponent();
        }


        private void txtMatKhau_IconRightClick(object sender, EventArgs e)
        {
            txtMatKhau.IconRight = isShowPass ? Properties.Resources.icons8_eye_32 : Properties.Resources.icons8_hide_32;
            txtMatKhau.PasswordChar = isShowPass ? CONSTANTS_DANGNHAP.PASS_CHAR : CONSTANTS_DANGNHAP.PASS_NOTHING;
            isShowPass = !isShowPass;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text.Trim()) || string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show(CONSTANTS_DANGNHAP.MES_INPUT_WAR, CONSTANTS_DANGNHAP.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TaiKhoanBUS.checkLogin(txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim()))
            {
                string hoTen = NhanVienBUS.layHoTen(txtTenDangNhap.Text.Trim());
                string chucVu = NhanVienBUS.layChucVu(txtTenDangNhap.Text.Trim());

                MessageBox.Show(CONSTANTS_DANGNHAP.LOGIN_SUCC);

                Form frmTrangChu = Application.OpenForms[CONSTANTS_DANGNHAP.MAIN_FORM];

                if (frmTrangChu != null)
                {
                    frmTrangChu.Show();
                }
                else
                {
                    frmTrangChu frm = new frmTrangChu(hoTen, chucVu, txtTenDangNhap.Text, this);
                    frm.Show();
                }
                LogBUS.themLog(txtTenDangNhap.Text.Trim(), CONSTANTS_DANGNHAP.LOGIN);
                Hide();
            }
            else
            {
                MessageBox.Show(CONSTANTS_DANGNHAP.USERNAME_OR_PASS_ERR);
            }

            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

        }
    }
}
