using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class QuanLyNhapBUS
    {
        QuanLyNhapDAO quanLyNhapDAO = new QuanLyNhapDAO();

        //Lấy danh sách hóa đơn nhập hàng
        public List<QuanLyNhapDTO> layDSHoaDonNhap()
        {
            return quanLyNhapDAO.layDSHoaDonNhap();
        }

        //Kiểm tra tổng tiền
        public double ktTongTien(int mahd)
        {
            return quanLyNhapDAO.ktTongTien(mahd);
        }

        //Tìm kiếm mã hóa đơn
        public List<QuanLyNhapDTO> TimKiemMaHoaDon(string mahd)
        {
            return quanLyNhapDAO.TimKiemMaHoaDon(mahd);
        }

        //Tìm kiếm mã nhân viên
        public List<QuanLyNhapDTO> TimKiemMaNhanVien(string manv)
        {
            return quanLyNhapDAO.TimKiemMaNhanVien(manv);
        }

        //Tìm kiếm mã nhà cung cấp
        public List<QuanLyNhapDTO> TimKiemMaNhaCungCap(string mancc)
        {
            return quanLyNhapDAO.TimKiemMaNhaCungCap(mancc);
        }

        //Tìm kiếm theo ngày
        public List<QuanLyNhapDTO> TimKiemTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            return quanLyNhapDAO.TimKiemTheoNgay(tuNgay, denNgay);
        }

        //Lấy hóa đơn thông tin theo mã hóa đơn
        public QuanLyNhapDTO LayHdTheoMaHD(int mahd)
        {
            return quanLyNhapDAO.LayHdTheoMaHD(mahd);
        }

        //Tìm kiếm theo tên nhân viên
        public List<QuanLyNhapDTO> TimKiemTenNhanVien(string tennv)
        {
            return quanLyNhapDAO.TimKiemTenNhanVien(tennv);
        }

        //Tìm kiếm theo tên nhà cung cấp
        public List<QuanLyNhapDTO> TimKiemTenNhaCungCap(string tenncc)
        {
            return quanLyNhapDAO.TimKiemTenNhaCungCap(tenncc);
        }

    }
}
