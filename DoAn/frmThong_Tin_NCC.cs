using BUS;
using DevExpress.XtraReports.UI;
using DoAn;
using DTO;
using Fut.KhachHang;
using Fut.NhaCungCap;
using Guna.UI2.WinForms.Suite;
//using RestSharp.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Interop;

namespace Fut
{
    public partial class frmThong_Tin_NCC : Form
    {
        Thong_Tin_Nha_Cung_CapBUS _nhaCungCapBUS = new Thong_Tin_Nha_Cung_CapBUS();
        string username;
        public frmThong_Tin_NCC()
        {
            InitializeComponent();

            dgvNCC.AutoGenerateColumns = false;
        }
        public frmThong_Tin_NCC(string username)
        {
            InitializeComponent();

            dgvNCC.AutoGenerateColumns = false;
            this.username = username;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            txtEmail.BorderColor = SystemColors.Window;

            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            if(!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!regex.IsMatch(txtEmail.Text))
                {
                    txtEmail.BorderColor = Color.Red;
                    MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_WAR_EMAIL, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
                else
                {
                    txtEmail.BorderColor = SystemColors.Window;
                }
            }    
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadData()
        {
            dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNCC.CurrentCell = null;

            dgvNCC.CellFormatting += dgvNCC_CellFormatting;

            dgvNCC.DataSource = _nhaCungCapBUS.LayDanhSachNhaCungCap();
        }

        private void dgvNCC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvNCC.Columns[CONSTANTS_NHACUNGCAP.colMST_dgv].Index && e.Value != null)
            {
                string mst = e.Value.ToString();
                if (mst.Length == 13)
                {
                    e.Value = string.Format("{0:0000000000-000}", long.Parse(mst.Replace("-", string.Empty)));
                    e.FormattingApplied = true;
                }
            }
        }

        private void frmThong_Tin_NCC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txtMaNCC.Text = dgvNCC.Rows[e.RowIndex].Cells[CONSTANTS_NHACUNGCAP.colMaNCC_dgv].Value.ToString();
            txtTenNCC.Text = dgvNCC.Rows[e.RowIndex].Cells[CONSTANTS_NHACUNGCAP.colTenNCC_dgv].Value.ToString();
            txtDiaChi.Text = dgvNCC.Rows[e.RowIndex].Cells[CONSTANTS_NHACUNGCAP.colDiaChi_dgv].Value.ToString();
            txtEmail.Text = dgvNCC.Rows[e.RowIndex].Cells[CONSTANTS_NHACUNGCAP.colEmail_dgv].Value.ToString();
            txtSDT.Text = dgvNCC.Rows[e.RowIndex].Cells[CONSTANTS_NHACUNGCAP.colSDT_dgv].Value.ToString();
            txtMST.Text = dgvNCC.Rows[e.RowIndex].Cells[CONSTANTS_NHACUNGCAP.colMST_dgv].Value != null ? dgvNCC.Rows[e.RowIndex].Cells[CONSTANTS_NHACUNGCAP.colMST_dgv].Value.ToString() : null;
        }

        private void Reset()
        {
            txtMaNCC.Enabled = true;
            txtMaNCC.Clear();
            txtMaNCC.Enabled = false;

            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtMST.Clear();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_WAR_INPUT, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mst = txtMST.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (mst.Length != 13 && !string.IsNullOrEmpty(mst))
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_WAR_TAXCODE, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if(sdt.Length != 10)
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_WAR_NUMPHONE, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Nha_Cung_CapDTO newNCC = new Nha_Cung_CapDTO
            {
                TenNCC = txtTenNCC.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                MaSoThue = txtMST.Text.Trim(),
                TrangThai = false
            };

            if (_nhaCungCapBUS.ThemNhaCungCap(newNCC))
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_ADD_SUCCESS, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_ADD_FAIL, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();

            Reset();
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_WAR_INPUT, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mst = txtMST.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (mst.Length != 13 && !string.IsNullOrEmpty(mst))
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_WAR_TAXCODE, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sdt.Length != 10)
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_WAR_NUMPHONE, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dlr = MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_UPDATE_CONFIRM, CONSTANTS_NHACUNGCAP.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlr == DialogResult.Yes)
            {
                Nha_Cung_CapDTO ncc = new Nha_Cung_CapDTO
                {
                    MaNCC = Convert.ToInt32(txtMaNCC.Text),
                    TenNCC = txtTenNCC.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    MaSoThue = txtMST.Text.Trim()
                };

                if (_nhaCungCapBUS.CapNhatNhaCungCap(ncc))
                {
                    MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_UPDATE_SUCCESS, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_UPDATE_FAIL, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadData();

            Reset();
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_DEL_ISSELECTED, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dlr = MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_DEL_CONFIRM, CONSTANTS_NHACUNGCAP.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlr == DialogResult.Yes)
            {
                int maNCC = Convert.ToInt32(txtMaNCC.Text);

                bool result = _nhaCungCapBUS.XoaNhaCungCap(maNCC);

                if (result)
                {
                    MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_DEL_SUCCESS, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(CONSTANTS_NHACUNGCAP.MES_DEL_FAIL, CONSTANTS_NHACUNGCAP.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            rptNhaCungCap rpt = new rptNhaCungCap();
            var result = _nhaCungCapBUS.LayDanhSachNhaCungCap();
            rpt.DataSource = result;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
