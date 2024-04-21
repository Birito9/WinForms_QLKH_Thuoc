namespace FormQLKH
{
    partial class UC_QLTaiKhoan
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
            tlpQLTK = new TableLayoutPanel();
            splQLTK_TTTK_CN = new SplitContainer();
            splQLTK_TT_TK = new SplitContainer();
            grbQLTK_TT = new GroupBox();
            cbQLTK_RoleID = new ComboBox();
            txtQLTK_GhiChu = new TextBox();
            txtQLTK_Password = new TextBox();
            txtQLTK_UserName = new TextBox();
            txtQLTK_UserID = new TextBox();
            lbQLTK_Password = new Label();
            lbQLTK_GhiChu = new Label();
            lbQLTK_UserName = new Label();
            lbQLTK_RoleID = new Label();
            lbQLTK_UserID = new Label();
            grbQLTK_TK = new GroupBox();
            cbQLTK_TK_UserID = new ComboBox();
            cbQLTK_TK_RoleID = new ComboBox();
            lbQLTK_TK_UserID = new Label();
            lbQLTK_TK_RoleID = new Label();
            grbQLTK_CN = new GroupBox();
            btnQLTK_Xoa = new Button();
            btnQLTK_Sua = new Button();
            btnQLTK_Them = new Button();
            grbQLTK_HT = new GroupBox();
            dgvQLTK = new DataGridView();
            UserID = new DataGridViewTextBoxColumn();
            RoleID = new DataGridViewTextBoxColumn();
            UserName = new DataGridViewTextBoxColumn();
            GhiChu = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            pnQLTK = new Panel();
            lbQLTK = new Label();
            tlpQLTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splQLTK_TTTK_CN).BeginInit();
            splQLTK_TTTK_CN.Panel1.SuspendLayout();
            splQLTK_TTTK_CN.Panel2.SuspendLayout();
            splQLTK_TTTK_CN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splQLTK_TT_TK).BeginInit();
            splQLTK_TT_TK.Panel1.SuspendLayout();
            splQLTK_TT_TK.Panel2.SuspendLayout();
            splQLTK_TT_TK.SuspendLayout();
            grbQLTK_TT.SuspendLayout();
            grbQLTK_TK.SuspendLayout();
            grbQLTK_CN.SuspendLayout();
            grbQLTK_HT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQLTK).BeginInit();
            pnQLTK.SuspendLayout();
            SuspendLayout();
            // 
            // tlpQLTK
            // 
            tlpQLTK.BackColor = Color.Transparent;
            tlpQLTK.BackgroundImage = Properties.Resources.bg;
            tlpQLTK.ColumnCount = 1;
            tlpQLTK.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpQLTK.Controls.Add(splQLTK_TTTK_CN, 0, 2);
            tlpQLTK.Controls.Add(grbQLTK_HT, 0, 1);
            tlpQLTK.Controls.Add(pnQLTK, 0, 0);
            tlpQLTK.Dock = DockStyle.Fill;
            tlpQLTK.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            tlpQLTK.Location = new Point(0, 0);
            tlpQLTK.Name = "tlpQLTK";
            tlpQLTK.RowCount = 3;
            tlpQLTK.RowStyles.Add(new RowStyle(SizeType.Absolute, 93F));
            tlpQLTK.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpQLTK.RowStyles.Add(new RowStyle());
            tlpQLTK.Size = new Size(1448, 1337);
            tlpQLTK.TabIndex = 1;
            // 
            // splQLTK_TTTK_CN
            // 
            splQLTK_TTTK_CN.Dock = DockStyle.Fill;
            splQLTK_TTTK_CN.Location = new Point(3, 799);
            splQLTK_TTTK_CN.Name = "splQLTK_TTTK_CN";
            // 
            // splQLTK_TTTK_CN.Panel1
            // 
            splQLTK_TTTK_CN.Panel1.Controls.Add(splQLTK_TT_TK);
            // 
            // splQLTK_TTTK_CN.Panel2
            // 
            splQLTK_TTTK_CN.Panel2.Controls.Add(grbQLTK_CN);
            splQLTK_TTTK_CN.Size = new Size(1442, 535);
            splQLTK_TTTK_CN.SplitterDistance = 1190;
            splQLTK_TTTK_CN.TabIndex = 4;
            // 
            // splQLTK_TT_TK
            // 
            splQLTK_TT_TK.BackColor = Color.Transparent;
            splQLTK_TT_TK.Dock = DockStyle.Fill;
            splQLTK_TT_TK.Location = new Point(0, 0);
            splQLTK_TT_TK.Name = "splQLTK_TT_TK";
            splQLTK_TT_TK.Orientation = Orientation.Horizontal;
            // 
            // splQLTK_TT_TK.Panel1
            // 
            splQLTK_TT_TK.Panel1.Controls.Add(grbQLTK_TT);
            // 
            // splQLTK_TT_TK.Panel2
            // 
            splQLTK_TT_TK.Panel2.Controls.Add(grbQLTK_TK);
            splQLTK_TT_TK.Size = new Size(1190, 535);
            splQLTK_TT_TK.SplitterDistance = 338;
            splQLTK_TT_TK.TabIndex = 0;
            // 
            // grbQLTK_TT
            // 
            grbQLTK_TT.Controls.Add(cbQLTK_RoleID);
            grbQLTK_TT.Controls.Add(txtQLTK_GhiChu);
            grbQLTK_TT.Controls.Add(txtQLTK_Password);
            grbQLTK_TT.Controls.Add(txtQLTK_UserName);
            grbQLTK_TT.Controls.Add(txtQLTK_UserID);
            grbQLTK_TT.Controls.Add(lbQLTK_Password);
            grbQLTK_TT.Controls.Add(lbQLTK_GhiChu);
            grbQLTK_TT.Controls.Add(lbQLTK_UserName);
            grbQLTK_TT.Controls.Add(lbQLTK_RoleID);
            grbQLTK_TT.Controls.Add(lbQLTK_UserID);
            grbQLTK_TT.Dock = DockStyle.Fill;
            grbQLTK_TT.Location = new Point(0, 0);
            grbQLTK_TT.Name = "grbQLTK_TT";
            grbQLTK_TT.Size = new Size(1190, 338);
            grbQLTK_TT.TabIndex = 2;
            grbQLTK_TT.TabStop = false;
            grbQLTK_TT.Text = "Thông tin";
            // 
            // cbQLTK_RoleID
            // 
            cbQLTK_RoleID.FormattingEnabled = true;
            cbQLTK_RoleID.Location = new Point(209, 148);
            cbQLTK_RoleID.Name = "cbQLTK_RoleID";
            cbQLTK_RoleID.Size = new Size(329, 45);
            cbQLTK_RoleID.TabIndex = 12;
            // 
            // txtQLTK_GhiChu
            // 
            txtQLTK_GhiChu.Location = new Point(737, 156);
            txtQLTK_GhiChu.Multiline = true;
            txtQLTK_GhiChu.Name = "txtQLTK_GhiChu";
            txtQLTK_GhiChu.Size = new Size(388, 151);
            txtQLTK_GhiChu.TabIndex = 11;
            // 
            // txtQLTK_Password
            // 
            txtQLTK_Password.Location = new Point(737, 47);
            txtQLTK_Password.Multiline = true;
            txtQLTK_Password.Name = "txtQLTK_Password";
            txtQLTK_Password.Size = new Size(388, 55);
            txtQLTK_Password.TabIndex = 10;
            txtQLTK_Password.KeyPress += txtQLTK_Password_KeyPress;
            // 
            // txtQLTK_UserName
            // 
            txtQLTK_UserName.Location = new Point(206, 243);
            txtQLTK_UserName.Multiline = true;
            txtQLTK_UserName.Name = "txtQLTK_UserName";
            txtQLTK_UserName.Size = new Size(332, 61);
            txtQLTK_UserName.TabIndex = 9;
            // 
            // txtQLTK_UserID
            // 
            txtQLTK_UserID.Location = new Point(206, 53);
            txtQLTK_UserID.Name = "txtQLTK_UserID";
            txtQLTK_UserID.Size = new Size(332, 43);
            txtQLTK_UserID.TabIndex = 6;
            // 
            // lbQLTK_Password
            // 
            lbQLTK_Password.AutoSize = true;
            lbQLTK_Password.BackColor = SystemColors.Control;
            lbQLTK_Password.BorderStyle = BorderStyle.Fixed3D;
            lbQLTK_Password.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLTK_Password.Location = new Point(580, 50);
            lbQLTK_Password.Name = "lbQLTK_Password";
            lbQLTK_Password.Size = new Size(134, 39);
            lbQLTK_Password.TabIndex = 5;
            lbQLTK_Password.Text = "Password";
            // 
            // lbQLTK_GhiChu
            // 
            lbQLTK_GhiChu.AutoSize = true;
            lbQLTK_GhiChu.BackColor = SystemColors.Control;
            lbQLTK_GhiChu.BorderStyle = BorderStyle.Fixed3D;
            lbQLTK_GhiChu.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLTK_GhiChu.Location = new Point(580, 156);
            lbQLTK_GhiChu.Name = "lbQLTK_GhiChu";
            lbQLTK_GhiChu.Size = new Size(113, 39);
            lbQLTK_GhiChu.TabIndex = 4;
            lbQLTK_GhiChu.Text = "Ghi chú";
            // 
            // lbQLTK_UserName
            // 
            lbQLTK_UserName.AutoSize = true;
            lbQLTK_UserName.BackColor = SystemColors.Control;
            lbQLTK_UserName.BorderStyle = BorderStyle.Fixed3D;
            lbQLTK_UserName.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLTK_UserName.Location = new Point(49, 243);
            lbQLTK_UserName.Name = "lbQLTK_UserName";
            lbQLTK_UserName.Size = new Size(147, 39);
            lbQLTK_UserName.TabIndex = 3;
            lbQLTK_UserName.Text = "UserName";
            // 
            // lbQLTK_RoleID
            // 
            lbQLTK_RoleID.AutoSize = true;
            lbQLTK_RoleID.BackColor = SystemColors.Control;
            lbQLTK_RoleID.BorderStyle = BorderStyle.Fixed3D;
            lbQLTK_RoleID.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLTK_RoleID.Location = new Point(49, 144);
            lbQLTK_RoleID.Name = "lbQLTK_RoleID";
            lbQLTK_RoleID.Size = new Size(99, 39);
            lbQLTK_RoleID.TabIndex = 2;
            lbQLTK_RoleID.Text = "RoleID";
            // 
            // lbQLTK_UserID
            // 
            lbQLTK_UserID.AutoSize = true;
            lbQLTK_UserID.BackColor = SystemColors.Control;
            lbQLTK_UserID.BorderStyle = BorderStyle.Fixed3D;
            lbQLTK_UserID.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLTK_UserID.Location = new Point(49, 50);
            lbQLTK_UserID.Name = "lbQLTK_UserID";
            lbQLTK_UserID.Size = new Size(101, 39);
            lbQLTK_UserID.TabIndex = 0;
            lbQLTK_UserID.Text = "UserID";
            // 
            // grbQLTK_TK
            // 
            grbQLTK_TK.Controls.Add(cbQLTK_TK_UserID);
            grbQLTK_TK.Controls.Add(cbQLTK_TK_RoleID);
            grbQLTK_TK.Controls.Add(lbQLTK_TK_UserID);
            grbQLTK_TK.Controls.Add(lbQLTK_TK_RoleID);
            grbQLTK_TK.Dock = DockStyle.Fill;
            grbQLTK_TK.Location = new Point(0, 0);
            grbQLTK_TK.Name = "grbQLTK_TK";
            grbQLTK_TK.Size = new Size(1190, 193);
            grbQLTK_TK.TabIndex = 5;
            grbQLTK_TK.TabStop = false;
            grbQLTK_TK.Text = "Tìm kiếm";
            // 
            // cbQLTK_TK_UserID
            // 
            cbQLTK_TK_UserID.FormattingEnabled = true;
            cbQLTK_TK_UserID.Location = new Point(49, 126);
            cbQLTK_TK_UserID.Name = "cbQLTK_TK_UserID";
            cbQLTK_TK_UserID.Size = new Size(442, 45);
            cbQLTK_TK_UserID.TabIndex = 14;
            cbQLTK_TK_UserID.SelectedIndexChanged += cbQLTK_TK_UserID_SelectedIndexChanged;
            // 
            // cbQLTK_TK_RoleID
            // 
            cbQLTK_TK_RoleID.FormattingEnabled = true;
            cbQLTK_TK_RoleID.Location = new Point(618, 126);
            cbQLTK_TK_RoleID.Name = "cbQLTK_TK_RoleID";
            cbQLTK_TK_RoleID.Size = new Size(442, 45);
            cbQLTK_TK_RoleID.TabIndex = 13;
            cbQLTK_TK_RoleID.SelectedIndexChanged += cbQLTK_TK_RoleID_SelectedIndexChanged;
            // 
            // lbQLTK_TK_UserID
            // 
            lbQLTK_TK_UserID.AutoSize = true;
            lbQLTK_TK_UserID.BackColor = SystemColors.Control;
            lbQLTK_TK_UserID.BorderStyle = BorderStyle.Fixed3D;
            lbQLTK_TK_UserID.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLTK_TK_UserID.Location = new Point(49, 62);
            lbQLTK_TK_UserID.Name = "lbQLTK_TK_UserID";
            lbQLTK_TK_UserID.Size = new Size(101, 39);
            lbQLTK_TK_UserID.TabIndex = 10;
            lbQLTK_TK_UserID.Text = "UserID";
            // 
            // lbQLTK_TK_RoleID
            // 
            lbQLTK_TK_RoleID.AutoSize = true;
            lbQLTK_TK_RoleID.BackColor = SystemColors.Control;
            lbQLTK_TK_RoleID.BorderStyle = BorderStyle.Fixed3D;
            lbQLTK_TK_RoleID.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLTK_TK_RoleID.Location = new Point(618, 62);
            lbQLTK_TK_RoleID.Name = "lbQLTK_TK_RoleID";
            lbQLTK_TK_RoleID.Size = new Size(99, 39);
            lbQLTK_TK_RoleID.TabIndex = 9;
            lbQLTK_TK_RoleID.Text = "RoleID";
            // 
            // grbQLTK_CN
            // 
            grbQLTK_CN.Controls.Add(btnQLTK_Xoa);
            grbQLTK_CN.Controls.Add(btnQLTK_Sua);
            grbQLTK_CN.Controls.Add(btnQLTK_Them);
            grbQLTK_CN.Location = new Point(0, 0);
            grbQLTK_CN.Name = "grbQLTK_CN";
            grbQLTK_CN.Size = new Size(242, 535);
            grbQLTK_CN.TabIndex = 0;
            grbQLTK_CN.TabStop = false;
            grbQLTK_CN.Text = "Chức năng";
            // 
            // btnQLTK_Xoa
            // 
            btnQLTK_Xoa.BackColor = SystemColors.ButtonHighlight;
            btnQLTK_Xoa.FlatStyle = FlatStyle.Popup;
            btnQLTK_Xoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLTK_Xoa.Image = Properties.Resources.delete;
            btnQLTK_Xoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLTK_Xoa.Location = new Point(36, 439);
            btnQLTK_Xoa.Name = "btnQLTK_Xoa";
            btnQLTK_Xoa.Size = new Size(169, 64);
            btnQLTK_Xoa.TabIndex = 12;
            btnQLTK_Xoa.Text = "Xóa";
            btnQLTK_Xoa.UseVisualStyleBackColor = false;
            btnQLTK_Xoa.Click += btnQLTK_Xoa_Click;
            // 
            // btnQLTK_Sua
            // 
            btnQLTK_Sua.BackColor = SystemColors.ButtonHighlight;
            btnQLTK_Sua.FlatStyle = FlatStyle.Popup;
            btnQLTK_Sua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLTK_Sua.Image = Properties.Resources.update;
            btnQLTK_Sua.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLTK_Sua.Location = new Point(36, 259);
            btnQLTK_Sua.Name = "btnQLTK_Sua";
            btnQLTK_Sua.Size = new Size(169, 64);
            btnQLTK_Sua.TabIndex = 11;
            btnQLTK_Sua.Text = "Sửa";
            btnQLTK_Sua.UseVisualStyleBackColor = false;
            btnQLTK_Sua.Click += btnQLTK_Sua_Click;
            // 
            // btnQLTK_Them
            // 
            btnQLTK_Them.BackColor = SystemColors.ButtonHighlight;
            btnQLTK_Them.FlatStyle = FlatStyle.Popup;
            btnQLTK_Them.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLTK_Them.Image = Properties.Resources.add;
            btnQLTK_Them.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLTK_Them.Location = new Point(36, 79);
            btnQLTK_Them.Name = "btnQLTK_Them";
            btnQLTK_Them.Size = new Size(169, 64);
            btnQLTK_Them.TabIndex = 10;
            btnQLTK_Them.Text = "Thêm";
            btnQLTK_Them.UseVisualStyleBackColor = false;
            btnQLTK_Them.Click += btnQLTK_Them_Click;
            // 
            // grbQLTK_HT
            // 
            grbQLTK_HT.Controls.Add(dgvQLTK);
            grbQLTK_HT.Dock = DockStyle.Fill;
            grbQLTK_HT.Location = new Point(3, 96);
            grbQLTK_HT.Name = "grbQLTK_HT";
            grbQLTK_HT.Size = new Size(1442, 697);
            grbQLTK_HT.TabIndex = 0;
            grbQLTK_HT.TabStop = false;
            grbQLTK_HT.Text = "Hiển thị";
            // 
            // dgvQLTK
            // 
            dgvQLTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQLTK.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQLTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQLTK.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQLTK.Columns.AddRange(new DataGridViewColumn[] { UserID, RoleID, UserName, GhiChu, Password });
            dgvQLTK.Dock = DockStyle.Fill;
            dgvQLTK.Location = new Point(3, 39);
            dgvQLTK.Name = "dgvQLTK";
            dgvQLTK.RowHeadersWidth = 82;
            dgvQLTK.RowTemplate.Height = 41;
            dgvQLTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQLTK.Size = new Size(1436, 655);
            dgvQLTK.TabIndex = 0;
            dgvQLTK.RowPostPaint += dgvQLTK_RowPostPaint;
            dgvQLTK.SelectionChanged += dgvQLTK_SelectionChanged;
            // 
            // UserID
            // 
            UserID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UserID.DataPropertyName = "UserID";
            UserID.HeaderText = "UserID";
            UserID.MinimumWidth = 10;
            UserID.Name = "UserID";
            // 
            // RoleID
            // 
            RoleID.DataPropertyName = "RoleID";
            RoleID.HeaderText = "RoleID";
            RoleID.MinimumWidth = 10;
            RoleID.Name = "RoleID";
            // 
            // UserName
            // 
            UserName.DataPropertyName = "UserName";
            UserName.HeaderText = "UserName";
            UserName.MinimumWidth = 10;
            UserName.Name = "UserName";
            // 
            // GhiChu
            // 
            GhiChu.DataPropertyName = "Description";
            GhiChu.HeaderText = "Ghi chú";
            GhiChu.MinimumWidth = 10;
            GhiChu.Name = "GhiChu";
            // 
            // Password
            // 
            Password.DataPropertyName = "Password";
            Password.HeaderText = "Password";
            Password.MinimumWidth = 10;
            Password.Name = "Password";
            Password.Visible = false;
            // 
            // pnQLTK
            // 
            pnQLTK.BackColor = Color.FromArgb(15, 142, 219);
            pnQLTK.Controls.Add(lbQLTK);
            pnQLTK.Dock = DockStyle.Fill;
            pnQLTK.Location = new Point(3, 3);
            pnQLTK.Name = "pnQLTK";
            pnQLTK.Size = new Size(1442, 87);
            pnQLTK.TabIndex = 3;
            // 
            // lbQLTK
            // 
            lbQLTK.AutoSize = true;
            lbQLTK.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLTK.ForeColor = SystemColors.ButtonHighlight;
            lbQLTK.Location = new Point(510, 15);
            lbQLTK.Name = "lbQLTK";
            lbQLTK.Size = new Size(394, 50);
            lbQLTK.TabIndex = 0;
            lbQLTK.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // UC_QLTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpQLTK);
            Name = "UC_QLTaiKhoan";
            Size = new Size(1448, 1337);
            tlpQLTK.ResumeLayout(false);
            splQLTK_TTTK_CN.Panel1.ResumeLayout(false);
            splQLTK_TTTK_CN.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splQLTK_TTTK_CN).EndInit();
            splQLTK_TTTK_CN.ResumeLayout(false);
            splQLTK_TT_TK.Panel1.ResumeLayout(false);
            splQLTK_TT_TK.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splQLTK_TT_TK).EndInit();
            splQLTK_TT_TK.ResumeLayout(false);
            grbQLTK_TT.ResumeLayout(false);
            grbQLTK_TT.PerformLayout();
            grbQLTK_TK.ResumeLayout(false);
            grbQLTK_TK.PerformLayout();
            grbQLTK_CN.ResumeLayout(false);
            grbQLTK_HT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQLTK).EndInit();
            pnQLTK.ResumeLayout(false);
            pnQLTK.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpQLTK;
        private GroupBox grbQLTK_HT;
        private DataGridView dgvQLTK;
        private Panel pnQLTK;
        private Label lbQLTK;
        private SplitContainer splQLTK_TTTK_CN;
        private SplitContainer splQLTK_TT_TK;
        private GroupBox grbQLTK_TT;
        private TextBox txtQLTK_GhiChu;
        private TextBox txtQLTK_Password;
        private TextBox txtQLTK_UserName;
        private TextBox txtQLTK_UserID;
        private Label lbQLTK_Password;
        private Label lbQLTK_GhiChu;
        private Label lbQLTK_UserName;
        private Label lbQLTK_RoleID;
        private Label lbQLTK_UserID;
        private GroupBox grbQLTK_CN;
        private Button btnQLTK_Xoa;
        private Button btnQLTK_Sua;
        private Button btnQLTK_Them;
        private ComboBox cbQLTK_RoleID;
        private GroupBox grbQLTK_TK;
        private ComboBox cbQLTK_TK_RoleID;
        private Label lbQLTK_TK_UserID;
        private Label lbQLTK_TK_RoleID;
        private ComboBox cbQLTK_TK_UserID;
        private DataGridViewTextBoxColumn UserID;
        private DataGridViewTextBoxColumn RoleID;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn GhiChu;
        private DataGridViewTextBoxColumn Password;
    }
}
