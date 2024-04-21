namespace FormQLKH
{
    partial class UC_QLThuoc
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
            tlpQLT = new TableLayoutPanel();
            pnQLT = new Panel();
            lbQLT = new Label();
            splQLT_CN_HT = new SplitContainer();
            grbQLT_TK = new GroupBox();
            btnQLT_Them = new Button();
            btnQLT_Sua = new Button();
            btnQLT_Xoa = new Button();
            grbQLT_HT = new GroupBox();
            dgvQLT = new DataGridView();
            Thuoc_ID = new DataGridViewTextBoxColumn();
            Nhom_ID = new DataGridViewTextBoxColumn();
            Thuoc_Name = new DataGridViewTextBoxColumn();
            pnQLT_TT_CN = new Panel();
            splQLT_TT_TK = new SplitContainer();
            grbQLT_TT = new GroupBox();
            cbQLT_MaNhom = new ComboBox();
            txtQLT_TenThuoc = new TextBox();
            txtQLT_MaThuoc = new TextBox();
            lbQLT_MaNhom = new Label();
            lbQLT_TenThuoc = new Label();
            lbQLT_MaThuoc = new Label();
            grbQLT_CN = new GroupBox();
            linkQLT_CTT = new LinkLabel();
            cbQLT_TK_MaNhom = new ComboBox();
            cbQLT_TK_MaThuoc = new ComboBox();
            lbQLT_TK_MaNhom = new Label();
            lbQLT_TK_MaThuoc = new Label();
            tlpQLT.SuspendLayout();
            pnQLT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splQLT_CN_HT).BeginInit();
            splQLT_CN_HT.Panel1.SuspendLayout();
            splQLT_CN_HT.Panel2.SuspendLayout();
            splQLT_CN_HT.SuspendLayout();
            grbQLT_TK.SuspendLayout();
            grbQLT_HT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQLT).BeginInit();
            pnQLT_TT_CN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splQLT_TT_TK).BeginInit();
            splQLT_TT_TK.Panel1.SuspendLayout();
            splQLT_TT_TK.Panel2.SuspendLayout();
            splQLT_TT_TK.SuspendLayout();
            grbQLT_TT.SuspendLayout();
            grbQLT_CN.SuspendLayout();
            SuspendLayout();
            // 
            // tlpQLT
            // 
            tlpQLT.BackColor = Color.Transparent;
            tlpQLT.ColumnCount = 1;
            tlpQLT.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpQLT.Controls.Add(pnQLT, 0, 0);
            tlpQLT.Controls.Add(splQLT_CN_HT, 0, 1);
            tlpQLT.Controls.Add(pnQLT_TT_CN, 0, 2);
            tlpQLT.Dock = DockStyle.Fill;
            tlpQLT.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            tlpQLT.Location = new Point(0, 0);
            tlpQLT.Name = "tlpQLT";
            tlpQLT.RowCount = 3;
            tlpQLT.RowStyles.Add(new RowStyle(SizeType.Absolute, 79F));
            tlpQLT.RowStyles.Add(new RowStyle(SizeType.Absolute, 942F));
            tlpQLT.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tlpQLT.Size = new Size(1448, 1337);
            tlpQLT.TabIndex = 1;
            // 
            // pnQLT
            // 
            pnQLT.BackColor = Color.FromArgb(15, 142, 219);
            pnQLT.Controls.Add(lbQLT);
            pnQLT.Dock = DockStyle.Fill;
            pnQLT.Location = new Point(3, 3);
            pnQLT.Name = "pnQLT";
            pnQLT.Size = new Size(1442, 73);
            pnQLT.TabIndex = 0;
            // 
            // lbQLT
            // 
            lbQLT.AutoSize = true;
            lbQLT.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLT.ForeColor = SystemColors.ButtonHighlight;
            lbQLT.Location = new Point(582, 15);
            lbQLT.Name = "lbQLT";
            lbQLT.Size = new Size(319, 50);
            lbQLT.TabIndex = 0;
            lbQLT.Text = "QUẢN LÝ THUỐC";
            lbQLT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splQLT_CN_HT
            // 
            splQLT_CN_HT.BackColor = Color.Transparent;
            splQLT_CN_HT.Dock = DockStyle.Fill;
            splQLT_CN_HT.Location = new Point(3, 82);
            splQLT_CN_HT.Name = "splQLT_CN_HT";
            splQLT_CN_HT.Orientation = Orientation.Horizontal;
            // 
            // splQLT_CN_HT.Panel1
            // 
            splQLT_CN_HT.Panel1.Controls.Add(grbQLT_TK);
            // 
            // splQLT_CN_HT.Panel2
            // 
            splQLT_CN_HT.Panel2.Controls.Add(grbQLT_HT);
            splQLT_CN_HT.Size = new Size(1442, 936);
            splQLT_CN_HT.SplitterDistance = 147;
            splQLT_CN_HT.TabIndex = 1;
            // 
            // grbQLT_TK
            // 
            grbQLT_TK.BackColor = Color.Transparent;
            grbQLT_TK.Controls.Add(btnQLT_Them);
            grbQLT_TK.Controls.Add(btnQLT_Sua);
            grbQLT_TK.Controls.Add(btnQLT_Xoa);
            grbQLT_TK.Dock = DockStyle.Fill;
            grbQLT_TK.Location = new Point(0, 0);
            grbQLT_TK.Name = "grbQLT_TK";
            grbQLT_TK.Size = new Size(1442, 147);
            grbQLT_TK.TabIndex = 0;
            grbQLT_TK.TabStop = false;
            grbQLT_TK.Text = "Chức năng";
            // 
            // btnQLT_Them
            // 
            btnQLT_Them.BackColor = SystemColors.ButtonHighlight;
            btnQLT_Them.FlatAppearance.BorderSize = 0;
            btnQLT_Them.FlatStyle = FlatStyle.Popup;
            btnQLT_Them.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLT_Them.ForeColor = SystemColors.ControlText;
            btnQLT_Them.Image = Properties.Resources.add;
            btnQLT_Them.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLT_Them.Location = new Point(56, 54);
            btnQLT_Them.Name = "btnQLT_Them";
            btnQLT_Them.Size = new Size(169, 64);
            btnQLT_Them.TabIndex = 6;
            btnQLT_Them.Text = "Thêm";
            btnQLT_Them.UseVisualStyleBackColor = false;
            btnQLT_Them.Click += btnQLT_Them_Click;
            // 
            // btnQLT_Sua
            // 
            btnQLT_Sua.BackColor = SystemColors.ButtonHighlight;
            btnQLT_Sua.FlatAppearance.BorderSize = 0;
            btnQLT_Sua.FlatStyle = FlatStyle.Popup;
            btnQLT_Sua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLT_Sua.ForeColor = SystemColors.ControlText;
            btnQLT_Sua.Image = Properties.Resources.update;
            btnQLT_Sua.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLT_Sua.Location = new Point(624, 54);
            btnQLT_Sua.Name = "btnQLT_Sua";
            btnQLT_Sua.Size = new Size(169, 64);
            btnQLT_Sua.TabIndex = 11;
            btnQLT_Sua.Text = "Sửa";
            btnQLT_Sua.UseVisualStyleBackColor = false;
            btnQLT_Sua.Click += btnQLT_Sua_Click;
            // 
            // btnQLT_Xoa
            // 
            btnQLT_Xoa.BackColor = SystemColors.ButtonHighlight;
            btnQLT_Xoa.FlatAppearance.BorderSize = 0;
            btnQLT_Xoa.FlatStyle = FlatStyle.Popup;
            btnQLT_Xoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLT_Xoa.ForeColor = SystemColors.ControlText;
            btnQLT_Xoa.Image = Properties.Resources.delete;
            btnQLT_Xoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLT_Xoa.Location = new Point(1217, 54);
            btnQLT_Xoa.Name = "btnQLT_Xoa";
            btnQLT_Xoa.Size = new Size(169, 64);
            btnQLT_Xoa.TabIndex = 7;
            btnQLT_Xoa.Text = "Xóa";
            btnQLT_Xoa.UseVisualStyleBackColor = false;
            btnQLT_Xoa.Click += btnQLT_Xoa_Click;
            // 
            // grbQLT_HT
            // 
            grbQLT_HT.Controls.Add(dgvQLT);
            grbQLT_HT.Dock = DockStyle.Fill;
            grbQLT_HT.Location = new Point(0, 0);
            grbQLT_HT.Name = "grbQLT_HT";
            grbQLT_HT.Size = new Size(1442, 785);
            grbQLT_HT.TabIndex = 0;
            grbQLT_HT.TabStop = false;
            grbQLT_HT.Text = "Hiển thị";
            // 
            // dgvQLT
            // 
            dgvQLT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQLT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQLT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQLT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQLT.Columns.AddRange(new DataGridViewColumn[] { Thuoc_ID, Nhom_ID, Thuoc_Name });
            dgvQLT.Dock = DockStyle.Fill;
            dgvQLT.Location = new Point(3, 39);
            dgvQLT.Name = "dgvQLT";
            dgvQLT.RowHeadersWidth = 82;
            dgvQLT.RowTemplate.Height = 41;
            dgvQLT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQLT.Size = new Size(1436, 743);
            dgvQLT.TabIndex = 0;
            dgvQLT.RowPostPaint += dgvQLT_RowPostPaint;
            dgvQLT.SelectionChanged += dgvQLT_SelectionChanged;
            // 
            // Thuoc_ID
            // 
            Thuoc_ID.DataPropertyName = "Thuoc_ID";
            Thuoc_ID.HeaderText = "Mã thuốc";
            Thuoc_ID.MinimumWidth = 10;
            Thuoc_ID.Name = "Thuoc_ID";
            // 
            // Nhom_ID
            // 
            Nhom_ID.DataPropertyName = "Nhom_ID";
            Nhom_ID.HeaderText = "Mã nhóm thuốc";
            Nhom_ID.MinimumWidth = 10;
            Nhom_ID.Name = "Nhom_ID";
            // 
            // Thuoc_Name
            // 
            Thuoc_Name.DataPropertyName = "Thuoc_Name";
            Thuoc_Name.HeaderText = "Tên thuốc";
            Thuoc_Name.MinimumWidth = 10;
            Thuoc_Name.Name = "Thuoc_Name";
            // 
            // pnQLT_TT_CN
            // 
            pnQLT_TT_CN.Controls.Add(splQLT_TT_TK);
            pnQLT_TT_CN.Dock = DockStyle.Bottom;
            pnQLT_TT_CN.Location = new Point(3, 1024);
            pnQLT_TT_CN.Name = "pnQLT_TT_CN";
            pnQLT_TT_CN.Size = new Size(1442, 310);
            pnQLT_TT_CN.TabIndex = 2;
            // 
            // splQLT_TT_TK
            // 
            splQLT_TT_TK.BackColor = Color.Transparent;
            splQLT_TT_TK.Dock = DockStyle.Fill;
            splQLT_TT_TK.Location = new Point(0, 0);
            splQLT_TT_TK.Name = "splQLT_TT_TK";
            // 
            // splQLT_TT_TK.Panel1
            // 
            splQLT_TT_TK.Panel1.Controls.Add(grbQLT_TT);
            // 
            // splQLT_TT_TK.Panel2
            // 
            splQLT_TT_TK.Panel2.Controls.Add(grbQLT_CN);
            splQLT_TT_TK.Size = new Size(1442, 310);
            splQLT_TT_TK.SplitterDistance = 793;
            splQLT_TT_TK.TabIndex = 3;
            // 
            // grbQLT_TT
            // 
            grbQLT_TT.Controls.Add(cbQLT_MaNhom);
            grbQLT_TT.Controls.Add(txtQLT_TenThuoc);
            grbQLT_TT.Controls.Add(txtQLT_MaThuoc);
            grbQLT_TT.Controls.Add(lbQLT_MaNhom);
            grbQLT_TT.Controls.Add(lbQLT_TenThuoc);
            grbQLT_TT.Controls.Add(lbQLT_MaThuoc);
            grbQLT_TT.Dock = DockStyle.Fill;
            grbQLT_TT.Location = new Point(0, 0);
            grbQLT_TT.Name = "grbQLT_TT";
            grbQLT_TT.Size = new Size(793, 310);
            grbQLT_TT.TabIndex = 0;
            grbQLT_TT.TabStop = false;
            grbQLT_TT.Text = "Thông tin";
            // 
            // cbQLT_MaNhom
            // 
            cbQLT_MaNhom.FormattingEnabled = true;
            cbQLT_MaNhom.Location = new Point(275, 145);
            cbQLT_MaNhom.Name = "cbQLT_MaNhom";
            cbQLT_MaNhom.Size = new Size(264, 45);
            cbQLT_MaNhom.TabIndex = 8;
            // 
            // txtQLT_TenThuoc
            // 
            txtQLT_TenThuoc.Location = new Point(275, 234);
            txtQLT_TenThuoc.Name = "txtQLT_TenThuoc";
            txtQLT_TenThuoc.Size = new Size(425, 43);
            txtQLT_TenThuoc.TabIndex = 7;
            // 
            // txtQLT_MaThuoc
            // 
            txtQLT_MaThuoc.Location = new Point(275, 63);
            txtQLT_MaThuoc.Name = "txtQLT_MaThuoc";
            txtQLT_MaThuoc.Size = new Size(425, 43);
            txtQLT_MaThuoc.TabIndex = 4;
            // 
            // lbQLT_MaNhom
            // 
            lbQLT_MaNhom.AutoSize = true;
            lbQLT_MaNhom.BackColor = SystemColors.Control;
            lbQLT_MaNhom.BorderStyle = BorderStyle.Fixed3D;
            lbQLT_MaNhom.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLT_MaNhom.Location = new Point(35, 148);
            lbQLT_MaNhom.Name = "lbQLT_MaNhom";
            lbQLT_MaNhom.Size = new Size(215, 39);
            lbQLT_MaNhom.TabIndex = 2;
            lbQLT_MaNhom.Text = "Mã nhóm thuốc";
            // 
            // lbQLT_TenThuoc
            // 
            lbQLT_TenThuoc.AutoSize = true;
            lbQLT_TenThuoc.BackColor = SystemColors.Control;
            lbQLT_TenThuoc.BorderStyle = BorderStyle.Fixed3D;
            lbQLT_TenThuoc.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLT_TenThuoc.Location = new Point(35, 233);
            lbQLT_TenThuoc.Name = "lbQLT_TenThuoc";
            lbQLT_TenThuoc.Size = new Size(139, 39);
            lbQLT_TenThuoc.TabIndex = 1;
            lbQLT_TenThuoc.Text = "Tên thuốc";
            // 
            // lbQLT_MaThuoc
            // 
            lbQLT_MaThuoc.AutoSize = true;
            lbQLT_MaThuoc.BackColor = SystemColors.Control;
            lbQLT_MaThuoc.BorderStyle = BorderStyle.Fixed3D;
            lbQLT_MaThuoc.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLT_MaThuoc.Location = new Point(35, 68);
            lbQLT_MaThuoc.Name = "lbQLT_MaThuoc";
            lbQLT_MaThuoc.Size = new Size(136, 39);
            lbQLT_MaThuoc.TabIndex = 0;
            lbQLT_MaThuoc.Text = "Mã thuốc";
            // 
            // grbQLT_CN
            // 
            grbQLT_CN.Controls.Add(linkQLT_CTT);
            grbQLT_CN.Controls.Add(cbQLT_TK_MaNhom);
            grbQLT_CN.Controls.Add(cbQLT_TK_MaThuoc);
            grbQLT_CN.Controls.Add(lbQLT_TK_MaNhom);
            grbQLT_CN.Controls.Add(lbQLT_TK_MaThuoc);
            grbQLT_CN.Dock = DockStyle.Fill;
            grbQLT_CN.Location = new Point(0, 0);
            grbQLT_CN.Name = "grbQLT_CN";
            grbQLT_CN.Size = new Size(645, 310);
            grbQLT_CN.TabIndex = 0;
            grbQLT_CN.TabStop = false;
            grbQLT_CN.Text = "Tìm kiếm";
            // 
            // linkQLT_CTT
            // 
            linkQLT_CTT.AutoSize = true;
            linkQLT_CTT.Location = new Point(359, 259);
            linkQLT_CTT.Name = "linkQLT_CTT";
            linkQLT_CTT.Size = new Size(176, 37);
            linkQLT_CTT.TabIndex = 8;
            linkQLT_CTT.TabStop = true;
            linkQLT_CTT.Text = "Chi tiết thuốc";
            linkQLT_CTT.Click += linkQLT_CTT_Click;
            // 
            // cbQLT_TK_MaNhom
            // 
            cbQLT_TK_MaNhom.FormattingEnabled = true;
            cbQLT_TK_MaNhom.Location = new Point(242, 166);
            cbQLT_TK_MaNhom.Name = "cbQLT_TK_MaNhom";
            cbQLT_TK_MaNhom.Size = new Size(297, 45);
            cbQLT_TK_MaNhom.TabIndex = 7;
            cbQLT_TK_MaNhom.SelectedIndexChanged += cbQLT_TK_MaNhom_SelectedIndexChanged;
            // 
            // cbQLT_TK_MaThuoc
            // 
            cbQLT_TK_MaThuoc.FormattingEnabled = true;
            cbQLT_TK_MaThuoc.Location = new Point(242, 70);
            cbQLT_TK_MaThuoc.Name = "cbQLT_TK_MaThuoc";
            cbQLT_TK_MaThuoc.Size = new Size(297, 45);
            cbQLT_TK_MaThuoc.TabIndex = 6;
            cbQLT_TK_MaThuoc.SelectedIndexChanged += cbQLT_TK_MaThuoc_SelectedIndexChanged;
            // 
            // lbQLT_TK_MaNhom
            // 
            lbQLT_TK_MaNhom.AutoSize = true;
            lbQLT_TK_MaNhom.BackColor = SystemColors.Control;
            lbQLT_TK_MaNhom.BorderStyle = BorderStyle.Fixed3D;
            lbQLT_TK_MaNhom.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLT_TK_MaNhom.Location = new Point(59, 166);
            lbQLT_TK_MaNhom.Name = "lbQLT_TK_MaNhom";
            lbQLT_TK_MaNhom.Size = new Size(137, 39);
            lbQLT_TK_MaNhom.TabIndex = 5;
            lbQLT_TK_MaNhom.Text = "Mã nhóm";
            // 
            // lbQLT_TK_MaThuoc
            // 
            lbQLT_TK_MaThuoc.AutoSize = true;
            lbQLT_TK_MaThuoc.BackColor = SystemColors.Control;
            lbQLT_TK_MaThuoc.BorderStyle = BorderStyle.Fixed3D;
            lbQLT_TK_MaThuoc.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLT_TK_MaThuoc.Location = new Point(59, 69);
            lbQLT_TK_MaThuoc.Name = "lbQLT_TK_MaThuoc";
            lbQLT_TK_MaThuoc.Size = new Size(136, 39);
            lbQLT_TK_MaThuoc.TabIndex = 4;
            lbQLT_TK_MaThuoc.Text = "Mã thuốc";
            // 
            // UC_QLThuoc
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = Properties.Resources.bg;
            Controls.Add(tlpQLT);
            Name = "UC_QLThuoc";
            Size = new Size(1448, 1337);
            tlpQLT.ResumeLayout(false);
            pnQLT.ResumeLayout(false);
            pnQLT.PerformLayout();
            splQLT_CN_HT.Panel1.ResumeLayout(false);
            splQLT_CN_HT.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splQLT_CN_HT).EndInit();
            splQLT_CN_HT.ResumeLayout(false);
            grbQLT_TK.ResumeLayout(false);
            grbQLT_HT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQLT).EndInit();
            pnQLT_TT_CN.ResumeLayout(false);
            splQLT_TT_TK.Panel1.ResumeLayout(false);
            splQLT_TT_TK.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splQLT_TT_TK).EndInit();
            splQLT_TT_TK.ResumeLayout(false);
            grbQLT_TT.ResumeLayout(false);
            grbQLT_TT.PerformLayout();
            grbQLT_CN.ResumeLayout(false);
            grbQLT_CN.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpQLT;
        private Panel pnQLT;
        private Label lbQLT;
        private SplitContainer splQLT_CN_HT;
        private GroupBox grbQLT_TK;
        private GroupBox grbQLT_HT;
        private DataGridView dgvQLT;
        private Panel pnQLT_TT_CN;
        private SplitContainer splQLT_TT_TK;
        private GroupBox grbQLT_TT;
        private TextBox txtQLT_TenThuoc;
        private TextBox txtQLT_MaThuoc;
        private Label lbQLT_MaNhom;
        private Label lbQLT_TenThuoc;
        private Label lbQLT_MaThuoc;
        private GroupBox grbQLT_CN;
        private Button btnQLT_Sua;
        private Button btnQLT_Them;
        private Button btnQLT_Xoa;
        private Label lbQLT_TK_MaNhom;
        private Label lbQLT_TK_MaThuoc;
        private DataGridViewTextBoxColumn Thuoc_ID;
        private DataGridViewTextBoxColumn Nhom_ID;
        private DataGridViewTextBoxColumn Thuoc_Name;
        private ComboBox cbQLT_TK_MaThuoc;
        private ComboBox cbQLT_MaNhom;
        private ComboBox cbQLT_TK_MaNhom;
        private LinkLabel linkQLT_CTT;
    }
}
