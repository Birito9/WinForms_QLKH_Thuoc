using System.Windows.Forms;
using System;

namespace WinFormsApp
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            uC_Login1 = new FormQLKH.UC_Login();
            SuspendLayout();
            // 
            // uC_Login1
            // 
            uC_Login1.Dock = DockStyle.Fill;
            uC_Login1.Location = new Point(0, 0);
            uC_Login1.Name = "uC_Login1";
            uC_Login1.Size = new Size(882, 990);
            uC_Login1.TabIndex = 0;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(882, 990);
            Controls.Add(uC_Login1);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            FormClosing += FrmLogin_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private FormQLKH.UC_Login uC_Login1;
    }
}
