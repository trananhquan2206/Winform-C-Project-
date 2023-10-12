using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class CTHD_NhapBUS
    {
        CTHD_NhapDAO CTHD_Nhap = new CTHD_NhapDAO();
        //Lay danh sach chi tiết hóa đơn nhập theo mahd
        public List<CTHD_NHAPDTO> layDSCTHDNhap(int mahd)
        {
            return CTHD_Nhap.LayDSCTHDNhap(mahd);
        }

        //Thêm mới 
        public bool ThemHoadon(CTHD_NHAPDTO hoadon)
        {
            return CTHD_Nhap.ThemHoadon(hoadon);
        }

        //Tính tổng tiền của chi tiết hóa đơn
        public double TinhTongTien(int mahd)
        {
            return CTHD_Nhap.TinhTongTien(mahd);
        }

        //Kiểm tra số lương
        public bool ktSoLuong(int SL)
        {
            if(SL==0) return false;
            return true;
        }

        //Xóa
        public bool XoaHoaDon(int mahd, int masp)
        {
            return CTHD_Nhap.XoaHoaDon(mahd, masp);
        }

        //Cập nhật số lượng của sản phẩm
        public void CapNhatSoLuongSanPham(List<int> masp, List<int> soluong)
        {
            CTHD_Nhap.CapNhatSoLuongSanPham(masp, soluong);
        }

        //Kiểm tra có chi tiết hóa đơn nào trạng thái là true không
        public int KiemTraCoCTHD(int mahd)
        {
            return CTHD_Nhap.KiemTraCoCTHD(mahd);
        }

        // Cập nhật Chi tiết hóa đơn
        public bool CapNhatCTHD( CTHD_NHAPDTO cthd)
        {
            return CTHD_Nhap.CapNhatCTHD(cthd);
        }

    }
}
