using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThemHDBanBUS
    {
        ThemHDBanDAO ThemHDBanDAO = new ThemHDBanDAO();

        //Lấy danh sách số điện thoại của khách hàng
        public  List<KHACHHANG>  layDSSDT()
        {
            return ThemHDBanDAO.layDSSDT();
        }

        //Lấy danh sách mã nhân viên
        public List<NHANVIEN> layDSMaNV()
        {
            return ThemHDBanDAO.layDSMaNV();
        }

        //Lấy giá theo mã sản phẩm
        public double layDonGia(int masp)
        {
            return ThemHDBanDAO.layDonGia(masp);
        }

        //lấy danh sách mã sản phẩm
        public List<SANPHAM> layDSMaSP()
        {
            return ThemHDBanDAO.layDSMaSP();
        }

        //Lấy tên khách hàng theo số điện thoại
        public string layTenKH(string sdt)
        {
            return ThemHDBanDAO.layTenKH(sdt);
        }

        //Lấy mã khách hàng theo số điện thoại
        public string layMaKH(string sdt)
        {
            return ThemHDBanDAO.layMaKH(sdt);
        }

        //Lấy địa chỉ khách hàng theo số điện thoại
        public string layDiaChiKH(string sdt)
        {
            return ThemHDBanDAO.layDiaChiKH(sdt);
        }

        //Lấy số lượng của sản phẩm theo mã sản phẩm
        public int laySoLuong(int masp)
        {
            return ThemHDBanDAO.laySoLuong(masp);
        }

        //Tạo hóa đơn mới
        public string ThemHoadon(QuanLyBanDTO hd)
        {
            return ThemHDBanDAO.ThemHoadon(hd);
        }

        // Cập nhật tổng tiền của HOADON_BAN
        public bool CapNhatThanhTien(int mahd, double thanhTien)
        {
            return ThemHDBanDAO.CapNhatThanhTien(mahd, thanhTien);
        }

        //Kiểm tra số lượng sản phẩm
        public bool ktsoluong(int sl)
        {
            if(sl == 0)
                return false;
            return true;
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
    }
}