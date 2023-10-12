using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuanLyNhapDTO
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaNV { get; set; }
        public int MaNCC { get; set; }
        public double ThanhTien { get; set; }
        public string TenNV { get; set; }
        public string TenNCC { get; set; }

        public string SDT { get; set; }
    }
}
