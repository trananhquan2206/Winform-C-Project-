using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BUS
{
    public class NhanVienBUS
    {
        static NhanVienDAO nvDAO = new NhanVienDAO();

        public static List<NhanVienDTO> layDSNV()
        {
            return nvDAO.layDSNV();
        }
        public static bool themNhanVien(NhanVienDTO nvDTO)
        {
            if(!nvDAO.isExisted(nvDTO.Email, nvDTO.SDT))
            {
                return nvDAO.themNhanVien(nvDTO);
            }
            return false;
        }
        public static bool checkInput(string hoTen, string email, string diaChi, string luong, string sdt)
        {
            return string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(luong) || string.IsNullOrEmpty(sdt);
        }
        public static bool checkValid(DateTime ngaySinh, DateTime ngayVaoLam)
        {
            return ngaySinh > DateTime.Now || ngayVaoLam > DateTime.Now || ngaySinh > ngayVaoLam;
        }
        public static bool chinhSuaNhanVien(NhanVienDTO nvDTO)
        {
            return nvDAO.chinhSuaNhanVien(nvDTO);
        }
        public static bool xoaNhanVien(int manv)
        {
            return nvDAO.xoaNhanVien(manv);
        }
        public static string layHoTen(string username)
        {
            return nvDAO.layHoTen(username);
        }
        public static string layChucVu(string username)
        {
            return nvDAO.layChucVu(username);
        }
        public static List<NhanVienDTO> dsNhanVienChuaCoTK()
        {
            return nvDAO.dsNhanVienChuaCoTK();
        }
        public static List<NhanVienDTO> timKiemTheoMa(int manv)
        {
            return nvDAO.timKiemTheoMa(manv);
        }
        public static List<NhanVienDTO> timKiemTheoTen(string hoTen)
        {
            return nvDAO.timKiemTheoHoTen(hoTen);
        }
        public static List<NhanVienDTO> timKiemTheoSDT(string sdt)
        {
            return nvDAO.timKiemTheoSDT(sdt);
        }
        public static List<NhanVienDTO> timKiemTheoEmail(string email)
        {
            return nvDAO.timKiemTheoEmail(email);
        }
        public static int layMaNV(string username)
        {
            return nvDAO.layMaNV(username);
        }
        public static bool IsEmailValid(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            bool isMatch = Regex.IsMatch(email, emailPattern);

            return isMatch;
        }
    }
}
