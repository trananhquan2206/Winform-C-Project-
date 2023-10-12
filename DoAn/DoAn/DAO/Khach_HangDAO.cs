using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Khach_HangDAO
    {
        public static QuanLyShopDienThoaiEntities qlsdtEntities = new QuanLyShopDienThoaiEntities();

        public List<string> GetDistinctValuesFromColumn(string tableName, string filterColumnName, string filterValue, string columnName)
        {
            using (var context = new MyDbContext())
            {
                var distinctValues = context.Database.SqlQuery<string>(
                    $"SELECT DISTINCT CAST({columnName} AS NVARCHAR(255)) AS {columnName} FROM {tableName} WHERE {filterColumnName} = @p0", filterValue)
                    .ToList();

                return distinctValues;
            }
        }

        public List<Khach_HangDTO> LayDanhSachKhachHang()
        {
            List<Khach_HangDTO> dsKhachHang = new List<Khach_HangDTO>();

            using (var context = new MyDbContext())
            {
                var dsKhachHangDAO = context.HienThiKhachHang();

                foreach (var khachHangDAO in dsKhachHangDAO)
                {
                    Khach_HangDTO khachHangDTO = new Khach_HangDTO();

                    khachHangDTO.MaKH = khachHangDAO.MaKH;
                    khachHangDTO.TenKH = khachHangDAO.TenKH;
                    khachHangDTO.SoDonHang = Convert.ToInt32(khachHangDAO.SoDonHang);
                    khachHangDTO.TongTien = khachHangDAO.TongTien;

                    dsKhachHang.Add(khachHangDTO);
                }
            }

            return dsKhachHang;
        }

        public List<Khach_HangDTO> TimKiemTheoBoLoc(string columnName, string value)
        {
            using (var context = new MyDbContext())
            {
                var query = context.KHACHHANGs.AsQueryable();

                var khachhangs = context.TimKiemKhachHangTheoBoLoc(columnName, value).ToList();

                var khachHangDTOs = khachhangs.Select(kh => new Khach_HangDTO
                {
                    MaKH = kh.MaKH,
                    TenKH = kh.TenKH,
                    SoDonHang = context.HOADON_BAN.Count(hdb => hdb.MaKH == kh.MaKH && hdb.TrangThai == true),
                    TongTien = context.HOADON_BAN.Where(hdb => hdb.MaKH == kh.MaKH && hdb.TrangThai == true)
                                        .Sum(hdb => (double?)hdb.ThanhTien)?.ToString("N0") ?? "0"
                }).ToList();

                return khachHangDTOs;
            }
        }

        public List<Khach_HangDTO> LoadDataByDate(DateTime fromDate, DateTime toDate)
        {
            List<Khach_HangDTO> dsKhachHang = new List<Khach_HangDTO>();

            using (var context = new MyDbContext())
            {
                var dsKhachHangDAO = context.LoadDataByDateInCustomer(fromDate, toDate);

                foreach (var khachHangDAO in dsKhachHangDAO)
                {
                    Khach_HangDTO khachHangDTO = new Khach_HangDTO();

                    khachHangDTO.MaKH = khachHangDAO.MaKH;
                    khachHangDTO.TenKH = khachHangDAO.TenKH;
                    khachHangDTO.SoDonHang = Convert.ToInt32(khachHangDAO.SoDonHang);
                    khachHangDTO.TongTien = khachHangDAO.TongTien;

                    dsKhachHang.Add(khachHangDTO);
                }
            }

            return dsKhachHang;
        }
    }
}
