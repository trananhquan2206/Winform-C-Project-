using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmThemHoaDonBan : Form
    {
        string username;
        List<int> masp = new List<int>();
        List<int> soluong = new List<int>();

        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();
        ThemHDBanBUS ThemHDBanBUS = new ThemHDBanBUS();
        CTHD_BanBUS CTHD_BanBUS = new CTHD_BanBUS();
        QuanLyBanBUS QuanLyBanBUS = new QuanLyBanBUS();
        public QuanLyBanDTO hoaDonBan = new QuanLyBanDTO();


        public int soluongSP;

        public frmThemHoaDonBan(string username)
        {
            InitializeComponent();

            dgvThongTinThemHoaDonBan.AutoGenerateColumns = false;
            txtThanhTien.Text = CONSTANTS_THEMHOADON.khong;
            txtTongTien.Text = CONSTANTS_THEMHOADON.khong;
            //System.Windows.Forms.
            this.cbbSDT.DropDownStyle = ComboBoxStyle.DropDown;
            this.username = username;
            load();
        }

        //Lưu dữ liệu tạm 
        public void layDuLieu()
        {
            hoaDonBan.MaHD = Convert.ToInt32(txtMaHoaDon.Text);
            hoaDonBan.MaNV = Convert.ToInt32(txtMaNV.Text);
            hoaDonBan.TenNV = txtTenNV.Text;
            hoaDonBan.MaKH = Convert.ToInt32(txtMaKhachHang.Text);
            hoaDonBan.SDT = cbbSDT.Text;
            hoaDonBan.DiaChi = txtDiaChi.Text;
        }

        //Trả lại dữ liệu
        public void traDuLieu()
        {
            txtMaHoaDon.Text = hoaDonBan.MaHD.ToString();
            txtMaNV.Text = hoaDonBan.MaNV.ToString();
            txtTenNV.Text = hoaDonBan.TenNV.ToString();
            txtMaKhachHang.Text = hoaDonBan.MaKH.ToString();
            cbbSDT.Text = hoaDonBan.SDT;
            txtDiaChi.Text = hoaDonBan.DiaChi;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThemHoaDonMoi.Enabled == true)
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_NEW, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ThemHDBanBUS.ktsoluong((int)nbSoLuong.Value))
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_ENTER_QUANTITY, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var hoadon = new CTHD_BanDTO
            {
                MaHD = Convert.ToInt32(txtMaHoaDon.Text),
                MaSP = Convert.ToInt32(txtMaSP.Text),
                SoLuong = (int)nbSoLuong.Value,
                DonGia = (double)nbGia.Value,
                ChietKhau = (double)nbKhuyenMai.Value,
                ThanhTien = Convert.ToDouble(txtThanhTien.Text),
                TrangThai = true

            };
            
            if (CTHD_BanBUS.ThemHoadon(hoadon))
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_ADD_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);

                layDuLieu();
                load();
                traDuLieu();
                reset();
            }
            else
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_PRODUCT_EXIST, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void load()
        {
            layDSSDT();
            layDSMaNV();
            layDSMaSP();
            layDSCTHD_Ban();

            //lấy số lượng max
            int masp;
            if (int.TryParse(txtMaSP.Text, out masp))
                nbSoLuong.Maximum = ThemHDBanBUS.laySoLuong(masp);

        }

        //Lấy số điện thoại
        public void layDSSDT()
        {
            cbbSDT.DataSource = ThemHDBanBUS.layDSSDT();
            cbbSDT.DisplayMember = CONSTANTS_THEMHOADON.SDT;
            cbbSDT.ValueMember = CONSTANTS_THEMHOADON.SDT;
        }

        public void layThongTinKhachHang()
        {
            string soDienThoai = cbbSDT.Text;
            txtTenKhachHang.Text = ThemHDBanBUS.layTenKH(soDienThoai);
            txtMaKhachHang.Text = ThemHDBanBUS.layMaKH(soDienThoai);
            txtDiaChi.Text = ThemHDBanBUS.layDiaChiKH(soDienThoai);
        }

        //Lấy tên nhân viên
        public void layDSMaNV()
        {
            txtTenNV.Text = NhanVienBUS.layHoTen(username);

            txtMaNV.Text = NhanVienBUS.layMaNV(username).ToString();
        }

        //lấy mã sản phẩm
        public void layDSMaSP()
        {
            cbbTenSP.DataSource = ThemHDBanBUS.layDSMaSP();
            cbbTenSP.DisplayMember = CONSTANTS_THEMHOADON.TenSP;
            cbbTenSP.ValueMember = CONSTANTS_THEMHOADON.MaSP;
            if (cbbTenSP.Items.Count != 0)
            {
                txtMaSP.Text = cbbTenSP.SelectedValue.ToString();
            }
            else
            {
                txtMaSP.Text = string.Empty;
            }


            //Lấy đơn giá theo mã sản phẩm
            int masp;
            if (int.TryParse(txtMaSP.Text, out masp))
            {
                nbGia.Value = (decimal)ThemHDBanBUS.layDonGia(masp);
            }
        }

        private void cbbSDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            layThongTinKhachHang();
        }

        private void cbbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaSP.Text = cbbTenSP.SelectedValue.ToString();

            //lấy số lượng max
            int masp;
            if(int.TryParse(txtMaSP.Text, out masp))
                nbSoLuong.Maximum = ThemHDBanBUS.laySoLuong(masp);

            //Lấy đơn giá theo mã sản phẩm
            int maspp;
            if (int.TryParse(txtMaSP.Text, out maspp))
            {
                nbGia.Value = (decimal)ThemHDBanBUS.layDonGia(masp);
            }

            reset();
        }

        //Số lượng sản phẩm lớn nhất
        public void laymaxSoLuong(int masp)
        {
            nbSoLuong.Maximum = ThemHDBanBUS.laySoLuong(masp);
        }

        private void btnThemHoaDonMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhachHang.Text))
                return;
            var hd = new QuanLyBanDTO()
            {
                MaNV = Convert.ToInt32(txtMaNV.Text),
                MaKH = Convert.ToInt32(txtMaKhachHang.Text),

            };
            txtMaHoaDon.Text = ThemHDBanBUS.ThemHoadon(hd);

            MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThemHoaDonMoi.Enabled = false;
            cbbSDT.Enabled = false;
            txtTenNV.Enabled = false;
        }

        //Lấy danh sách chi tiết hóa đơn
        public void layDSCTHD_Ban()
        {
            int mahd;
            if (int.TryParse(txtMaHoaDon.Text, out mahd))
            {
                dgvThongTinThemHoaDonBan.DataSource = CTHD_BanBUS.layDSCTHDBan(mahd);
                txtTongTien.Text = CTHD_BanBUS.TinhTongTien(mahd).ToString();
            }
            else
            {
                dgvThongTinThemHoaDonBan.DataSource = null;
            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            double tongtien = (double)(nbSoLuong.Value * nbGia.Value - nbSoLuong.Value * nbGia.Value * nbKhuyenMai.Value / 100);
            txtThanhTien.Text = tongtien.ToString();
        }

        private void nbSoLuong_ValueChanged(object sender, EventArgs e)
        {
            double tongtien = (double)(nbSoLuong.Value * nbGia.Value - nbSoLuong.Value * nbGia.Value * nbKhuyenMai.Value / 100);
            txtThanhTien.Text = tongtien.ToString();
        }

        private void nbKhuyenMai_ValueChanged(object sender, EventArgs e)
        {
            double tongtien = (double)(nbSoLuong.Value * nbGia.Value - nbSoLuong.Value * nbGia.Value * nbKhuyenMai.Value / 100);
            txtThanhTien.Text = tongtien.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThemHoaDonMoi.Enabled == true)
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_NEW, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mahd;
            if (int.TryParse(txtMaHoaDon.Text, out mahd))
            {
                if (CTHD_BanBUS.KiemTraCoCTHD(mahd) == 0)
                    return;

                if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_SAVE_QUESTION, CONSTANTS_THEMHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                foreach (DataGridViewRow row in dgvThongTinThemHoaDonBan.Rows)
                {
                    laymaxSoLuong(Convert.ToInt32(row.Cells[CONSTANTS_THEMHOADON.masp].Value.ToString()));
                    masp.Add(Convert.ToInt32(row.Cells[CONSTANTS_THEMHOADON.masp].Value.ToString()));
                    int soluongSP = Convert.ToInt32(nbSoLuong.Maximum) - Convert.ToInt32(row.Cells[CONSTANTS_THEMHOADON.soluong].Value.ToString());
                    soluong.Add(soluongSP);
                }

                double thanhtien = Convert.ToDouble(txtTongTien.Text);
                if (ThemHDBanBUS.CapNhatThanhTien(mahd, thanhtien))
                {
                    MessageBox.Show(CONSTANTS_THEMHOADON.MES_SAVE_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_PRINT_CONFIRM_ALERT, CONSTANTS_THEMHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InHoaDon();

                    }

                    CTHD_BanBUS.CapNhatSoLuongSanPham(soluong, masp);

                    txtMaHoaDon.Text = string.Empty;
                    btnThemHoaDonMoi.Enabled = true;
                    cbbSDT.Enabled = true;
                    txtTenNV.Enabled = true;
                    txtTongTien.Text = CONSTANTS_THEMHOADON.khong;
                    load();
                }
            }
        }

        //Làm mới thông tin sản phẩm
        public void reset()
        {
            txtThanhTien.Text = CONSTANTS_THEMHOADON.khong;
            nbKhuyenMai.Value = 0;
            nbSoLuong.Value = 0;

        }

        private void dgvThongTinThemHoaDonBan_DoubleClick(object sender, EventArgs e)
        {
            if (dgvThongTinThemHoaDonBan.SelectedRows.Count == 0) { return; }
            if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_DELETE_CONFIRM, CONSTANTS_THEMHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Xác định chỉ số của hàng hiện tại được chọn
            int rowIndex = dgvThongTinThemHoaDonBan.CurrentRow.Index;

            // Truy xuất các giá trị cần thiết từ các ô trong hàng được chọn
            int mahd = Convert.ToInt32(dgvThongTinThemHoaDonBan.Rows[rowIndex].Cells[CONSTANTS_THEMHOADON.mahd].Value);
            int masp = Convert.ToInt32(dgvThongTinThemHoaDonBan.Rows[rowIndex].Cells[CONSTANTS_THEMHOADON.masp].Value);
            int soluong = Convert.ToInt32(dgvThongTinThemHoaDonBan.Rows[rowIndex].Cells[CONSTANTS_THEMHOADON.soluong].Value);

            if (CTHD_BanBUS.XoaHoaDon(mahd, masp))
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_DELETE_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                layDuLieu();
                load();
                reset();
                traDuLieu();
            }
        }

        private void InHoaDon()
        {
            pddHoaDon.Document = pdHoaDon;
            pddHoaDon.ShowDialog();
        }
        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            hoaDonBan.MaHD = Convert.ToInt32(txtMaHoaDon.Text);
            hoaDonBan.MaNV = Convert.ToInt32(txtMaNV.Text);
            hoaDonBan.TenNV = txtTenNV.Text;
            hoaDonBan.TenKH = txtTenKhachHang.Text;
            hoaDonBan.MaKH = Convert.ToInt32(txtMaKhachHang.Text);
            hoaDonBan.SDT = cbbSDT.Text;
            hoaDonBan.DiaChi = txtDiaChi.Text;
            hoaDonBan.ThanhTien = Convert.ToDouble(txtTongTien.Text);


            //Lấy thông tin cấu hình
            var tenCuaHang = CONSTANTS_INHOADON.tenCuaHang;
            var diaChi = CONSTANTS_INHOADON.diachi;
            var phone = CONSTANTS_INHOADON.phone;

            //Tạo chiều dài
            var y = 10;

            //lấy bề rộng của giấy in
            var w = pdHoaDon.DefaultPageSettings.PaperSize.Width;


            //Vẽ header của hóa đơn
            // Tên cửa hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.cuahang, tenCuaHang), new Font(CONSTANTS_INHOADON.kieuchu, 22, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 40;

            //Địa chỉ
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.dc, diaChi), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //Số điện thoại
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.sdt, phone), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //Định dạng bút vẽ
            Pen blackPen = new Pen(Color.Black, 1);

            //Tọa độ theo chiều dọc
            y += 20;

            //Định nghĩa 2 điểm để vẽ đường thẳng
            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);

            //Kẻ đường thẳng thứ nhất
            e.Graphics.DrawLine(blackPen, p1, p2);
            y += 30;

            //Hóa đơn bán hàng
            e.Graphics.DrawString(CONSTANTS_INHOADON.hoadonbanhang, new Font(CONSTANTS_INHOADON.kieuchu, 22, FontStyle.Bold), Brushes.Black, new Point(280, y));
            y += 50;


            // mã hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.mahoadon, hoaDonBan.MaHD.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In mã nhân viên 
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.manv, hoaDonBan.MaNV.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In tên nhân viên
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tennv, hoaDonBan.TenNV), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In mã khách hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.mankh, hoaDonBan.MaKH.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In tên khách hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tenkh, hoaDonBan.TenKH), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //Thời gian in hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.thoigian, DateTime.Now.ToString(CONSTANTS_INHOADON.date)), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));

            y += 40;
            //Kẻ đường thẳng thứ hai
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            //Định dạng các cột
            y += 35;

            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tensanpham), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.soluong), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(280, y));
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.dongia), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 20, y));
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.giamgia), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 110, y));
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.thanhtien), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            //Lấy dữ liệu CTHD_Nhap
            var result = CTHD_BanBUS.layDSCTHDBan(hoaDonBan.MaHD);

            //Lặp các phần tử
            //Mỗi phần từ là một hàng trên hóa đơn
            int i = 1;
            y += 40;
            foreach (var l in result)
            {
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.TenSP), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.SoLuong.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(280, y));
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.DonGia.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 20, y));
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.ChietKhau.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 110, y));
                e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.p, l.ThanhTien.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
                y += 30;
            }

            //Kẻ đường thẳng thứ ba
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            y += 35;
            //Tổng tiền của hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tongtien, hoaDonBan.ThanhTien.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 14, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));


            y += 50;
            //Lời chúc
            e.Graphics.DrawString(CONSTANTS_INHOADON.loichuc, new Font(CONSTANTS_INHOADON.kieuchu, 16, FontStyle.Bold), Brushes.Black, new Point(300, y));


        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (btnThemHoaDonMoi.Enabled == true)
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_NEW, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ThemHDBanBUS.ktMaHoaDon(txtMaHoaDon.Text))
                return;

            if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_CANCEL_ALERT, CONSTANTS_THEMHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtMaHoaDon.Text = string.Empty;
                btnThemHoaDonMoi.Enabled = true;
                cbbSDT.Enabled = true;
                txtTenNV.Enabled = true;
                txtTongTien.Text = CONSTANTS_THEMHOADON.khong;
                load();
            }
        }

        private void frmThemHoaDonBan_Load(object sender, EventArgs e)
        {
            layDSMaNV();
            layDSSDT();
            layDSMaSP();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (btnThemHoaDonMoi.Enabled == true)
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_NEW, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CTHD_BanBUS.ktSoLuong(Convert.ToInt32(nbSoLuong.Value)))
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_ENTER_QUANTITY, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_UPDATE_CONFIRM, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int mahd;
            if (int.TryParse(txtMaHoaDon.Text, out mahd))
            {
                var hoadon = new CTHD_NHAPDTO
                {
                    MaHD = Convert.ToInt32(txtMaHoaDon.Text),
                    MaSP = Convert.ToInt32(txtMaSP.Text),
                    SoLuong = (int)nbSoLuong.Value,
                    DonGia = (double)nbGia.Value,
                    ChietKhau = (double)nbKhuyenMai.Value,
                    ThanhTien = Convert.ToDouble(txtThanhTien.Text),
                    TrangThai = true
                };

                if (CTHD_BanBUS.CapNhatCTHD(hoadon))
                {
                    MessageBox.Show(CONSTANTS_THEMHOADON.MES_UPDATE_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    layDuLieu();
                    load();
                    traDuLieu();
                    reset();
                }
                else
                {
                    MessageBox.Show(CONSTANTS_THEMHOADON.MES_UPDATE_FAIL, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvThongTinThemHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cbbTenSP.Text = dgvThongTinThemHoaDonBan.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.tensp].Value.ToString();
                txtMaSP.Text = dgvThongTinThemHoaDonBan.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.masp].Value.ToString();
                nbKhuyenMai.Value = Convert.ToInt32(dgvThongTinThemHoaDonBan.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.chietkhau].Value);
                nbGia.Value = Convert.ToInt32(dgvThongTinThemHoaDonBan.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.dongia].Value);
                nbSoLuong.Value = Convert.ToInt32(dgvThongTinThemHoaDonBan.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.soluong].Value);
                txtThanhTien.Text = dgvThongTinThemHoaDonBan.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.thanhtien].Value.ToString();
            }
        }
    }
}
