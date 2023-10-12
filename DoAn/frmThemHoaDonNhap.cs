using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;
using BUS;
using System.Text.RegularExpressions;
using DoAn;
using DevExpress.XtraRichEdit.API.Native;

namespace do_an_winform
{
    public partial class frmThemHoaDonNhap : Form
    {
        List<int> masp = new List<int>();
        List<int> soluong = new List<int>();
        ThemHDNhapBUS ThemHDNhapBUS = new ThemHDNhapBUS();
        CTHD_NhapBUS CTHD_NhapBUS = new CTHD_NhapBUS();
        QuanLyNhapBUS QuanLyNhapBUS = new QuanLyNhapBUS();

        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();
        public QuanLyNhapDTO hdNhap =new QuanLyNhapDTO();
        string username;
        public frmThemHoaDonNhap(string username)
        {
            InitializeComponent();
            dgvThongTinThemHoaDonNhapHang.AutoGenerateColumns = false;
            txtTongTien.Text = CONSTANTS_THEMHOADON.khong;
            txtTongTien.Text = CONSTANTS_THEMHOADON.khong;
            txtThanhTien.Text = CONSTANTS_THEMHOADON.khong;
            this.username = username;
        }

        public void loadData()
        {
            layDSTenNCC();
            layDSTenSP();
            layTenNV();
            txtMaNhanVien.Text = NhanVienBUS.layMaNV(username).ToString();
            if (cbbTenSanPham.SelectedValue != null)
            {
                txtMaSanPham.Text = cbbTenSanPham.SelectedValue.ToString();
            }

            int mahd;
            if (int.TryParse(txtMaHoaDon.Text, out mahd))
            {
                dgvThongTinThemHoaDonNhapHang.DataSource = CTHD_NhapBUS.layDSCTHDNhap(mahd);
                txtTongTien.Text= TinhTongTien(mahd).ToString();
            }
            else
            {
                dgvThongTinThemHoaDonNhapHang.DataSource = null;
            }
                

        }
        //Lấy danh sách tên nhà cung cấp 
        public void layDSTenNCC()
        {
            if (ThemHDNhapBUS.layDSTenNCC().Count==0)
            {
                return;
            }
            cbbNhaCungCap.DataSource = ThemHDNhapBUS.layDSTenNCC();
            cbbNhaCungCap.DisplayMember = CONSTANTS_THEMHOADON.TenNCC;
            cbbNhaCungCap.ValueMember = CONSTANTS_THEMHOADON.MaNCC;

            txtMaNhaCungCap.Text = cbbNhaCungCap.SelectedValue.ToString();
            laySDT();


        }

        //Lấy  tên sản phẩm đưa vào cbbTenSanPham
        public void layDSTenSP()
        {
            int mancc;
            if (int.TryParse(txtMaNhaCungCap.Text, out mancc))
            {
                cbbTenSanPham.DataSource = ThemHDNhapBUS.layDSTenSP(mancc);
                cbbTenSanPham.DisplayMember = CONSTANTS_THEMHOADON.TenSP;
                cbbTenSanPham.ValueMember = CONSTANTS_THEMHOADON.MaSP;

                if (cbbTenSanPham.SelectedValue != null)
                {
                    txtMaSanPham.Text = cbbTenSanPham.SelectedValue.ToString();
                    layDonGia();
                }
                else
                {
                    txtMaSanPham.Text=String.Empty;
                    nbGia.Value = 0;

                }
            }

        }

        private void cbbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaNhaCungCap.Text = cbbNhaCungCap.SelectedValue.ToString();
            layDSTenSP();
            layDonGia();
            laySDT();
            LamMoi();
        }

