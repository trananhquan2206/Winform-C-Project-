using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhanVienDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();

        public List<NhanVienDTO> layDSNV()
        {
            return db.NHANVIENs.Where(u => u.TrangThai == true).Select(v => new NhanVienDTO
            {
                MaNV = v.MaNV,
                HoTen = v.HoTen,
                NgaySinh = v.NgaySinh,
                DiaChi = v.DiaChi,
                SDT = v.SDT,
                Email = v.Email,
                Luong = v.Luong,
                NgayVaoLam = v.NgayVaoLam,
                ChucVu = v.ChucVu
            }).ToList();
        }
        public bool themNhanVien(NhanVienDTO nvDTO)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN
                {
                    HoTen = nvDTO.HoTen,
                    NgaySinh = nvDTO.NgaySinh,
                    DiaChi = nvDTO.DiaChi,
                    SDT = nvDTO.SDT,
                    Email = nvDTO.Email,
                    NgayVaoLam = nvDTO.NgayVaoLam,
                    Luong = nvDTO.Luong,
                    ChucVu = nvDTO.ChucVu,
                    TrangThai = true
                };
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool isExisted(string email, string sdt)
        {
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(u => (u.SDT == sdt || u.Email == email) && u.TrangThai == true);
            return nv != null;
        }
        public bool chinhSuaNhanVien(NhanVienDTO nvDTO)
        {
            try
            {
                NHANVIEN nv = db.NHANVIENs.SingleOrDefault(u => u.MaNV == nvDTO.MaNV);
                nv.ChucVu = nvDTO.ChucVu;
                nv.HoTen = nvDTO.HoTen;
                nv.Email = nvDTO.Email;
                nv.DiaChi = nvDTO.DiaChi;
                nv.SDT = nvDTO.SDT;
                nv.Luong = nvDTO.Luong;
                nv.NgaySinh = nvDTO.NgaySinh;
                nv.NgayVaoLam = nvDTO.NgayVaoLam;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaNhanVien(int manv)
        {
            try
            {
                NHANVIEN nv = db.NHANVIENs.SingleOrDefault(u => u.MaNV == manv);
                nv.TrangThai = false;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string layHoTen(string username)
        {
            var hoten = db.TAIKHOANs.Where(u => u.Username == username).Select(v => v.NHANVIEN.HoTen).SingleOrDefault();
            
            return hoten;
        }
        public int layMaNV(string username)
        {
            return db.TAIKHOANs.Where(u => u.Username == username).Select(v => v.MaNV.Value).SingleOrDefault();
        }
        public string layChucVu(string username)
        {
            return db.TAIKHOANs.Where(u => u.TrangThai == true && u.Username == username).Select(v => v.NHANVIEN.ChucVu).SingleOrDefault();
        }
        public List<NhanVienDTO> dsNhanVienChuaCoTK()
        {
            return db.NHANVIENs.Where(u => u.TrangThai == true && !db.TAIKHOANs.Any(tk => tk.MaNV == u.MaNV && tk.TrangThai == true)).Select(v => new NhanVienDTO
            {
                MaNV = v.MaNV,
                HoTen = v.HoTen,
            }).ToList();
        }
        public List<NhanVienDTO> timKiemTheoMa(int manv)
        {
            return db.NHANVIENs.Where(u => u.TrangThai == true && u.MaNV == manv).Select(v => new NhanVienDTO
            {
                MaNV = v.MaNV,
                HoTen = v.HoTen,
                DiaChi = v.DiaChi,
                SDT = v.SDT,
                Email =  v.Email,
                NgaySinh = v.NgaySinh,
                NgayVaoLam = v.NgayVaoLam,
                Luong = v.Luong,
                ChucVu = v.ChucVu,
                
            }).ToList();
        }
        public List<NhanVienDTO> timKiemTheoHoTen(string hoTen)
        {
            return db.NHANVIENs.Where(u => u.TrangThai == true && u.HoTen.Contains(hoTen)).Select(v => new NhanVienDTO
            {
                MaNV = v.MaNV,
                HoTen = v.HoTen,
                DiaChi = v.DiaChi,
                SDT = v.SDT,
                Email = v.Email,
                NgaySinh = v.NgaySinh,
                NgayVaoLam = v.NgayVaoLam,
                Luong = v.Luong,
                ChucVu = v.ChucVu,

            }).ToList();
        }
        public List<NhanVienDTO> timKiemTheoSDT(string sdt)
        {
            return db.NHANVIENs.Where(u => u.TrangThai == true && u.SDT.Contains(sdt)).Select(v => new NhanVienDTO
            {
                MaNV = v.MaNV,
                HoTen = v.HoTen,
                DiaChi = v.DiaChi,
                SDT = v.SDT,
                Email = v.Email,
                NgaySinh = v.NgaySinh,
                NgayVaoLam = v.NgayVaoLam,
                Luong = v.Luong,
                ChucVu = v.ChucVu,

            }).ToList();
        }
        public List<NhanVienDTO> timKiemTheoEmail(string email)
        {
            return db.NHANVIENs.Where(u => u.TrangThai == true && u.Email.Contains(email)).Select(v => new NhanVienDTO
            {
                MaNV = v.MaNV,
                HoTen = v.HoTen,
                DiaChi = v.DiaChi,
                SDT = v.SDT,
                Email = v.Email,
                NgaySinh = v.NgaySinh,
                NgayVaoLam = v.NgayVaoLam,
                Luong = v.Luong,
                ChucVu = v.ChucVu,

            }).ToList();
        }
    }
}
