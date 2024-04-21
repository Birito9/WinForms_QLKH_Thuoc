namespace FormQLKH
{
    partial class UC_Login
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
            tlpLogin = new TableLayoutPanel();
            pnLogin = new Panel();
            lbLogin = new Label();
            pnLoginText = new Panel();
            pcbEye = new PictureBox();
            btnLogin = new Button();
            txtLogin_Password = new TextBox();
            lbLogin_Password = new Label();
            txtLogin_UserName = new TextBox();
            lbLogin_UserName = new Label();
            picLogin = new PictureBox();
            tlpLogin.SuspendLayout();
            pnLogin.SuspendLayout();
            pnLoginText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbEye).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogin).BeginInit();
            SuspendLayout();
            // 
            // tlpLogin
            // 
            tlpLogin.ColumnCount = 1;
            tlpLogin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpLogin.Controls.Add(pnLogin, 0, 0);
            tlpLogin.Controls.Add(pnLoginText, 0, 1);
            tlpLogin.Dock = DockStyle.Fill;
            tlpLogin.Location = new Point(0, 0);
            tlpLogin.Name = "tlpLogin";
            tlpLogin.RowCount = 2;
            tlpLogin.RowStyles.Add(new RowStyle(SizeType.Percent, 25.2809F));
            tlpLogin.RowStyles.Add(new RowStyle(SizeType.Percent, 74.7191F));
            tlpLogin.Size = new Size(864, 897);
            tlpLogin.TabIndex = 0;
            // 
            // pnLogin
            // 
            pnLogin.BackgroundImage = Properties.Resources.bgThuoc1;
            pnLogin.Controls.Add(lbLogin);
            pnLogin.Dock = DockStyle.Fill;
            pnLogin.Location = new Point(3, 3);
            pnLogin.Name = "pnLogin";
            pnLogin.Size = new Size(858, 220);
            pnLogin.TabIndex = 0;
            // 
            // lbLogin
            // 
            lbLogin.AutoSize = true;
            lbLogin.BackColor = Color.Transparent;
            lbLogin.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
            lbLogin.Location = new Point(64, 59);
            lbLogin.Name = "lbLogin";
            lbLogin.Size = new Size(290, 106);
            lbLogin.TabIndex = 0;
            lbLogin.Text = "LOGIN";
            // 
            // pnLoginText
            // 
            pnLoginText.BackColor = SystemColors.ButtonHighlight;
            pnLoginText.Controls.Add(pcbEye);
            pnLoginText.Controls.Add(btnLogin);
            pnLoginText.Controls.Add(txtLogin_Password);
            pnLoginText.Controls.Add(lbLogin_Password);
            pnLoginText.Controls.Add(txtLogin_UserName);
            pnLoginText.Controls.Add(lbLogin_UserName);
            pnLoginText.Controls.Add(picLogin);
            pnLoginText.Dock = DockStyle.Fill;
            pnLoginText.Location = new Point(3, 229);
            pnLoginText.Name = "pnLoginText";
            pnLoginText.Size = new Size(858, 665);
            pnLoginText.TabIndex = 1;
            // 
            // pcbEye
            // 
            pcbEye.Image = Properties.Resources.close;
            pcbEye.Location = new Point(765, 171);
            pcbEye.Name = "pcbEye";
            pcbEye.Size = new Size(90, 54);
            pcbEye.SizeMode = PictureBoxSizeMode.CenterImage;
            pcbEye.TabIndex = 5;
            pcbEye.TabStop = false;
            pcbEye.Click += pcbEye_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(1, 147, 213);
            btnLogin.FlatAppearance.BorderColor = SystemColors.Highlight;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(23, 150, 204);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(613, 468);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(206, 113);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtLogin_Password
            // 
            txtLogin_Password.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            txtLogin_Password.Location = new Point(324, 171);
            txtLogin_Password.Multiline = true;
            txtLogin_Password.Name = "txtLogin_Password";
            txtLogin_Password.PasswordChar = '*';
            txtLogin_Password.PlaceholderText = "Nhập Password...";
            txtLogin_Password.Size = new Size(423, 54);
            txtLogin_Password.TabIndex = 2;
            txtLogin_Password.KeyDown += txtLogin_Password_KeyDown;
            txtLogin_Password.KeyPress += txtLogin_Password_KeyPress;
            // 
            // lbLogin_Password
            // 
            lbLogin_Password.AutoSize = true;
            lbLogin_Password.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbLogin_Password.Location = new Point(64, 171);
            lbLogin_Password.Name = "lbLogin_Password";
            lbLogin_Password.Size = new Size(157, 45);
            lbLogin_Password.TabIndex = 2;
            lbLogin_Password.Text = "Password";
            // 
            // txtLogin_UserName
            // 
            txtLogin_UserName.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            txtLogin_UserName.Location = new Point(324, 63);
            txtLogin_UserName.Multiline = true;
            txtLogin_UserName.Name = "txtLogin_UserName";
            txtLogin_UserName.PlaceholderText = "Nhập UserName...";
            txtLogin_UserName.Size = new Size(423, 54);
            txtLogin_UserName.TabIndex = 1;
            txtLogin_UserName.TextChanged += txtLogin_UserName_TextChanged;
            txtLogin_UserName.KeyDown += txtLogin_UserName_KeyDown;
            txtLogin_UserName.KeyPress += txtLogin_UserName_KeyPress;
            // 
            // lbLogin_UserName
            // 
            lbLogin_UserName.AutoSize = true;
            lbLogin_UserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbLogin_UserName.Location = new Point(64, 60);
            lbLogin_UserName.Name = "lbLogin_UserName";
            lbLogin_UserName.Size = new Size(173, 45);
            lbLogin_UserName.TabIndex = 0;
            lbLogin_UserName.Text = "UserName";
            // 
            // picLogin
            // 
            picLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picLogin.Image = Properties.Resources.bgThuoc2;
            picLogin.Location = new Point(3, 279);
            picLogin.Name = "picLogin";
            picLogin.Size = new Size(646, 386);
            picLogin.SizeMode = PictureBoxSizeMode.AutoSize;
            picLogin.TabIndex = 4;
            picLogin.TabStop = false;
            // 
            // UC_Login
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpLogin);
            Name = "UC_Login";
            Size = new Size(864, 897);
            Load += UC_Login_Load;
            tlpLogin.ResumeLayout(false);
            pnLogin.ResumeLayout(false);
            pnLogin.PerformLayout();
            pnLoginText.ResumeLayout(false);
            pnLoginText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcbEye).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpLogin;
        private Panel pnLogin;
        private Label lbLogin;
        private Panel pnLoginText;
        private PictureBox picLogin;
        private TextBox txtLogin_Password;
        private Label lbLogin_Password;
        private TextBox txtLogin_UserName;
        private Label lbLogin_UserName;
        private Button btnLogin;
        private PictureBox pcbEye;
    }
}
