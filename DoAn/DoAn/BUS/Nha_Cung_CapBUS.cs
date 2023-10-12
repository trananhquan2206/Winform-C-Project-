using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class Nha_Cung_CapBUS
    {
        Nha_Cung_CapDAO _nhaCungCapDAO = new Nha_Cung_CapDAO();

        public List<string> GetDistinctValuesFromColumn(string tableName, string filterColumnName, string filterValue, string columnName)
        {
            return _nhaCungCapDAO.GetDistinctValuesFromColumn(tableName, filterColumnName, filterValue, columnName);
        }

        public List<Nha_Cung_CapDTO> LayDanhSachNhaCungCap()
        {
            return _nhaCungCapDAO.LayDanhSachNhaCungCap();
        }

        public List<Nha_Cung_CapDTO> TimKiemTheoBoLoc(string tableName, string columnName, string value)
        {
            return _nhaCungCapDAO.TimKiemTheoBoLoc(tableName, columnName, value);
        }

        public List<Nha_Cung_CapDTO> LoadDataByDate(DateTime fromDate, DateTime toDate)
        {
            return _nhaCungCapDAO.LoadDataByDate(fromDate, toDate);
        }
    }
}
