using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class QuanLyNhapDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();

        //Lấy danh sách hóa đơn nhập hang
        public List<QuanLyNhapDTO> layDSHoaDonNhap()
        {
            var lst = db.HOADON_NHAP.Where(u => u.TrangThai == true );
            return lst.Select(u => new QuanLyNhapDTO
            {
                MaHD = u.MaHD,
                NgayLap = u.NgayLap,
                MaNV = u.MaNV,
                MaNCC = u.MaNCC,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == u.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenNCC=db.NHACUNGCAPs.Where(ncc=>ncc.MaNCC==u.MaNCC).Select(ncc=>ncc.TenNCC).FirstOrDefault(),
                ThanhTien = u.ThanhTien
            }).ToList();
        }

        //lấy tổng tiền
        public double ktTongTien(int mahd)
        {
            double tongtien = db.HOADON_NHAP.Where(u => u.MaHD == mahd).Select(u => u.ThanhTien).FirstOrDefault();
            return tongtien;
        }

        //Tìm kiếm mã hóa đơn
        public List<QuanLyNhapDTO> TimKiemMaHoaDon(string mahd)
        {
            var hoadon = db.HOADON_NHAP.Where(u => u.MaHD.ToString().Contains(mahd) && u.TrangThai == true).Select(u => new QuanLyNhapDTO
            {
                MaHD = u.MaHD,
                NgayLap = u.NgayLap,
                MaNV = u.MaNV,
                MaNCC = u.MaNCC,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == u.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenNCC = db.NHACUNGCAPs.Where(ncc => ncc.MaNCC == u.MaNCC).Select(ncc => ncc.TenNCC).FirstOrDefault(),
                ThanhTien = u.ThanhTien
            }).ToList();
            return hoadon;
        }
        //Tìm kiếm theo tên nhân viên
        public List<QuanLyNhapDTO> TimKiemTenNhanVien(string tennv)
        {
            var hoadon = db.HOADON_NHAP.Where(x => x.NHANVIEN.HoTen.Contains(tennv) && x.TrangThai == true).Select(u => new QuanLyNhapDTO
            {
                MaHD = u.MaHD,
                NgayLap = u.NgayLap,
                MaNV = u.MaNV,
                MaNCC = u.MaNCC,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == u.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenNCC = db.NHACUNGCAPs.Where(ncc => ncc.MaNCC == u.MaNCC).Select(ncc => ncc.TenNCC).FirstOrDefault(),
                ThanhTien = u.ThanhTien
            }).ToList();
            return hoadon;
        }

        //Tìm kiếm theo tên nhà cung cấp
        public List<QuanLyNhapDTO> TimKiemTenNhaCungCap(string tenncc)
        {
            var hoadon = db.HOADON_NHAP.Where(x => x.NHACUNGCAP.TenNCC.Contains(tenncc) && x.TrangThai == true).Select(u => new QuanLyNhapDTO
            {
                MaHD = u.MaHD,
                NgayLap = u.NgayLap,
                MaNV = u.MaNV,
                MaNCC = u.MaNCC,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == u.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenNCC = db.NHACUNGCAPs.Where(ncc => ncc.MaNCC == u.MaNCC).Select(ncc => ncc.TenNCC).FirstOrDefault(),
                ThanhTien = u.ThanhTien
            }).ToList();
            return hoadon;
        }

        //Tìm kiếm mã nhân viên
        public List<QuanLyNhapDTO> TimKiemMaNhanVien(string manv)
        {
            var hoadon = db.HOADON_NHAP.Where(x => x.MaNV.ToString().Contains(manv) && x.TrangThai == true).Select(u => new QuanLyNhapDTO
            {
                MaHD = u.MaHD,
                NgayLap = u.NgayLap,
                MaNV = u.MaNV,
                MaNCC = u.MaNCC,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == u.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenNCC = db.NHACUNGCAPs.Where(ncc => ncc.MaNCC == u.MaNCC).Select(ncc => ncc.TenNCC).FirstOrDefault(),
                ThanhTien = u.ThanhTien
            }).ToList();
            return hoadon;
        }

        //Tìm kiếm mã nhà cung cấp
        public List<QuanLyNhapDTO> TimKiemMaNhaCungCap(string mancc)
        {
            var hoadon = db.HOADON_NHAP.Where(x => x.MaNCC.ToString().Contains(mancc) && x.TrangThai == true).Select(u => new QuanLyNhapDTO
            {
                MaHD = u.MaHD,
                NgayLap = u.NgayLap,
                MaNV = u.MaNV,
                MaNCC = u.MaNCC,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == u.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenNCC = db.NHACUNGCAPs.Where(ncc => ncc.MaNCC == u.MaNCC).Select(ncc => ncc.TenNCC).FirstOrDefault(),
                ThanhTien = u.ThanhTien
            }).ToList();
            return hoadon;
        }

        //Tìm kiếm theo ngày
        public List<QuanLyNhapDTO> TimKiemTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            var hoadon = db.HOADON_NHAP.Where(x => x.NgayLap >= tuNgay && x.NgayLap <= denNgay && x.TrangThai == true).Select(u => new QuanLyNhapDTO{
                MaHD = u.MaHD,
                NgayLap = u.NgayLap,
                MaNV = u.MaNV,
                MaNCC = u.MaNCC,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == u.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenNCC = db.NHACUNGCAPs.Where(ncc => ncc.MaNCC == u.MaNCC).Select(ncc => ncc.TenNCC).FirstOrDefault(),
                ThanhTien = u.ThanhTien
            }).ToList();
            return hoadon;
        }

        //Lấy hóa đơn thông tin theo mã hóa đơn
        public QuanLyNhapDTO LayHdTheoMaHD(int mahd)
        {
            var hoadon = db.HOADON_NHAP.SingleOrDefault(u => u.MaHD == mahd);
            if (hoadon == null)
            {
                return null;
            }
            return new QuanLyNhapDTO
            {
                MaHD = hoadon.MaHD,
                NgayLap = hoadon.NgayLap,
                MaNV = hoadon.MaNV,
                MaNCC = hoadon.MaNCC,
                TenNV = db.NHANVIENs.Where(nv => nv.MaNV == hoadon.MaNV).Select(nv => nv.HoTen).FirstOrDefault(),
                TenNCC = db.NHACUNGCAPs.Where(ncc => ncc.MaNCC == hoadon.MaNCC).Select(ncc => ncc.TenNCC).FirstOrDefault(),
                ThanhTien = hoadon.ThanhTien
            };
        }

    }
}
