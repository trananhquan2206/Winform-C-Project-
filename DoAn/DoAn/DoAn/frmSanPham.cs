using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmSanPham : Form
    {

        string username;
        public frmSanPham()
        {
            InitializeComponent();
        }

        public frmSanPham(string username)
        {
            InitializeComponent();
            this.username = username;
            dgvDSSP.AutoGenerateColumns = false;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            cboNCC.DataSource = SanPhamBUS.loadNCC();
            cboNCC.ValueMember = CONSTANTS_SANPHAM.MANCC;
            cboNCC.DisplayMember = CONSTANTS_SANPHAM.TENNCC;
            LoadDSSP();
        }

        private void LoadDSSP()
        {
            dgvDSSP.DataSource = SanPhamBUS.layDSSP();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (SanPhamBUS.checkInput(txtTenSP.Text, txtSoLuong.Text, txtDonGia.Text, txtCamera.Text, txtMauSac.Text, txtNamPhatHanh.Text, txtBaoHanh.Text, txtChip.Text, txtRam.Text, txtBoNho.Text, txtHDH.Text) || picHinhAnh.Image == null)
            {
                MessageBox.Show(CONSTANTS_SANPHAM.MES_INPUT_WAR, CONSTANTS_SANPHAM.NOTIFICATIONS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SanPhamDTO spDTO = new SanPhamDTO
            {
                MaSP = Convert.ToInt32(txtMaSP.Text),
                TenSP = txtTenSP.Text,
                MaNCC = Convert.ToInt32(cboNCC.SelectedValue),
                SoLuong = Convert.ToInt32(txtSoLuong.Text),
                DonGia = Convert.ToDouble(txtDonGia.Text),
                HeDieuHanh = txtHDH.Text,
                BoNho = Convert.ToInt32(txtBoNho.Text),
                MauSac = txtMauSac.Text,
                Chip = txtChip.Text,
                Camera = txtCamera.Text,
                NamPhatHanh = Convert.ToInt32(txtNamPhatHanh.Text),
                BaoHanh = Convert.ToInt32(txtBaoHanh.Text),
                Ram = Convert.ToInt32(txtRam.Text),
                HinhAnh = (byte[])new ImageConverter().ConvertTo(picHinhAnh.Image, typeof(Byte[])),
            };

            if (SanPhamBUS.chinhSuaSanPham(spDTO))
            {
                MessageBox.Show(CONSTANTS_SANPHAM.EDIT_PROD_SUCC);
                LogBUS.themLog(username, string.Format(CONSTANTS_SANPHAM.EDITED_PROD, txtTenSP.Text));
                LoadDSSP();
            }
            else
            {
                MessageBox.Show(CONSTANTS_SANPHAM.EDIT_PROD_ERR);
            }
            
            reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (SanPhamBUS.checkInput(txtTenSP.Text, txtSoLuong.Text, txtDonGia.Text, txtCamera.Text, txtMauSac.Text, txtNamPhatHanh.Text, txtBaoHanh.Text, txtChip.Text, txtRam.Text, txtBoNho.Text, txtHDH.Text) || picHinhAnh.Image == null)
            {
                MessageBox.Show(CONSTANTS_SANPHAM.MES_INPUT_WAR, CONSTANTS_SANPHAM.NOTIFICATIONS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SanPhamDTO spDTO = new SanPhamDTO
            {
                
                TenSP = txtTenSP.Text,
                MaNCC = Convert.ToInt32(cboNCC.SelectedValue),
                SoLuong = Convert.ToInt32(txtSoLuong.Text),
                DonGia = Convert.ToDouble(txtDonGia.Text),
                HeDieuHanh = txtHDH.Text,
                BoNho = Convert.ToInt32(txtBoNho.Text),
                MauSac = txtMauSac.Text,
                Chip = txtChip.Text,
                Camera = txtCamera.Text,
                NamPhatHanh = Convert.ToInt32(txtNamPhatHanh.Text),
                BaoHanh = Convert.ToInt32(txtBaoHanh.Text),
                Ram = Convert.ToInt32(txtRam.Text),
                HinhAnh = (byte[]) new ImageConverter().ConvertTo(picHinhAnh.Image, typeof(Byte[])),
            };

            if (SanPhamBUS.themSanPham(spDTO))
            {
                MessageBox.Show(CONSTANTS_SANPHAM.ADD_PROD_SUCC);
                LogBUS.themLog(username, string.Format(CONSTANTS_SANPHAM.ADDED_PROD, txtTenSP.Text));
                LoadDSSP();
            }
            else
            {
                MessageBox.Show(CONSTANTS_SANPHAM.ADD_PROD_ERR);
            }
            reset();
        }

        private void reset()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSoLuong.Clear();
            txtChip.Clear();
            txtDonGia.Clear();
            txtMauSac.Clear();
            txtRam.Clear();
            txtBoNho.Clear();
            txtNamPhatHanh.Clear();
            txtBaoHanh.Clear();
            txtHDH.Clear();
            txtCamera.Clear();
            cboNCC.SelectedIndex =0;
            txtTimKiem.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show(CONSTANTS_SANPHAM.SELECT_PROD_WAR, CONSTANTS_SANPHAM.NOTIFICATIONS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(CONSTANTS_SANPHAM.DEL_CONFIRM, CONSTANTS_SANPHAM.CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int maSP = Convert.ToInt32(txtMaSP.Text);
                if (SanPhamBUS.xoaSanPham(maSP))
                {
                    MessageBox.Show(CONSTANTS_SANPHAM.DEL_PROD_SUCC);
                    LogBUS.themLog(username, string.Format(CONSTANTS_SANPHAM.DELETED_PROD, txtTenSP.Text));
                    LoadDSSP();
                }
                else
                {
                    MessageBox.Show(CONSTANTS_SANPHAM.DEL_PROD_ERR);
                }
                reset();
            }
        }

        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < CONSTANTS_SANPHAM.ZERO)
            {
                return;
            }
            DataGridViewRow row = dgvDSSP.Rows[e.RowIndex];
            txtMaSP.Text = row.Cells[CONSTANTS_SANPHAM.COL_MASP].Value.ToString();
            txtTenSP.Text = row.Cells[CONSTANTS_SANPHAM.COL_TENSP].Value.ToString();
            txtSoLuong.Text = row.Cells[CONSTANTS_SANPHAM.COL_SOLUONG].Value.ToString();
            cboNCC.SelectedValue = Convert.ToInt32(row.Cells[CONSTANTS_SANPHAM.MANCC].Value);
            txtDonGia.Text = row.Cells[CONSTANTS_SANPHAM.COL_DONGIA].Value.ToString();
            txtHDH.Text = row.Cells[CONSTANTS_SANPHAM.COL_HDH].Value.ToString();
            txtBoNho.Text = row.Cells[CONSTANTS_SANPHAM.COL_BONHO].Value.ToString();
            txtRam.Text = row.Cells[CONSTANTS_SANPHAM.COL_RAM].Value.ToString();
            txtChip.Text = row.Cells[CONSTANTS_SANPHAM.COL_CHIP].Value.ToString();
            txtMauSac.Text = row.Cells[CONSTANTS_SANPHAM.COL_MAUSAC].Value.ToString();
            txtCamera.Text = row.Cells[CONSTANTS_SANPHAM.COL_CAMERA].Value.ToString();
            txtNamPhatHanh.Text = row.Cells[CONSTANTS_SANPHAM.COL_NAMPHATHANH].Value.ToString();
            txtBaoHanh.Text = row.Cells[CONSTANTS_SANPHAM.COL_BAOHANH].Value.ToString();
            Byte[] image = (byte[])row.Cells[CONSTANTS_SANPHAM.COL_HINHANH].Value;
            MemoryStream stream = new MemoryStream(image);
            picHinhAnh.Image = Image.FromStream(stream);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            ofdImage.Filter = CONSTANTS_SANPHAM.IMG_FILTER;
            if (ofdImage.ShowDialog() == DialogResult.OK) 
            {
                picHinhAnh.Load(ofdImage.FileName);
            }
        }

        private void txtTimKiem_IconRightClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                MessageBox.Show(CONSTANTS_SANPHAM.SEARCH_WAR, CONSTANTS_SANPHAM.NOTIFICATIONS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radTenSP.Checked)
            {
                dgvDSSP.DataSource = SanPhamBUS.timKiemTheoTen(txtTimKiem.Text);
            }
            else if (radNCC.Checked)
            {
                dgvDSSP.DataSource = SanPhamBUS.timKiemTheoNCC(txtTimKiem.Text);
            }
            else if (radHDH.Checked)
            {
                dgvDSSP.DataSource = SanPhamBUS.timKiemTheoHDH(txtTimKiem.Text);
            }
            else
            {
                dgvDSSP.DataSource = SanPhamBUS.timKiemTheoGia(Convert.ToDouble(txtTimKiem.Text));
            }
            reset();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
            LoadDSSP();
        }

    }
}
