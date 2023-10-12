﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string ChucVu { get; set; }
        public string SDT { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public double Luong { get; set; }
    }
}
