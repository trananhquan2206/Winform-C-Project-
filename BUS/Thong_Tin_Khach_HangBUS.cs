using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Thong_Tin_Khach_HangBUS
    {
        Thong_Tin_Khach_HangDAO _khachHangDAO = new Thong_Tin_Khach_HangDAO();

        public List<Khach_HangDTO> LayDanhSachKhachHang()
        {
            return _khachHangDAO.LayDanhSachKhachHang();
        }

        public bool ThemKhachHang(Khach_HangDTO newKH)
        {
            if (_khachHangDAO.IsExisted(newKH))
                return false;

            return _khachHangDAO.ThemKhachHang(newKH);
        }

        public bool CapNhatKhachHang(Khach_HangDTO _khachHangDTO)
        {
            return _khachHangDAO.CapNhatKhachHang(_khachHangDTO);
        }

        public bool XoaKhachHang(int maKH)
        {
            if (_khachHangDAO.XoaKhachHang(maKH))
            {
                _khachHangDAO.LayDanhSachKhachHang();
                return true;
            }

            return false;
        }
    }
}
