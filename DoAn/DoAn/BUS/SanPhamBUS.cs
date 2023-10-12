using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPhamBUS
    {
        static SanPhamDAO spDAO = new SanPhamDAO();
        public static List<SanPhamDTO> layDSSP()
        {
            return spDAO.layDSSP();
        }
        public static dynamic loadNCC()
        {
            return spDAO.loadNCC();
        }
        public static bool themSanPham(SanPhamDTO spDTO)
        {
            return spDAO.themSanPham(spDTO);
        }
        public static bool chinhSuaSanPham(SanPhamDTO spDTO)
        {  
            return spDAO.chinhSuaSanPham(spDTO);
        }
        public static bool checkInput(string tenSP, string soLuong, string donGia, string camera, string mauSac, string namPhatHanh, string baoHanh, string chip, string ram, string boNho, string heDieuHanh)
        {
            return string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(soLuong) || string.IsNullOrEmpty(donGia) || string.IsNullOrEmpty(camera) || string.IsNullOrEmpty(mauSac) || string.IsNullOrEmpty(namPhatHanh) || string.IsNullOrEmpty(baoHanh) || string.IsNullOrEmpty(chip) || string.IsNullOrEmpty(ram) || string.IsNullOrEmpty(boNho) || string.IsNullOrEmpty(heDieuHanh);
        }
        public static bool xoaSanPham(int maSP)
        {
            return spDAO.xoaSanPham(maSP);
        }
        public static List<SanPhamDTO> timKiemTheoTen(string tenSP)
        {
            return spDAO.timKiemTheoTen(tenSP);
        }
        public static List<SanPhamDTO> timKiemTheoNCC(string ncc)
        {
            return spDAO.timKiemTheoNCC(ncc);
        }
        public static List<SanPhamDTO> timKiemTheoHDH(string hdh)
        {
            return spDAO.timKiemTheoHDH(hdh);
        }
        public static List<SanPhamDTO> timKiemTheoGia(double gia)
        {
            return spDAO.timKiemTheoGia(gia);
        }
    }
}
