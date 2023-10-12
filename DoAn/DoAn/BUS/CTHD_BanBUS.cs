using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CTHD_BanBUS
    {
        CTHD_BanDAO CTHD_Ban = new CTHD_BanDAO();
        //Lay danh sach chi tiết hóa đơn nhập theo mahd
        public List<CTHD_BanDTO> layDSCTHDBan(int mahd)
        {
            return CTHD_Ban.layDSCTHDBan(mahd);
        }

        //Thêm mới 
        public bool ThemHoadon(CTHD_BanDTO hoadon)
        {
            return CTHD_Ban.ThemHoadon(hoadon);
        }

        //Tính tổng tiền của chi tiết hóa đơn
        public double TinhTongTien(int mahd)
        {
            return CTHD_Ban.TinhTongTien(mahd);
        }

        //Kiểm tra số lương
        public bool ktSoLuong(int SL)
        {
            if (SL == 0) return false;
            return true;
        }

        //Xóa
        public bool XoaHoaDon(int mahd, int masp)
        {
            return CTHD_Ban.XoaHoaDon(mahd, masp);
        }

        //Cập nhật số lượng sản phẩm
        public void CapNhatSoLuongSanPham(List<int> soluong, List<int> masp)
        {
            CTHD_Ban.CapNhatSoLuongSanPham(masp, soluong);
        }

        //Kiểm tra có chi tiết hóa đơn nào trạng thái là true không
        public int KiemTraCoCTHD(int mahd)
        {
            return CTHD_Ban.KiemTraCoCTHD(mahd);
        }

        // Cập nhật Chi tiết hóa đơn
        public bool CapNhatCTHD(CTHD_NHAPDTO cthd)
        {
           return CTHD_Ban.CapNhatCTHD(cthd);
        }

    }
}
