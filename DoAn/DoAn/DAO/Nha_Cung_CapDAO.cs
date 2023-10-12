using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.SqlServer;
using Microsoft.SqlServer.Server;

namespace DAO
{
    public class Nha_Cung_CapDAO
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

        public List<Nha_Cung_CapDTO> LayDanhSachNhaCungCap()
        {
            List<Nha_Cung_CapDTO> dsNhaCungCap = new List<Nha_Cung_CapDTO>();

            using (var context = new MyDbContext())
            {
                var dsNhaCungCapDAO = context.HienThiNhaCungCap();

                foreach (var nhaCungCapDAO in dsNhaCungCapDAO)
                {
                    Nha_Cung_CapDTO nhaCungCapDTO = new Nha_Cung_CapDTO();

                    nhaCungCapDTO.MaNCC = nhaCungCapDAO.MaNCC;
                    nhaCungCapDTO.TenNCC = nhaCungCapDAO.TenNCC;
                    nhaCungCapDTO.SoDonHang = Convert.ToInt32(nhaCungCapDAO.SoDonHang);
                    nhaCungCapDTO.TongTien = nhaCungCapDAO.TongTien;

                    dsNhaCungCap.Add(nhaCungCapDTO);
                }
            }

            return dsNhaCungCap;
        }

        public List<Nha_Cung_CapDTO> TimKiemTheoBoLoc(string tableName, string columnName, string value)
        {
            using (var context = new MyDbContext())
            {
                var query = context.NHACUNGCAPs.AsQueryable();

                var nhacungcaps = context.TimKiemNhaCungCapTheoBoLoc(tableName, columnName, value).ToList();

                var nhaCungCapDTOs = nhacungcaps.Select(ncc => new Nha_Cung_CapDTO
                {
                    MaNCC = ncc.MaNCC,
                    TenNCC = ncc.TenNCC,
                    SoDonHang = context.HOADON_NHAP.Count(hdn => hdn.MaNCC == ncc.MaNCC && hdn.TrangThai == true),
                    TongTien = context.HOADON_NHAP.Where(hdn => hdn.MaNCC == ncc.MaNCC && hdn.TrangThai == true)
                                        .Sum(hdn => (double?)hdn.ThanhTien)?.ToString("N0") ?? "0"
                }).ToList();

                return nhaCungCapDTOs;
            }
        }

        public List<Nha_Cung_CapDTO> LoadDataByDate(DateTime fromDate, DateTime toDate)
        {
            List<Nha_Cung_CapDTO> dsNhaCungCap = new List<Nha_Cung_CapDTO>();

            using (var context = new MyDbContext())
            {
                var dsNhaCungCapDAO = context.LoadDataByDateInSupplier(fromDate, toDate);

                foreach (var nhaCungCapDAO in dsNhaCungCapDAO)
                {
                    Nha_Cung_CapDTO nhaCungCapDTO = new Nha_Cung_CapDTO();

                    nhaCungCapDTO.MaNCC = nhaCungCapDAO.MaNCC;
                    nhaCungCapDTO.TenNCC = nhaCungCapDAO.TenNCC;
                    nhaCungCapDTO.SoDonHang = Convert.ToInt32(nhaCungCapDAO.SoDonHang);
                    nhaCungCapDTO.TongTien = nhaCungCapDAO.TongTien;

                    dsNhaCungCap.Add(nhaCungCapDTO);
                }
            }

            return dsNhaCungCap;
        }
    }
}
