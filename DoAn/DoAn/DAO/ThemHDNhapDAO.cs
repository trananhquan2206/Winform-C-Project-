using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThemHDNhapDAO
    {
        QuanLyShopDienThoaiEntities db=new QuanLyShopDienThoaiEntities();

        //Lấy danh sách tên sản phẩm theo mã nhà cung cấp
        public List<SanPhamDTO> layDSTenSP(int mancc)
        {
            var dsTenSP = db.SANPHAMs.Where(u => u.MaNCC == mancc && u.TrangThai == true).Select(v => new SanPhamDTO
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
            return dsTenSP;
        }

        //Lấy danh sách tên sản phẩm theo mã nhà cung cấp
        public List<NhanVienDTO> layTenNV()
        {
            var dsTenNV = db.NHANVIENs.Where(u => u.TrangThai == true).Select(v => new NhanVienDTO
            {
                MaNV = v.MaNV,
                HoTen = v.HoTen,
                NgaySinh = v.NgaySinh,
                DiaChi = v.DiaChi,
                SDT = v.SDT,
                Email = v.Email,
                Luong = v.Luong,
                NgayVaoLam = v.NgayVaoLam,
                ChucVu = v.ChucVu
            }).ToList();
            return dsTenNV;
        }

        //Lấy danh sách tên nhà cung cấp 
        public List<NHACUNGCAP> layDSTenNCC()
        {
            var dsTenNCC= db.NHACUNGCAPs.Where(ncc => ncc.TrangThai == true && ncc.SANPHAMs.Any(sp => sp.MaNCC == ncc.MaNCC&& sp.TrangThai==true)).ToList();// lấy nhà cung cấp có ít nhất 1 sản phẩm
            return dsTenNCC;
        }


        //Lấy  tên nhà cung cấp theo mahd
        public HOADON_NHAP layTenNV(int mahd)
        {
            var dsTenNCC = db.HOADON_NHAP.Where(u => u.TrangThai == true && u.MaHD == mahd).FirstOrDefault();
            return dsTenNCC;
        }

        //Lấy số điện thoại theo mã nhà cung cấp 
        public string laySDT(int mancc)
        {
            var sdt = db.NHACUNGCAPs.Where(u => u.TrangThai == true && u.MaNCC==mancc).Select(nccsdt=>nccsdt.SDT).FirstOrDefault();
            return sdt;
        }

        //Lấy giá theo mã sản phẩm
        public double layDonGia(int masp)
        {
            var dongia = db.SANPHAMs.Where(sp => sp.MaSP == masp).Select(sp => sp.DonGia).FirstOrDefault();
            return Convert.ToDouble(dongia);
        }

        //Tạo hóa đơn mới
        public string ThemHoadon(QuanLyNhapDTO hd)
        {
            string ngayLapStr = DateTime.Now.ToString("dd/MM/yyyy");
            var hoaDon = new HOADON_NHAP
            {
                NgayLap = DateTime.Parse(ngayLapStr),
                MaNV = hd.MaNV,
                MaNCC = hd.MaNCC,
                ThanhTien = 0,
                TrangThai = false
            };

            db.HOADON_NHAP.Add(hoaDon);
            db.SaveChanges();
            return hoaDon.MaHD.ToString();
        }

        // Cập nhật tổng tiền của HOADON_NHAP
        public bool CapNhatThanhTien(int mahd, double thanhTien)
        {
            var hoaDon = db.HOADON_NHAP.SingleOrDefault(hd => hd.MaHD == mahd);
            if (hoaDon != null)
            {
                hoaDon.ThanhTien = thanhTien;
                hoaDon.TrangThai = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Lấy số lượng của sản phẩm theo mã sản phẩm
        public int laySoLuong(int masp)
        {
            return db.SANPHAMs.Where(u => u.MaSP == masp).Select(u => u.SoLuong).SingleOrDefault();
        }


        //cập nhật số lượng sản phẩm khi xóa
        public bool CapNhatSoLuongSanPhamTheoXoa(int masp, int soluong)
        {
            var sp=db.SANPHAMs.Where(u=>u.MaSP==masp).FirstOrDefault();
            if(sp==null)
                return false;

            sp.SoLuong = soluong;
            db.SaveChanges();
            return true;
        }
    }
}
