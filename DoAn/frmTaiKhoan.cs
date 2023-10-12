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
    public partial class frmTaiKhoan : Form
    {
        string username;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        public frmTaiKhoan(string username)
        {
            InitializeComponent();
            this.username = username;
            dgvDSNV.AutoGenerateColumns = false;
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            loadDSTK();
        }

        private void loadDSTK()
        {
            dgvDSNV.DataSource = TaiKhoanBUS.layDSTK();
        }

        private void dgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dgvDSNV.Rows[e.RowIndex];
            txtMaNV.Text = row.Cells[CONSTANTS_TAIKHOAN.COL_MANV].Value.ToString();
            txtTaiKhoan.Text = row.Cells[CONSTANTS_TAIKHOAN.COL_TAIKHOAN].Value.ToString();
            txtHoTen.Text = row.Cells[CONSTANTS_TAIKHOAN.COL_HOTEN].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmTaoTaiKhoan frm = new frmTaoTaiKhoan(username);
            frm.ShowDialog();
            loadDSTK();
            reset();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show(CONSTANTS_TAIKHOAN.SEL_ACC_WAR, CONSTANTS_TAIKHOAN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmDoiMatKhau frm = new frmDoiMatKhau(username, txtHoTen.Text, txtTaiKhoan.Text);
            frm.ShowDialog();
            loadDSTK();
            reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show(CONSTANTS_TAIKHOAN.DEL_ACC_WAR, CONSTANTS_TAIKHOAN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TaiKhoanBUS.checkTrung(username, txtTaiKhoan.Text))
            {
                MessageBox.Show(CONSTANTS_TAIKHOAN.CAN_NOT_DEL_MES, CONSTANTS_TAIKHOAN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show(CONSTANTS_TAIKHOAN.DEL_ACC_CONF, CONSTANTS_TAIKHOAN.CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                if (TaiKhoanBUS.xoaTaiKhoan(txtTaiKhoan.Text))
                {
                    MessageBox.Show(CONSTANTS_TAIKHOAN.DEL_ACC_SUCC);
                    LogBUS.themLog(username, string.Format(CONSTANTS_TAIKHOAN.DELETED_ACC, txtTaiKhoan.Text));
                }
                else
                {
                    MessageBox.Show(CONSTANTS_TAIKHOAN.DEL_ACC_ERR);
                }
                reset();
                loadDSTK();
            }
            
        }
        private void reset()
        {
            txtMaNV.Clear();
            txtTaiKhoan.Clear();
            txtHoTen.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void txtTimKiem_IconRightClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                MessageBox.Show(CONSTANTS_TAIKHOAN.SEARCH_INPUT_WAR, CONSTANTS_TAIKHOAN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvDSNV.DataSource = TaiKhoanBUS.timKiem(txtTimKiem.Text);
        }
    }
}
