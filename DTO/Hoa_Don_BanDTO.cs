using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Hoa_Don_BanDTO
    {
        public int MaHD { get; set; }
        public System.DateTime NgayLap { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public double ThanhTien { get; set; }
        public bool TrangThai { get; set; }
    }
}
