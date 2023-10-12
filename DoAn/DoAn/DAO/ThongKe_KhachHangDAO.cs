using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Entity.Core.Objects;
using System.Runtime.Remoting.Contexts;

namespace DAO
{
    public class ThongKe_KhachHangDAO
    {
        //Thống kê khách hàng mua hàng Theo ngày tháng năm
        public List<ThongKe_KhachHangDTO> KhachHangMuaNhieu(DateTime TuNgay, DateTime DenNgay)
        {
            List<ThongKe_KhachHangDTO> lstSP = new List<ThongKe_KhachHangDTO>();

            using (var context = new QuanLyShopDienThoaiEntities())
            {
                var query = context.LayDSKhachHangMuaHangNhieu(TuNgay, DenNgay);

                foreach (var kh in query)
                {
                    ThongKe_KhachHangDTO _thongKekhachhang= new ThongKe_KhachHangDTO();

                    _thongKekhachhang.MaKH = kh.makh;
                    _thongKekhachhang.TenKH = kh.TenKH;
                    _thongKekhachhang.DiaChi = kh.diachi;
                    _thongKekhachhang.SDT = kh.SDT;
                    _thongKekhachhang.tong_soluong = (int)kh.tong_soluong;

                    lstSP.Add(_thongKekhachhang);
                }
            }
            return lstSP;
        }


        //Thống kê khách hàng mua Theo năm
        public List<ThongKe_KhachHangDTO> KhachHangMuaNhieuTheoNam(int nam)
        {
            List<ThongKe_KhachHangDTO> lstSP = new List<ThongKe_KhachHangDTO>();

            using (var context = new QuanLyShopDienThoaiEntities())
            {
                var query = context.LayDSKhachHangMuaHangNhieuTheoNam(nam);

                foreach (var kh in query)
                {
                    ThongKe_KhachHangDTO _thongKekhachhang = new ThongKe_KhachHangDTO();

                    _thongKekhachhang.MaKH = kh.makh;
                    _thongKekhachhang.TenKH = kh.TenKH;
                    _thongKekhachhang.DiaChi = kh.diachi;
                    _thongKekhachhang.SDT = kh.SDT;
                    _thongKekhachhang.tong_soluong = (int)kh.tong_soluong;

                    lstSP.Add(_thongKekhachhang);
                }
            }
            return lstSP;
        }

        //Thống kê khách hàng mua hàng theo quý
        public List<ThongKe_KhachHangDTO> KhachHangMuaNhieuTheoQuy(int quy)
        {
            List<ThongKe_KhachHangDTO> lstSP = new List<ThongKe_KhachHangDTO>();

            using (var context = new QuanLyShopDienThoaiEntities())
            {
                var query = context.LayDSKhachHangMuaHangNhieuTheoQuy(quy);

                foreach (var kh in query)
                {
                    ThongKe_KhachHangDTO _thongKekhachhang = new ThongKe_KhachHangDTO();

                    _thongKekhachhang.MaKH = kh.makh;
                    _thongKekhachhang.TenKH = kh.TenKH;
                    _thongKekhachhang.DiaChi = kh.diachi;
                    _thongKekhachhang.SDT = kh.SDT;
                    _thongKekhachhang.tong_soluong = (int)kh.tong_soluong;

                    lstSP.Add(_thongKekhachhang);
                }
            }
            return lstSP;
        }

        //Số lượng khách hàng đã mua hàng
        public int SoLuongKhachHangDaMuaHang()
        {
            //using (var context = new QuanLyShopDienThoaiEntities())
            //{
            //    ObjectResult<int?> result = context.LaySoLuongKhachHangDaMuaHang();
            //    if(result != null && result.FirstOrDefault() != null)
            //    {
            //        int soluong = Convert.ToInt32(result.FirstOrDefault());
            //        return soluong;
            //    }
            //    return 0;

            //}

            using (var context = new QuanLyShopDienThoaiEntities())
            {
                var result = context.Database.SqlQuery<int>("EXEC LaySoLuongKhachHangDaMuaHang").FirstOrDefault();
                return result;
            }
        }

        //Số lượng khách hàng chưa mua hàng
        public int SoLuongKhachHangChuaMuaHang()
        {
            //using (var context = new QuanLyShopDienThoaiEntities())
            //{
            //    return Convert.ToInt32(context.LaySoLuongKhachHangChuaMuaHang());
            //}

            using (var context = new QuanLyShopDienThoaiEntities())
            {
                var result = context.Database.SqlQuery<int>("EXEC LaySoLuongKhachHangChuaMuaHang").FirstOrDefault();
                return result;
            }
        }
    }
}
