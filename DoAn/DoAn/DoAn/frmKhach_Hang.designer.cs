namespace Fut.KhachHang
{
    partial class frmKhach_Hang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpChucNangNCC = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.grpThongTinNCC = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTimKiemKH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBoLocKH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvQuanLyKH = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKH_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpChucNangNCC.SuspendLayout();
            this.grpThongTinNCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyKH)).BeginInit();
            this.SuspendLayout();
            // 
            // grpChucNangNCC
            // 
            this.grpChucNangNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.grpChucNangNCC.BorderColor = System.Drawing.Color.White;
            this.grpChucNangNCC.Controls.Add(this.btnLamMoi);
            this.grpChucNangNCC.CustomBorderColor = System.Drawing.Color.White;
            this.grpChucNangNCC.CustomBorderThickness = new System.Windows.Forms.Padding(0, 34, 0, 0);
            this.grpChucNangNCC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.grpChucNangNCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpChucNangNCC.ForeColor = System.Drawing.Color.DimGray;
            this.grpChucNangNCC.Location = new System.Drawing.Point(1030, 110);
            this.grpChucNangNCC.Name = "grpChucNangNCC";
            this.grpChucNangNCC.Size = new System.Drawing.Size(200, 215);
            this.grpChucNangNCC.TabIndex = 26;
            this.grpChucNangNCC.Text = "Chức Năng";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.btnLamMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLamMoi.BorderRadius = 7;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(35)))));
            this.btnLamMoi.Image = global::DoAn.Properties.Resources.reset;
            this.btnLamMoi.ImageSize = new System.Drawing.Size(45, 45);
            this.btnLamMoi.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btnLamMoi.IndicateFocus = true;
            this.btnLamMoi.Location = new System.Drawing.Point(77, 95);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(50, 50);
            this.btnLamMoi.TabIndex = 5;
            this.toolTip.SetToolTip(this.btnLamMoi, "Làm mới");
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // grpThongTinNCC
            // 
            this.grpThongTinNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.grpThongTinNCC.BorderColor = System.Drawing.Color.White;
            this.grpThongTinNCC.Controls.Add(this.label5);
            this.grpThongTinNCC.Controls.Add(this.cboTimKiemKH);
            this.grpThongTinNCC.Controls.Add(this.dtpTo);
            this.grpThongTinNCC.Controls.Add(this.dtpFrom);
            this.grpThongTinNCC.Controls.Add(this.label4);
            this.grpThongTinNCC.Controls.Add(this.label3);
            this.grpThongTinNCC.Controls.Add(this.label2);
            this.grpThongTinNCC.Controls.Add(this.cboBoLocKH);
            this.grpThongTinNCC.CustomBorderColor = System.Drawing.Color.White;
            this.grpThongTinNCC.CustomBorderThickness = new System.Windows.Forms.Padding(0, 34, 0, 0);
            this.grpThongTinNCC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.grpThongTinNCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpThongTinNCC.ForeColor = System.Drawing.Color.DimGray;
            this.grpThongTinNCC.Location = new System.Drawing.Point(45, 110);
            this.grpThongTinNCC.Name = "grpThongTinNCC";
            this.grpThongTinNCC.Size = new System.Drawing.Size(940, 215);
            this.grpThongTinNCC.TabIndex = 25;
            this.grpThongTinNCC.Text = "Tìm Kiếm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(40, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "Danh sách:";
            // 
            // cboTimKiemKH
            // 
            this.cboTimKiemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.cboTimKiemKH.BorderColor = System.Drawing.Color.White;
            this.cboTimKiemKH.BorderRadius = 7;
            this.cboTimKiemKH.BorderThickness = 2;
            this.cboTimKiemKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTimKiemKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimKiemKH.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.cboTimKiemKH.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTimKiemKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTimKiemKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTimKiemKH.ForeColor = System.Drawing.Color.White;
            this.cboTimKiemKH.ItemHeight = 30;
            this.cboTimKiemKH.Location = new System.Drawing.Point(135, 70);
            this.cboTimKiemKH.Name = "cboTimKiemKH";
            this.cboTimKiemKH.Size = new System.Drawing.Size(300, 36);
            this.cboTimKiemKH.TabIndex = 2;
            this.cboTimKiemKH.SelectedValueChanged += new System.EventHandler(this.cboTimKiemKH_SelectedValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.BorderColor = System.Drawing.Color.White;
            this.dtpTo.BorderRadius = 7;
            this.dtpTo.BorderThickness = 2;
            this.dtpTo.Checked = true;
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.ForeColor = System.Drawing.Color.White;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(597, 140);
            this.dtpTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(300, 40);
            this.dtpTo.TabIndex = 4;
            this.dtpTo.Value = new System.DateTime(2023, 4, 3, 14, 40, 57, 687);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.BorderColor = System.Drawing.Color.White;
            this.dtpFrom.BorderRadius = 7;
            this.dtpFrom.BorderThickness = 2;
            this.dtpFrom.Checked = true;
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.ForeColor = System.Drawing.Color.White;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(135, 140);
            this.dtpFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(300, 40);
            this.dtpFrom.TabIndex = 3;
            this.dtpFrom.Value = new System.DateTime(2023, 4, 3, 14, 40, 57, 687);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(485, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Đến ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(485, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tìm kiếm theo:";
            // 
            // cboBoLocKH
            // 
            this.cboBoLocKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.cboBoLocKH.BorderColor = System.Drawing.Color.White;
            this.cboBoLocKH.BorderRadius = 7;
            this.cboBoLocKH.BorderThickness = 2;
            this.cboBoLocKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBoLocKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoLocKH.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.cboBoLocKH.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBoLocKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBoLocKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboBoLocKH.ForeColor = System.Drawing.Color.White;
            this.cboBoLocKH.ItemHeight = 30;
            this.cboBoLocKH.Items.AddRange(new object[] {
            "Mã khách hàng",
            "Tên khách hàng",
            "Giới tính"});
            this.cboBoLocKH.Location = new System.Drawing.Point(597, 70);
            this.cboBoLocKH.Name = "cboBoLocKH";
            this.cboBoLocKH.Size = new System.Drawing.Size(300, 36);
            this.cboBoLocKH.TabIndex = 1;
            this.cboBoLocKH.SelectedIndexChanged += new System.EventHandler(this.cboBoLocKH_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(480, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 38);
            this.label1.TabIndex = 21;
            this.label1.Text = "QUẢN LÝ KHÁCH HÀNG\r\n";
            // 
            // dgvQuanLyKH
            // 
            this.dgvQuanLyKH.AllowUserToAddRows = false;
            this.dgvQuanLyKH.AllowUserToDeleteRows = false;
            this.dgvQuanLyKH.AllowUserToResizeColumns = false;
            this.dgvQuanLyKH.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvQuanLyKH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuanLyKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuanLyKH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQuanLyKH.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.dgvQuanLyKH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyKH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuanLyKH.ColumnHeadersHeight = 25;
            this.dgvQuanLyKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKH,
            this.colTenKH_db,
            this.colSoDH,
            this.colTongTien_db});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuanLyKH.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQuanLyKH.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQuanLyKH.Location = new System.Drawing.Point(45, 365);
            this.dgvQuanLyKH.Name = "dgvQuanLyKH";
            this.dgvQuanLyKH.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyKH.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvQuanLyKH.RowHeadersVisible = false;
            this.dgvQuanLyKH.RowHeadersWidth = 51;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvQuanLyKH.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvQuanLyKH.RowTemplate.Height = 24;
            this.dgvQuanLyKH.Size = new System.Drawing.Size(1185, 436);
            this.dgvQuanLyKH.TabIndex = 6;
            this.dgvQuanLyKH.TabStop = false;
            this.dgvQuanLyKH.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuanLyKH.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvQuanLyKH.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvQuanLyKH.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvQuanLyKH.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvQuanLyKH.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.dgvQuanLyKH.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQuanLyKH.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvQuanLyKH.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQuanLyKH.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQuanLyKH.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvQuanLyKH.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvQuanLyKH.ThemeStyle.HeaderStyle.Height = 25;
            this.dgvQuanLyKH.ThemeStyle.ReadOnly = true;
            this.dgvQuanLyKH.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuanLyKH.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvQuanLyKH.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQuanLyKH.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvQuanLyKH.ThemeStyle.RowsStyle.Height = 24;
            this.dgvQuanLyKH.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQuanLyKH.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colMaKH
            // 
            this.colMaKH.DataPropertyName = "MaKH";
            this.colMaKH.HeaderText = "Mã khách hàng";
            this.colMaKH.MinimumWidth = 6;
            this.colMaKH.Name = "colMaKH";
            this.colMaKH.ReadOnly = true;
            this.colMaKH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTenKH_db
            // 
            this.colTenKH_db.DataPropertyName = "TenKH";
            this.colTenKH_db.HeaderText = "Tên khách hàng";
            this.colTenKH_db.MinimumWidth = 6;
            this.colTenKH_db.Name = "colTenKH_db";
            this.colTenKH_db.ReadOnly = true;
            // 
            // colSoDH
            // 
            this.colSoDH.DataPropertyName = "SoDonHang";
            this.colSoDH.HeaderText = "Số đơn hàng";
            this.colSoDH.MinimumWidth = 6;
            this.colSoDH.Name = "colSoDH";
            this.colSoDH.ReadOnly = true;
            this.colSoDH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTongTien_db
            // 
            this.colTongTien_db.DataPropertyName = "TongTien";
            this.colTongTien_db.HeaderText = "Tổng tiền";
            this.colTongTien_db.MinimumWidth = 6;
            this.colTongTien_db.Name = "colTongTien_db";
            this.colTongTien_db.ReadOnly = true;
            // 
            // frmKhach_Hang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1273, 841);
            this.ControlBox = false;
            this.Controls.Add(this.grpChucNangNCC);
            this.Controls.Add(this.grpThongTinNCC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvQuanLyKH);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "frmKhach_Hang";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmKhach_Hang_Load);
            this.grpChucNangNCC.ResumeLayout(false);
            this.grpThongTinNCC.ResumeLayout(false);
            this.grpThongTinNCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox grpChucNangNCC;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2GroupBox grpThongTinNCC;
        private Guna.UI2.WinForms.Guna2ComboBox cboBoLocKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvQuanLyKH;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cboTimKiemKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKH_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien_db;
    }
}