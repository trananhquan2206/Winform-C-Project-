using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Thong_Tin_Nha_Cung_CapDAO
    {
        public static QuanLyShopDienThoaiEntities qlsdtEntities = new QuanLyShopDienThoaiEntities();

        public List<Nha_Cung_CapDTO> LayDanhSachNhaCungCap()
        {
            var lst = qlsdtEntities.NHACUNGCAPs.Where(u => u.TrangThai == true).ToList();

            using (var context = new MyDbContext())
            {
                return lst.Select(u => new Nha_Cung_CapDTO
                {
                    MaNCC = u.MaNCC,
                    TenNCC = u.TenNCC,
                    DiaChi = u.DiaChi,
                    Email = u.Email,
                    SDT = u.SDT,
                    MaSoThue = u.MaSoThue,
                    SoDonHang = context.HOADON_NHAP.Count(hdn => hdn.MaNCC == u.MaNCC && hdn.TrangThai == true),
                    TongTien = context.HOADON_NHAP.Where(hdn => hdn.MaNCC == u.MaNCC && hdn.TrangThai == true)
                                        .Sum(hdb => (double?)hdb.ThanhTien)?.ToString("N0") ?? "0"
                }).ToList();
            }
        }

        public bool IsExisted(Nha_Cung_CapDTO newNCC)
        {
            var nccEF = qlsdtEntities.NHACUNGCAPs.FirstOrDefault(u => u.SDT == newNCC.SDT || u.MaSoThue == newNCC.MaSoThue);

            return nccEF != null;
        }

        public bool ThemNhaCungCap(Nha_Cung_CapDTO newNCC)
        {
            NHACUNGCAP nccEF = new NHACUNGCAP
            {
                TenNCC = newNCC.TenNCC,
                DiaChi = newNCC.DiaChi,
                Email = newNCC.Email,
                SDT = newNCC.SDT,
                MaSoThue = newNCC.MaSoThue,
                TrangThai = true
            };

            qlsdtEntities.NHACUNGCAPs.Add(nccEF);
            qlsdtEntities.SaveChanges();

            return true;
        }

        public bool CapNhatNhaCungCap(Nha_Cung_CapDTO _nhaCungCapDTO)
        {
            var ncc = qlsdtEntities.NHACUNGCAPs.SingleOrDefault(u => u.MaNCC == _nhaCungCapDTO.MaNCC);

            if (ncc == null) 
            {
                return false;
            }

            ncc.MaNCC = _nhaCungCapDTO.MaNCC;
            ncc.TenNCC = _nhaCungCapDTO.TenNCC;
            ncc.DiaChi = _nhaCungCapDTO.DiaChi;
            ncc.Email = _nhaCungCapDTO.Email;
            ncc.SDT = _nhaCungCapDTO.SDT;
            ncc.MaSoThue = _nhaCungCapDTO.MaSoThue;

            int count = qlsdtEntities.SaveChanges();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool XoaNhaCungCap(int maNCC)
        {
            var ncc = qlsdtEntities.NHACUNGCAPs.SingleOrDefault(u => u.MaNCC == maNCC);

            ncc.TrangThai = false;

            int count = qlsdtEntities.SaveChanges();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
