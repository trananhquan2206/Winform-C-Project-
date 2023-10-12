using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class QuanLyBanBUS
    {
        QuanLyBanDAO quanLyBanDAO = new QuanLyBanDAO();
        // lấy danh sách hóa đơn bán
        public List<QuanLyBanDTO> layDSHoaDonBan()
        {
            return quanLyBanDAO.layDSHoaDonBan();
        }

        //Kiểm tra tổng tiền
        public double ktTongTien(int mahd)
        {
            return quanLyBanDAO.ktTongTien(mahd);
        }

        //Tìm kiếm mã hóa đơn
        public List<QuanLyBanDTO> TimKiemMaHoaDon(string mahd)
        {
            return quanLyBanDAO.TimKiemMaHoaDon(mahd);

        }

        //Tìm kiếm mã nhân viên
        public List<QuanLyBanDTO> TimKiemMaNhanVien(string manv)
        {
            return quanLyBanDAO.TimKiemMaNhanVien(manv);
        }

        //Tìm kiếm mã khách hàng
        public List<QuanLyBanDTO> TimKiemMaKhachHang(string makh)
        {
            return quanLyBanDAO.TimKiemMaKhachHang(makh);
        }

        //Tìm kiếm theo ngày
        public List<QuanLyBanDTO> TimKiemTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            return quanLyBanDAO.TimKiemTheoNgay(tuNgay, denNgay);
        }

        //Lấy hóa đơn thông tin theo mã hóa đơn
        public QuanLyBanDTO LayHdTheoMaHD(int mahd)
        {
            return quanLyBanDAO.LayHdTheoMaHD(mahd);
        }

        //Tìm kiếm theo tên khách hàng
        public List<QuanLyBanDTO> TimKiemTenKhachHang(string tenkh)
        {
            return quanLyBanDAO.TimKiemTenKhachHang(tenkh);
        }

        //Tìm kiếm theo tên nhân viên
        public List<QuanLyBanDTO> TimKiemTenNhanVien(string tennv)
        {
            return quanLyBanDAO.TimKiemTenNhanVien(tennv);
        }

    }
}
