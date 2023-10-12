using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThemHDBanDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();

        //Lấy danh sách số điện thoại của khách hàng
        public List<KHACHHANG> layDSSDT()
        {
            var dskh = db.KHACHHANGs.Where(nv => nv.TrangThai == true).ToList();
            return dskh;
        }

        //Lấy danh sách mã nhân viên
        public List<NHANVIEN> layDSMaNV()
        {
            var dsMaNV = db.NHANVIENs.Where(u => u.TrangThai == true).ToList();
            return dsMaNV;
        }

        //Lấy danh sách mã sản phẩm
        public List<SANPHAM> layDSMaSP()
        {
            var dsMaSP = db.SANPHAMs.Where(u => u.TrangThai == true && u.SoLuong>0 ).ToList();
            return dsMaSP;
        }

        //Lấy giá theo mã sản phẩm
        public double layDonGia(int masp)
        {
            var dongia = db.SANPHAMs.Where(sp => sp.MaSP == masp).Select(sp => sp.DonGia).FirstOrDefault();
            return Convert.ToDouble(dongia);
        }

        //Tạo hóa đơn mới
        public string ThemHoadon(QuanLyBanDTO hd)
        {
            string ngayLapStr = DateTime.Now.ToString("dd/MM/yyyy");
            var hoaDon = new HOADON_BAN
            {
                NgayLap = DateTime.Parse(ngayLapStr),
                MaNV = hd.MaNV,
                MaKH = hd.MaKH,
                ThanhTien = 0,
                TrangThai = false
            };

            db.HOADON_BAN.Add(hoaDon);
            db.SaveChanges();
            return hoaDon.MaHD.ToString();
        }

        // Cập nhật tổng tiền của HOADON_BAN
        public bool CapNhatThanhTien(int mahd, double thanhTien)
        {
            var hoaDon = db.HOADON_BAN.SingleOrDefault(hd => hd.MaHD == mahd);
            if (hoaDon != null)
            {
                hoaDon.ThanhTien = thanhTien;
                hoaDon.TrangThai = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Lấy tên khách hàng theo số điện thoại
        public string layTenKH(string sdt)
        {
            return db.KHACHHANGs.Where(u => u.SDT == sdt).Select(u => u.TenKH).SingleOrDefault()?.ToString();
        }

        //Lấy mã khách hàng theo số điện thoại
        public string layMaKH(string sdt)
        {
            return db.KHACHHANGs.Where(u => u.SDT == sdt).Select(u => u.MaKH).SingleOrDefault().ToString();
        }

        //Lấy địa chỉ khách hàng theo số điện thoại
        public string layDiaChiKH(string sdt)
        {
            return db.KHACHHANGs.Where(u => u.SDT == sdt).Select(u => u.DiaChi).SingleOrDefault()?.ToString();
        }

        //Lấy số lượng của sản phẩm theo mã sản phẩm
        public int laySoLuong(int masp)
        {
            return db.SANPHAMs.Where(u => u.MaSP == masp).Select(u => u.SoLuong).SingleOrDefault();
        }

    }
}
