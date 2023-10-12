using BUS;
using DTO;
using Fut.NhaCungCap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fut.KhachHang
{
    public partial class frmNha_Cung_Cap : Form
    {
        string username;
        Nha_Cung_CapBUS _nhaCungCapBUS = new Nha_Cung_CapBUS();

        public frmNha_Cung_Cap()
        {
            InitializeComponent();

            dgvQuanLyNCC.AutoGenerateColumns = false;

            dtpFrom.Value = dtpTo.Value = DateTime.Now;

            cboBoLocNCC.Enabled = true;
            cboTimKiemNCC.Enabled = false;
        }

        public frmNha_Cung_Cap(string username)
        {
            InitializeComponent();

            dgvQuanLyNCC.AutoGenerateColumns = false;

            dtpFrom.Value = dtpTo.Value = DateTime.Now;

            cboBoLocNCC.Enabled = true;
            cboTimKiemNCC.Enabled = false;
            this.username = username;
        }

        private void LoadData()
        {
            dgvQuanLyNCC.DataSource = _nhaCungCapBUS.LayDanhSachNhaCungCap();
        }

        private void frmNha_Cung_Cap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboBoLocNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();

            cboTimKiemNCC.Enabled = true;

            string columnName = "";
            string tableName = "NHACUNGCAP";

            if (cboBoLocNCC.SelectedIndex != -1)
            {
                if (cboBoLocNCC.SelectedIndex == 0)
                {
                    columnName = CONSTANTS_NHACUNGCAP.colMaNCC;
                }
                else if (cboBoLocNCC.SelectedIndex == 1)
                {
                    columnName = CONSTANTS_NHACUNGCAP.colTenNCC;
                }
                else if (cboBoLocNCC.SelectedIndex == 2)
                {
                    columnName = CONSTANTS_NHACUNGCAP.colTenSP;
                    tableName = "SANPHAM";
                }

                if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(tableName))
                {
                    return;
                }

                List<string> distinctValues = _nhaCungCapBUS.GetDistinctValuesFromColumn(tableName, CONSTANTS_NHACUNGCAP.colTrangThai, "1", columnName);

                cboTimKiemNCC.Items.Clear();

                foreach (string value in distinctValues)
                {
                    cboTimKiemNCC.Items.Add(value);
                }
            }
        }

        public DataTable ConvertToDataTable(List<Nha_Cung_CapDTO> nccList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(CONSTANTS_NHACUNGCAP.colMaNCC, typeof(int));
            dt.Columns.Add(CONSTANTS_NHACUNGCAP.colTenNCC, typeof(string));
            dt.Columns.Add(CONSTANTS_NHACUNGCAP.colSoDonHang, typeof(int));
            dt.Columns.Add(CONSTANTS_NHACUNGCAP.colTongTien, typeof(string));

            foreach (var ncc in nccList)
            {
                string tongTienString = ncc.TongTien?.ToString() ?? "0";
                double tongTienDouble;
                if (double.TryParse(tongTienString, out tongTienDouble))
                {
                    string formattedTongTien = string.Format("{0:#,##0}", tongTienDouble);
                    DataRow row = dt.NewRow();
                    row[CONSTANTS_NHACUNGCAP.colMaNCC] = ncc.MaNCC;
                    row[CONSTANTS_NHACUNGCAP.colTenNCC] = ncc.TenNCC;
                    row[CONSTANTS_NHACUNGCAP.colSoDonHang] = ncc.SoDonHang;
                    row[CONSTANTS_NHACUNGCAP.colTongTien] = formattedTongTien;
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        private void cboTimKiemNCC_SelectedValueChanged(object sender, EventArgs e)
        {
            string tableName = "NHACUNGCAP";
            string columnName = "";
            string value = "";


            if (cboBoLocNCC.SelectedIndex == 0)
            {
                columnName = CONSTANTS_NHACUNGCAP.colMaNCC;
            }
            else if (cboBoLocNCC.SelectedIndex == 1)
            {
                columnName = CONSTANTS_NHACUNGCAP.colTenNCC;
            }
            else if (cboBoLocNCC.SelectedIndex == 2)
            {
                tableName = "SANPHAM";
                columnName = CONSTANTS_NHACUNGCAP.colTenSP;
            }

            if (cboTimKiemNCC.Items != null && cboBoLocNCC.SelectedIndex != -1)
            {
                value = cboTimKiemNCC.SelectedItem.ToString();
            }

            DataTable tbl = ConvertToDataTable(_nhaCungCapBUS.TimKiemTheoBoLoc(tableName, columnName, value));

            dgvQuanLyNCC.DataSource = tbl;
        }

        private void dtpValueChanged(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;

            if (dtpFrom.Value > DateTime.Now || dtpTo.Value > DateTime.Now)
            {
                dtpFrom.Value = dtpTo.Value = DateTime.Now;
            }

            if (dtpFrom.Value > dtpTo.Value)
            {
                DateTime time = dtpFrom.Value;
                dtpFrom.Value = dtpTo.Value;
                dtpTo.Value = time;
            }

            cboBoLocNCC.Enabled = false;
            cboTimKiemNCC.Enabled = false;

            dgvQuanLyNCC.DataSource = _nhaCungCapBUS.LoadDataByDate(fromDate, toDate);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboBoLocNCC.SelectedIndex = -1;
            dtpFrom.Value = dtpTo.Value = DateTime.Now;
            cboBoLocNCC.Enabled = true;
            cboTimKiemNCC.Items.Clear();
            cboTimKiemNCC.Refresh();
            cboTimKiemNCC.Enabled = false;

            LoadData();
        }
    }
}
