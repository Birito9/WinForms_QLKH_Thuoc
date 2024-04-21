namespace FormQLKH
{
    partial class UC_QLNhomThuoc
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tlpQLNT = new TableLayoutPanel();
            pnQLNT = new Panel();
            lbQLNT = new Label();
            grbQLNT_TK = new GroupBox();
            grbQLNT_TT = new GroupBox();
            pnlQLNT_TK = new Panel();
            btnQLNT_TK = new Button();
            txtQLNT_TK_TenNhom = new TextBox();
            cbQLNT_TK_MaNhom = new ComboBox();
            lbQLNT_TK_TenNhom = new Label();
            lbQLNT_TK_MaNhom = new Label();
            btnQLNT_Xoa = new Button();
            btnQLNT_Sua = new Button();
            txtQLNT_GhiChu = new TextBox();
            lbQLNT_MaNhom = new Label();
            btnQLNT_Them = new Button();
            txtQLNT_MaNhom = new TextBox();
            txtQLNT_TenNhom = new TextBox();
            lbQLNT_GhiChu = new Label();
            lbQLNT_TenNhom = new Label();
            splQLNT_TT_TK = new SplitContainer();
            pnlQLNT_HT = new Panel();
            grbQLNT_HT = new GroupBox();
            dgvQLNT = new DataGridView();
            Nhom_ID = new DataGridViewTextBoxColumn();
            Nhom_Name = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            pcbQLNT_CN = new PictureBox();
            tlpQLNT.SuspendLayout();
            pnQLNT.SuspendLayout();
            grbQLNT_TK.SuspendLayout();
            grbQLNT_TT.SuspendLayout();
            pnlQLNT_TK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splQLNT_TT_TK).BeginInit();
            splQLNT_TT_TK.Panel1.SuspendLayout();
            splQLNT_TT_TK.Panel2.SuspendLayout();
            splQLNT_TT_TK.SuspendLayout();
            pnlQLNT_HT.SuspendLayout();
            grbQLNT_HT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQLNT).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbQLNT_CN).BeginInit();
            SuspendLayout();
            // 
            // tlpQLNT
            // 
            tlpQLNT.BackColor = SystemColors.Control;
            tlpQLNT.ColumnCount = 1;
            tlpQLNT.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpQLNT.Controls.Add(splQLNT_TT_TK, 0, 2);
            tlpQLNT.Controls.Add(pnQLNT, 0, 0);
            tlpQLNT.Controls.Add(pnlQLNT_HT, 0, 1);
            tlpQLNT.Dock = DockStyle.Fill;
            tlpQLNT.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            tlpQLNT.Location = new Point(0, 0);
            tlpQLNT.Name = "tlpQLNT";
            tlpQLNT.RowCount = 3;
            tlpQLNT.RowStyles.Add(new RowStyle(SizeType.Percent, 11.4666662F));
            tlpQLNT.RowStyles.Add(new RowStyle(SizeType.Percent, 88.53333F));
            tlpQLNT.RowStyles.Add(new RowStyle(SizeType.Absolute, 586F));
            tlpQLNT.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpQLNT.Size = new Size(1448, 1337);
            tlpQLNT.TabIndex = 1;
            // 
            // pnQLNT
            // 
            pnQLNT.BackColor = Color.FromArgb(15, 142, 219);
            pnQLNT.Controls.Add(lbQLNT);
            pnQLNT.Dock = DockStyle.Fill;
            pnQLNT.Location = new Point(3, 3);
            pnQLNT.Name = "pnQLNT";
            pnQLNT.Size = new Size(1442, 80);
            pnQLNT.TabIndex = 0;
            // 
            // lbQLNT
            // 
            lbQLNT.AutoSize = true;
            lbQLNT.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNT.ForeColor = SystemColors.ButtonHighlight;
            lbQLNT.Location = new Point(514, 19);
            lbQLNT.Name = "lbQLNT";
            lbQLNT.Size = new Size(449, 50);
            lbQLNT.TabIndex = 0;
            lbQLNT.Text = "QUẢN LÝ NHÓM THUỐC";
            lbQLNT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grbQLNT_TK
            // 
            grbQLNT_TK.Controls.Add(txtQLNT_GhiChu);
            grbQLNT_TK.Controls.Add(lbQLNT_MaNhom);
            grbQLNT_TK.Controls.Add(txtQLNT_MaNhom);
            grbQLNT_TK.Controls.Add(txtQLNT_TenNhom);
            grbQLNT_TK.Controls.Add(lbQLNT_GhiChu);
            grbQLNT_TK.Controls.Add(lbQLNT_TenNhom);
            grbQLNT_TK.Dock = DockStyle.Left;
            grbQLNT_TK.Location = new Point(0, 0);
            grbQLNT_TK.Name = "grbQLNT_TK";
            grbQLNT_TK.Size = new Size(963, 327);
            grbQLNT_TK.TabIndex = 0;
            grbQLNT_TK.TabStop = false;
            grbQLNT_TK.Text = "Thông tin";
            // 
            // grbQLNT_TT
            // 
            grbQLNT_TT.Controls.Add(pnlQLNT_TK);
            grbQLNT_TT.Controls.Add(cbQLNT_TK_MaNhom);
            grbQLNT_TT.Controls.Add(lbQLNT_TK_TenNhom);
            grbQLNT_TT.Controls.Add(lbQLNT_TK_MaNhom);
            grbQLNT_TT.Dock = DockStyle.Right;
            grbQLNT_TT.Location = new Point(969, 0);
            grbQLNT_TT.Name = "grbQLNT_TT";
            grbQLNT_TT.Size = new Size(473, 327);
            grbQLNT_TT.TabIndex = 9;
            grbQLNT_TT.TabStop = false;
            grbQLNT_TT.Text = "Tìm kiếm";
            // 
            // pnlQLNT_TK
            // 
            pnlQLNT_TK.Controls.Add(btnQLNT_TK);
            pnlQLNT_TK.Controls.Add(txtQLNT_TK_TenNhom);
            pnlQLNT_TK.Location = new Point(189, 184);
            pnlQLNT_TK.Name = "pnlQLNT_TK";
            pnlQLNT_TK.Size = new Size(234, 119);
            pnlQLNT_TK.TabIndex = 9;
            // 
            // btnQLNT_TK
            // 
            btnQLNT_TK.BackColor = Color.WhiteSmoke;
            btnQLNT_TK.Dock = DockStyle.Right;
            btnQLNT_TK.FlatStyle = FlatStyle.Popup;
            btnQLNT_TK.Image = Properties.Resources.glass;
            btnQLNT_TK.Location = new Point(185, 0);
            btnQLNT_TK.Name = "btnQLNT_TK";
            btnQLNT_TK.Size = new Size(49, 119);
            btnQLNT_TK.TabIndex = 10;
            btnQLNT_TK.UseVisualStyleBackColor = false;
            // 
            // txtQLNT_TK_TenNhom
            // 
            txtQLNT_TK_TenNhom.Dock = DockStyle.Left;
            txtQLNT_TK_TenNhom.Location = new Point(0, 0);
            txtQLNT_TK_TenNhom.Multiline = true;
            txtQLNT_TK_TenNhom.Name = "txtQLNT_TK_TenNhom";
            txtQLNT_TK_TenNhom.ScrollBars = ScrollBars.Vertical;
            txtQLNT_TK_TenNhom.Size = new Size(186, 119);
            txtQLNT_TK_TenNhom.TabIndex = 8;
            // 
            // cbQLNT_TK_MaNhom
            // 
            cbQLNT_TK_MaNhom.FormattingEnabled = true;
            cbQLNT_TK_MaNhom.Location = new Point(189, 64);
            cbQLNT_TK_MaNhom.Name = "cbQLNT_TK_MaNhom";
            cbQLNT_TK_MaNhom.Size = new Size(233, 45);
            cbQLNT_TK_MaNhom.TabIndex = 6;
            // 
            // lbQLNT_TK_TenNhom
            // 
            lbQLNT_TK_TenNhom.AutoSize = true;
            lbQLNT_TK_TenNhom.BackColor = SystemColors.Control;
            lbQLNT_TK_TenNhom.BorderStyle = BorderStyle.Fixed3D;
            lbQLNT_TK_TenNhom.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNT_TK_TenNhom.Location = new Point(24, 196);
            lbQLNT_TK_TenNhom.Name = "lbQLNT_TK_TenNhom";
            lbQLNT_TK_TenNhom.Size = new Size(140, 39);
            lbQLNT_TK_TenNhom.TabIndex = 5;
            lbQLNT_TK_TenNhom.Text = "Tên nhóm";
            // 
            // lbQLNT_TK_MaNhom
            // 
            lbQLNT_TK_MaNhom.AutoSize = true;
            lbQLNT_TK_MaNhom.BackColor = SystemColors.Control;
            lbQLNT_TK_MaNhom.BorderStyle = BorderStyle.Fixed3D;
            lbQLNT_TK_MaNhom.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNT_TK_MaNhom.Location = new Point(24, 60);
            lbQLNT_TK_MaNhom.Name = "lbQLNT_TK_MaNhom";
            lbQLNT_TK_MaNhom.Size = new Size(137, 39);
            lbQLNT_TK_MaNhom.TabIndex = 4;
            lbQLNT_TK_MaNhom.Text = "Mã nhóm";
            // 
            // btnQLNT_Xoa
            // 
            btnQLNT_Xoa.BackColor = SystemColors.ButtonHighlight;
            btnQLNT_Xoa.FlatAppearance.BorderSize = 0;
            btnQLNT_Xoa.FlatStyle = FlatStyle.Popup;
            btnQLNT_Xoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLNT_Xoa.ForeColor = SystemColors.ControlText;
            btnQLNT_Xoa.Image = Properties.Resources.delete;
            btnQLNT_Xoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLNT_Xoa.Location = new Point(199, 161);
            btnQLNT_Xoa.Name = "btnQLNT_Xoa";
            btnQLNT_Xoa.Size = new Size(142, 64);
            btnQLNT_Xoa.TabIndex = 5;
            btnQLNT_Xoa.Text = "Xóa";
            btnQLNT_Xoa.UseVisualStyleBackColor = false;
            // 
            // btnQLNT_Sua
            // 
            btnQLNT_Sua.BackColor = SystemColors.ButtonHighlight;
            btnQLNT_Sua.FlatAppearance.BorderSize = 0;
            btnQLNT_Sua.FlatStyle = FlatStyle.Popup;
            btnQLNT_Sua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLNT_Sua.ForeColor = SystemColors.ControlText;
            btnQLNT_Sua.Image = Properties.Resources.update;
            btnQLNT_Sua.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLNT_Sua.Location = new Point(348, 69);
            btnQLNT_Sua.Name = "btnQLNT_Sua";
            btnQLNT_Sua.Size = new Size(142, 64);
            btnQLNT_Sua.TabIndex = 5;
            btnQLNT_Sua.Text = "Sửa";
            btnQLNT_Sua.UseVisualStyleBackColor = false;
            // 
            // txtQLNT_GhiChu
            // 
            txtQLNT_GhiChu.Location = new Point(667, 60);
            txtQLNT_GhiChu.Multiline = true;
            txtQLNT_GhiChu.Name = "txtQLNT_GhiChu";
            txtQLNT_GhiChu.Size = new Size(275, 96);
            txtQLNT_GhiChu.TabIndex = 3;
            // 
            // lbQLNT_MaNhom
            // 
            lbQLNT_MaNhom.AutoSize = true;
            lbQLNT_MaNhom.BackColor = SystemColors.Control;
            lbQLNT_MaNhom.BorderStyle = BorderStyle.Fixed3D;
            lbQLNT_MaNhom.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNT_MaNhom.Location = new Point(40, 60);
            lbQLNT_MaNhom.Name = "lbQLNT_MaNhom";
            lbQLNT_MaNhom.Size = new Size(137, 39);
            lbQLNT_MaNhom.TabIndex = 6;
            lbQLNT_MaNhom.Text = "Mã nhóm";
            // 
            // btnQLNT_Them
            // 
            btnQLNT_Them.BackColor = SystemColors.ButtonHighlight;
            btnQLNT_Them.FlatAppearance.BorderSize = 0;
            btnQLNT_Them.FlatStyle = FlatStyle.Popup;
            btnQLNT_Them.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLNT_Them.ForeColor = SystemColors.ControlText;
            btnQLNT_Them.Image = Properties.Resources.add;
            btnQLNT_Them.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLNT_Them.Location = new Point(55, 69);
            btnQLNT_Them.Name = "btnQLNT_Them";
            btnQLNT_Them.Size = new Size(142, 64);
            btnQLNT_Them.TabIndex = 0;
            btnQLNT_Them.Text = "Thêm";
            btnQLNT_Them.UseVisualStyleBackColor = false;
            // 
            // txtQLNT_MaNhom
            // 
            txtQLNT_MaNhom.Location = new Point(199, 60);
            txtQLNT_MaNhom.Name = "txtQLNT_MaNhom";
            txtQLNT_MaNhom.Size = new Size(263, 43);
            txtQLNT_MaNhom.TabIndex = 1;
            // 
            // txtQLNT_TenNhom
            // 
            txtQLNT_TenNhom.Location = new Point(199, 196);
            txtQLNT_TenNhom.Multiline = true;
            txtQLNT_TenNhom.Name = "txtQLNT_TenNhom";
            txtQLNT_TenNhom.Size = new Size(263, 56);
            txtQLNT_TenNhom.TabIndex = 2;
            // 
            // lbQLNT_GhiChu
            // 
            lbQLNT_GhiChu.AutoSize = true;
            lbQLNT_GhiChu.BackColor = SystemColors.Control;
            lbQLNT_GhiChu.BorderStyle = BorderStyle.Fixed3D;
            lbQLNT_GhiChu.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNT_GhiChu.Location = new Point(505, 60);
            lbQLNT_GhiChu.Name = "lbQLNT_GhiChu";
            lbQLNT_GhiChu.Size = new Size(113, 39);
            lbQLNT_GhiChu.TabIndex = 8;
            lbQLNT_GhiChu.Text = "Ghi chú";
            // 
            // lbQLNT_TenNhom
            // 
            lbQLNT_TenNhom.AutoSize = true;
            lbQLNT_TenNhom.BackColor = SystemColors.Control;
            lbQLNT_TenNhom.BorderStyle = BorderStyle.Fixed3D;
            lbQLNT_TenNhom.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNT_TenNhom.Location = new Point(38, 199);
            lbQLNT_TenNhom.Name = "lbQLNT_TenNhom";
            lbQLNT_TenNhom.Size = new Size(140, 39);
            lbQLNT_TenNhom.TabIndex = 7;
            lbQLNT_TenNhom.Text = "Tên nhóm";
            // 
            // splQLNT_TT_TK
            // 
            splQLNT_TT_TK.BackColor = Color.Transparent;
            splQLNT_TT_TK.BackgroundImage = Properties.Resources.bg;
            splQLNT_TT_TK.Dock = DockStyle.Fill;
            splQLNT_TT_TK.Location = new Point(3, 753);
            splQLNT_TT_TK.Name = "splQLNT_TT_TK";
            splQLNT_TT_TK.Orientation = Orientation.Horizontal;
            // 
            // splQLNT_TT_TK.Panel1
            // 
            splQLNT_TT_TK.Panel1.Controls.Add(grbQLNT_TT);
            splQLNT_TT_TK.Panel1.Controls.Add(grbQLNT_TK);
            // 
            // splQLNT_TT_TK.Panel2
            // 
            splQLNT_TT_TK.Panel2.Controls.Add(pcbQLNT_CN);
            splQLNT_TT_TK.Panel2.Controls.Add(groupBox1);
            splQLNT_TT_TK.Size = new Size(1442, 581);
            splQLNT_TT_TK.SplitterDistance = 327;
            splQLNT_TT_TK.TabIndex = 3;
            // 
            // pnlQLNT_HT
            // 
            pnlQLNT_HT.Controls.Add(grbQLNT_HT);
            pnlQLNT_HT.Dock = DockStyle.Fill;
            pnlQLNT_HT.Location = new Point(3, 89);
            pnlQLNT_HT.Name = "pnlQLNT_HT";
            pnlQLNT_HT.Size = new Size(1442, 658);
            pnlQLNT_HT.TabIndex = 4;
            // 
            // grbQLNT_HT
            // 
            grbQLNT_HT.Controls.Add(dgvQLNT);
            grbQLNT_HT.Dock = DockStyle.Fill;
            grbQLNT_HT.Location = new Point(0, 0);
            grbQLNT_HT.Name = "grbQLNT_HT";
            grbQLNT_HT.Size = new Size(1442, 658);
            grbQLNT_HT.TabIndex = 1;
            grbQLNT_HT.TabStop = false;
            grbQLNT_HT.Text = "Hiển thị";
            // 
            // dgvQLNT
            // 
            dgvQLNT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQLNT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvQLNT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvQLNT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQLNT.Columns.AddRange(new DataGridViewColumn[] { Nhom_ID, Nhom_Name, Description });
            dgvQLNT.Dock = DockStyle.Fill;
            dgvQLNT.Location = new Point(3, 39);
            dgvQLNT.Name = "dgvQLNT";
            dgvQLNT.RowHeadersWidth = 82;
            dgvQLNT.RowTemplate.Height = 41;
            dgvQLNT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQLNT.Size = new Size(1436, 616);
            dgvQLNT.TabIndex = 0;
            // 
            // Nhom_ID
            // 
            Nhom_ID.DataPropertyName = "Nhom_ID";
            Nhom_ID.HeaderText = "Mã nhóm thuốc";
            Nhom_ID.MinimumWidth = 10;
            Nhom_ID.Name = "Nhom_ID";
            // 
            // Nhom_Name
            // 
            Nhom_Name.DataPropertyName = "Nhom_Name";
            Nhom_Name.HeaderText = "Tên nhóm thuốc";
            Nhom_Name.MinimumWidth = 10;
            Nhom_Name.Name = "Nhom_Name";
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Ghi chú";
            Description.MinimumWidth = 10;
            Description.Name = "Description";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnQLNT_Xoa);
            groupBox1.Controls.Add(btnQLNT_Sua);
            groupBox1.Controls.Add(btnQLNT_Them);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(538, 250);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // pcbQLNT_CN
            // 
            pcbQLNT_CN.Dock = DockStyle.Fill;
            pcbQLNT_CN.Image = Properties.Resources.bgNgang;
            pcbQLNT_CN.Location = new Point(538, 0);
            pcbQLNT_CN.Name = "pcbQLNT_CN";
            pcbQLNT_CN.Size = new Size(904, 250);
            pcbQLNT_CN.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbQLNT_CN.TabIndex = 1;
            pcbQLNT_CN.TabStop = false;
            // 
            // UC_QLNhomThuoc
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpQLNT);
            Name = "UC_QLNhomThuoc";
            Size = new Size(1448, 1337);
            tlpQLNT.ResumeLayout(false);
            pnQLNT.ResumeLayout(false);
            pnQLNT.PerformLayout();
            grbQLNT_TK.ResumeLayout(false);
            grbQLNT_TK.PerformLayout();
            grbQLNT_TT.ResumeLayout(false);
            grbQLNT_TT.PerformLayout();
            pnlQLNT_TK.ResumeLayout(false);
            pnlQLNT_TK.PerformLayout();
            splQLNT_TT_TK.Panel1.ResumeLayout(false);
            splQLNT_TT_TK.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splQLNT_TT_TK).EndInit();
            splQLNT_TT_TK.ResumeLayout(false);
            pnlQLNT_HT.ResumeLayout(false);
            grbQLNT_HT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQLNT).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcbQLNT_CN).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpQLNT;
        private Panel pnQLNT;
        private Label lbQLNT;
        private SplitContainer splQLNT_TT_TK;
        private GroupBox grbQLNT_TK;
        private GroupBox grbQLNT_TT;
        private Panel pnlQLNT_TK;
        private Button btnQLNT_TK;
        private TextBox txtQLNT_TK_TenNhom;
        private ComboBox cbQLNT_TK_MaNhom;
        private Label lbQLNT_TK_TenNhom;
        private Label lbQLNT_TK_MaNhom;
        private Button btnQLNT_Xoa;
        private Button btnQLNT_Sua;
        private TextBox txtQLNT_GhiChu;
        private Label lbQLNT_MaNhom;
        private Button btnQLNT_Them;
        private TextBox txtQLNT_MaNhom;
        private TextBox txtQLNT_TenNhom;
        private Label lbQLNT_GhiChu;
        private Label lbQLNT_TenNhom;
        private Panel pnlQLNT_HT;
        private GroupBox grbQLNT_HT;
        private DataGridView dgvQLNT;
        private DataGridViewTextBoxColumn Nhom_ID;
        private DataGridViewTextBoxColumn Nhom_Name;
        private DataGridViewTextBoxColumn Description;
        private GroupBox groupBox1;
        private PictureBox pcbQLNT_CN;
    }
}
