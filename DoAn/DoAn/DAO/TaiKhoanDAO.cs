using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TaiKhoanDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();
        public bool checkLogin(string Username, string Password)
        {
            var taiKhoan = db.TAIKHOANs.SingleOrDefault(u => u.Username == Username && u.Password == Password && u.TrangThai == true);
            return taiKhoan != null;
        }
        public List<TaiKhoanDTO> layDSTK()
        {
            return db.TAIKHOANs.Where(u => u.TrangThai == true).Select(v => new TaiKhoanDTO 
            {
                Username = v.Username,
                Password = v.Password,
                MaNV = v.MaNV.Value,
                HoTen = v.NHANVIEN.HoTen
            }
            ).ToList();
        }
        public bool themTaiKhoan(TaiKhoanDTO tkDTO)
        {
            try
            {
                var tk = new TAIKHOAN
                {
                    Username = tkDTO.Username,
                    Password = tkDTO.Password,
                    MaNV = tkDTO.MaNV,
                    TrangThai = true
                };
                db.TAIKHOANs.Add(tk);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } 
        public bool xoaTaiKhoan(string username)
        {
            try
            {
                var tk = db.TAIKHOANs.SingleOrDefault(u => u.Username == username);
                tk.TrangThai = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool doiMatKhau(TaiKhoanDTO tkDTO)
        {
            try
            {
                var tk = db.TAIKHOANs.SingleOrDefault(u => u.Username == tkDTO.Username);
                tk.Password = tkDTO.Password;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool checkTonTai(int manv)
        {
            var tk = db.TAIKHOANs.SingleOrDefault(u => u.TrangThai == true && u.MaNV == manv);
            return tk != null;
        }
        public bool checkTrung(string username, int manv)
        {
            var ma = db.TAIKHOANs.Where(u => u.TrangThai == true && u.Username == username).Select(p => p.MaNV).SingleOrDefault();
            return ma == manv;
        }
        public bool checkPassword(string username, string password)
        {
            var tk = db.TAIKHOANs.SingleOrDefault(u => u.Username == username && u.Password == password);
            return tk != null;
        }

        public List<TaiKhoanDTO> timKiem(string username)
        {
            return db.TAIKHOANs.Where(u => u.TrangThai == true && u.Username == username).Select(v => new TaiKhoanDTO
            {
                Username = v.Username,
                HoTen = v.NHANVIEN.HoTen,
                MaNV = v.MaNV.Value
            }).ToList();
        }
        public string layTaiKhoan(int manv)
        {
            return db.TAIKHOANs.Where(u => u.MaNV == manv).Select(v => v.Username).FirstOrDefault();
        }
 
        
    }
}
