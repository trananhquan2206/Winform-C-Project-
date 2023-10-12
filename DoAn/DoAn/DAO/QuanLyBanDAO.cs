using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class QuanLyBanDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();

        //Lấy danh sách hóa đơn bán hàng
        public List<QuanLyBanDTO> layDSHoaDonBan()
        {
            var lst = db.HOADON_BAN.Where(u => u.TrangThai == true );
            return lst.Select(u => new QuanLyBanDTO
            {
                MaHD = u.MaHD,
                NgayLap = u.NgayLap,
                MaNV = u.MaNV,
                MaKH= u.MaKH,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == u.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenKH = db.KHACHHANGs.Where(kh => kh.MaKH == u.MaKH).Select(kh => kh.TenKH).FirstOrDefault(),
                ThanhTien = u.ThanhTien,
                SDT= db.KHACHHANGs.Where(kh => kh.MaKH == u.MaKH).Select(kh => kh.SDT).FirstOrDefault(),
                DiaChi = db.KHACHHANGs.Where(kh => kh.MaKH == u.MaKH).Select(kh => kh.DiaChi).FirstOrDefault(),
            }).ToList();
        }

        //lấy tổng tiền
        public double ktTongTien(int mahd)
        {
            double tongtien = db.HOADON_BAN.Where(u => u.MaHD == mahd).Select(u => u.ThanhTien).FirstOrDefault();
            return tongtien;
        }

        //Tìm kiếm mã hóa đơn
        public List<QuanLyBanDTO> TimKiemMaHoaDon(string mahd)
        {
            var hoadon = db.HOADON_BAN.Where(x=>x.MaHD.ToString().Contains(mahd)&& x.TrangThai==true  ).Select(x => new QuanLyBanDTO
            {
                MaHD=x.MaHD,
                NgayLap=x.NgayLap,
                MaNV =x.MaNV,
                MaKH=x.MaKH,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == x.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenKH = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.TenKH).FirstOrDefault(),
                ThanhTien = x.ThanhTien,
                SDT = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.SDT).FirstOrDefault(),
                DiaChi = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.DiaChi).FirstOrDefault(),
            }).ToList();
            return hoadon;
        }

        //Tìm kiếm mã nhân viên
        public List<QuanLyBanDTO> TimKiemMaNhanVien(string manv)
        {
            var hoadon = db.HOADON_BAN.Where(x => x.MaNV.ToString().Contains(manv) && x.TrangThai == true ).Select(x => new QuanLyBanDTO
            {
                MaHD = x.MaHD,
                NgayLap = x.NgayLap,
                MaNV = x.MaNV,
                MaKH = x.MaKH,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == x.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenKH = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.TenKH).FirstOrDefault(),
                ThanhTien = x.ThanhTien,
                SDT = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.SDT).FirstOrDefault(),
                DiaChi = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.DiaChi).FirstOrDefault(),
            }).ToList();
            return hoadon;
        }

        //Tìm kiếm theo tên nhân viên
        public List<QuanLyBanDTO> TimKiemTenNhanVien(string tennv)
        {
            var hoadon = db.HOADON_BAN.Where(x => x.NHANVIEN.HoTen.Contains(tennv) && x.TrangThai == true).Select(x => new QuanLyBanDTO
            {
                MaHD = x.MaHD,
                NgayLap = x.NgayLap,
                MaNV = x.MaNV,
                MaKH = x.MaKH,
                TenNV = x.NHANVIEN.HoTen,
                TenKH = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.TenKH).FirstOrDefault(),
                ThanhTien = x.ThanhTien,
                SDT = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.SDT).FirstOrDefault(),
                DiaChi = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.DiaChi).FirstOrDefault(),
            }).ToList();
            return hoadon;
        }

        //Tìm kiếm mã khách hàng
        public List<QuanLyBanDTO> TimKiemMaKhachHang(string makh)
        {
            var hoadon = db.HOADON_BAN.Where(x => x.MaKH.ToString().Contains(makh) && x.TrangThai == true ).Select(x => new QuanLyBanDTO
            {
                MaHD = x.MaHD,
                NgayLap = x.NgayLap,
                MaNV = x.MaNV,
                MaKH = x.MaKH,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == x.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenKH = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.TenKH).FirstOrDefault(),
                ThanhTien = x.ThanhTien,
                SDT = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.SDT).FirstOrDefault(),
                DiaChi = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.DiaChi).FirstOrDefault(),
            }).ToList();
            return hoadon;
        }


        //Tìm kiếm tên khách hàng
        public List<QuanLyBanDTO> TimKiemTenKhachHang(string tenkh)
        {
            var hoadon = db.HOADON_BAN.Where(x => x.KHACHHANG.TenKH.Contains(tenkh) && x.TrangThai == true).Select(x => new QuanLyBanDTO
            {
                MaHD = x.MaHD,
                NgayLap = x.NgayLap,
                MaNV = x.MaNV,
                MaKH = x.MaKH,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == x.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenKH = x.KHACHHANG.TenKH,
                ThanhTien = x.ThanhTien,
                SDT = x.KHACHHANG.SDT,
                DiaChi = x.KHACHHANG.DiaChi,
            }).ToList();
            return hoadon;
        }


        //Tìm kiếm theo ngày
        public List<QuanLyBanDTO> TimKiemTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            var hoadon = db.HOADON_BAN.Where(x => x.NgayLap >= tuNgay && x.NgayLap <= denNgay && x.TrangThai == true).Select(x => new QuanLyBanDTO{
                MaHD = x.MaHD,
                NgayLap = x.NgayLap,
                MaNV = x.MaNV,
                MaKH = x.MaKH,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == x.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenKH = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.TenKH).FirstOrDefault(),
                ThanhTien = x.ThanhTien,
                SDT = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.SDT).FirstOrDefault(),
                DiaChi = db.KHACHHANGs.Where(kh => kh.MaKH == x.MaKH).Select(kh => kh.DiaChi).FirstOrDefault(),
            }).ToList();
            return hoadon;
        }

        //Lấy hóa đơn thông tin theo mã hóa đơn
        public QuanLyBanDTO LayHdTheoMaHD(int mahd)
        {
            var hoadon = db.HOADON_BAN.SingleOrDefault(u => u.MaHD == mahd);
            if (hoadon == null)
            {
                return null;
            }
            return new QuanLyBanDTO
            {
                MaHD = hoadon.MaHD,
                NgayLap = hoadon.NgayLap,
                MaNV = hoadon.MaNV,
                MaKH = hoadon.MaKH,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == hoadon.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenKH = db.KHACHHANGs.Where(kh => kh.MaKH == hoadon.MaKH).Select(kh => kh.TenKH).FirstOrDefault(),
                ThanhTien = hoadon.ThanhTien,
                SDT = db.KHACHHANGs.Where(kh => kh.MaKH == hoadon.MaKH).Select(kh => kh.SDT).FirstOrDefault(),
                DiaChi = db.KHACHHANGs.Where(kh => kh.MaKH == hoadon.MaKH).Select(kh => kh.DiaChi).FirstOrDefault(),
            };
        }
    }
}

