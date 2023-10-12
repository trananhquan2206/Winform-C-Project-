using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlClient;

namespace DAO
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=QuanLyShopDienThoaiEntities")
        {
        }

        public virtual DbSet<HOADON_BAN> HOADON_BAN { get; set; }
        public virtual DbSet<HOADON_NHAP> HOADON_NHAP { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }

        public virtual ObjectResult<HienThiKhachHang_Result> HienThiKhachHang()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HienThiKhachHang_Result>("HienThiKhachHang");
        }

        public virtual ObjectResult<HienThiNhaCungCap_Result> HienThiNhaCungCap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HienThiNhaCungCap_Result>("HienThiNhaCungCap");
        }

        public virtual ObjectResult<LoadDataByDateInCustomer_Result> LoadDataByDateInCustomer(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));

            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoadDataByDateInCustomer_Result>("LoadDataByDateInCustomer", fromDateParameter, toDateParameter);
        }

        public virtual ObjectResult<LoadDataByDateInSupplier_Result> LoadDataByDateInSupplier(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));

            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoadDataByDateInSupplier_Result>("LoadDataByDateInSupplier", fromDateParameter, toDateParameter);
        }

        public virtual List<Khach_HangDTO> TimKiemKhachHangTheoBoLoc(string columnName, string value)
        {
            using (var context = new MyDbContext())
            {
                var query = context.Database.SqlQuery<Khach_HangDTO>("EXEC TimKiemKhachHangTheoBoLoc @columnName, @value",
                    new SqlParameter("@columnName", columnName),
                    new SqlParameter("@value", value)
                );

                var khachangs = query.ToList();

                return khachangs;
            }
        }

        public virtual List<Nha_Cung_CapDTO> TimKiemNhaCungCapTheoBoLoc(string tableName, string columnName, string value)
        {
            using (var context = new MyDbContext())
            {
                var query = context.Database.SqlQuery<Nha_Cung_CapDTO>("EXEC TimKiemNhaCungCapTheoBoLoc @tableName, @columnName, @value",
                    new SqlParameter("@tableName", tableName),
                    new SqlParameter("@columnName", columnName),
                    new SqlParameter("@value", value)
                );

                var nhacungcaps = query.ToList();

                return nhacungcaps;
            }
        }

        [DbFunction("QuanLyShopDienThoaiEntities", "ThongKeDoanhThuSanPham")]
        public virtual IQueryable<ThongKeDoanhThuSanPham_Result> ThongKeDoanhThuSanPham(Nullable<System.DateTime> ngayBatDau, Nullable<System.DateTime> ngayKetThuc)
        {
            var ngayBatDauParameter = ngayBatDau.HasValue ?
                new ObjectParameter("ngayBatDau", ngayBatDau) :
                new ObjectParameter("ngayBatDau", typeof(System.DateTime));

            var ngayKetThucParameter = ngayKetThuc.HasValue ?
                new ObjectParameter("ngayKetThuc", ngayKetThuc) :
                new ObjectParameter("ngayKetThuc", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ThongKeDoanhThuSanPham_Result>("[QuanLyShopDienThoaiEntities].[ThongKeDoanhThuSanPham](@ngayBatDau, @ngayKetThuc)", ngayBatDauParameter, ngayKetThucParameter);
        }
    }
}
