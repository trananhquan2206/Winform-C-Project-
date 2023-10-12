using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        static TaiKhoanDAO tkDAO = new TaiKhoanDAO();
        
        public static bool checkLogin(string username, string password)
        {
            return tkDAO.checkLogin(username, password);
        }
        public static List<TaiKhoanDTO> layDSTK()
        {
            return tkDAO.layDSTK();
        }
        public static bool checkTrung(string username, int manv)
        {
            return tkDAO.checkTrung(username, manv);
        }
        public static bool themTaiKhoan(TaiKhoanDTO tkDTO)
        {
            return tkDAO.themTaiKhoan(tkDTO);
        }
        public static bool checkTrung(string username, string user_del)
        {
            return username == user_del;
        }
        public static bool checkTonTai(int manv)
        {
            return tkDAO.checkTonTai(manv);
        }

        public static bool xoaTaiKhoan(string username)
        {
            return tkDAO.xoaTaiKhoan(username);
        }
        public static bool doiMatKhau(TaiKhoanDTO tkDTO)
        {
            return tkDAO.doiMatKhau(tkDTO);
        }
        public static bool checkPassword(string username, string password)
        {
            return tkDAO.checkPassword(username, password);
        }
        public static List<TaiKhoanDTO> timKiem(string username)
        {
            return tkDAO.timKiem(username);
        }
        public static string layTaiKhoan(int manv)
        {
            return tkDAO.layTaiKhoan(manv);
        }

    }
}
