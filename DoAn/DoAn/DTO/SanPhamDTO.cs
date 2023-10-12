using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public double DonGia { get; set; }
        public string HeDieuHanh { get; set; }
        public int BoNho { get; set; }
        public int Ram { get; set; }
        public string Chip { get; set; }
        public string MauSac { get; set; }
        public string Camera { get; set; }
        public int NamPhatHanh { get; set; }
        public int BaoHanh { get; set; }
        public byte[] HinhAnh { get; set; }
    }
}
