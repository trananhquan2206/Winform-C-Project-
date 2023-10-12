using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Khach_HangDTO
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public Nullable<int> SoDonHang { get; set; }
        public string TongTien { get; set; }
        public bool TrangThai { get; set; }
        public string GioiTinhText => GioiTinh ? "Nam" : "Nữ";
    }
}
