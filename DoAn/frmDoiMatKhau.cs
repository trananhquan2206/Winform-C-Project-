using BUS;
using DTO;
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
    public partial class frmDoiMatKhau : Form
    {
        string user, hoTen, taiKhoan;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public frmDoiMatKhau(string user, string hoTen, string taiKhoan)
        {
            InitializeComponent();
            this.user = user;
            this.taiKhoan = taiKhoan;
            this.hoTen = hoTen;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhauCu.Text.Trim()) || string.IsNullOrEmpty(txtMatKhauMoi.Text.Trim()))
            {
                MessageBox.Show(CONSTANTS_DOIMATKHAU.MES_INPUT_FULL, CONSTANTS_DOIMATKHAU.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TaiKhoanBUS.checkPassword(user, txtMatKhauCu.Text.Trim()))
            {
                MessageBox.Show(CONSTANTS_DOIMATKHAU.OLD_PASS_ERR, CONSTANTS_DOIMATKHAU.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMatKhauCu.Text.Trim() == txtMatKhauMoi.Text.Trim())
            {
                MessageBox.Show(CONSTANTS_DOIMATKHAU.SAME_PASS, CONSTANTS_DOIMATKHAU.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tk = new TaiKhoanDTO
            {
                Username = txtTenDangNhap.Text,
                Password = txtMatKhauMoi.Text.Trim()
            };

            if (TaiKhoanBUS.doiMatKhau(tk))
            {
                MessageBox.Show(CONSTANTS_DOIMATKHAU.CHANGE_PASS_SUCC);
                LogBUS.themLog(user, string.Format(CONSTANTS_DOIMATKHAU.CHANGED_PASS, txtNhanVien.Text));
            }
            else
            {
                MessageBox.Show(CONSTANTS_DOIMATKHAU.CHANGE_PASS_ERR);
            }
            Close();
        }

        

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtNhanVien.Text = hoTen;
            txtTenDangNhap.Text = taiKhoan;
        }
    }
}
