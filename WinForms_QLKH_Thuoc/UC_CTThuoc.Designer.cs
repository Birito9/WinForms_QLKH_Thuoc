namespace FormQLKH
{
    partial class UC_CTThuoc
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
            tlpCTT = new TableLayoutPanel();
            pnCTT = new Panel();
            lbCTT = new Label();
            grbCCT_TT = new GroupBox();
            cbCTT_MaLo = new ComboBox();
            btnCTT_Sua = new Button();
            numCTT_SoLuong = new NumericUpDown();
            txtCTT_GhiChu = new TextBox();
            txtCTT_MaThuoc = new TextBox();
            lbCTT_GhiChu = new Label();
            lbCTT_MaThuoc = new Label();
            lbCTT_SoLuong = new Label();
            lbCTT_MaLo = new Label();
            tlpCTT.SuspendLayout();
            pnCTT.SuspendLayout();
            grbCCT_TT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCTT_SoLuong).BeginInit();
            SuspendLayout();
            // 
            // tlpCTT
            // 
            tlpCTT.ColumnCount = 1;
            tlpCTT.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCTT.Controls.Add(pnCTT, 0, 0);
            tlpCTT.Controls.Add(grbCCT_TT, 0, 1);
            tlpCTT.Dock = DockStyle.Fill;
            tlpCTT.Location = new Point(0, 0);
            tlpCTT.Name = "tlpCTT";
            tlpCTT.RowCount = 2;
            tlpCTT.RowStyles.Add(new RowStyle(SizeType.Percent, 16.9781933F));
            tlpCTT.RowStyles.Add(new RowStyle(SizeType.Percent, 83.0218048F));
            tlpCTT.Size = new Size(634, 641);
            tlpCTT.TabIndex = 1;
            // 
            // pnCTT
            // 
            pnCTT.BackColor = Color.FromArgb(63, 139, 208);
            pnCTT.Controls.Add(lbCTT);
            pnCTT.Dock = DockStyle.Fill;
            pnCTT.Location = new Point(3, 3);
            pnCTT.Name = "pnCTT";
            pnCTT.Size = new Size(628, 102);
            pnCTT.TabIndex = 0;
            // 
            // lbCTT
            // 
            lbCTT.AutoSize = true;
            lbCTT.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lbCTT.ForeColor = SystemColors.ButtonHighlight;
            lbCTT.Location = new Point(161, 33);
            lbCTT.Name = "lbCTT";
            lbCTT.Size = new Size(309, 50);
            lbCTT.TabIndex = 0;
            lbCTT.Text = "CHI TIẾT THUỐC";
            // 
            // grbCCT_TT
            // 
            grbCCT_TT.BackColor = SystemColors.Control;
            grbCCT_TT.Controls.Add(cbCTT_MaLo);
            grbCCT_TT.Controls.Add(btnCTT_Sua);
            grbCCT_TT.Controls.Add(numCTT_SoLuong);
            grbCCT_TT.Controls.Add(txtCTT_GhiChu);
            grbCCT_TT.Controls.Add(txtCTT_MaThuoc);
            grbCCT_TT.Controls.Add(lbCTT_GhiChu);
            grbCCT_TT.Controls.Add(lbCTT_MaThuoc);
            grbCCT_TT.Controls.Add(lbCTT_SoLuong);
            grbCCT_TT.Controls.Add(lbCTT_MaLo);
            grbCCT_TT.Dock = DockStyle.Fill;
            grbCCT_TT.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            grbCCT_TT.Location = new Point(3, 111);
            grbCCT_TT.Name = "grbCCT_TT";
            grbCCT_TT.Size = new Size(628, 527);
            grbCCT_TT.TabIndex = 1;
            grbCCT_TT.TabStop = false;
            grbCCT_TT.Text = "Thông tin";
            // 
            // cbCTT_MaLo
            // 
            cbCTT_MaLo.FormattingEnabled = true;
            cbCTT_MaLo.Location = new Point(218, 158);
            cbCTT_MaLo.Name = "cbCTT_MaLo";
            cbCTT_MaLo.Size = new Size(376, 45);
            cbCTT_MaLo.TabIndex = 9;
            // 
            // btnCTT_Sua
            // 
            btnCTT_Sua.BackColor = SystemColors.Highlight;
            btnCTT_Sua.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnCTT_Sua.ForeColor = SystemColors.ButtonHighlight;
            btnCTT_Sua.Location = new Point(459, 430);
            btnCTT_Sua.Name = "btnCTT_Sua";
            btnCTT_Sua.Size = new Size(135, 57);
            btnCTT_Sua.TabIndex = 8;
            btnCTT_Sua.Text = "Sửa";
            btnCTT_Sua.UseVisualStyleBackColor = false;
            btnCTT_Sua.Click += btnCTT_Sua_Click;
            // 
            // numCTT_SoLuong
            // 
            numCTT_SoLuong.Location = new Point(216, 239);
            numCTT_SoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCTT_SoLuong.Name = "numCTT_SoLuong";
            numCTT_SoLuong.Size = new Size(167, 43);
            numCTT_SoLuong.TabIndex = 7;
            // 
            // txtCTT_GhiChu
            // 
            txtCTT_GhiChu.Location = new Point(216, 318);
            txtCTT_GhiChu.Multiline = true;
            txtCTT_GhiChu.Name = "txtCTT_GhiChu";
            txtCTT_GhiChu.Size = new Size(378, 76);
            txtCTT_GhiChu.TabIndex = 6;
            // 
            // txtCTT_MaThuoc
            // 
            txtCTT_MaThuoc.Location = new Point(216, 79);
            txtCTT_MaThuoc.Name = "txtCTT_MaThuoc";
            txtCTT_MaThuoc.Size = new Size(378, 43);
            txtCTT_MaThuoc.TabIndex = 5;
            // 
            // lbCTT_GhiChu
            // 
            lbCTT_GhiChu.AutoSize = true;
            lbCTT_GhiChu.Location = new Point(30, 334);
            lbCTT_GhiChu.Name = "lbCTT_GhiChu";
            lbCTT_GhiChu.Size = new Size(107, 37);
            lbCTT_GhiChu.TabIndex = 3;
            lbCTT_GhiChu.Text = "Ghi chú";
            // 
            // lbCTT_MaThuoc
            // 
            lbCTT_MaThuoc.AutoSize = true;
            lbCTT_MaThuoc.Location = new Point(30, 82);
            lbCTT_MaThuoc.Name = "lbCTT_MaThuoc";
            lbCTT_MaThuoc.Size = new Size(129, 37);
            lbCTT_MaThuoc.TabIndex = 2;
            lbCTT_MaThuoc.Text = "Mã thuốc";
            // 
            // lbCTT_SoLuong
            // 
            lbCTT_SoLuong.AutoSize = true;
            lbCTT_SoLuong.Location = new Point(30, 250);
            lbCTT_SoLuong.Name = "lbCTT_SoLuong";
            lbCTT_SoLuong.Size = new Size(124, 37);
            lbCTT_SoLuong.TabIndex = 1;
            lbCTT_SoLuong.Text = "Số lượng";
            // 
            // lbCTT_MaLo
            // 
            lbCTT_MaLo.AutoSize = true;
            lbCTT_MaLo.Location = new Point(30, 166);
            lbCTT_MaLo.Name = "lbCTT_MaLo";
            lbCTT_MaLo.Size = new Size(85, 37);
            lbCTT_MaLo.TabIndex = 0;
            lbCTT_MaLo.Text = "Mã lô";
            // 
            // UC_CTThuoc
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpCTT);
            Name = "UC_CTThuoc";
            Size = new Size(634, 641);
            tlpCTT.ResumeLayout(false);
            pnCTT.ResumeLayout(false);
            pnCTT.PerformLayout();
            grbCCT_TT.ResumeLayout(false);
            grbCCT_TT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCTT_SoLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpCTT;
        private Panel pnCTT;
        private Label lbCTT;
        private GroupBox grbCCT_TT;
        private Button btnCTT_Sua;
        private NumericUpDown numCTT_SoLuong;
        private TextBox txtCTT_GhiChu;
        private TextBox txtCTT_MaThuoc;
        private Label lbCTT_GhiChu;
        private Label lbCTT_MaThuoc;
        private Label lbCTT_SoLuong;
        private Label lbCTT_MaLo;
        private ComboBox cbCTT_MaLo;
    }
}
