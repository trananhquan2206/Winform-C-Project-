using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SanPhamDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();
        public List<SanPhamDTO> layDSSP()
        {
            return db.SANPHAMs.Where(u => u.TrangThai == true && u.NHACUNGCAP.TrangThai == true).Select(v => new SanPhamDTO
            {
                MaSP = v.MaSP,
                TenSP = v.TenSP,
                MaNCC = v.MaNCC,
                TenNCC = v.NHACUNGCAP.TenNCC,
                SoLuong = v.SoLuong,
                DonGia = v.DonGia,
                HeDieuHanh = v.HeDieuHanh,
                Ram = v.Ram,    
                Chip = v.Chip,
                BoNho = v.BoNho,
                MauSac = v.MauSac,
                Camera = v.Camera,
                NamPhatHanh = v.NamPhatHanh,
                BaoHanh = v.BaoHanh,
                HinhAnh = v.HinhAnh
            }).ToList();
        }
        public dynamic loadNCC()
        {
            var result = from ncc in db.NHACUNGCAPs where ncc.TrangThai == true select new { ncc.TenNCC, ncc.MaNCC };
            return result.ToList();
        }
        public bool themSanPham(SanPhamDTO spDTO)
        {
            try
            {
                Console.WriteLine(spDTO.MaNCC + "MANCC");
                SANPHAM sp = new SANPHAM
                {
                    
                    TenSP = spDTO.TenSP,
                    SoLuong = spDTO.SoLuong,
                    DonGia = spDTO.DonGia,
                    MaNCC = spDTO.MaNCC,
                    HeDieuHanh = spDTO.HeDieuHanh,
                    BoNho = spDTO.BoNho,
                    Ram = spDTO.Ram,
                    Chip = spDTO.Chip,
                    Camera = spDTO.Camera,
                    MauSac = spDTO.MauSac,
                    NamPhatHanh = spDTO.NamPhatHanh,
                    BaoHanh = spDTO.BaoHanh,
                    HinhAnh = spDTO.HinhAnh,
                    TrangThai = true
                };
                db.SANPHAMs.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }
        public bool chinhSuaSanPham(SanPhamDTO spDTO)
        {
            try
            {
                var sp = db.SANPHAMs.SingleOrDefault(u => u.TrangThai == true && u.MaSP == spDTO.MaSP);

                sp.MaNCC = spDTO.MaNCC;
                sp.TenSP = spDTO.TenSP;
                sp.MauSac = spDTO.MauSac;
                sp.Camera = spDTO.Camera;
                sp.Chip = spDTO.Chip;
                sp.BaoHanh = spDTO.BaoHanh;
                sp.BoNho = spDTO.BoNho;
                sp.NamPhatHanh = spDTO.NamPhatHanh;
                sp.Ram = spDTO.Ram;
                sp.HeDieuHanh = spDTO.HeDieuHanh;
                sp.DonGia = spDTO.DonGia;
                sp.SoLuong = spDTO.SoLuong;
                sp.HinhAnh = spDTO.HinhAnh;

                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaSanPham(int maSP)
        {
            try
            {
                var sp = db.SANPHAMs.SingleOrDefault(u => u.MaSP == maSP);
                sp.TrangThai = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<SanPhamDTO> timKiemTheoTen(string tenSP)
        {
            return db.SANPHAMs.Where(u => u.TrangThai == true && u.TenSP.Contains(tenSP)).Select(v => new SanPhamDTO
            {
                MaSP = v.MaSP,
                TenSP = v.TenSP,
                MaNCC = v.MaNCC,
                TenNCC = v.NHACUNGCAP.TenNCC,
                SoLuong = v.SoLuong,
                DonGia = v.DonGia,
                HeDieuHanh = v.HeDieuHanh,
                Ram = v.Ram,
                Chip = v.Chip,
                BoNho = v.BoNho,
                MauSac = v.MauSac,
                Camera = v.Camera,
                NamPhatHanh = v.NamPhatHanh,
                BaoHanh = v.BaoHanh,
                HinhAnh = v.HinhAnh
            }).ToList();
        }
        public List<SanPhamDTO> timKiemTheoNCC(string ncc)
        {
            return db.SANPHAMs.Where(u => u.TrangThai == true && u.NHACUNGCAP.TenNCC.Contains(ncc)).Select(v => new SanPhamDTO
            {
                MaSP = v.MaSP,
                TenSP = v.TenSP,
                MaNCC = v.MaNCC,
                TenNCC = v.NHACUNGCAP.TenNCC,
                SoLuong = v.SoLuong,
                DonGia = v.DonGia,
                HeDieuHanh = v.HeDieuHanh,
                Ram = v.Ram,
                Chip = v.Chip,
                BoNho = v.BoNho,
                MauSac = v.MauSac,
                Camera = v.Camera,
                NamPhatHanh = v.NamPhatHanh,
                BaoHanh = v.BaoHanh,
                HinhAnh = v.HinhAnh
            }).ToList();
        }
        public List<SanPhamDTO> timKiemTheoGia(double gia)
        {
            return db.SANPHAMs.Where(u => u.TrangThai == true && u.DonGia <= gia).Select(v => new SanPhamDTO
            {
                MaSP = v.MaSP,
                TenSP = v.TenSP,
                MaNCC = v.MaNCC,
                TenNCC = v.NHACUNGCAP.TenNCC,
                SoLuong = v.SoLuong,
                DonGia = v.DonGia,
                HeDieuHanh = v.HeDieuHanh,
                Ram = v.Ram,
                Chip = v.Chip,
                BoNho = v.BoNho,
                MauSac = v.MauSac,
                Camera = v.Camera,
                NamPhatHanh = v.NamPhatHanh,
                BaoHanh = v.BaoHanh,
                HinhAnh = v.HinhAnh
            }).ToList();
        }
        public List<SanPhamDTO> timKiemTheoHDH(string hdh)
        {
            return db.SANPHAMs.Where(u => u.TrangThai == true && u.HeDieuHanh.Contains(hdh)).Select(v => new SanPhamDTO
            {
                MaSP = v.MaSP,
                TenSP = v.TenSP,
                MaNCC = v.MaNCC,
                TenNCC = v.NHACUNGCAP.TenNCC,
                SoLuong = v.SoLuong,
                DonGia = v.DonGia,
                HeDieuHanh = v.HeDieuHanh,
                Ram = v.Ram,
                Chip = v.Chip,
                BoNho = v.BoNho,
                MauSac = v.MauSac,
                Camera = v.Camera,
                NamPhatHanh = v.NamPhatHanh,
                BaoHanh = v.BaoHanh,
                HinhAnh = v.HinhAnh
            }).ToList();
        }
    }
}
