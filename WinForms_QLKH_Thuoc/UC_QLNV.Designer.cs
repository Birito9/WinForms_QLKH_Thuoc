namespace FormQLKH
{
    partial class UC_QLNV
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
            tlpQLNV = new TableLayoutPanel();
            pnQLNV = new Panel();
            lbQLNV = new Label();
            grbQLNV_HT = new GroupBox();
            dgvNV = new DataGridView();
            NV_ID = new DataGridViewTextBoxColumn();
            UserID = new DataGridViewTextBoxColumn();
            CN_ID = new DataGridViewTextBoxColumn();
            NV_Name = new DataGridViewTextBoxColumn();
            BirthDay = new DataGridViewTextBoxColumn();
            Sex = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            pnQLNV_TT = new Panel();
            grbQLNV_TT = new GroupBox();
            cbQLNV_MaCN = new ComboBox();
            cbQLNV_UserID = new ComboBox();
            lbQLNV_GioiTinh = new Label();
            gboxGioiTinh = new GroupBox();
            rdbQLNV_Nam = new RadioButton();
            rdbQLNV_Nu = new RadioButton();
            dtpQLNV_NgaySinh = new DateTimePicker();
            txtQLNV_HoTen = new TextBox();
            txtQLNV_Email = new TextBox();
            txtQLNV_DiaChi = new TextBox();
            txtQLNV_SDT = new TextBox();
            txtQLNV_MaNV = new TextBox();
            lbQLNV_DiaChi = new Label();
            lbQLNV_Email = new Label();
            lbQLNV_SDT = new Label();
            lbQLNV_NgaySinh = new Label();
            lbQLNV_HoTen = new Label();
            lbQLNV_MaCN = new Label();
            lbQLNV_UserID = new Label();
            lbQLNV_MaNV = new Label();
            splQLNV_TK_CN = new SplitContainer();
            grbQLNV_TK = new GroupBox();
            pnQLNV_TK = new Panel();
            btnQLNV_TK = new Button();
            txtQLNV_TK_TenNV = new TextBox();
            cbQLNV_TK_MaNV = new ComboBox();
            lbQLNV_TK_HoTen = new Label();
            lbQLNV_TK_MaNV = new Label();
            grbQLNV_CN = new GroupBox();
            btnQLNV_Them = new Button();
            btnQLNV_Sua = new Button();
            btnQLNV_Xoa = new Button();
            tlpQLNV.SuspendLayout();
            pnQLNV.SuspendLayout();
            grbQLNV_HT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNV).BeginInit();
            pnQLNV_TT.SuspendLayout();
            grbQLNV_TT.SuspendLayout();
            gboxGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splQLNV_TK_CN).BeginInit();
            splQLNV_TK_CN.Panel1.SuspendLayout();
            splQLNV_TK_CN.Panel2.SuspendLayout();
            splQLNV_TK_CN.SuspendLayout();
            grbQLNV_TK.SuspendLayout();
            pnQLNV_TK.SuspendLayout();
            grbQLNV_CN.SuspendLayout();
            SuspendLayout();
            // 
            // tlpQLNV
            // 
            tlpQLNV.BackColor = SystemColors.Control;
            tlpQLNV.ColumnCount = 1;
            tlpQLNV.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpQLNV.Controls.Add(pnQLNV, 0, 0);
            tlpQLNV.Controls.Add(grbQLNV_HT, 0, 1);
            tlpQLNV.Controls.Add(pnQLNV_TT, 0, 2);
            tlpQLNV.Controls.Add(splQLNV_TK_CN, 0, 3);
            tlpQLNV.Dock = DockStyle.Fill;
            tlpQLNV.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            tlpQLNV.Location = new Point(0, 0);
            tlpQLNV.Name = "tlpQLNV";
            tlpQLNV.RowCount = 4;
            tlpQLNV.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            tlpQLNV.RowStyles.Add(new RowStyle(SizeType.Absolute, 693F));
            tlpQLNV.RowStyles.Add(new RowStyle(SizeType.Absolute, 328F));
            tlpQLNV.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            tlpQLNV.Size = new Size(1448, 1337);
            tlpQLNV.TabIndex = 1;
            // 
            // pnQLNV
            // 
            pnQLNV.BackColor = Color.FromArgb(15, 142, 219);
            pnQLNV.Controls.Add(lbQLNV);
            pnQLNV.Dock = DockStyle.Fill;
            pnQLNV.Location = new Point(3, 3);
            pnQLNV.Name = "pnQLNV";
            pnQLNV.Size = new Size(1442, 76);
            pnQLNV.TabIndex = 0;
            // 
            // lbQLNV
            // 
            lbQLNV.AutoSize = true;
            lbQLNV.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV.ForeColor = SystemColors.ButtonHighlight;
            lbQLNV.Location = new Point(552, 18);
            lbQLNV.Name = "lbQLNV";
            lbQLNV.Size = new Size(399, 50);
            lbQLNV.TabIndex = 0;
            lbQLNV.Text = "QUẢN LÝ NHÂN VIÊN";
            lbQLNV.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grbQLNV_HT
            // 
            grbQLNV_HT.BackColor = Color.Transparent;
            grbQLNV_HT.BackgroundImage = Properties.Resources.bg;
            grbQLNV_HT.Controls.Add(dgvNV);
            grbQLNV_HT.Dock = DockStyle.Fill;
            grbQLNV_HT.Location = new Point(3, 85);
            grbQLNV_HT.Name = "grbQLNV_HT";
            grbQLNV_HT.Padding = new Padding(3, 10, 3, 3);
            grbQLNV_HT.Size = new Size(1442, 687);
            grbQLNV_HT.TabIndex = 3;
            grbQLNV_HT.TabStop = false;
            grbQLNV_HT.Text = "Hiển thị";
            // 
            // dgvNV
            // 
            dgvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNV.Columns.AddRange(new DataGridViewColumn[] { NV_ID, UserID, CN_ID, NV_Name, BirthDay, Sex, Phone, Email, Address });
            dgvNV.Dock = DockStyle.Fill;
            dgvNV.Location = new Point(3, 46);
            dgvNV.Name = "dgvNV";
            dgvNV.RowHeadersWidth = 82;
            dgvNV.RowTemplate.Height = 41;
            dgvNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNV.Size = new Size(1436, 638);
            dgvNV.TabIndex = 1;
            dgvNV.RowPostPaint += dgvNV_RowPostPaint;
            dgvNV.SelectionChanged += dgvNV_SelectionChanged;
            // 
            // NV_ID
            // 
            NV_ID.DataPropertyName = "NV_ID";
            NV_ID.HeaderText = "Mã NV";
            NV_ID.MinimumWidth = 10;
            NV_ID.Name = "NV_ID";
            // 
            // UserID
            // 
            UserID.DataPropertyName = "UserID";
            UserID.HeaderText = "UserID";
            UserID.MinimumWidth = 10;
            UserID.Name = "UserID";
            // 
            // CN_ID
            // 
            CN_ID.DataPropertyName = "CN_ID";
            CN_ID.HeaderText = "Mã CN";
            CN_ID.MinimumWidth = 10;
            CN_ID.Name = "CN_ID";
            // 
            // NV_Name
            // 
            NV_Name.DataPropertyName = "NV_Name";
            NV_Name.HeaderText = "Họ tên";
            NV_Name.MinimumWidth = 10;
            NV_Name.Name = "NV_Name";
            // 
            // BirthDay
            // 
            BirthDay.DataPropertyName = "BirthDay";
            BirthDay.HeaderText = "Ngày sinh";
            BirthDay.MinimumWidth = 10;
            BirthDay.Name = "BirthDay";
            // 
            // Sex
            // 
            Sex.DataPropertyName = "Sex";
            Sex.HeaderText = "Giới tính";
            Sex.MinimumWidth = 10;
            Sex.Name = "Sex";
            // 
            // Phone
            // 
            Phone.DataPropertyName = "Phone";
            Phone.HeaderText = "SĐT";
            Phone.MinimumWidth = 10;
            Phone.Name = "Phone";
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 10;
            Email.Name = "Email";
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Địa chỉ";
            Address.MinimumWidth = 10;
            Address.Name = "Address";
            // 
            // pnQLNV_TT
            // 
            pnQLNV_TT.BackColor = Color.Transparent;
            pnQLNV_TT.Controls.Add(grbQLNV_TT);
            pnQLNV_TT.Dock = DockStyle.Fill;
            pnQLNV_TT.Location = new Point(3, 778);
            pnQLNV_TT.Name = "pnQLNV_TT";
            pnQLNV_TT.Size = new Size(1442, 322);
            pnQLNV_TT.TabIndex = 4;
            // 
            // grbQLNV_TT
            // 
            grbQLNV_TT.BackColor = Color.Transparent;
            grbQLNV_TT.BackgroundImage = Properties.Resources.bg;
            grbQLNV_TT.Controls.Add(cbQLNV_MaCN);
            grbQLNV_TT.Controls.Add(cbQLNV_UserID);
            grbQLNV_TT.Controls.Add(lbQLNV_GioiTinh);
            grbQLNV_TT.Controls.Add(gboxGioiTinh);
            grbQLNV_TT.Controls.Add(dtpQLNV_NgaySinh);
            grbQLNV_TT.Controls.Add(txtQLNV_HoTen);
            grbQLNV_TT.Controls.Add(txtQLNV_Email);
            grbQLNV_TT.Controls.Add(txtQLNV_DiaChi);
            grbQLNV_TT.Controls.Add(txtQLNV_SDT);
            grbQLNV_TT.Controls.Add(txtQLNV_MaNV);
            grbQLNV_TT.Controls.Add(lbQLNV_DiaChi);
            grbQLNV_TT.Controls.Add(lbQLNV_Email);
            grbQLNV_TT.Controls.Add(lbQLNV_SDT);
            grbQLNV_TT.Controls.Add(lbQLNV_NgaySinh);
            grbQLNV_TT.Controls.Add(lbQLNV_HoTen);
            grbQLNV_TT.Controls.Add(lbQLNV_MaCN);
            grbQLNV_TT.Controls.Add(lbQLNV_UserID);
            grbQLNV_TT.Controls.Add(lbQLNV_MaNV);
            grbQLNV_TT.Dock = DockStyle.Fill;
            grbQLNV_TT.Location = new Point(0, 0);
            grbQLNV_TT.Name = "grbQLNV_TT";
            grbQLNV_TT.Size = new Size(1442, 322);
            grbQLNV_TT.TabIndex = 0;
            grbQLNV_TT.TabStop = false;
            grbQLNV_TT.Text = "Thông tin";
            // 
            // cbQLNV_MaCN
            // 
            cbQLNV_MaCN.FormattingEnabled = true;
            cbQLNV_MaCN.Location = new Point(664, 49);
            cbQLNV_MaCN.Name = "cbQLNV_MaCN";
            cbQLNV_MaCN.Size = new Size(242, 45);
            cbQLNV_MaCN.TabIndex = 22;
            // 
            // cbQLNV_UserID
            // 
            cbQLNV_UserID.FormattingEnabled = true;
            cbQLNV_UserID.Location = new Point(154, 125);
            cbQLNV_UserID.Name = "cbQLNV_UserID";
            cbQLNV_UserID.Size = new Size(284, 45);
            cbQLNV_UserID.TabIndex = 21;
            // 
            // lbQLNV_GioiTinh
            // 
            lbQLNV_GioiTinh.AutoSize = true;
            lbQLNV_GioiTinh.BackColor = SystemColors.Control;
            lbQLNV_GioiTinh.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_GioiTinh.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_GioiTinh.Location = new Point(496, 229);
            lbQLNV_GioiTinh.Name = "lbQLNV_GioiTinh";
            lbQLNV_GioiTinh.Size = new Size(125, 39);
            lbQLNV_GioiTinh.TabIndex = 20;
            lbQLNV_GioiTinh.Text = "Giới tính";
            // 
            // gboxGioiTinh
            // 
            gboxGioiTinh.Controls.Add(rdbQLNV_Nam);
            gboxGioiTinh.Controls.Add(rdbQLNV_Nu);
            gboxGioiTinh.FlatStyle = FlatStyle.System;
            gboxGioiTinh.Location = new Point(664, 208);
            gboxGioiTinh.Margin = new Padding(4);
            gboxGioiTinh.Name = "gboxGioiTinh";
            gboxGioiTinh.Padding = new Padding(4);
            gboxGioiTinh.Size = new Size(242, 84);
            gboxGioiTinh.TabIndex = 19;
            gboxGioiTinh.TabStop = false;
            // 
            // rdbQLNV_Nam
            // 
            rdbQLNV_Nam.AutoSize = true;
            rdbQLNV_Nam.Checked = true;
            rdbQLNV_Nam.Location = new Point(21, 31);
            rdbQLNV_Nam.Name = "rdbQLNV_Nam";
            rdbQLNV_Nam.Size = new Size(105, 41);
            rdbQLNV_Nam.TabIndex = 17;
            rdbQLNV_Nam.TabStop = true;
            rdbQLNV_Nam.Text = "Nam";
            rdbQLNV_Nam.UseVisualStyleBackColor = true;
            // 
            // rdbQLNV_Nu
            // 
            rdbQLNV_Nu.AutoSize = true;
            rdbQLNV_Nu.Location = new Point(151, 33);
            rdbQLNV_Nu.Name = "rdbQLNV_Nu";
            rdbQLNV_Nu.Size = new Size(84, 41);
            rdbQLNV_Nu.TabIndex = 18;
            rdbQLNV_Nu.TabStop = true;
            rdbQLNV_Nu.Text = "Nữ";
            rdbQLNV_Nu.UseVisualStyleBackColor = true;
            // 
            // dtpQLNV_NgaySinh
            // 
            dtpQLNV_NgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpQLNV_NgaySinh.Format = DateTimePickerFormat.Custom;
            dtpQLNV_NgaySinh.Location = new Point(664, 137);
            dtpQLNV_NgaySinh.Name = "dtpQLNV_NgaySinh";
            dtpQLNV_NgaySinh.Size = new Size(242, 43);
            dtpQLNV_NgaySinh.TabIndex = 16;
            // 
            // txtQLNV_HoTen
            // 
            txtQLNV_HoTen.Location = new Point(154, 204);
            txtQLNV_HoTen.Multiline = true;
            txtQLNV_HoTen.Name = "txtQLNV_HoTen";
            txtQLNV_HoTen.Size = new Size(284, 82);
            txtQLNV_HoTen.TabIndex = 15;
            // 
            // txtQLNV_Email
            // 
            txtQLNV_Email.Location = new Point(1101, 124);
            txtQLNV_Email.Name = "txtQLNV_Email";
            txtQLNV_Email.Size = new Size(303, 43);
            txtQLNV_Email.TabIndex = 14;
            txtQLNV_Email.KeyPress += txtQLNV_Email_KeyPress;
            // 
            // txtQLNV_DiaChi
            // 
            txtQLNV_DiaChi.Location = new Point(1101, 204);
            txtQLNV_DiaChi.Multiline = true;
            txtQLNV_DiaChi.Name = "txtQLNV_DiaChi";
            txtQLNV_DiaChi.Size = new Size(303, 86);
            txtQLNV_DiaChi.TabIndex = 13;
            // 
            // txtQLNV_SDT
            // 
            txtQLNV_SDT.Location = new Point(1101, 49);
            txtQLNV_SDT.Name = "txtQLNV_SDT";
            txtQLNV_SDT.Size = new Size(303, 43);
            txtQLNV_SDT.TabIndex = 12;
            txtQLNV_SDT.KeyPress += txtQLNV_SDT_KeyPress;
            // 
            // txtQLNV_MaNV
            // 
            txtQLNV_MaNV.Location = new Point(154, 51);
            txtQLNV_MaNV.Name = "txtQLNV_MaNV";
            txtQLNV_MaNV.Size = new Size(284, 43);
            txtQLNV_MaNV.TabIndex = 9;
            // 
            // lbQLNV_DiaChi
            // 
            lbQLNV_DiaChi.AutoSize = true;
            lbQLNV_DiaChi.BackColor = SystemColors.Control;
            lbQLNV_DiaChi.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_DiaChi.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_DiaChi.Location = new Point(968, 223);
            lbQLNV_DiaChi.Name = "lbQLNV_DiaChi";
            lbQLNV_DiaChi.Size = new Size(102, 39);
            lbQLNV_DiaChi.TabIndex = 8;
            lbQLNV_DiaChi.Text = "Địa chỉ";
            // 
            // lbQLNV_Email
            // 
            lbQLNV_Email.AutoSize = true;
            lbQLNV_Email.BackColor = SystemColors.Control;
            lbQLNV_Email.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_Email.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_Email.Location = new Point(968, 137);
            lbQLNV_Email.Name = "lbQLNV_Email";
            lbQLNV_Email.Size = new Size(85, 39);
            lbQLNV_Email.TabIndex = 7;
            lbQLNV_Email.Text = "Email";
            // 
            // lbQLNV_SDT
            // 
            lbQLNV_SDT.AutoSize = true;
            lbQLNV_SDT.BackColor = SystemColors.Control;
            lbQLNV_SDT.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_SDT.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_SDT.Location = new Point(968, 51);
            lbQLNV_SDT.Name = "lbQLNV_SDT";
            lbQLNV_SDT.Size = new Size(68, 39);
            lbQLNV_SDT.TabIndex = 6;
            lbQLNV_SDT.Text = "SĐT";
            // 
            // lbQLNV_NgaySinh
            // 
            lbQLNV_NgaySinh.AutoSize = true;
            lbQLNV_NgaySinh.BackColor = SystemColors.Control;
            lbQLNV_NgaySinh.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_NgaySinh.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_NgaySinh.Location = new Point(496, 141);
            lbQLNV_NgaySinh.Name = "lbQLNV_NgaySinh";
            lbQLNV_NgaySinh.Size = new Size(142, 39);
            lbQLNV_NgaySinh.TabIndex = 5;
            lbQLNV_NgaySinh.Text = "Ngày sinh";
            // 
            // lbQLNV_HoTen
            // 
            lbQLNV_HoTen.AutoSize = true;
            lbQLNV_HoTen.BackColor = SystemColors.Control;
            lbQLNV_HoTen.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_HoTen.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_HoTen.Location = new Point(35, 204);
            lbQLNV_HoTen.Name = "lbQLNV_HoTen";
            lbQLNV_HoTen.Size = new Size(102, 39);
            lbQLNV_HoTen.TabIndex = 3;
            lbQLNV_HoTen.Text = "Họ tên";
            // 
            // lbQLNV_MaCN
            // 
            lbQLNV_MaCN.AutoSize = true;
            lbQLNV_MaCN.BackColor = SystemColors.Control;
            lbQLNV_MaCN.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_MaCN.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_MaCN.Location = new Point(496, 51);
            lbQLNV_MaCN.Name = "lbQLNV_MaCN";
            lbQLNV_MaCN.Size = new Size(103, 39);
            lbQLNV_MaCN.TabIndex = 2;
            lbQLNV_MaCN.Text = "Mã CN";
            // 
            // lbQLNV_UserID
            // 
            lbQLNV_UserID.AutoSize = true;
            lbQLNV_UserID.BackColor = SystemColors.Control;
            lbQLNV_UserID.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_UserID.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_UserID.Location = new Point(32, 125);
            lbQLNV_UserID.Name = "lbQLNV_UserID";
            lbQLNV_UserID.Size = new Size(101, 39);
            lbQLNV_UserID.TabIndex = 1;
            lbQLNV_UserID.Text = "UserID";
            // 
            // lbQLNV_MaNV
            // 
            lbQLNV_MaNV.AutoSize = true;
            lbQLNV_MaNV.BackColor = SystemColors.Control;
            lbQLNV_MaNV.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_MaNV.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_MaNV.Location = new Point(32, 47);
            lbQLNV_MaNV.Name = "lbQLNV_MaNV";
            lbQLNV_MaNV.Size = new Size(103, 39);
            lbQLNV_MaNV.TabIndex = 0;
            lbQLNV_MaNV.Text = "Mã NV";
            // 
            // splQLNV_TK_CN
            // 
            splQLNV_TK_CN.BackColor = Color.Transparent;
            splQLNV_TK_CN.BackgroundImage = Properties.Resources.bg;
            splQLNV_TK_CN.Dock = DockStyle.Bottom;
            splQLNV_TK_CN.Location = new Point(3, 1107);
            splQLNV_TK_CN.Name = "splQLNV_TK_CN";
            // 
            // splQLNV_TK_CN.Panel1
            // 
            splQLNV_TK_CN.Panel1.Controls.Add(grbQLNV_TK);
            // 
            // splQLNV_TK_CN.Panel2
            // 
            splQLNV_TK_CN.Panel2.Controls.Add(grbQLNV_CN);
            splQLNV_TK_CN.Size = new Size(1442, 227);
            splQLNV_TK_CN.SplitterDistance = 588;
            splQLNV_TK_CN.TabIndex = 5;
            // 
            // grbQLNV_TK
            // 
            grbQLNV_TK.Controls.Add(pnQLNV_TK);
            grbQLNV_TK.Controls.Add(cbQLNV_TK_MaNV);
            grbQLNV_TK.Controls.Add(lbQLNV_TK_HoTen);
            grbQLNV_TK.Controls.Add(lbQLNV_TK_MaNV);
            grbQLNV_TK.Dock = DockStyle.Fill;
            grbQLNV_TK.Location = new Point(0, 0);
            grbQLNV_TK.Name = "grbQLNV_TK";
            grbQLNV_TK.Size = new Size(588, 227);
            grbQLNV_TK.TabIndex = 0;
            grbQLNV_TK.TabStop = false;
            grbQLNV_TK.Text = "Tìm kiếm";
            // 
            // pnQLNV_TK
            // 
            pnQLNV_TK.BackColor = Color.White;
            pnQLNV_TK.Controls.Add(btnQLNV_TK);
            pnQLNV_TK.Controls.Add(txtQLNV_TK_TenNV);
            pnQLNV_TK.Location = new Point(182, 127);
            pnQLNV_TK.Name = "pnQLNV_TK";
            pnQLNV_TK.Size = new Size(350, 94);
            pnQLNV_TK.TabIndex = 28;
            // 
            // btnQLNV_TK
            // 
            btnQLNV_TK.BackColor = Color.WhiteSmoke;
            btnQLNV_TK.Dock = DockStyle.Right;
            btnQLNV_TK.FlatStyle = FlatStyle.Popup;
            btnQLNV_TK.Image = Properties.Resources.glass;
            btnQLNV_TK.Location = new Point(279, 0);
            btnQLNV_TK.Name = "btnQLNV_TK";
            btnQLNV_TK.Size = new Size(71, 94);
            btnQLNV_TK.TabIndex = 25;
            btnQLNV_TK.UseVisualStyleBackColor = false;
            btnQLNV_TK.Click += btnQLNV_TK_Click;
            // 
            // txtQLNV_TK_TenNV
            // 
            txtQLNV_TK_TenNV.Dock = DockStyle.Left;
            txtQLNV_TK_TenNV.Location = new Point(0, 0);
            txtQLNV_TK_TenNV.Multiline = true;
            txtQLNV_TK_TenNV.Name = "txtQLNV_TK_TenNV";
            txtQLNV_TK_TenNV.ScrollBars = ScrollBars.Vertical;
            txtQLNV_TK_TenNV.Size = new Size(281, 94);
            txtQLNV_TK_TenNV.TabIndex = 24;
            txtQLNV_TK_TenNV.KeyUp += txtQLNV_TK_TenNV_KeyUp;
            // 
            // cbQLNV_TK_MaNV
            // 
            cbQLNV_TK_MaNV.FormattingEnabled = true;
            cbQLNV_TK_MaNV.Location = new Point(182, 58);
            cbQLNV_TK_MaNV.Name = "cbQLNV_TK_MaNV";
            cbQLNV_TK_MaNV.Size = new Size(350, 45);
            cbQLNV_TK_MaNV.TabIndex = 27;
            cbQLNV_TK_MaNV.SelectedIndexChanged += cbQLNV_TK_MaNV_SelectedIndexChanged;
            // 
            // lbQLNV_TK_HoTen
            // 
            lbQLNV_TK_HoTen.AutoSize = true;
            lbQLNV_TK_HoTen.BackColor = SystemColors.Control;
            lbQLNV_TK_HoTen.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_TK_HoTen.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_TK_HoTen.Location = new Point(32, 135);
            lbQLNV_TK_HoTen.Name = "lbQLNV_TK_HoTen";
            lbQLNV_TK_HoTen.Size = new Size(102, 39);
            lbQLNV_TK_HoTen.TabIndex = 26;
            lbQLNV_TK_HoTen.Text = "Họ tên";
            // 
            // lbQLNV_TK_MaNV
            // 
            lbQLNV_TK_MaNV.AutoSize = true;
            lbQLNV_TK_MaNV.BackColor = SystemColors.Control;
            lbQLNV_TK_MaNV.BorderStyle = BorderStyle.Fixed3D;
            lbQLNV_TK_MaNV.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lbQLNV_TK_MaNV.Location = new Point(29, 61);
            lbQLNV_TK_MaNV.Name = "lbQLNV_TK_MaNV";
            lbQLNV_TK_MaNV.Size = new Size(103, 39);
            lbQLNV_TK_MaNV.TabIndex = 25;
            lbQLNV_TK_MaNV.Text = "Mã NV";
            // 
            // grbQLNV_CN
            // 
            grbQLNV_CN.Controls.Add(btnQLNV_Them);
            grbQLNV_CN.Controls.Add(btnQLNV_Sua);
            grbQLNV_CN.Controls.Add(btnQLNV_Xoa);
            grbQLNV_CN.Dock = DockStyle.Fill;
            grbQLNV_CN.Location = new Point(0, 0);
            grbQLNV_CN.Name = "grbQLNV_CN";
            grbQLNV_CN.Size = new Size(850, 227);
            grbQLNV_CN.TabIndex = 11;
            grbQLNV_CN.TabStop = false;
            grbQLNV_CN.Text = "Chức năng";
            // 
            // btnQLNV_Them
            // 
            btnQLNV_Them.BackColor = SystemColors.ButtonHighlight;
            btnQLNV_Them.FlatAppearance.BorderColor = Color.Gainsboro;
            btnQLNV_Them.FlatAppearance.BorderSize = 0;
            btnQLNV_Them.FlatStyle = FlatStyle.Popup;
            btnQLNV_Them.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLNV_Them.Image = Properties.Resources.add;
            btnQLNV_Them.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLNV_Them.Location = new Point(54, 103);
            btnQLNV_Them.Name = "btnQLNV_Them";
            btnQLNV_Them.Size = new Size(169, 58);
            btnQLNV_Them.TabIndex = 7;
            btnQLNV_Them.Text = " Thêm";
            btnQLNV_Them.UseVisualStyleBackColor = false;
            btnQLNV_Them.Click += btnQLNV_Them_Click;
            // 
            // btnQLNV_Sua
            // 
            btnQLNV_Sua.BackColor = SystemColors.ButtonHighlight;
            btnQLNV_Sua.FlatAppearance.BorderColor = Color.Gainsboro;
            btnQLNV_Sua.FlatAppearance.BorderSize = 0;
            btnQLNV_Sua.FlatStyle = FlatStyle.Popup;
            btnQLNV_Sua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLNV_Sua.Image = Properties.Resources.update;
            btnQLNV_Sua.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLNV_Sua.Location = new Point(331, 103);
            btnQLNV_Sua.Name = "btnQLNV_Sua";
            btnQLNV_Sua.Size = new Size(169, 58);
            btnQLNV_Sua.TabIndex = 8;
            btnQLNV_Sua.Text = "Sửa";
            btnQLNV_Sua.UseVisualStyleBackColor = false;
            btnQLNV_Sua.Click += btnQLNV_Sua_Click;
            // 
            // btnQLNV_Xoa
            // 
            btnQLNV_Xoa.BackColor = SystemColors.ButtonHighlight;
            btnQLNV_Xoa.FlatAppearance.BorderColor = Color.Gainsboro;
            btnQLNV_Xoa.FlatAppearance.BorderSize = 0;
            btnQLNV_Xoa.FlatStyle = FlatStyle.Popup;
            btnQLNV_Xoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQLNV_Xoa.Image = Properties.Resources.delete;
            btnQLNV_Xoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnQLNV_Xoa.Location = new Point(608, 103);
            btnQLNV_Xoa.Name = "btnQLNV_Xoa";
            btnQLNV_Xoa.Size = new Size(169, 58);
            btnQLNV_Xoa.TabIndex = 9;
            btnQLNV_Xoa.Text = "Xóa";
            btnQLNV_Xoa.UseVisualStyleBackColor = false;
            btnQLNV_Xoa.Click += btnQLNV_Xoa_Click;
            // 
            // UC_QLNV
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpQLNV);
            Name = "UC_QLNV";
            Size = new Size(1448, 1337);
            tlpQLNV.ResumeLayout(false);
            pnQLNV.ResumeLayout(false);
            pnQLNV.PerformLayout();
            grbQLNV_HT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNV).EndInit();
            pnQLNV_TT.ResumeLayout(false);
            grbQLNV_TT.ResumeLayout(false);
            grbQLNV_TT.PerformLayout();
            gboxGioiTinh.ResumeLayout(false);
            gboxGioiTinh.PerformLayout();
            splQLNV_TK_CN.Panel1.ResumeLayout(false);
            splQLNV_TK_CN.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splQLNV_TK_CN).EndInit();
            splQLNV_TK_CN.ResumeLayout(false);
            grbQLNV_TK.ResumeLayout(false);
            grbQLNV_TK.PerformLayout();
            pnQLNV_TK.ResumeLayout(false);
            pnQLNV_TK.PerformLayout();
            grbQLNV_CN.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpQLNV;
        private Panel pnQLNV;
        private Label lbQLNV;
        private GroupBox grbQLNV_HT;
        private DataGridView dgvNV;
        private Panel pnQLNV_TT;
        private GroupBox grbQLNV_TT;
        private Label lbQLNV_GioiTinh;
        private GroupBox gboxGioiTinh;
        private RadioButton rdbQLNV_Nam;
        private RadioButton rdbQLNV_Nu;
        private DateTimePicker dtpQLNV_NgaySinh;
        private TextBox txtQLNV_HoTen;
        private TextBox txtQLNV_Email;
        private TextBox txtQLNV_DiaChi;
        private TextBox txtQLNV_SDT;
        private TextBox txtQLNV_MaNV;
        private Label lbQLNV_DiaChi;
        private Label lbQLNV_Email;
        private Label lbQLNV_SDT;
        private Label lbQLNV_NgaySinh;
        private Label lbQLNV_HoTen;
        private Label lbQLNV_MaCN;
        private Label lbQLNV_UserID;
        private Label lbQLNV_MaNV;
        private SplitContainer splQLNV_TK_CN;
        private GroupBox grbQLNV_TK;
        private TextBox txtQLNV_TK_TenNV;
        private GroupBox grbQLNV_CN;
        private Button btnQLNV_Them;
        private Button btnQLNV_Sua;
        private Button btnQLNV_Xoa;
        private Label lbQLNV_TK_HoTen;
        private Label lbQLNV_TK_MaNV;
        private DataGridViewTextBoxColumn NV_ID;
        private DataGridViewTextBoxColumn UserID;
        private DataGridViewTextBoxColumn CN_ID;
        private DataGridViewTextBoxColumn NV_Name;
        private DataGridViewTextBoxColumn BirthDay;
        private DataGridViewTextBoxColumn Sex;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
        private ComboBox cbQLNV_MaCN;
        private ComboBox cbQLNV_UserID;
        private ComboBox cbQLNV_TK_MaNV;
        private Panel pnQLNV_TK;
        private Button btnQLNV_TK;
    }
}
