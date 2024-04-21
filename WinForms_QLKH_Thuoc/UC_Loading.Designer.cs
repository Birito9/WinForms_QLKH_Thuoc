namespace FormQLKH
{
    partial class UC_Loading
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            lbLoad = new Label();
            pcLoad = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcLoad).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1448, 1337);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbLoad);
            panel1.Controls.Add(pcLoad);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1442, 1331);
            panel1.TabIndex = 0;
            // 
            // lbLoad
            // 
            lbLoad.AutoSize = true;
            lbLoad.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point);
            lbLoad.Location = new Point(300, 911);
            lbLoad.Name = "lbLoad";
            lbLoad.Size = new Size(805, 71);
            lbLoad.TabIndex = 1;
            lbLoad.Text = "Xin vui lòng chờ trong giây lát ";
            // 
            // pcLoad
            // 
            pcLoad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pcLoad.Image = Properties.Resources.loading;
            pcLoad.Location = new Point(401, 294);
            pcLoad.Name = "pcLoad";
            pcLoad.Size = new Size(610, 533);
            pcLoad.SizeMode = PictureBoxSizeMode.StretchImage;
            pcLoad.TabIndex = 0;
            pcLoad.TabStop = false;
            // 
            // UC_Loading
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_Loading";
            Size = new Size(1448, 1337);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcLoad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private PictureBox pcLoad;
        private Label lbLoad;
    }
}
