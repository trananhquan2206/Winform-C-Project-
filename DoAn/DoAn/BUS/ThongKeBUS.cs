using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongKeBUS
    {
        static ThongKeDAO tkDAO = new ThongKeDAO();

        public static double? layDoanhThuTheoNgay(DateTime start, DateTime end)
        {
            return tkDAO.layDoanhThuTheoNgay(start, end);
        }
        public static double layChiTieuTheoNgay(DateTime start, DateTime end)
        {
            return tkDAO.layChiTieuTheoNgay(start, end);
        }
        public static List<DoanhThuDTO> chiTietDoanhThuTheoNgay(DateTime start, DateTime end)
        {
            return tkDAO.chiTietDoanhThuTheoNgay(start, end);
        }
        public static List<ChiTieuDTO> chiTietChiTieuTheoNgay(DateTime start, DateTime end)
        {
            return tkDAO.chiTietChiTieuTheoNgay(start, end);
        }
        public static double layDoanhThuTheoQuy(string quy)
        {
            return tkDAO.layDoanhThuTheoQuy(quy);
        }
        public static double layChiTieuTheoQuy(string quy)
        {
            return tkDAO.layChiTieuTheoQuy(quy);
        }
        public static double layDoanhThuTheoNam(int nam)
        { 
            return tkDAO.layDoanhThuTheoNam(nam);
        }
        public static double layChiTieuTheoNam(int nam)
        {
            return tkDAO.layChiTieuTheoNam(nam);
        }
        public static List<DoanhThuDTO> chiTietDoanhThuTheoQuy(string quy)
        {
            return tkDAO.chiTietDoanhThuTheoQuy(quy);
        }
        public static List<ChiTieuDTO> chiTietChiTieuTheoQuy(string quy)
        {
            return tkDAO.chiTietChiTieuTheoQuy(quy);
        }
        public static List<DoanhThuDTO> chiTietDoanhThuTheoNam(int nam)
        {
            return tkDAO.chiTietDoanhThuTheoNam(nam);
        }
        public static List<ChiTieuDTO> chiTietChiTieuTheoNam(int nam)
        {
            return tkDAO.chiTietChiTieuTheoNam(nam);
        }
        public static List<ThongKeDoanhThuSanPhamDTO> MatHangBanChayNhat(DateTime fromDate, DateTime toDate)
        {
            return tkDAO.MatHangBanChayNhat(fromDate, toDate);
        }


    }
}
