namespace WinFormsApp
{
    partial class FrmMain
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uC_Main1 = new FormQLKH.UC_Main();
            SuspendLayout();
            // 
            // uC_Main1
            // 
            uC_Main1.Dock = DockStyle.Fill;
            uC_Main1.Location = new Point(0, 0);
            uC_Main1.Name = "uC_Main1";
            uC_Main1.Size = new Size(1914, 1412);
            uC_Main1.TabIndex = 0;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1914, 1412);
            Controls.Add(uC_Main1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý";
            FormClosing += FrmMain_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private FormQLKH.UC_Main uC_Main1;
    }
}