using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Thong_Tin_Nha_Cung_CapBUS
    {
        Thong_Tin_Nha_Cung_CapDAO _nhaCungCapDAO = new Thong_Tin_Nha_Cung_CapDAO();

        public List<Nha_Cung_CapDTO> LayDanhSachNhaCungCap()
        {
            return _nhaCungCapDAO.LayDanhSachNhaCungCap();
        }

        public bool ThemNhaCungCap(Nha_Cung_CapDTO newNCC)
        {
            if (_nhaCungCapDAO.IsExisted(newNCC))
                return false;

            return _nhaCungCapDAO.ThemNhaCungCap(newNCC);
        }

        public bool CapNhatNhaCungCap(Nha_Cung_CapDTO _nhaCungCapDTO)
        {
            return _nhaCungCapDAO.CapNhatNhaCungCap(_nhaCungCapDTO);
        }

        public bool XoaNhaCungCap(int maNCC)
        {
            if (_nhaCungCapDAO.XoaNhaCungCap(maNCC))
            {
                _nhaCungCapDAO.LayDanhSachNhaCungCap();
                return true;
            }

            return false;
        }
    }
}
