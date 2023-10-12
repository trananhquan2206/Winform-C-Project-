using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Thong_Tin_Khach_HangDAO
    {
        public static QuanLyShopDienThoaiEntities qlsdtEntities = new QuanLyShopDienThoaiEntities();

        public List<Khach_HangDTO> LayDanhSachKhachHang()
        {
            var lst = qlsdtEntities.KHACHHANGs.Where(u => u.TrangThai == true).ToList();

            using (var context = new MyDbContext())
            {
                return lst.Select(u => new Khach_HangDTO
                {
                    MaKH = u.MaKH,
                    TenKH = u.TenKH,
                    GioiTinh = u.GioiTinh.Value,
                    NgaySinh = Convert.ToDateTime(u.NgaySinh),
                    DiaChi = u.DiaChi,
                    SDT = u.SDT,
                    SoDonHang = context.HOADON_BAN.Count(hdb => hdb.MaKH == u.MaKH && hdb.TrangThai == true),
                    TongTien = context.HOADON_BAN.Where(hdb => hdb.MaKH == u.MaKH && hdb.TrangThai == true)
                                        .Sum(hdb => (double?)hdb.ThanhTien)?.ToString("N0") ?? "0"
                }).ToList();
            }
        }

        public bool IsExisted(Khach_HangDTO newKH)
        {
            var khEF = qlsdtEntities.KHACHHANGs.FirstOrDefault(u => u.SDT == newKH.SDT);

            return khEF != null;
        }

        public bool ThemKhachHang(Khach_HangDTO newKH)
        {
            KHACHHANG khEF = new KHACHHANG
            {
                TenKH = newKH.TenKH,
                GioiTinh = newKH.GioiTinh,
                NgaySinh = newKH.NgaySinh,
                DiaChi = newKH.DiaChi,
                SDT = newKH.SDT,
                TrangThai = true
            };

            qlsdtEntities.KHACHHANGs.Add(khEF);
            qlsdtEntities.SaveChanges();

            return true;
        }

        public bool CapNhatKhachHang(Khach_HangDTO _khachHangDTO)
        {
            var kh = qlsdtEntities.KHACHHANGs.SingleOrDefault(u => u.MaKH == _khachHangDTO.MaKH);

            if (kh == null)
            {
                return false;
            }

            kh.MaKH = _khachHangDTO.MaKH;
            kh.TenKH = _khachHangDTO.TenKH;
            kh.GioiTinh = _khachHangDTO.GioiTinh;
            kh.NgaySinh = _khachHangDTO.NgaySinh;
            kh.DiaChi = _khachHangDTO.DiaChi;
            kh.SDT = _khachHangDTO.SDT;

            int count = qlsdtEntities.SaveChanges();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool XoaKhachHang(int maKH)
        {
            var kh = qlsdtEntities.KHACHHANGs.SingleOrDefault(u => u.MaKH == maKH);

            kh.TrangThai = false;

            int count = qlsdtEntities.SaveChanges();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
