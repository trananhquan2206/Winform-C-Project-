using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThemHDNhapBUS
    {
        ThemHDNhapDAO ThemHDNhapDAO = new ThemHDNhapDAO();
        //Lấy danh sách tên sản phẩm theo mã nhà cung cấp
        public List<SanPhamDTO> layDSTenSP(int mancc)
        {
            return ThemHDNhapDAO.layDSTenSP(mancc);
        }

        //Lấy danh sách tên nhà cung cấp 
        public List<NHACUNGCAP> layDSTenNCC()
        {
            return ThemHDNhapDAO.layDSTenNCC();
        }

        //Lấy giá theo mã sản phẩm
        public double layDonGia(int masp)
        {
            return ThemHDNhapDAO.layDonGia(masp);
        }

        //Lấy số điện thoại theo mã nhà cung cấp 
        public string laySDT(int mancc)
        {
            return ThemHDNhapDAO.laySDT(mancc);
        }

        ////Lấy mã Nhân viên
        //public string layMaNV(int mahd)
        //{
        //    return ThemHDBanDAO.layMaNV(mahd);
        //}

        //Lấy danh sách tên sản phẩm theo mã nhà cung cấp
        public List<NhanVienDTO> layTenNV()
        {
            return ThemHDNhapDAO.layTenNV();
        }

        //Tạo hóa đơn mới
        public string ThemHoadon(QuanLyNhapDTO hd)
        {
            return ThemHDNhapDAO.ThemHoadon(hd);
        }

        // Cập nhật tổng tiền của HOADON_NHAP
        public bool CapNhatThanhTien(int mahd, double thanhTien)
        {
            return ThemHDNhapDAO.CapNhatThanhTien(mahd, thanhTien);
        }

        //Lấy số lượng của sản phẩm theo mã sản phẩm
        public int laySoLuong(int masp)
        {
            return ThemHDNhapDAO.laySoLuong(masp);
        }

        //Kiểm tra txtHoaDon có hay không
        public bool ktMaHoaDon(string mahd)
        {
            if (string.IsNullOrEmpty(mahd))
            {
                return false;
            }
            return true;
        }

        //Cập nhật số lượng sản phẩm khi xóa
        public bool CapNhatSoLuongSanPhamTheoXoa(int masp, int soluong)
        {
            return ThemHDNhapDAO.CapNhatSoLuongSanPhamTheoXoa(masp, soluong);
        }
    }
}
