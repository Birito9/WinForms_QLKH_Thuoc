namespace FormQLKH
{
    partial class UC_NCC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tlpNCC = new TableLayoutPanel();
            pnNCC = new Panel();
            lbNCC = new Label();
            splNCC_TK_TT = new SplitContainer();
            grbNCC_TK = new GroupBox();
            pnNCC_TK = new Panel();
            btnNCC_TK = new Button();
            txtNCC_TK_TenNCC = new TextBox();
            cbNCC_TK_MaNCC = new ComboBox();
            lbNCC_TK_TenNCC = new Label();
            lbNCC_TK_MaNCC = new Label();
            grbNCC_TT = new GroupBox();
            cbNCC_TrangThai = new ComboBox();
            lbNCC_TrangThai = new Label();
            txtNCC_DiaChi = new TextBox();
            txtNCC_SDT = new TextBox();
            txtNCC_TenNCC = new TextBox();
            txtNCC_MaNCC = new TextBox();
            lbNCC_DiaChi = new Label();
            lbNCC_SDT = new Label();
            lbNCC_TenNCC = new Label();
            lbNCC_MaNCC = new Label();
            pnlNCC_CN = new Panel();
            pictureBox1 = new PictureBox();
            grbNCC_CN = new GroupBox();
            btnNCC_Sua = new Button();
            btnNCC_Them = new Button();
            pnlNCC_HT = new Panel();
            grbNCC_HT = new GroupBox();
            dgvNCC = new DataGridView();
            NCC_ID = new DataGridViewTextBoxColumn();
            NCC_Name = new DataGridViewTextBoxColumn();
            NCC_Phone = new DataGridViewTextBoxColumn();
            NCC_Address = new DataGridViewTextBoxColumn();
            NCC_Status = new DataGridViewTextBoxColumn();
            tlpNCC.SuspendLayout();
            pnNCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splNCC_TK_TT).BeginInit();
            splNCC_TK_TT.Panel1.SuspendLayout();
            splNCC_TK_TT.Panel2.SuspendLayout();
            splNCC_TK_TT.SuspendLayout();
            grbNCC_TK.SuspendLayout();
            pnNCC_TK.SuspendLayout();
            grbNCC_TT.SuspendLayout();
            pnlNCC_CN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grbNCC_CN.SuspendLayout();
            pnlNCC_HT.SuspendLayout();
            grbNCC_HT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNCC).BeginInit();
            SuspendLayout();
            // 
            // tlpNCC
            // 
            tlpNCC.BackColor = Color.Transparent;
            tlpNCC.BackgroundImage = Properties.Resources.bg;
            tlpNCC.ColumnCount = 1;
            tlpNCC.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpNCC.Controls.Add(pnNCC, 0, 0);
            tlpNCC.Controls.Add(splNCC_TK_TT, 0, 2);
            tlpNCC.Controls.Add(pnlNCC_CN, 0, 3);
            tlpNCC.Controls.Add(pnlNCC_HT, 0, 1);
            tlpNCC.Dock = DockStyle.Fill;
            tlpNCC.Location = new Point(0, 0);
            tlpNCC.Name = "tlpNCC";
            tlpNCC.RowCount = 4;
            tlpNCC.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            tlpNCC.RowStyles.Add(new RowStyle(SizeType.Absolute, 665F));
            tlpNCC.RowStyles.Add(new RowStyle(SizeType.Absolute, 330F));
            tlpNCC.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tlpNCC.Size = new Size(1448, 1337);
            tlpNCC.TabIndex = 1;
            // 
            // pnNCC
            // 
            pnNCC.BackColor = Color.FromArgb(15, 142, 219);
            pnNCC.Controls.Add(lbNCC);
            pnNCC.Dock = DockStyle.Fill;
            pnNCC.Location = new Point(3, 3);
            pnNCC.Name = "pnNCC";
            pnNCC.Size = new Size(1442, 77);
            pnNCC.TabIndex = 0;
            // 
            // lbNCC
            // 
            lbNCC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbNCC.AutoSize = true;
            lbNCC.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lbNCC.ForeColor = SystemColors.ButtonHighlight;
            lbNCC.Location = new Point(484, 15);
            lbNCC.Name = "lbNCC";
            lbNCC.Size = new Size(471, 50);
            lbNCC.TabIndex = 0;
            lbNCC.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            // 
            // splNCC_TK_TT
            // 
            splNCC_TK_TT.BackColor = Color.Transparent;
            splNCC_TK_TT.Dock = DockStyle.Top;
            splNCC_TK_TT.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            splNCC_TK_TT.Location = new Point(3, 751);
            splNCC_TK_TT.Name = "splNCC_TK_TT";
            // 
            // splNCC_TK_TT.Panel1
            // 
            splNCC_TK_TT.Panel1.Controls.Add(grbNCC_TK);
            // 
            // splNCC_TK_TT.Panel2
            // 
            splNCC_TK_TT.Panel2.Controls.Add(grbNCC_TT);
            splNCC_TK_TT.Size = new Size(1442, 324);
            splNCC_TK_TT.SplitterDistance = 488;
            splNCC_TK_TT.TabIndex = 2;
            // 
            // grbNCC_TK
            // 
            grbNCC_TK.Controls.Add(pnNCC_TK);
            grbNCC_TK.Controls.Add(cbNCC_TK_MaNCC);
            grbNCC_TK.Controls.Add(lbNCC_TK_TenNCC);
            grbNCC_TK.Controls.Add(lbNCC_TK_MaNCC);
            grbNCC_TK.Dock = DockStyle.Fill;
            grbNCC_TK.Location = new Point(0, 0);
            grbNCC_TK.Name = "grbNCC_TK";
            grbNCC_TK.Size = new Size(488, 324);
            grbNCC_TK.TabIndex = 0;
            grbNCC_TK.TabStop = false;
            grbNCC_TK.Text = "Tìm kiếm";
            // 
            // pnNCC_TK
            // 
            pnNCC_TK.Controls.Add(btnNCC_TK);
            pnNCC_TK.Controls.Add(txtNCC_TK_TenNCC);
            pnNCC_TK.Location = new Point(182, 189);
            pnNCC_TK.Name = "pnNCC_TK";
            pnNCC_TK.Size = new Size(266, 117);
            pnNCC_TK.TabIndex = 11;
            // 
            // btnNCC_TK
            // 
            btnNCC_TK.BackColor = Color.WhiteSmoke;
            btnNCC_TK.Dock = DockStyle.Right;
            btnNCC_TK.FlatStyle = FlatStyle.Popup;
            btnNCC_TK.Image = Properties.Resources.glass;
            btnNCC_TK.Location = new Point(218, 0);
            btnNCC_TK.Name = "btnNCC_TK";
            btnNCC_TK.Size = new Size(48, 117);
            btnNCC_TK.TabIndex = 4;
            btnNCC_TK.UseVisualStyleBackColor = false;
            btnNCC_TK.Click += btnNCC_TK_Click;
            // 
            // txtNCC_TK_TenNCC
            // 
            txtNCC_TK_TenNCC.Dock = DockStyle.Left;
            txtNCC_TK_TenNCC.Location = new Point(0, 0);
            txtNCC_TK_TenNCC.Multiline = true;
            txtNCC_TK_TenNCC.Name = "txtNCC_TK_TenNCC";
            txtNCC_TK_TenNCC.ScrollBars = ScrollBars.Vertical;
            txtNCC_TK_TenNCC.Size = new Size(219, 117);
            txtNCC_TK_TenNCC.TabIndex = 3;
            txtNCC_TK_TenNCC.KeyUp += txtNCC_TK_TenNCC_KeyUp;
            // 
            // cbNCC_TK_MaNCC
            // 
            cbNCC_TK_MaNCC.FormattingEnabled = true;
            cbNCC_TK_MaNCC.Location = new Point(182, 79);
            cbNCC_TK_MaNCC.Name = "cbNCC_TK_MaNCC";
            cbNCC_TK_MaNCC.Size = new Size(266, 45);
            cbNCC_TK_MaNCC.TabIndex = 10;
            cbNCC_TK_MaNCC.SelectedIndexChanged += cbNCC_TK_MaNCC_SelectedIndexChanged;
            // 
            // lbNCC_TK_TenNCC
            // 
            lbNCC_TK_TenNCC.AutoSize = true;
            lbNCC_TK_TenNCC.BackColor = SystemColors.Control;
            lbNCC_TK_TenNCC.BorderStyle = BorderStyle.Fixed3D;
            lbNCC_TK_TenNCC.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbNCC_TK_TenNCC.Location = new Point(27, 200);
            lbNCC_TK_TenNCC.Name = "lbNCC_TK_TenNCC";
            lbNCC_TK_TenNCC.Size = new Size(122, 39);
            lbNCC_TK_TenNCC.TabIndex = 5;
            lbNCC_TK_TenNCC.Text = "Tên NCC";
            // 
            // lbNCC_TK_MaNCC
            // 
            lbNCC_TK_MaNCC.AutoSize = true;
            lbNCC_TK_MaNCC.BackColor = SystemColors.Control;
            lbNCC_TK_MaNCC.BorderStyle = BorderStyle.Fixed3D;
            lbNCC_TK_MaNCC.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbNCC_TK_MaNCC.Location = new Point(27, 82);
            lbNCC_TK_MaNCC.Name = "lbNCC_TK_MaNCC";
            lbNCC_TK_MaNCC.Size = new Size(119, 39);
            lbNCC_TK_MaNCC.TabIndex = 4;
            lbNCC_TK_MaNCC.Text = "Mã NCC";
            // 
            // grbNCC_TT
            // 
            grbNCC_TT.Controls.Add(cbNCC_TrangThai);
            grbNCC_TT.Controls.Add(lbNCC_TrangThai);
            grbNCC_TT.Controls.Add(txtNCC_DiaChi);
            grbNCC_TT.Controls.Add(txtNCC_SDT);
            grbNCC_TT.Controls.Add(txtNCC_TenNCC);
            grbNCC_TT.Controls.Add(txtNCC_MaNCC);
            grbNCC_TT.Controls.Add(lbNCC_DiaChi);
            grbNCC_TT.Controls.Add(lbNCC_SDT);
            grbNCC_TT.Controls.Add(lbNCC_TenNCC);
            grbNCC_TT.Controls.Add(lbNCC_MaNCC);
            grbNCC_TT.Dock = DockStyle.Fill;
            grbNCC_TT.Location = new Point(0, 0);
            grbNCC_TT.Name = "grbNCC_TT";
            grbNCC_TT.Size = new Size(950, 324);
            grbNCC_TT.TabIndex = 0;
            grbNCC_TT.TabStop = false;
            grbNCC_TT.Text = "Thông tin";
            // 
            // cbNCC_TrangThai
            // 
            cbNCC_TrangThai.FormattingEnabled = true;
            cbNCC_TrangThai.Location = new Point(191, 145);
            cbNCC_TrangThai.Name = "cbNCC_TrangThai";
            cbNCC_TrangThai.Size = new Size(250, 45);
            cbNCC_TrangThai.TabIndex = 11;
            // 
            // lbNCC_TrangThai
            // 
            lbNCC_TrangThai.AutoSize = true;
            lbNCC_TrangThai.BackColor = SystemColors.Control;
            lbNCC_TrangThai.BorderStyle = BorderStyle.Fixed3D;
            lbNCC_TrangThai.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbNCC_TrangThai.Location = new Point(23, 149);
            lbNCC_TrangThai.Name = "lbNCC_TrangThai";
            lbNCC_TrangThai.Size = new Size(142, 39);
            lbNCC_TrangThai.TabIndex = 10;
            lbNCC_TrangThai.Text = "Trạng thái";
            // 
            // txtNCC_DiaChi
            // 
            txtNCC_DiaChi.Location = new Point(631, 197);
            txtNCC_DiaChi.Multiline = true;
            txtNCC_DiaChi.Name = "txtNCC_DiaChi";
            txtNCC_DiaChi.Size = new Size(289, 109);
            txtNCC_DiaChi.TabIndex = 8;
            // 
            // txtNCC_SDT
            // 
            txtNCC_SDT.Location = new Point(191, 242);
            txtNCC_SDT.Name = "txtNCC_SDT";
            txtNCC_SDT.Size = new Size(250, 43);
            txtNCC_SDT.TabIndex = 7;
            // 
            // txtNCC_TenNCC
            // 
            txtNCC_TenNCC.Location = new Point(631, 56);
            txtNCC_TenNCC.Multiline = true;
            txtNCC_TenNCC.Name = "txtNCC_TenNCC";
            txtNCC_TenNCC.Size = new Size(289, 112);
            txtNCC_TenNCC.TabIndex = 6;
            // 
            // txtNCC_MaNCC
            // 
            txtNCC_MaNCC.Location = new Point(191, 57);
            txtNCC_MaNCC.Name = "txtNCC_MaNCC";
            txtNCC_MaNCC.Size = new Size(250, 43);
            txtNCC_MaNCC.TabIndex = 5;
            // 
            // lbNCC_DiaChi
            // 
            lbNCC_DiaChi.AutoSize = true;
            lbNCC_DiaChi.BackColor = SystemColors.Control;
            lbNCC_DiaChi.BorderStyle = BorderStyle.Fixed3D;
            lbNCC_DiaChi.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbNCC_DiaChi.Location = new Point(485, 200);
            lbNCC_DiaChi.Name = "lbNCC_DiaChi";
            lbNCC_DiaChi.Size = new Size(102, 39);
            lbNCC_DiaChi.TabIndex = 4;
            lbNCC_DiaChi.Text = "Địa chỉ";
            // 
            // lbNCC_SDT
            // 
            lbNCC_SDT.AutoSize = true;
            lbNCC_SDT.BackColor = SystemColors.Control;
            lbNCC_SDT.BorderStyle = BorderStyle.Fixed3D;
            lbNCC_SDT.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbNCC_SDT.Location = new Point(28, 246);
            lbNCC_SDT.Name = "lbNCC_SDT";
            lbNCC_SDT.Size = new Size(68, 39);
            lbNCC_SDT.TabIndex = 2;
            lbNCC_SDT.Text = "SĐT";
            // 
            // lbNCC_TenNCC
            // 
            lbNCC_TenNCC.AutoSize = true;
            lbNCC_TenNCC.BackColor = SystemColors.Control;
            lbNCC_TenNCC.BorderStyle = BorderStyle.Fixed3D;
            lbNCC_TenNCC.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbNCC_TenNCC.Location = new Point(485, 59);
            lbNCC_TenNCC.Name = "lbNCC_TenNCC";
            lbNCC_TenNCC.Size = new Size(122, 39);
            lbNCC_TenNCC.TabIndex = 1;
            lbNCC_TenNCC.Text = "Tên NCC";
            // 
            // lbNCC_MaNCC
            // 
            lbNCC_MaNCC.AutoSize = true;
            lbNCC_MaNCC.BackColor = SystemColors.Control;
            lbNCC_MaNCC.BorderStyle = BorderStyle.Fixed3D;
            lbNCC_MaNCC.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbNCC_MaNCC.Location = new Point(23, 61);
            lbNCC_MaNCC.Name = "lbNCC_MaNCC";
            lbNCC_MaNCC.Size = new Size(119, 39);
            lbNCC_MaNCC.TabIndex = 0;
            lbNCC_MaNCC.Text = "Mã NCC";
            // 
            // pnlNCC_CN
            // 
            pnlNCC_CN.Controls.Add(pictureBox1);
            pnlNCC_CN.Controls.Add(grbNCC_CN);
            pnlNCC_CN.Dock = DockStyle.Fill;
            pnlNCC_CN.Location = new Point(3, 1081);
            pnlNCC_CN.Name = "pnlNCC_CN";
            pnlNCC_CN.Size = new Size(1442, 253);
            pnlNCC_CN.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.bgNgang;
            pictureBox1.Location = new Point(275, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1167, 253);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // grbNCC_CN
            // 
            grbNCC_CN.Controls.Add(btnNCC_Sua);
            grbNCC_CN.Controls.Add(btnNCC_Them);
            grbNCC_CN.Dock = DockStyle.Left;
            grbNCC_CN.Location = new Point(0, 0);
            grbNCC_CN.Margin = new Padding(3, 3, 0, 3);
            grbNCC_CN.Name = "grbNCC_CN";
            grbNCC_CN.Size = new Size(275, 253);
            grbNCC_CN.TabIndex = 1;
            grbNCC_CN.TabStop = false;
            grbNCC_CN.Text = "Chức năng";
            // 
            // btnNCC_Sua
            // 
            btnNCC_Sua.BackColor = SystemColors.ButtonHighlight;
            btnNCC_Sua.FlatAppearance.BorderSize = 0;
            btnNCC_Sua.FlatStyle = FlatStyle.Popup;
            btnNCC_Sua.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnNCC_Sua.Image = Properties.Resources.update;
            btnNCC_Sua.ImageAlign = ContentAlignment.MiddleLeft;
            btnNCC_Sua.Location = new Point(57, 167);
            btnNCC_Sua.Name = "btnNCC_Sua";
            btnNCC_Sua.Size = new Size(148, 58);
            btnNCC_Sua.TabIndex = 1;
            btnNCC_Sua.Text = "Sửa";
            btnNCC_Sua.UseVisualStyleBackColor = false;
            // 
            // btnNCC_Them
            // 
            btnNCC_Them.BackColor = SystemColors.ButtonHighlight;
            btnNCC_Them.FlatAppearance.BorderSize = 0;
            btnNCC_Them.FlatStyle = FlatStyle.Popup;
            btnNCC_Them.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnNCC_Them.Image = Properties.Resources.add;
            btnNCC_Them.ImageAlign = ContentAlignment.MiddleLeft;
            btnNCC_Them.Location = new Point(57, 61);
            btnNCC_Them.Name = "btnNCC_Them";
            btnNCC_Them.Size = new Size(148, 58);
            btnNCC_Them.TabIndex = 0;
            btnNCC_Them.Text = "Thêm";
            btnNCC_Them.UseVisualStyleBackColor = false;
            // 
            // pnlNCC_HT
            // 
            pnlNCC_HT.Controls.Add(grbNCC_HT);
            pnlNCC_HT.Dock = DockStyle.Fill;
            pnlNCC_HT.Location = new Point(3, 86);
            pnlNCC_HT.Name = "pnlNCC_HT";
            pnlNCC_HT.Size = new Size(1442, 659);
            pnlNCC_HT.TabIndex = 4;
            // 
            // grbNCC_HT
            // 
            grbNCC_HT.Controls.Add(dgvNCC);
            grbNCC_HT.Dock = DockStyle.Fill;
            grbNCC_HT.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            grbNCC_HT.Location = new Point(0, 0);
            grbNCC_HT.Name = "grbNCC_HT";
            grbNCC_HT.Padding = new Padding(3, 10, 3, 3);
            grbNCC_HT.Size = new Size(1442, 659);
            grbNCC_HT.TabIndex = 3;
            grbNCC_HT.TabStop = false;
            grbNCC_HT.Text = "Hiển thị";
            // 
            // dgvNCC
            // 
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNCC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNCC.Columns.AddRange(new DataGridViewColumn[] { NCC_ID, NCC_Name, NCC_Phone, NCC_Address, NCC_Status });
            dgvNCC.Dock = DockStyle.Fill;
            dgvNCC.Location = new Point(3, 46);
            dgvNCC.Name = "dgvNCC";
            dgvNCC.RowHeadersWidth = 82;
            dgvNCC.RowTemplate.Height = 41;
            dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNCC.Size = new Size(1436, 610);
            dgvNCC.TabIndex = 0;
            // 
            // NCC_ID
            // 
            NCC_ID.DataPropertyName = "NCC_ID";
            NCC_ID.HeaderText = "Mã NCC";
            NCC_ID.MinimumWidth = 10;
            NCC_ID.Name = "NCC_ID";
            // 
            // NCC_Name
            // 
            NCC_Name.DataPropertyName = "NCC_Name";
            NCC_Name.HeaderText = "Tên NCC";
            NCC_Name.MinimumWidth = 10;
            NCC_Name.Name = "NCC_Name";
            // 
            // NCC_Phone
            // 
            NCC_Phone.DataPropertyName = "NCC_Phone";
            NCC_Phone.HeaderText = "SĐT";
            NCC_Phone.MinimumWidth = 10;
            NCC_Phone.Name = "NCC_Phone";
            // 
            // NCC_Address
            // 
            NCC_Address.DataPropertyName = "NCC_Address";
            NCC_Address.HeaderText = "Địa chỉ";
            NCC_Address.MinimumWidth = 10;
            NCC_Address.Name = "NCC_Address";
            // 
            // NCC_Status
            // 
            NCC_Status.DataPropertyName = "NCC_Status";
            NCC_Status.HeaderText = "Trạng thái ";
            NCC_Status.MinimumWidth = 10;
            NCC_Status.Name = "NCC_Status";
            NCC_Status.Resizable = DataGridViewTriState.True;
            // 
            // UC_NCC
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpNCC);
            Name = "UC_NCC";
            Size = new Size(1448, 1337);
            tlpNCC.ResumeLayout(false);
            pnNCC.ResumeLayout(false);
            pnNCC.PerformLayout();
            splNCC_TK_TT.Panel1.ResumeLayout(false);
            splNCC_TK_TT.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splNCC_TK_TT).EndInit();
            splNCC_TK_TT.ResumeLayout(false);
            grbNCC_TK.ResumeLayout(false);
            grbNCC_TK.PerformLayout();
            pnNCC_TK.ResumeLayout(false);
            pnNCC_TK.PerformLayout();
            grbNCC_TT.ResumeLayout(false);
            grbNCC_TT.PerformLayout();
            pnlNCC_CN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grbNCC_CN.ResumeLayout(false);
            pnlNCC_HT.ResumeLayout(false);
            grbNCC_HT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNCC).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpNCC;
        private Panel pnNCC;
        private Label lbNCC;
        private SplitContainer splNCC_TK_TT;
        private GroupBox grbNCC_TK;
        private TextBox txtNCC_TK_TenNCC;
        private GroupBox grbNCC_TT;
        private TextBox txtNCC_DiaChi;
        private TextBox txtNCC_SDT;
        private TextBox txtNCC_TenNCC;
        private TextBox txtNCC_MaNCC;
        private Label lbNCC_DiaChi;
        private Label lbNCC_SDT;
        private Label lbNCC_TenNCC;
        private Label lbNCC_MaNCC;
        private Label lbNCC_TK_TenNCC;
        private Label lbNCC_TK_MaNCC;
        private ComboBox cbNCC_TK_MaNCC;
        private Panel pnNCC_TK;
        private Button btnNCC_TK;
        private Label lbNCC_TrangThai;
        private ComboBox cbNCC_TrangThai;
        private Panel pnlNCC_CN;
        private GroupBox grbNCC_CN;
        private Button btnNCC_Sua;
        private Button btnNCC_Them;
        private Panel pnlNCC_HT;
        private GroupBox grbNCC_HT;
        private DataGridView dgvNCC;
        private DataGridViewTextBoxColumn NCC_ID;
        private DataGridViewTextBoxColumn NCC_Name;
        private DataGridViewTextBoxColumn NCC_Phone;
        private DataGridViewTextBoxColumn NCC_Address;
        private DataGridViewTextBoxColumn NCC_Status;
        private PictureBox pictureBox1;
    }
}
