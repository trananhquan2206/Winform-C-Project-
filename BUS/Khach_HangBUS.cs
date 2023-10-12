using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Khach_HangBUS
    {
        Khach_HangDAO _khachHangDAO = new Khach_HangDAO();

        public List<string> GetDistinctValuesFromColumn(string tableName, string filterColumnName, string filterValue, string columnName)
        {
            return _khachHangDAO.GetDistinctValuesFromColumn(tableName, filterColumnName, filterValue, columnName);
        }

        public List<Khach_HangDTO> LayDanhSachKhachHang()
        {
            return _khachHangDAO.LayDanhSachKhachHang();
        }

        public List<Khach_HangDTO> TimKiemTheoBoLoc(string columnName, string value)
        {
            return _khachHangDAO.TimKiemTheoBoLoc(columnName, value);
        }

        public List<Khach_HangDTO> LoadDataByDate(DateTime fromDate, DateTime toDate)
        {
            return _khachHangDAO.LoadDataByDate(fromDate, toDate);
        }
    }
}
