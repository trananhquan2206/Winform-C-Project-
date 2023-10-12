using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
            dgvLog.AutoGenerateColumns = false;
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void LoadLog()
        {
            dgvLog.DataSource = LogBUS.layDSLog();
        }
    }
}
