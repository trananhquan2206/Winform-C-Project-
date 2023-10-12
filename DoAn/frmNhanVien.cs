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
    public partial class frmNhanVien : Form
    {
        string username;
        public frmNhanVien()
        {
            InitializeComponent();
            dgvDSNV.AutoGenerateColumns = false;
        }

        public frmNhanVien(string username)
        {
            InitializeComponent();
            dgvDSNV.AutoGenerateColumns = false;
            this.username = username;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            cboChucVu.SelectedIndex = 2;
            LoadDSNV();
        }

        private void LoadDSNV()
        {
            dgvDSNV.DataSource = NhanVienBUS.layDSNV();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiem_IconRightClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text)) 
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.SERACH_INPUT_WAR, CONSTANTS_NHANVIEN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radMaNV.Checked)
            {
                dgvDSNV.DataSource = NhanVienBUS.timKiemTheoMa(Convert.ToInt32(txtTimKiem.Text));
            }
            else if (radHoTen.Checked)
            {
                dgvDSNV.DataSource = NhanVienBUS.timKiemTheoTen(txtTimKiem.Text);
            }
            else if (radSDT.Checked)
            {
                dgvDSNV.DataSource = NhanVienBUS.timKiemTheoSDT(txtTimKiem.Text);
            }
            else
            {
                dgvDSNV.DataSource = NhanVienBUS.timKiemTheoEmail(txtTimKiem.Text);
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDSNV();
            Reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (NhanVienBUS.checkInput(txtHoTen.Text, txtEmail.Text, txtDiaChi.Text, txtLuong.Text, txtSDT.Text))
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.MES_INPUT_WAR, CONSTANTS_NHANVIEN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NhanVienBUS.checkValid(dtpNgaySinh.Value, dtpNgayVaoLam.Value))
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.VALID_DAY_MES, CONSTANTS_NHANVIEN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!NhanVienBUS.IsEmailValid(txtEmail.Text))
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.INVALID_EMAIL, CONSTANTS_NHANVIEN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVienDTO nvDTO = new NhanVienDTO
            {
                HoTen = txtHoTen.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                NgaySinh = dtpNgaySinh.Value,
                NgayVaoLam = dtpNgayVaoLam.Value,
                Luong = Convert.ToDouble(txtLuong.Text),
                ChucVu = cboChucVu.Text,
            };

           
            if (NhanVienBUS.themNhanVien(nvDTO))
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.ADD_USER_SUCC);
                string content = string.Format(CONSTANTS_NHANVIEN.ADDED_USER, txtHoTen.Text);
                LogBUS.themLog(username, content);
            }
            else
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.ADD_USER_ERR);
            }
            LoadDSNV();
        }


        private void Reset()
        {
            txtMaNV.Text =string.Empty;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();
            txtTimKiem.Clear();
            cboChucVu.SelectedIndex = CONSTANTS_NHANVIEN.TWO;
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
            txtTimKiem.Clear();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (NhanVienBUS.checkInput(txtHoTen.Text, txtEmail.Text, txtDiaChi.Text, txtLuong.Text, txtSDT.Text))
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.MES_INPUT_WAR, CONSTANTS_NHANVIEN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NhanVienBUS.checkValid(dtpNgaySinh.Value, dtpNgayVaoLam.Value))
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.VALID_DAY_MES, CONSTANTS_NHANVIEN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVienDTO nvDTO = new NhanVienDTO
            {
                MaNV = Convert.ToInt32(txtMaNV.Text),
                HoTen = txtHoTen.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                NgaySinh = dtpNgaySinh.Value,
                NgayVaoLam = dtpNgayVaoLam.Value,
                Luong = Convert.ToDouble(txtLuong.Text),
                ChucVu = cboChucVu.Text,
            };

            if (NhanVienBUS.chinhSuaNhanVien(nvDTO))
            {
                MessageBox.Show("Cập nhật thành công");
                string content = string.Format(CONSTANTS_NHANVIEN.UPDATED_USER, txtHoTen.Text);
                LogBUS.themLog(username, content);
            }
            else
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.UPDATE_USER_ERR);
            }
            LoadDSNV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show(CONSTANTS_NHANVIEN.SELECT_USER_DEL, CONSTANTS_NHANVIEN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(CONSTANTS_NHANVIEN.DEL_USE_CONF, CONSTANTS_NHANVIEN.CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                

                if (TaiKhoanBUS.checkTrung(username, Convert.ToInt32(txtMaNV.Text)))
                {
                    MessageBox.Show(CONSTANTS_NHANVIEN.CAN_NOT_DEL_BY_SELF, CONSTANTS_NHANVIEN.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (NhanVienBUS.xoaNhanVien(Convert.ToInt32(txtMaNV.Text)))
                {
                    int manv = Convert.ToInt32(txtMaNV.Text);
                    MessageBox.Show(CONSTANTS_NHANVIEN.DELETE_USER_SUCC);
                    if (TaiKhoanBUS.checkTonTai(manv))
                    {
                        string username = TaiKhoanBUS.layTaiKhoan(manv);
                        TaiKhoanBUS.xoaTaiKhoan(username);
                    }
                    string content = string.Format(CONSTANTS_NHANVIEN.DELETED_USER, txtHoTen.Text);
                    LogBUS.themLog(username, content);
                }
                else
                {
                    MessageBox.Show(CONSTANTS_NHANVIEN.DELETE_USER_ERR);
                }
                LoadDSNV();
                Reset();
            }
        }

        private void dgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvDSNV.Rows[e.RowIndex];
            txtMaNV.Text = row.Cells[CONSTANTS_NHANVIEN.ZERO].Value.ToString();
            txtHoTen.Text = row.Cells[CONSTANTS_NHANVIEN.ONE].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells[CONSTANTS_NHANVIEN.TWO].Value);
            dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells[CONSTANTS_NHANVIEN.THREE].Value);
            cboChucVu.Text = row.Cells[CONSTANTS_NHANVIEN.FOUR].Value.ToString();
            txtSDT.Text = row.Cells[CONSTANTS_NHANVIEN.FIVE].Value.ToString();
            txtEmail.Text = row.Cells[CONSTANTS_NHANVIEN.SIX].Value.ToString();
            txtDiaChi.Text = row.Cells[CONSTANTS_NHANVIEN.SEVEN].Value.ToString();
            txtLuong.Text = row.Cells[CONSTANTS_NHANVIEN.EIGHT].Value.ToString();
        }


    }
}
