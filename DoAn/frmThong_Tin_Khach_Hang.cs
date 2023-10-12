using BUS;
using DAO;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DoAn;
using DTO;
using Fut.KhachHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fut
{
    public partial class frmThong_Tin_Khach_Hang : Form
    {
        string username;
        Thong_Tin_Khach_HangBUS _khachHangBUS = new Thong_Tin_Khach_HangBUS();

        public frmThong_Tin_Khach_Hang()
        {
            InitializeComponent();

            dgvKH.AutoGenerateColumns = false;
        }

        public frmThong_Tin_Khach_Hang(string username)
        {
            InitializeComponent();

            dgvKH.AutoGenerateColumns = false;
            this.username = username;
        }

        private void dtpNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            if(dtpNgaySinh.Value >  DateTime.Now)
            {
                dtpNgaySinh.BorderColor = Color.Red;
                dtpNgaySinh.Value = DateTime.Now;
                dtpNgaySinh.Focus();
            }
            else
            {
                dtpNgaySinh.BorderColor = SystemColors.Window;
            }
        }

        private void LoadData()
        {
            dgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKH.CurrentCell = null;

            dgvKH.Columns[CONSTANTS_KHACHHANG.colGioiTinh_dgv].DataPropertyName = "GioiTinhText";

            cboGioiTinh.SelectedIndex = 0;

            dtpNgaySinh.Value = DateTime.Now;

            dgvKH.DataSource = _khachHangBUS.LayDanhSachKhachHang();
        }

        private void frmThong_Tin_Khach_Hang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgaySinh.Value > DateTime.Now)
            {
                dtpNgaySinh.Value = DateTime.Now;
            }
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txtMaKH.Text = dgvKH.Rows[e.RowIndex].Cells[CONSTANTS_KHACHHANG.colMaKH_dgv].Value.ToString();
            txtTenKH.Text = dgvKH.Rows[e.RowIndex].Cells[CONSTANTS_KHACHHANG.colTenKH_dgv].Value.ToString();
            cboGioiTinh.SelectedValue = dgvKH.Rows[e.RowIndex].Cells[CONSTANTS_KHACHHANG.colGioiTinh_dgv].Value.ToString() == "Nam" ? cboGioiTinh.SelectedIndex = 0 : cboGioiTinh.SelectedIndex = 1;
            dtpNgaySinh.Value = Convert.ToDateTime(dgvKH.Rows[e.RowIndex].Cells[CONSTANTS_KHACHHANG.colNgaySinh_dgv].Value.ToString());
            txtDiaChi.Text = dgvKH.Rows[e.RowIndex].Cells[CONSTANTS_KHACHHANG.colDiaChi_dgv].Value.ToString();
            txtSDT.Text = dgvKH.Rows[e.RowIndex].Cells[CONSTANTS_KHACHHANG.colSDT_dgv].Value.ToString();
        }

        private void Reset()
        {
            txtMaKH.Enabled = true;
            txtMaKH.Clear();
            txtMaKH.Enabled = false;
            txtTenKH.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtSDT.Clear();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text.Trim()) || string.IsNullOrEmpty(txtDiaChi.Text.Trim()) || string.IsNullOrEmpty(txtSDT.Text.Trim()))
            {
                MessageBox.Show(CONSTANTS_KHACHHANG.MES_WAR_INPUT, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sdt = txtSDT.Text.Trim();

            if (sdt.Length != 10)
            {
                MessageBox.Show(CONSTANTS_KHACHHANG.MES_WAR_NUMPHONE, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool gioiTinh = false;

            if (cboGioiTinh.SelectedIndex == 0)
            {
                gioiTinh = true;
            }

            Khach_HangDTO newKH = new Khach_HangDTO
            {
                TenKH = txtTenKH.Text.Trim(),
                GioiTinh = gioiTinh,
                NgaySinh = Convert.ToDateTime(dtpNgaySinh.Value.ToString()),
                DiaChi = txtDiaChi.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                TrangThai = false
            };

            if (_khachHangBUS.ThemKhachHang(newKH))
            {
                MessageBox.Show(CONSTANTS_KHACHHANG.MES_ADD_SUCCESS, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(CONSTANTS_KHACHHANG.MES_ADD_FAIL, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();

            Reset();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show(CONSTANTS_KHACHHANG.MES_WAR_INPUT, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sdt = txtSDT.Text.Trim();

            if (sdt.Length != 10)
            {
                MessageBox.Show(CONSTANTS_KHACHHANG.MES_WAR_NUMPHONE, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dlr = MessageBox.Show(CONSTANTS_KHACHHANG.MES_UPDATE_CONFIRM, CONSTANTS_KHACHHANG.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlr == DialogResult.Yes)
            {

                bool gioiTinh;

                if (cboGioiTinh.SelectedItem != null && cboGioiTinh.SelectedIndex == 0)
                {
                    gioiTinh = true;
                }
                else
                {
                    gioiTinh = false;
                }

                Khach_HangDTO kh = new Khach_HangDTO
                {
                    MaKH = Convert.ToInt32(txtMaKH.Text),
                    TenKH = txtTenKH.Text.Trim(),
                    GioiTinh = gioiTinh,
                    NgaySinh = Convert.ToDateTime(dtpNgaySinh.Value.ToString()),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SDT = txtSDT.Text.Trim()
                };

                if (_khachHangBUS.CapNhatKhachHang(kh))
                {
                    MessageBox.Show(CONSTANTS_KHACHHANG.MES_UPDATE_SUCCESS, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(CONSTANTS_KHACHHANG.MES_UPDATE_FAIL, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadData();

            Reset();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show(CONSTANTS_KHACHHANG.MES_DEL_ISSELECTED, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dlr = MessageBox.Show(CONSTANTS_KHACHHANG.MES_DEL_CONFIRM, CONSTANTS_KHACHHANG.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlr == DialogResult.Yes)
            {
                int maKH = Convert.ToInt32(txtMaKH.Text);

                bool result = _khachHangBUS.XoaKhachHang(maKH);

                if (result)
                {
                    MessageBox.Show(CONSTANTS_KHACHHANG.MES_DEL_SUCCESS, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(CONSTANTS_KHACHHANG.MES_DEL_FAIL, CONSTANTS_KHACHHANG.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadData();

            Reset();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            rptKhachHang rpt = new rptKhachHang();
            var result = _khachHangBUS.LayDanhSachKhachHang();
            rpt.DataSource = result;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
