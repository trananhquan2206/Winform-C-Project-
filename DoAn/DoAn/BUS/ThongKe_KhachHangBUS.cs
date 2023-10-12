using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongKe_KhachHangBUS
    {
        static ThongKe_KhachHangDAO ThongKe_KhachHangDAO = new ThongKe_KhachHangDAO();

        //Thống kê khách hàng mua hàng theo ngày tháng năm
        public static List<ThongKe_KhachHangDTO> KhachHangMuaNhieu(DateTime TuNgay, DateTime DenNgay)
        {
            return ThongKe_KhachHangDAO.KhachHangMuaNhieu(TuNgay, DenNgay);
        }

        //Thống kê khách hàng mua hàng theo năm
        public static List<ThongKe_KhachHangDTO> KhachHangMuaNhieuTheoNam(int nam)
        {
            return ThongKe_KhachHangDAO.KhachHangMuaNhieuTheoNam(nam);
        }

        //Thống kê khách hàng mua hàng theo quý
        public static List<ThongKe_KhachHangDTO> KhachHangMuaNhieuTheoQuy(int quy)
        { 
            return ThongKe_KhachHangDAO.KhachHangMuaNhieuTheoQuy(quy);
        }

        //Số lượng khách hàng đã mua hàng
        public static int SoLuongKhachHangDaMuaHang()
        {
            return ThongKe_KhachHangDAO.SoLuongKhachHangDaMuaHang();
        }

        //Số lượng khách hàng chưa mua hàng
        public static int SoLuongKhachHangChuaMuaHang()
        {
            return ThongKe_KhachHangDAO.SoLuongKhachHangChuaMuaHang();
        }
    }
}
