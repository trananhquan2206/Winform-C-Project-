using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class CTHD_NhapDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();
        //Lay danh sach chi tiết hóa đơn nhập theo mahd
        public List<CTHD_NHAPDTO> LayDSCTHDNhap(int mahd)
        {
            var lst = db.CTHD_NHAP.Where(u => u.MaHD == mahd  &&u.TrangThai==true).ToList();
            return lst.Select(u => new CTHD_NHAPDTO
            {
                MaHD = u.MaHD,
                MaSP = u.MaSP,
                TenSP = db.SANPHAMs.Where(sp => sp.MaSP == u.MaSP).Select(sp => sp.TenSP).FirstOrDefault(),
                SoLuong = u.SoLuong,
                DonGia = u.DonGia,
                ChietKhau = u.ChietKhau, 
                ThanhTien = u.ThanhTien.Value,
                TrangThai=true
            }).ToList();
        }

        //Kiểm tra có chi tiết hóa đơn nào trạng thái là true không
        public int KiemTraCoCTHD(int mahd)
        {
            int count = db.CTHD_NHAP.Where(i => i.TrangThai == true && i.MaHD == mahd).Count();
            return count;
        }

        //Thêm mới 
        public bool ThemHoadon(CTHD_NHAPDTO hoadon)
        {
            try
            {
                //Kiểm tra xem cthd đã có chưa
                var hd = db.CTHD_NHAP.SingleOrDefault(x => x.MaHD == hoadon.MaHD && x.MaSP == hoadon.MaSP && x.TrangThai == false);
                var hdd = db.CTHD_NHAP.SingleOrDefault(x => x.MaHD == hoadon.MaHD && x.MaSP == hoadon.MaSP && x.TrangThai == true);
                if (hd != null)
                {
                    hd.SoLuong = hoadon.SoLuong;
                    hd.ChietKhau = hoadon.ChietKhau;
                    hd.ThanhTien = hoadon.ThanhTien;
                    hd.TrangThai = true;
                    db.SaveChanges();
                }
                else if (hdd != null)
                {
                    return false;
                }
                else
                {
                    hd = new CTHD_NHAP
                    {
                        MaHD = hoadon.MaHD,
                        MaSP = hoadon.MaSP,
                        SoLuong = hoadon.SoLuong,
                        DonGia = hoadon.DonGia,
                        ChietKhau = hoadon.ChietKhau,
                        TrangThai = true,
                        ThanhTien = hoadon.ThanhTien
                    };
                    db.CTHD_NHAP.Add(hd);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                return false;
            }
        }

        //Tính tổng tiền của chi tiết hóa đơn
        public double TinhTongTien(int mahd)
        {
            double tongTien = 0;
            var dsCTHDNhap = db.CTHD_NHAP.Where(u=>u.MaHD==mahd && u.TrangThai==true &&u.ThanhTien !=0).ToList();
            foreach (var cthd in dsCTHDNhap)
            {
                tongTien += cthd.ThanhTien.Value;
            }
            return tongTien;
        }

        // Xóa
        public bool XoaHoaDon(int hoadon,int masp)
        {
            try
            {
                var hd = db.CTHD_NHAP.Where(u=>u.MaHD==hoadon &&u.MaSP==masp).FirstOrDefault();
                if (hd != null)
                {
                    hd.TrangThai = false;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Cập nhật số lượng của sản phẩm
        public void CapNhatSoLuongSanPham(List<int> masp, List<int> soluong)
        {
            var sp = db.SANPHAMs.Where(u => masp.Contains(u.MaSP) && u.TrangThai == true).ToList();
            for (int i = 0; i < sp.Count(); i++)
            {
                sp[i].SoLuong = soluong[i];
                db.SaveChanges();
            }
        }

        // Cập nhật Chi tiết hóa đơn
        public bool CapNhatCTHD( CTHD_NHAPDTO cthd)
        {
            try
            {
                var hd = db.CTHD_NHAP.Where(u => u.MaHD == cthd.MaHD && u.MaSP ==cthd.MaSP && u.TrangThai==true).FirstOrDefault();
                if (hd != null)
                {
                    hd.ThanhTien= cthd.ThanhTien;
                    hd.ChietKhau= cthd.ChietKhau;
                    hd.SoLuong= cthd.SoLuong;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
