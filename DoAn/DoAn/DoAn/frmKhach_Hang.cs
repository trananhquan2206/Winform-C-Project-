using BUS;
using DAO;
using DevExpress.XtraReports.UI;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fut.KhachHang
{
    public partial class frmKhach_Hang : Form
    {
        Khach_HangBUS _khachHangBUS = new Khach_HangBUS();
        string username;
        public frmKhach_Hang()
        {
            InitializeComponent();

            dgvQuanLyKH.AutoGenerateColumns = false;

            dtpFrom.Value = dtpTo.Value = DateTime.Now;

            cboBoLocKH.Enabled = true;
            cboTimKiemKH.Enabled = false;
        }
        public frmKhach_Hang(string username)
        {
            InitializeComponent();

            dgvQuanLyKH.AutoGenerateColumns = false;

            dtpFrom.Value = dtpTo.Value = DateTime.Now;

            cboBoLocKH.Enabled = true;
            cboTimKiemKH.Enabled = false;
            this.username = username;
        }

        private void LoadData()
        {
            dgvQuanLyKH.DataSource = _khachHangBUS.LayDanhSachKhachHang();
        }

        private void frmKhach_Hang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboBoLocKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();

            cboTimKiemKH.Enabled = true;

            string columnName = "";

            if (cboBoLocKH.SelectedIndex != -1)
            {
                if (cboBoLocKH.SelectedIndex == 0)
                {
                    columnName = CONSTANTS_KHACHHANG.colMaKH;
                }
                else if (cboBoLocKH.SelectedIndex == 1)
                {
                    columnName = CONSTANTS_KHACHHANG.colTenKH;
                }
                else if (cboBoLocKH.SelectedIndex == 2)
                {
                    columnName = CONSTANTS_KHACHHANG.colGioiTinh;
                }

                if (string.IsNullOrEmpty(columnName))
                {
                    return;
                }

                List<string> distinctValues = _khachHangBUS.GetDistinctValuesFromColumn("KHACHHANG", CONSTANTS_KHACHHANG.colTrangThai, "1", columnName);

                cboTimKiemKH.Items.Clear();

                foreach (string value in distinctValues)
                {
                    if (columnName == CONSTANTS_KHACHHANG.colGioiTinh)
                    {
                        if (value == "1")
                        {
                            cboTimKiemKH.Items.Add("Nam");
                        }
                        else
                        {
                            cboTimKiemKH.Items.Add("Nữ");
                        }
                    }
                    else
                    {
                        cboTimKiemKH.Items.Add(value);
                    }
                }
            }
        }

        public DataTable ConvertToDataTable(List<Khach_HangDTO> khList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(CONSTANTS_KHACHHANG.colMaKH, typeof(int));
            dt.Columns.Add(CONSTANTS_KHACHHANG.colTenKH, typeof(string));
            dt.Columns.Add(CONSTANTS_KHACHHANG.colSoDonHang, typeof(int));
            dt.Columns.Add(CONSTANTS_KHACHHANG.colTongTien, typeof(string));

            foreach (var kh in khList)
            {
                string tongTienString = kh.TongTien?.ToString() ?? "0";
                double tongTienDouble;
                if (double.TryParse(tongTienString, out tongTienDouble))
                {
                    string formattedTongTien = string.Format("{0:#,##0}", tongTienDouble);
                    DataRow row = dt.NewRow();
                    row[CONSTANTS_KHACHHANG.colMaKH] = kh.MaKH;
                    row[CONSTANTS_KHACHHANG.colTenKH] = kh.TenKH;
                    row[CONSTANTS_KHACHHANG.colSoDonHang] = kh.SoDonHang;
                    row[CONSTANTS_KHACHHANG.colTongTien] = formattedTongTien;
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        private void cboTimKiemKH_SelectedValueChanged(object sender, EventArgs e)
        {
            string columnName = "";
            string value = "";


            if (cboBoLocKH.SelectedIndex == 0)
            {
                columnName = CONSTANTS_KHACHHANG.colMaKH;
            }
            else if (cboBoLocKH.SelectedIndex == 1)
            {
                columnName = CONSTANTS_KHACHHANG.colTenKH;
            }
            else if (cboBoLocKH.SelectedIndex == 2)
            {
                columnName = CONSTANTS_KHACHHANG.colGioiTinh;
            }

            if (cboTimKiemKH.Items != null && cboBoLocKH.SelectedIndex != -1)
            {
                if (columnName == CONSTANTS_KHACHHANG.colGioiTinh)
                {
                    value = cboTimKiemKH.SelectedItem.ToString() == "Nam" ? "1" : "0";
                }
                else
                {
                    value = cboTimKiemKH.SelectedItem.ToString();
                }
            }

            DataTable tbl = ConvertToDataTable(_khachHangBUS.TimKiemTheoBoLoc(columnName, value));

            dgvQuanLyKH.DataSource = tbl;
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

            cboBoLocKH.Enabled = false;
            cboTimKiemKH.Enabled = false;

            dgvQuanLyKH.DataSource = _khachHangBUS.LoadDataByDate(fromDate, toDate);
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmThong_Tin_Khach_Hang frm = new frmThong_Tin_Khach_Hang();
            this.Hide();
            frm.Show();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboBoLocKH.SelectedIndex = -1;
            dtpFrom.Value = dtpTo.Value = DateTime.Now;
            cboBoLocKH.Enabled = true;
            cboTimKiemKH.Items.Clear();
            cboTimKiemKH.Refresh();
            cboTimKiemKH.Enabled = false;

            LoadData();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            frmThong_Tin_Khach_Hang frm = new frmThong_Tin_Khach_Hang();
            this.Hide();
            frm.Show();
        }
    }
}
