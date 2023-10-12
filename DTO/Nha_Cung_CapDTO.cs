using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Nha_Cung_CapDTO
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string MaSoThue { get; set; }
        public Nullable<int> SoDonHang { get; set; }
        public string TongTien { get; set; }
        public bool TrangThai { get; set; }
    }
}
