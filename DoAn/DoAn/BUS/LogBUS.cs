using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LogBUS
    {
        static LogDAO logDAO = new LogDAO();

        public static List<LogDTO> layDSLog()
        {
            return logDAO.layDSLog();
        }

        public static void themLog(string username, string content)
        {
            logDAO.themLog(username, content);
        }
    }
}