        private void cbbTenSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaSanPham.Text = cbbTenSanPham.SelectedValue.ToString();
            layDonGia();
            LamMoi();
        }

        //Lấy giá theo mã sản phẩm
        public void layDonGia()
        {
            int masp;
            if (int.TryParse(txtMaSanPham.Text, out masp))
            {
                nbGia.Value = (decimal)ThemHDNhapBUS.layDonGia(masp);
            }
        }


        //Lấy số điện thoại theo mã nhà cung cấp
        public void laySDT()
        {
            int mancc;
            if (int.TryParse(txtMaNhaCungCap.Text, out mancc))
            {
                txtSDT.Text=ThemHDNhapBUS.laySDT(mancc);
            }
        }
         

        //Làm mới 
        public void LamMoi()
        {
            nbSoLuong.Value = 0;
            nbChietKhau.Value = 0;
            txtThanhTien.Text = CONSTANTS_THEMHOADON.khong;
        }

        private void nbSoLuong_ValueChanged(object sender, EventArgs e)
        {
            double tong = (double)(nbSoLuong.Value * nbGia.Value - nbSoLuong.Value * nbGia.Value * nbChietKhau.Value / 100);
            txtThanhTien.Text = tong.ToString();
        }

        private void nbChietKhau_ValueChanged(object sender, EventArgs e)
        {
            double tong = (double)(nbSoLuong.Value * nbGia.Value - nbSoLuong.Value * nbGia.Value * nbChietKhau.Value / 100);
            txtThanhTien.Text= tong.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnLapHoaDon.Enabled == true)
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_NEW, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CTHD_NhapBUS.ktSoLuong(Convert.ToInt32(nbSoLuong.Value)))
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_ENTER_QUANTITY, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var hoadon = new CTHD_NHAPDTO
            {
                MaHD = Convert.ToInt32( txtMaHoaDon.Text),
                MaSP= Convert.ToInt32(txtMaSanPham.Text),
                SoLuong= (int)nbSoLuong.Value,
                DonGia= (double)nbGia.Value,
                ChietKhau= (double)nbChietKhau.Value,
                ThanhTien = Convert.ToDouble(txtThanhTien.Text),
                TrangThai=true
            };
            layDuLieu();
            
            if (CTHD_NhapBUS.ThemHoadon(hoadon))
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_ADD_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR,MessageBoxButtons.OK,MessageBoxIcon.Information);

                loadData();
                traDuLieu();
                LamMoi();
            }
            else
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_PRODUCT_EXIST, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //Lấy  tên nhân viên
        public void layTenNV()
        {
            txtTenNV.Text = NhanVienBUS.layHoTen(username);
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhaCungCap.Text))
                return;

            hdNhap.MaNCC = Convert.ToInt32(txtMaNhaCungCap.Text);
            hdNhap.MaNV = Convert.ToInt32(txtMaNhanVien.Text);
            hdNhap.TenNV = txtTenNV.Text;
            hdNhap.TenNCC = cbbNhaCungCap.Text;
            hdNhap.SDT = txtSDT.Text;

            var hd=new QuanLyNhapDTO()
            {
                MaNV= Convert.ToInt32(txtMaNhanVien.Text),
                MaNCC=Convert.ToInt32(txtMaNhaCungCap.Text),

            };
            txtMaHoaDon.Text= ThemHDNhapBUS.ThemHoadon(hd);

            MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLapHoaDon.Enabled = false;
            cbbNhaCungCap.Enabled= false;
            txtTenNV.Enabled = false;
        }

        public double TinhTongTien(int mahd)
        {          
            return CTHD_NhapBUS.TinhTongTien(mahd);
        }

        //Cập nhật thành tiền của HOADON_NHAP
        public void CapNhatThanhTien(int mahd, double thanhTien)
        {
            ThemHDNhapBUS.CapNhatThanhTien(mahd, thanhTien);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnLapHoaDon.Enabled == true)
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_NEW, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mahd;
            if(int.TryParse(txtMaHoaDon.Text,out mahd))
            {
                if (CTHD_NhapBUS.KiemTraCoCTHD(mahd) == 0)
                    return;

                if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_SAVE_QUESTION, CONSTANTS_THEMHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                foreach (DataGridViewRow row in dgvThongTinThemHoaDonNhapHang.Rows)
                {
                    int MaSP = Convert.ToInt32(row.Cells[CONSTANTS_THEMHOADON.MaSP].Value.ToString());
                    int SoLuong = Convert.ToInt32(row.Cells[CONSTANTS_THEMHOADON.SoLuong].Value.ToString()) + ThemHDNhapBUS.laySoLuong(MaSP);
                    masp.Add(MaSP);
                    soluong.Add(SoLuong);
                }
                double thanhtien = Convert.ToDouble(txtTongTien.Text);
                ThemHDNhapBUS.CapNhatThanhTien(mahd, thanhtien);
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_SAVE_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_PRINT_CONFIRM_ALERT, CONSTANTS_THEMHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InHoaDon();
                }

               
                CTHD_NhapBUS.CapNhatSoLuongSanPham(masp, soluong);
                txtMaHoaDon.Text = String.Empty;
                btnLapHoaDon.Enabled = true;
                txtTenNV.Enabled = true;
                cbbNhaCungCap.Enabled = true;
                txtTongTien.Text = CONSTANTS_THEMHOADON.khong;
                loadData();
            }
        }

        private void dgvThongTinThemHoaDonNhapHang_DoubleClick(object sender, EventArgs e)
        {
            if (dgvThongTinThemHoaDonNhapHang.SelectedRows.Count == 0) { return; }
            if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_DELETE_CONFIRM, CONSTANTS_THEMHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Xác định chỉ số của hàng hiện tại được chọn
            int rowIndex = dgvThongTinThemHoaDonNhapHang.CurrentRow.Index;

            // Truy xuất các giá trị cần thiết từ các ô trong hàng được chọn
            int mahd = Convert.ToInt32(dgvThongTinThemHoaDonNhapHang.Rows[rowIndex].Cells[CONSTANTS_THEMHOADON.MaHD].Value);
            int masp = Convert.ToInt32(dgvThongTinThemHoaDonNhapHang.Rows[rowIndex].Cells[CONSTANTS_THEMHOADON.MaSP].Value);
            int soluong = Convert.ToInt32(dgvThongTinThemHoaDonNhapHang.Rows[rowIndex].Cells[CONSTANTS_THEMHOADON.SoLuong].Value);
            layDuLieu();
            if (CTHD_NhapBUS.XoaHoaDon(mahd, masp))
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_DELETE_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadData();
                traDuLieu();
                LamMoi();
            }
        }

        //Lấy dữ liệu tạm thời
        public void layDuLieu()
        {
            hdNhap.MaHD = Convert.ToInt32(txtMaNhanVien.Text);
            hdNhap.MaNCC= Convert.ToInt32(txtMaNhaCungCap.Text);
            hdNhap.TenNCC= cbbNhaCungCap.Text;
            hdNhap.MaNV= Convert.ToInt32(txtMaNhanVien.Text);
            hdNhap.TenNV= txtTenNV.Text;
            hdNhap.SDT = txtSDT.Text;
        }

        //Trả dữ liệu
        public void traDuLieu()
        {
            txtMaNhanVien.Text = hdNhap.MaHD.ToString();
            txtMaNhaCungCap.Text = hdNhap.MaNCC.ToString();
            txtMaNhanVien.Text = hdNhap.MaNV.ToString();
            txtTenNV.Text = hdNhap.TenNV;
            cbbNhaCungCap.Text = hdNhap.TenNCC;
            txtSDT.Text = hdNhap.SDT;
        }

        private void InHoaDon()
        {
            pddHoaDon.Document = pdHoaDon;
            pddHoaDon.ShowDialog();
        }
        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            hdNhap.MaHD = Convert.ToInt32(txtMaHoaDon.Text);
            hdNhap.MaNV = Convert.ToInt32(txtMaNhanVien.Text);
            hdNhap.TenNV = txtTenNV.Text;
            hdNhap.TenNCC = cbbNhaCungCap.Text;
            hdNhap.MaNCC = Convert.ToInt32(txtMaNhaCungCap.Text);
            hdNhap.ThanhTien = Convert.ToDouble(txtTongTien.Text);


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
            e.Graphics.DrawString(CONSTANTS_INHOADON.hoadonnhaphang, new Font(CONSTANTS_INHOADON.kieuchu, 22, FontStyle.Bold), Brushes.Black, new Point(280, y));
            y += 50;


            // mã hóa đơn
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.mahoadon, hdNhap.MaHD.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In mã nhân viên 
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.manv, hdNhap.MaNV.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In tên nhân viên
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tennv, hdNhap.TenNV), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In mã khách hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.mancc, hdNhap.MaNCC.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
            y += 30;

            //In tên khách hàng
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tenncc, hdNhap.TenNCC), new Font(CONSTANTS_INHOADON.kieuchu, 13, FontStyle.Bold), Brushes.Black, new Point(10, y));
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
            var result = CTHD_NhapBUS.layDSCTHDNhap(hdNhap.MaHD);

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
            e.Graphics.DrawString(String.Format(CONSTANTS_INHOADON.tongtien, hdNhap.ThanhTien.ToString()), new Font(CONSTANTS_INHOADON.kieuchu, 14, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));


            y += 50;
            //Lời chúc
            e.Graphics.DrawString(CONSTANTS_INHOADON.loichuc, new Font(CONSTANTS_INHOADON.kieuchu, 16, FontStyle.Bold), Brushes.Black, new Point(300, y));
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (btnLapHoaDon.Enabled == true)
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_NEW, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ThemHDNhapBUS.ktMaHoaDon(txtMaHoaDon.Text))
                return;

            if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_CANCEL_ALERT, CONSTANTS_THEMHOADON.MES_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Lấy dữ liệu CTHD_Nhap
                var result = CTHD_NhapBUS.layDSCTHDNhap(Convert.ToInt32(txtMaHoaDon.Text));

                txtMaHoaDon.Text = String.Empty;
                btnLapHoaDon.Enabled = true;
                txtTenNV.Enabled = true;
                cbbNhaCungCap.Enabled = true;
                txtTongTien.Text = CONSTANTS_THEMHOADON.khong;
                loadData();
            }
        }

        private void frmThemHoaDonNhap_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvThongTinThemHoaDonNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cbbTenSanPham.Text = dgvThongTinThemHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.TenSP].Value.ToString();
                txtMaSanPham.Text = dgvThongTinThemHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.MaSP].Value.ToString();
                nbChietKhau.Value =Convert.ToInt32( dgvThongTinThemHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.ChietKhau].Value);
                nbGia.Value = Convert.ToInt32(dgvThongTinThemHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.DonGia].Value);
                nbSoLuong.Value = Convert.ToInt32(dgvThongTinThemHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.SoLuong].Value);
                txtThanhTien.Text = dgvThongTinThemHoaDonNhapHang.Rows[e.RowIndex].Cells[CONSTANTS_THEMHOADON.ThanhTien].Value.ToString();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (btnLapHoaDon.Enabled == true)
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_CREATE_NEW, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CTHD_NhapBUS.ktSoLuong(Convert.ToInt32(nbSoLuong.Value)))
            {
                MessageBox.Show(CONSTANTS_THEMHOADON.MES_ENTER_QUANTITY, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(CONSTANTS_THEMHOADON.MES_UPDATE_CONFIRM, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int mahd;
            if(int.TryParse(txtMaHoaDon.Text,out mahd))
            {
                var hoadon = new CTHD_NHAPDTO
                {
                    MaHD = Convert.ToInt32(txtMaHoaDon.Text),
                    MaSP = Convert.ToInt32(txtMaSanPham.Text),
                    SoLuong = (int)nbSoLuong.Value,
                    DonGia = (double)nbGia.Value,
                    ChietKhau = (double)nbChietKhau.Value,
                    ThanhTien = Convert.ToDouble(txtThanhTien.Text),
                    TrangThai = true
                };

                if (CTHD_NhapBUS.CapNhatCTHD(hoadon))
                {
                    MessageBox.Show(CONSTANTS_THEMHOADON.MES_UPDATE_SUCCESS, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    layDuLieu();
                    loadData();
                    traDuLieu();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show(CONSTANTS_THEMHOADON.MES_UPDATE_FAIL, CONSTANTS_THEMHOADON.MES_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
