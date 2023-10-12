using BUS;
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace DoAn
{
    public partial class frmThongKe : Form
    {
        string username;
        private DevExpress.XtraCharts.Series series;
        public frmThongKe(string username)
        {
            InitializeComponent();
            this.username = username;
            dgvChiTieu.AutoGenerateColumns = false;
            dgvDoanhThu.AutoGenerateColumns = false;

            dtpFrom.Value = dtpTo.Value = DateTime.Now;
            btnBaoCaoKhachHang.Visible = false;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            double? doanhThu = 0,  chiTieu = 0;
            if (radNgay.Checked)
            {
                if (dtpBatDau.Value > dtpKetThuc.Value)
                {
                    MessageBox.Show(CONSTANTS_THONGKE.INVALID_DAY, CONSTANTS_THONGKE.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtpBatDau.Value > DateTime.Now || dtpKetThuc.Value > DateTime.Now) 
                {
                    MessageBox.Show(CONSTANTS_THONGKE.INVALID_DAY2, CONSTANTS_THONGKE.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                doanhThu = ThongKeBUS.layDoanhThuTheoNgay(dtpBatDau.Value, dtpKetThuc.Value);
                chiTieu = ThongKeBUS.layChiTieuTheoNgay(dtpBatDau.Value, dtpKetThuc.Value);

                dgvDoanhThu.DataSource = ThongKeBUS.chiTietDoanhThuTheoNgay(dtpBatDau.Value, dtpKetThuc.Value);
                dgvChiTieu.DataSource = ThongKeBUS.chiTietChiTieuTheoNgay(dtpBatDau.Value, dtpKetThuc.Value);

            }

            else if (radQuy.Checked)
            {
                doanhThu = ThongKeBUS.layDoanhThuTheoQuy(cboQuy.Text);
                chiTieu = ThongKeBUS.layChiTieuTheoQuy(cboQuy.Text);
                dgvDoanhThu.DataSource = ThongKeBUS.chiTietDoanhThuTheoQuy(cboQuy.Text);
                dgvChiTieu.DataSource = ThongKeBUS.chiTietChiTieuTheoQuy(cboQuy.Text);
            }
            else
            {
                doanhThu = ThongKeBUS.layDoanhThuTheoNam((int)nbrNam.Value);
                chiTieu = ThongKeBUS.layChiTieuTheoNam((int)nbrNam.Value);

                dgvChiTieu.DataSource = ThongKeBUS.chiTietChiTieuTheoNam((int)nbrNam.Value);
                dgvDoanhThu.DataSource = ThongKeBUS.chiTietDoanhThuTheoNam((int)nbrNam.Value);
            }
            dgvDoanhThu.Visible = true;
            dgvChiTieu.Visible = true;
            chartThuChi.Visible = true;
            btnBaoCaoDoanhThu.Visible = true;
            btnBaoCaoChiTieu.Visible = true;
            if (series == null)
            {
                series = new DevExpress.XtraCharts.Series(CONSTANTS_THONGKE.THU_CHI, ViewType.Pie);
                chartThuChi.Series.Add(series);
                series.Label.TextPattern = CONSTANTS_THONGKE.DESIGN_PARTTEN;
                chartThuChi.Titles.Add(new ChartTitle() { Text = CONSTANTS_THONGKE.CHART_NAME });

            }
            else
            {
                series.Points.Clear();
            }
            series.Points.Add(new SeriesPoint(CONSTANTS_THONGKE.DOANH_THU, doanhThu));
            series.Points.Add(new SeriesPoint(CONSTANTS_THONGKE.CHI_TIEU, chiTieu));
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            cboQuy.SelectedIndex = CONSTANTS_THONGKE.ZERO;
            loadChartKhachHang();
            cboMua.SelectedIndex = CONSTANTS_THONGKE.ZERO;
        }


        private void btnBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            if (radNgay.Checked)
            {
                rptThu_Ngay rpt = new rptThu_Ngay();
                var result = ThongKeBUS.chiTietDoanhThuTheoNgay(dtpBatDau.Value, dtpKetThuc.Value);
                rpt.DataSource = result;
                rpt.Parameters[CONSTANTS_THONGKE.START].Value = dtpBatDau.Value;
                rpt.Parameters[CONSTANTS_THONGKE.END].Value = dtpKetThuc.Value;
                rpt.RequestParameters = false;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else if (radQuy.Checked)
            {
                rptThu_Quy rpt = new rptThu_Quy();
                var result = ThongKeBUS.chiTietDoanhThuTheoQuy(cboQuy.Text);
                rpt.DataSource = result;
                rpt.Parameters[CONSTANTS_THONGKE.QUY].Value = cboQuy.Text;
                rpt.RequestParameters = false;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else
            {
                rptThu_Nam rpt = new rptThu_Nam();
                var result = ThongKeBUS.chiTietDoanhThuTheoNam((int)nbrNam.Value);
                rpt.DataSource = result;
                rpt.Parameters[CONSTANTS_THONGKE.NAM].Value = (int)nbrNam.Value;
                rpt.RequestParameters = false;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
        }

        private void btnBaoCaoChiTieu_Click(object sender, EventArgs e)
        {
            if (radNgay.Checked)
            {
                rptChi_Ngay rpt = new rptChi_Ngay();
                var result = ThongKeBUS.chiTietChiTieuTheoNgay(dtpBatDau.Value, dtpKetThuc.Value);
                rpt.DataSource = result;
                rpt.Parameters[CONSTANTS_THONGKE.START].Value = dtpBatDau.Value;
                rpt.Parameters[CONSTANTS_THONGKE.END].Value = dtpKetThuc.Value;
                rpt.RequestParameters = false;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else if (radQuy.Checked)
            {
                rptChi_Quy rpt = new rptChi_Quy();
                var result = ThongKeBUS.chiTietChiTieuTheoQuy(cboQuy.Text);
                rpt.DataSource = result;
                rpt.Parameters[CONSTANTS_THONGKE.QUY].Value = cboQuy.Text;
                rpt.RequestParameters = false;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else
            {
                rptChi_Nam rpt = new rptChi_Nam();
                var result = ThongKeBUS.chiTietChiTieuTheoNam((int)nbrNam.Value);
                rpt.DataSource = result;
                rpt.Parameters[CONSTANTS_THONGKE.NAM].Value = (int)nbrNam.Value;
                rpt.RequestParameters = false;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
        }

        private void chartSP_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartSP.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dataPoint = result.Series.Points[result.PointIndex];
                DateTime ngayLap = DateTime.FromOADate(dataPoint.XValue);
                double doanhThu = dataPoint.YValues[0];

                string tooltipText = $"Ngày mua: {ngayLap.ToString("dd/MM/yyyy")}\nDoanh thu: {doanhThu.ToString("N0")} triệu";

                toolTip.Show(tooltipText, chartSP, e.Location.X + 10, e.Location.Y + 10);
            }
            else
            {
                toolTip.Hide(chartSP);
            }
        }
        private void UpdateData()
        {
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;

            List<ThongKeDoanhThuSanPhamDTO> danhSachSanPham = ThongKeBUS.MatHangBanChayNhat(fromDate, toDate).ToList();

            chartSP.Series.Clear();

            if (danhSachSanPham.Count == 0)
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series(CONSTANTS_THONGKE.NO_RECORD_FOUND);
                series.ChartType = SeriesChartType.Spline;

                series.Points.AddXY(CONSTANTS_THONGKE.ASISX_TITLE, 0);

                chartSP.Series.Add(series);
            }
            else
            {
                HashSet<string> uniqueNames = new HashSet<string>();

                foreach (ThongKeDoanhThuSanPhamDTO sanPham in danhSachSanPham)
                {
                    string tenSP = sanPham.TenSP;
                    DateTime ngayLap = sanPham.NgayLap;

                    if (!uniqueNames.Contains(tenSP))
                    {
                        uniqueNames.Add(tenSP);

                        System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series(tenSP);
                        series.ChartType = SeriesChartType.Spline;

                        List<DataPoint> dataPoints = danhSachSanPham
                            .Where(x => x.TenSP == tenSP && x.TongTien > 0)
                            .Select(x => new DataPoint(x.NgayLap.ToOADate(), x.TongTien))
                            .ToList();

                        foreach (DataPoint dataPoint in dataPoints)
                        {
                            DateTime ngayMua = DateTime.FromOADate(dataPoint.XValue);
                            double doanhThu = dataPoint.YValues[0];
                            DataPoint newPoint = new DataPoint(ngayMua.ToOADate(), doanhThu);
                            newPoint.MarkerStyle = MarkerStyle.Circle;
                            series.Points.Add(newPoint);
                        }

                        chartSP.Series.Add(series);
                    }
                }
            }

            chartSP.ChartAreas[0].AxisX.Title = CONSTANTS_THONGKE.ASISX_TITLE;

            chartSP.ChartAreas[0].AxisY.Title = CONSTANTS_THONGKE.ASISY_TITLE;

            dgvSP.DataSource = ThongKeBUS.MatHangBanChayNhat(fromDate, toDate);
        }
        private void dtpValueChanged(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;

            if (dtpFrom.Value > DateTime.Now || dtpTo.Value > DateTime.Now)
            {
                dtpFrom.Value = dtpTo.Value = DateTime.Now;
            }

            if (dtpFrom.Value > dtpTo.Value)
            {
                DateTime time = dtpFrom.Value;
                dtpFrom.Value = dtpTo.Value;
                dtpTo.Value = time;
            }

            UpdateData();
        }

        private void btnThongKeKhachHang_Click(object sender, EventArgs e)
        {
            btnBaoCaoKhachHang.Visible = true;
            if (radThongKeTheoNgay.Checked == true)
            {
                DateTime TuNgay = dtpTuNgay.Value;
                DateTime DenNgay = dtpDenNgay.Value;
                dgvThongkeKhachHang.DataSource = ThongKe_KhachHangBUS.KhachHangMuaNhieu(TuNgay, DenNgay);
            }
            else if (radThongKeTheoNam.Checked == true)
            {
                int nam = (int)nbNam.Value;
                dgvThongkeKhachHang.DataSource = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoNam(nam);

            }
            else if (radThongKeTheoQuy.Checked == true)
            {
                if (cboMua.SelectedIndex == 0)
                {
                    dgvThongkeKhachHang.DataSource = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoQuy(1);
                }
                else if (cboMua.SelectedIndex == 1)
                {
                    dgvThongkeKhachHang.DataSource = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoQuy(2);
                }
                else if (cboMua.SelectedIndex == 2)
                {
                    dgvThongkeKhachHang.DataSource = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoQuy(3);
                }
                else if (cboMua.SelectedIndex == 3)
                {
                    dgvThongkeKhachHang.DataSource = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoQuy(4);
                }
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
                dtpTuNgay.Value = dtpDenNgay.Value = DateTime.Now;
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > DateTime.Now)
                dtpTuNgay.Value = dtpDenNgay.Value = DateTime.Now;
        }

        private void nbNam_ValueChanged(object sender, EventArgs e)
        {
            if (nbNam.Value > DateTime.Now.Year)
            {
                nbNam.Value = Convert.ToInt32(DateTime.Now.Year);
            }
        }
        public void loadChartKhachHang()
        {
            // Load chartKhachHang
            DevExpress.XtraCharts.Series _seri = new DevExpress.XtraCharts.Series(CONSTANTS_THONGKE.CUSTOMMER, ViewType.Pie);
            var KhachHangDaMua = ThongKe_KhachHangBUS.SoLuongKhachHangDaMuaHang();
            var KhachHangChuaMua = ThongKe_KhachHangBUS.SoLuongKhachHangChuaMuaHang();
            _seri.Points.Add(new SeriesPoint(CONSTANTS_THONGKE.BOUGHT_CUSTOMMER, KhachHangDaMua));
            _seri.Points.Add(new SeriesPoint(CONSTANTS_THONGKE.DONT_BOUGHT_CUSTOMMER, KhachHangChuaMua));
            _seri.Label.TextPattern = CONSTANTS_THONGKE.DESIGN_PARTTEN;
            chartKhachHang.Series.Add(_seri);

            // Thiết lập tiêu đề cho biểu đồ
            chartKhachHang.Titles.Add(new ChartTitle() { Text = CONSTANTS_THONGKE.KH_CHART_NAME });

            //// Thiết lập màu sắc cho chuỗi dữ liệu
            //_seri.View.ColorPaletteName = "NatureColors";
            //_seri.View.ColorModel.BaseColor = Color.FromArgb(150, 0, 150);

            // Thiết lập các thuộc tính khác cho biểu đồ
            chartKhachHang.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartKhachHang.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            chartKhachHang.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            chartKhachHang.Legend.Direction = LegendDirection.LeftToRight;
            chartKhachHang.Legend.MarkerSize = new Size(20, 20);
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;

            rptSanPhamBanChay rpt = new rptSanPhamBanChay();
            var result = ThongKeBUS.MatHangBanChayNhat(fromDate, toDate);
            rpt.DataSource = result;
            rpt.Parameters[CONSTANTS_THONGKE.START].Value = dtpFrom.Value;
            rpt.Parameters[CONSTANTS_THONGKE.END].Value = dtpTo.Value;
            rpt.RequestParameters = false;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnBaoCaoKhachHang_Click(object sender, EventArgs e)
        {
            
            if (radThongKeTheoNgay.Checked == true)
            {
                DateTime TuNgay = dtpTuNgay.Value;
                DateTime DenNgay = dtpDenNgay.Value;
                rptKhachHangMuaNhieuTheoNgay rpt = new rptKhachHangMuaNhieuTheoNgay();
                var result = ThongKe_KhachHangBUS.KhachHangMuaNhieu(TuNgay, DenNgay);
                rpt.DataSource = result;
                rpt.RequestParameters = false;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else if (radThongKeTheoNam.Checked == true)
            {
                int nam = (int)nbNam.Value;
                rptKhachHangMuaNhieuTheoNam rpt = new rptKhachHangMuaNhieuTheoNam();
                var result = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoNam(nam);
                rpt.DataSource = result;
                rpt.RequestParameters = false;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();

            }
            else if (radThongKeTheoQuy.Checked == true)
            {
                if (cboMua.SelectedIndex == 0)
                {
                    rptKhachHangMuaNhieuTheoQuy rpt = new rptKhachHangMuaNhieuTheoQuy();
                    var result =  ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoQuy(1);
                    rpt.DataSource = result;
                    rpt.RequestParameters = false;
                    ReportPrintTool print = new ReportPrintTool(rpt);
                    print.ShowPreviewDialog();
                }
                else if (cboMua.SelectedIndex == 1)
                {
                    rptKhachHangMuaNhieuTheoQuy rpt = new rptKhachHangMuaNhieuTheoQuy();
                    var result = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoQuy(2);
                    rpt.DataSource = result;
                    rpt.RequestParameters = false;
                    ReportPrintTool print = new ReportPrintTool(rpt);
                    print.ShowPreviewDialog();
                }
                else if (cboMua.SelectedIndex == 2)
                {
                    rptKhachHangMuaNhieuTheoQuy rpt = new rptKhachHangMuaNhieuTheoQuy();
                    var result = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoQuy(3);
                    rpt.DataSource = result;
                    rpt.RequestParameters = false;
                    ReportPrintTool print = new ReportPrintTool(rpt);
                    print.ShowPreviewDialog();
                }
                else if (cboMua.SelectedIndex == 3)
                {
                    rptKhachHangMuaNhieuTheoQuy rpt = new rptKhachHangMuaNhieuTheoQuy();
                    var result = ThongKe_KhachHangBUS.KhachHangMuaNhieuTheoQuy(4);
                    rpt.DataSource = result;
                    rpt.RequestParameters = false;
                    ReportPrintTool print = new ReportPrintTool(rpt);
                    print.ShowPreviewDialog();
                }
            }
        }
    }
}
