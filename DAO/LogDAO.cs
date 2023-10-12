using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LogDAO
    {
        QuanLyShopDienThoaiEntities db = new QuanLyShopDienThoaiEntities();

        public List<LogDTO> layDSLog()
        {
            return db.LOGs.Where(u => u.TrangThai == true).Select(v => new LogDTO {
                LogID = v.LogID,
                Username = v.Username,
                ThoiGian = v.ThoiGian,
                MoTa = v.MoTa
            }).ToList();
        }

        public void themLog(string username, string content)
        {
            var log = new LOG
            {
                Username = username,
                MoTa = content,
                ThoiGian = DateTime.Now,
                TrangThai = true
            };

            db.LOGs.Add(log);
            db.SaveChanges();
        }

    }
}
