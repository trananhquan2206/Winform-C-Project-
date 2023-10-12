namespace Fut.KhachHang
{
    partial class frmNha_Cung_Cap
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
            this.dgvQuanLyNCC = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpChucNangNCC = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.grpTimKiem = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTimKiemNCC = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBoLocNCC = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyNCC)).BeginInit();
            this.grpChucNangNCC.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuanLyNCC
            // 
            this.dgvQuanLyNCC.AllowUserToAddRows = false;
            this.dgvQuanLyNCC.AllowUserToDeleteRows = false;
            this.dgvQuanLyNCC.AllowUserToResizeColumns = false;
            this.dgvQuanLyNCC.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvQuanLyNCC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuanLyNCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuanLyNCC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQuanLyNCC.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.dgvQuanLyNCC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyNCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuanLyNCC.ColumnHeadersHeight = 25;
            this.dgvQuanLyNCC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNCC,
            this.colTenNCC,
            this.colSoDH,
            this.colTongTien_db});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuanLyNCC.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQuanLyNCC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQuanLyNCC.Location = new System.Drawing.Point(45, 365);
            this.dgvQuanLyNCC.Name = "dgvQuanLyNCC";
            this.dgvQuanLyNCC.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyNCC.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvQuanLyNCC.RowHeadersVisible = false;
            this.dgvQuanLyNCC.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvQuanLyNCC.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvQuanLyNCC.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvQuanLyNCC.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvQuanLyNCC.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvQuanLyNCC.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvQuanLyNCC.RowTemplate.Height = 24;
            this.dgvQuanLyNCC.Size = new System.Drawing.Size(1185, 436);
            this.dgvQuanLyNCC.TabIndex = 6;
            this.dgvQuanLyNCC.TabStop = false;
            this.dgvQuanLyNCC.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuanLyNCC.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvQuanLyNCC.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvQuanLyNCC.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvQuanLyNCC.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvQuanLyNCC.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.dgvQuanLyNCC.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQuanLyNCC.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvQuanLyNCC.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQuanLyNCC.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQuanLyNCC.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvQuanLyNCC.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvQuanLyNCC.ThemeStyle.HeaderStyle.Height = 25;
            this.dgvQuanLyNCC.ThemeStyle.ReadOnly = true;
            this.dgvQuanLyNCC.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuanLyNCC.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvQuanLyNCC.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQuanLyNCC.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvQuanLyNCC.ThemeStyle.RowsStyle.Height = 24;
            this.dgvQuanLyNCC.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQuanLyNCC.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colMaNCC
            // 
            this.colMaNCC.DataPropertyName = "MaNCC";
            this.colMaNCC.HeaderText = "Mã nhà cung cấp";
            this.colMaNCC.MinimumWidth = 6;
            this.colMaNCC.Name = "colMaNCC";
            this.colMaNCC.ReadOnly = true;
            this.colMaNCC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTenNCC
            // 
            this.colTenNCC.DataPropertyName = "TenNCC";
            this.colTenNCC.HeaderText = "Tên nhà cung cấp";
            this.colTenNCC.MinimumWidth = 6;
            this.colTenNCC.Name = "colTenNCC";
            this.colTenNCC.ReadOnly = true;
            // 
            // colSoDH
            // 
            this.colSoDH.DataPropertyName = "SoDonHang";
            this.colSoDH.HeaderText = "Số đơn hàng";
            this.colSoDH.MinimumWidth = 6;
            this.colSoDH.Name = "colSoDH";
            this.colSoDH.ReadOnly = true;
            // 
            // colTongTien_db
            // 
            this.colTongTien_db.DataPropertyName = "TongTien";
            this.colTongTien_db.HeaderText = "Tổng tiền";
            this.colTongTien_db.MinimumWidth = 6;
            this.colTongTien_db.Name = "colTongTien_db";
            this.colTongTien_db.ReadOnly = true;
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
            this.grpChucNangNCC.TabIndex = 29;
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
            // grpTimKiem
            // 
            this.grpTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.grpTimKiem.BorderColor = System.Drawing.Color.White;
            this.grpTimKiem.Controls.Add(this.label5);
            this.grpTimKiem.Controls.Add(this.cboTimKiemNCC);
            this.grpTimKiem.Controls.Add(this.dtpTo);
            this.grpTimKiem.Controls.Add(this.dtpFrom);
            this.grpTimKiem.Controls.Add(this.label4);
            this.grpTimKiem.Controls.Add(this.label3);
            this.grpTimKiem.Controls.Add(this.label2);
            this.grpTimKiem.Controls.Add(this.cboBoLocNCC);
            this.grpTimKiem.CustomBorderColor = System.Drawing.Color.White;
            this.grpTimKiem.CustomBorderThickness = new System.Windows.Forms.Padding(0, 34, 0, 0);
            this.grpTimKiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpTimKiem.ForeColor = System.Drawing.Color.DimGray;
            this.grpTimKiem.Location = new System.Drawing.Point(45, 110);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(940, 215);
            this.grpTimKiem.TabIndex = 28;
            this.grpTimKiem.Text = "Tìm Kiếm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(40, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Danh sách:";
            // 
            // cboTimKiemNCC
            // 
            this.cboTimKiemNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.cboTimKiemNCC.BorderColor = System.Drawing.Color.White;
            this.cboTimKiemNCC.BorderRadius = 7;
            this.cboTimKiemNCC.BorderThickness = 2;
            this.cboTimKiemNCC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTimKiemNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimKiemNCC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.cboTimKiemNCC.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTimKiemNCC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTimKiemNCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTimKiemNCC.ForeColor = System.Drawing.Color.White;
            this.cboTimKiemNCC.ItemHeight = 30;
            this.cboTimKiemNCC.Location = new System.Drawing.Point(135, 70);
            this.cboTimKiemNCC.Name = "cboTimKiemNCC";
            this.cboTimKiemNCC.Size = new System.Drawing.Size(300, 36);
            this.cboTimKiemNCC.TabIndex = 2;
            this.cboTimKiemNCC.SelectedValueChanged += new System.EventHandler(this.cboTimKiemNCC_SelectedValueChanged);
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
            // cboBoLocNCC
            // 
            this.cboBoLocNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.cboBoLocNCC.BorderColor = System.Drawing.Color.White;
            this.cboBoLocNCC.BorderRadius = 7;
            this.cboBoLocNCC.BorderThickness = 2;
            this.cboBoLocNCC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBoLocNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoLocNCC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.cboBoLocNCC.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBoLocNCC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBoLocNCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboBoLocNCC.ForeColor = System.Drawing.Color.White;
            this.cboBoLocNCC.ItemHeight = 30;
            this.cboBoLocNCC.Items.AddRange(new object[] {
            "Mã nhà cung cấp",
            "Tên nhà cung cấp",
            "Tên sản phẩm"});
            this.cboBoLocNCC.Location = new System.Drawing.Point(597, 70);
            this.cboBoLocNCC.Name = "cboBoLocNCC";
            this.cboBoLocNCC.Size = new System.Drawing.Size(300, 36);
            this.cboBoLocNCC.TabIndex = 1;
            this.cboBoLocNCC.SelectedIndexChanged += new System.EventHandler(this.cboBoLocNCC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(455, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 38);
            this.label1.TabIndex = 27;
            this.label1.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            // 
            // frmNha_Cung_Cap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1273, 841);
            this.ControlBox = false;
            this.Controls.Add(this.grpChucNangNCC);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvQuanLyNCC);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmNha_Cung_Cap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmNha_Cung_Cap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyNCC)).EndInit();
            this.grpChucNangNCC.ResumeLayout(false);
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView dgvQuanLyNCC;
        private Guna.UI2.WinForms.Guna2GroupBox grpChucNangNCC;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2GroupBox grpTimKiem;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cboBoLocNCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private Guna.UI2.WinForms.Guna2ComboBox cboTimKiemNCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien_db;
    }
}