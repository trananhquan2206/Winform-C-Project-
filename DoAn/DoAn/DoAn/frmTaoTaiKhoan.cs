using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DoAn
{
    public partial class frmTaoTaiKhoan : Form
    {
        string username;
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        public frmTaoTaiKhoan(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            cboNhanVien.DataSource = NhanVienBUS.dsNhanVienChuaCoTK();
            cboNhanVien.ValueMember = CONSTANTS_TAOTAIKHOAN.MANV;
            cboNhanVien.DisplayMember = CONSTANTS_TAOTAIKHOAN.HOTEN;
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show(CONSTANTS_TAOTAIKHOAN.MES_INPUT_WAR, CONSTANTS_TAOTAIKHOAN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tk = new TaiKhoanDTO
            {
                Username = txtTenDangNhap.Text,
                Password = txtMatKhau.Text,
                MaNV = Convert.ToInt32(cboNhanVien.SelectedValue)
            };

            if (TaiKhoanBUS.themTaiKhoan(tk))
            {
                MessageBox.Show(CONSTANTS_TAOTAIKHOAN.ADD_ACC_SUCC);
                LogBUS.themLog(username, string.Format(CONSTANTS_TAOTAIKHOAN.ADDED_ACC, cboNhanVien.Text));
            }
            else
            {
                MessageBox.Show(CONSTANTS_TAOTAIKHOAN.ADD_ACC_ERR);
            }
            Close();
        }
    }
}
