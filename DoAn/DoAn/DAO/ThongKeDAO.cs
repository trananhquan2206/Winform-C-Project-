using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThongKeDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();

        public double layDoanhThuTheoNgay(DateTime start, DateTime end)
        {
            int count = db.HOADON_BAN.Count(u => u.TrangThai == true && u.NgayLap >= start && u.NgayLap <= end);
            
            return count > 0 ? db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap >= start && u.NgayLap <= end).Sum(v => v.ThanhTien) : 0;
        }
        public double layChiTieuTheoNgay(DateTime start, DateTime end)
        {
            int count = db.HOADON_NHAP.Count(u => u.TrangThai == true && u.NgayLap >= start && u.NgayLap <= end);

            return count > 0 ? db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap >= start && u.NgayLap <= end).Sum(v => v.ThanhTien) : 0;
        }
        public List<DoanhThuDTO> chiTietDoanhThuTheoNgay(DateTime start, DateTime end)
        {
            //return db.DoanhThuTheoNgay(start, end);
            return db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap >= start && u.NgayLap <= end).Select(v => new DoanhThuDTO
            {
                MAHD = v.MaHD,
                NgayLap = v.NgayLap,
                DoanhThu = v.CTHD_BAN.Count() > 0 ? v.CTHD_BAN.Sum(p => p.ThanhTien.Value) : 0
            }).ToList();
        }
        public List<ChiTieuDTO> chiTietChiTieuTheoNgay(DateTime start, DateTime end)
        {
            //return db.ChiTieuTheoNgay(start, end);

            return db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap >= start && u.NgayLap <= end).Select(v => new ChiTieuDTO
            {
                MAHD = v.MaHD,
                NgayLap = v.NgayLap,
                ChiTieu = v.CTHD_NHAP.Count() > 0 ? v.CTHD_NHAP.Sum(p => p.ThanhTien.Value) : 0
            }).ToList();
        }
        public double layDoanhThuTheoQuy(string quy)
        {

            if (quy == CONST_THONGKE.QUY1)
            {
                int count = db.HOADON_BAN.Count(u => u.TrangThai == true && u.NgayLap.Month >= 1 && u.NgayLap.Month <= 3);

                return count > 0 ? db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap.Month >= 1 && u.NgayLap.Month <= 3).Sum(v => v.ThanhTien) : 0;
            }
            else if (quy == CONST_THONGKE.QUY2)
            {
                int count = db.HOADON_BAN.Count(u => u.TrangThai == true && u.NgayLap.Month >= 4 && u.NgayLap.Month <= 6);

                return count > 0 ? db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap.Month >= 4 && u.NgayLap.Month <= 6).Sum(v => v.ThanhTien) : 0;
            }
            else if (quy == CONST_THONGKE.QUY3)
            {
                int count = db.HOADON_BAN.Count(u => u.TrangThai == true && u.NgayLap.Month >= 7 && u.NgayLap.Month <= 9);

                return count > 0 ? db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap.Month >= 7 && u.NgayLap.Month <= 9).Sum(v => v.ThanhTien) : 0;
            }
            else
            {
                int count = db.HOADON_BAN.Count(u => u.TrangThai == true && u.NgayLap.Month >= 10 && u.NgayLap.Month <= 12);

                return count > 0 ? db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap.Month >= 10 && u.NgayLap.Month <= 12).Sum(v => v.ThanhTien) : 0;
            }
        }

        public double layChiTieuTheoQuy(string quy)
        {

            if (quy == CONST_THONGKE.QUY1)
            {
                int count = db.HOADON_NHAP.Count(u => u.TrangThai == true && u.NgayLap.Month >= 1 && u.NgayLap.Month <= 3 && u.NgayLap.Year == DateTime.Now.Year);

                return count > 0 ? db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap.Month >= 1 && u.NgayLap.Month <= 3 && u.NgayLap.Year == DateTime.Now.Year).Sum(v => v.ThanhTien) : 0;
            }
            else if (quy == CONST_THONGKE.QUY2)
            {
                int count = db.HOADON_NHAP.Count(u => u.TrangThai == true && u.NgayLap.Month >= 4 && u.NgayLap.Month <= 6 && u.NgayLap.Year == DateTime.Now.Year);

                return count > 0 ? db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap.Month >= 4 && u.NgayLap.Month <= 6 && u.NgayLap.Year == DateTime.Now.Year).Sum(v => v.ThanhTien) : 0;
            }
            else if (quy == CONST_THONGKE.QUY3)
            {
                int count = db.HOADON_NHAP.Count(u => u.TrangThai == true && u.NgayLap.Month >= 7 && u.NgayLap.Month <= 9 && u.NgayLap.Year == DateTime.Now.Year);

                return count > 0 ? db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap.Month >= 7 && u.NgayLap.Month <= 9 && u.NgayLap.Year == DateTime.Now.Year).Sum(v => v.ThanhTien) : 0;
            }
            else
            {
                int count = db.HOADON_NHAP.Count(u => u.TrangThai == true && u.NgayLap.Month >= 10 && u.NgayLap.Month <= 12 && u.NgayLap.Year == DateTime.Now.Year);

                return count > 0 ? db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap.Month >= 10 && u.NgayLap.Month <= 12 && u.NgayLap.Year == DateTime.Now.Year).Sum(v => v.ThanhTien) : 0;
            }
        }
        public double layDoanhThuTheoNam(int nam)
        {
            int count = db.HOADON_BAN.Count(u => u.TrangThai == true && u.NgayLap.Year == nam);

            return count > 0 ? db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap.Year == nam).Sum(v => v.ThanhTien) : 0;
        }
        public double layChiTieuTheoNam(int nam)
        {
            int count = db.HOADON_NHAP.Count(u => u.TrangThai == true && u.NgayLap.Year == nam);

            return count > 0 ? db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap.Year == nam).Sum(v => v.ThanhTien) : 0;
        }
        public List<DoanhThuDTO> chiTietDoanhThuTheoQuy(string quy)
        {
            //return db.DoanhThuTheoQuy(quy);
            int start, end;
            if (quy == CONST_THONGKE.QUY1)
            {
                start = 1;
                end = 3;
            } 
            else if (quy == CONST_THONGKE.QUY2)
            {
                start = 4;
                end = 6;
            }
            else if (quy == CONST_THONGKE.QUY3)
            {
                start = 7;
                end = 9;
            }
            else
            {
                start = 10;
                end = 12;
            }

            return db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap.Month >= start && u.NgayLap.Month <= end).Select(v => new DoanhThuDTO
            {
                MAHD = v.MaHD,
                NgayLap = v.NgayLap,
                DoanhThu = v.CTHD_BAN.Count() > 0 ? v.CTHD_BAN.Sum(p => p.ThanhTien.Value) : 0
            }).ToList();
        }
        public List<ChiTieuDTO> chiTietChiTieuTheoQuy(string quy)
        {
            //return db.ChiTieuTheoQuy(quy);
            int start, end;
            if (quy == CONST_THONGKE.QUY1)
            {
                start = 1;
                end = 3;
            }
            else if (quy == CONST_THONGKE.QUY2)
            {
                start = 4;
                end = 6;
            }
            else if (quy == CONST_THONGKE.QUY3)
            {
                start = 7;
                end = 9;
            }
            else
            {
                start = 10;
                end = 12;
            }

            return db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap.Month >= start && u.NgayLap.Month <= end && u.NgayLap.Year == DateTime.Now.Year).Select(v => new ChiTieuDTO
            {
                MAHD = v.MaHD,
                NgayLap = v.NgayLap,
                ChiTieu = v.CTHD_NHAP.Count() > 0 ? v.CTHD_NHAP.Sum(p => p.ThanhTien.Value) : 0
            }).ToList();
        }
        public List<DoanhThuDTO> chiTietDoanhThuTheoNam(int nam)
        {
            //return db.DoanhThuTheoNam(nam);
            return db.HOADON_BAN.Where(u => u.TrangThai == true && u.NgayLap.Year == nam).Select(v => new DoanhThuDTO
            {
                MAHD = v.MaHD,
                NgayLap = v.NgayLap,
                DoanhThu = v.CTHD_BAN.Count() > 0 ? v.CTHD_BAN.Sum(p => p.ThanhTien.Value) : 0
            }).ToList();
        } 
        public List<ChiTieuDTO> chiTietChiTieuTheoNam(int nam)
        {
            //return db.ChiTieuTheoNam(nam);
            return db.HOADON_NHAP.Where(u => u.TrangThai == true && u.NgayLap.Year == nam).Select(v => new ChiTieuDTO
            {
                MAHD = v.MaHD,
                NgayLap = v.NgayLap,
                ChiTieu = v.CTHD_NHAP.Count() > 0 ? v.CTHD_NHAP.Sum(p => p.ThanhTien.Value) : 0
            }).ToList();
        }
        public List<ThongKeDoanhThuSanPhamDTO> MatHangBanChayNhat(DateTime fromDate, DateTime toDate)
        {
            List<ThongKeDoanhThuSanPhamDTO> lstSP = new List<ThongKeDoanhThuSanPhamDTO>();

            using (var context = new MyDbContext())
            {
                var query = context.ThongKeDoanhThuSanPham(fromDate, toDate);

                foreach (var sp in query)
                {
                    ThongKeDoanhThuSanPhamDTO _thongKeSanPham = new ThongKeDoanhThuSanPhamDTO();

                    _thongKeSanPham.MaSP = sp.MaSP;
                    _thongKeSanPham.TenSP = sp.TenSP;
                    _thongKeSanPham.TongTien = sp.TongTien.Value;
                    _thongKeSanPham.NgayLap = sp.NgayLap;

                    lstSP.Add(_thongKeSanPham);
                }
            }

            return lstSP;
        }
    }
}
