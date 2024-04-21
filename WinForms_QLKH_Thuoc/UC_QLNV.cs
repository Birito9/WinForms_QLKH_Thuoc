using FormQLKH.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPI_QLKH.Models;
using WebAPI_QLKH.Services;
using WebAPI_QLKH.StateManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static WebAPI_QLKH.Controllers.KhoController;
using static WebAPI_QLKH.Controllers.NhanVienController;

namespace FormQLKH
{
    public partial class UC_QLNV : UserControl
    {
        private readonly NhanVienService nvService;
        private readonly TaiKhoanService tkService;
        private readonly ChiNhanhService cnService;
        public UC_QLNV()
        {
            InitializeComponent();
            dgvNV.AutoGenerateColumns = false;

            nvService = new NhanVienService("https://localhost:7195");
            tkService = new TaiKhoanService("https://localhost:7195");
            cnService = new ChiNhanhService("https://localhost:7195");

            LoadDataGridView();
            LoadComboBox();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<NhanVien> dsnv = await Task.Run(() => nvService.LayDSNV());

                if (dsnv != null)
                {
                    dsnv = dsnv
                        .OrderBy(nv =>
                        {
                            string numberPart = new string(nv.NV_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvNV.DataSource = null;
                    dgvNV.DataSource = dsnv;

                    foreach (DataGridViewColumn column in dgvNV.Columns)
                    {
                        column.ReadOnly = true;
                        dgvNV.Columns["BirthDay"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy dữ liệu từ API.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvNV.SelectedRows[0];

                string userID = Convert.ToString(selectedRow.Cells["UserID"].Value);
                string maNV = Convert.ToString(selectedRow.Cells["NV_ID"].Value);
                string maCN = Convert.ToString(selectedRow.Cells["CN_ID"].Value);
                string hoTen = Convert.ToString(selectedRow.Cells["NV_Name"].Value);
                DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells["BirthDay"].Value);
                string sdt = Convert.ToString(selectedRow.Cells["Phone"].Value);
                string email = Convert.ToString(selectedRow.Cells["Email"].Value);
                string address = Convert.ToString(selectedRow.Cells["Address"].Value);
                string gioiTinh = Convert.ToString(selectedRow.Cells["Sex"].Value).Trim();

                if (gioiTinh == "Nam")
                {
                    rdbQLNV_Nam.Checked = true;
                    rdbQLNV_Nu.Checked = false;
                }
                else if (gioiTinh == "Nữ")
                {
                    rdbQLNV_Nu.Checked = true;
                    rdbQLNV_Nam.Checked = false;
                }

                cbQLNV_UserID.Text = userID;
                txtQLNV_HoTen.Text = hoTen;
                txtQLNV_MaNV.Text = maNV;
                cbQLNV_MaCN.Text = maCN;
                if (ngaySinh >= dtpQLNV_NgaySinh.MinDate && ngaySinh <= dtpQLNV_NgaySinh.MaxDate)
                {
                    dtpQLNV_NgaySinh.Value = ngaySinh;
                }
                else
                {
                    MessageBox.Show("Giá trị ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtQLNV_SDT.Text = sdt;
                txtQLNV_Email.Text = email;
                txtQLNV_DiaChi.Text = address;
                txtQLNV_MaNV.ReadOnly = true;
            }
        }
        private void dgvNV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvNV.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void LoadComboBox()
        {
            try
            {
                // Load cbQLNV_UserID
                List<TaiKhoan> dstk = tkService.LayDSTaiKhoan();
                dstk = dstk.OrderBy(tk => GetNumericPartOfMa(tk.UserID)).ToList();

                cbQLNV_UserID.DataSource = dstk;
                cbQLNV_UserID.DisplayMember = "UserID";
                cbQLNV_UserID.ValueMember = "UserID";
                cbQLNV_UserID.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dstk.Count > 0)
                {
                    cbQLNV_UserID.SelectedIndex = 0;
                }

                // Load cbQLNV_MaCN
                List<ChiNhanh> dscn = cnService.LayDanhSachChiNhanh();
                dscn = dscn.OrderBy(cn => GetNumericPartOfMa(cn.CN_ID)).ToList();

                cbQLNV_MaCN.DataSource = dscn;
                cbQLNV_MaCN.DisplayMember = "CN_ID";
                cbQLNV_MaCN.ValueMember = "CN_ID";
                cbQLNV_MaCN.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dscn.Count > 0)
                {
                    cbQLNV_MaCN.SelectedIndex = 0;
                }

                //Load cbQLNV_TK_MaNV
                List<NhanVien> dsnv = nvService.LayDSNV();
                dsnv = dsnv.OrderBy(nv => GetNumericPartOfMa(nv.NV_ID)).ToList();
                dsnv.Insert(0, new NhanVien { NV_ID = "All" });

                cbQLNV_TK_MaNV.DataSource = dsnv;
                cbQLNV_TK_MaNV.DisplayMember = "NV_ID";
                cbQLNV_TK_MaNV.ValueMember = "NV_ID";
                cbQLNV_TK_MaNV.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsnv.Count > 0)
                {
                    cbQLNV_TK_MaNV.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string TaoMaNVTuDong()
        {
            List<string> danhSachMaNV = dgvNV.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["NV_ID"].Value.ToString())
                .ToList();

            for (int i = 1; i <= danhSachMaNV.Count + 1; i++)
            {
                string maDinhDang = "NV" + i;
                if (!danhSachMaNV.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (danhSachMaNV.Count > 0)
            {
                string maLonNhat = danhSachMaNV.Max();
                if (int.TryParse(maLonNhat.Substring(4), out int so))
                {
                    return "NV" + (so + 1).ToString();
                }
            }

            return "NV1";
        }
        private int GetNumericPartOfMa(string ma)
        {
            if (ma.StartsWith("NV") && int.TryParse(ma.Substring(2), out int result))
            {
                return result;
            }

            if (ma.StartsWith("User") && int.TryParse(ma.Substring(4), out int user))
            {
                return user;
            }

            if (ma.StartsWith("CN") && int.TryParse(ma.Substring(2), out int role))
            {
                return role;
            }

            return int.MaxValue;
        }
        public string IsValidSDT(string sdt)
        {
            if (sdt.Length != 10)
            {
                return "Số điện thoại phải có đúng 10 chữ số.";
            }

            if (!sdt.All(char.IsDigit))
            {
                return "Số điện thoại chỉ được chứa chữ số.";
            }

            if (sdt[0] != '0')
            {
                return "Số điện thoại phải bắt đầu bằng số 0.";
            }

            foreach (DataGridViewRow row in dgvNV.Rows)
            {
                if (row.Cells["Phone"].Value != null && row.Cells["Phone"].Value.ToString().Equals(sdt))
                {
                    return "Số điện thoại đã tồn tại.";
                }
            }

            return null;
        }
        private void txtQLNV_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == '\t' || e.KeyChar == '\n')
            {
                e.Handled = true;
            }
        }
        public string IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (!Regex.IsMatch(email, pattern))
            {
                return "Email phải đúng định dạng (example@gmail.com)";
            }

            foreach (DataGridViewRow row in dgvNV.Rows)
            {
                if (row.Cells["Email"].Value != null && row.Cells["Email"].Value.ToString().Equals(email))
                {
                    return "Email đã tồn tại.";
                }
            }

            return null;
        }
        private void txtQLNV_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == '\t' || e.KeyChar == '\n')
            {
                e.Handled = true;
            }
        }
        public string IsValidUserID(string userID)
        {
            foreach (DataGridViewRow row in dgvNV.Rows)
            {
                if (row.Cells["UserID"].Value != null && row.Cells["UserID"].Value.ToString().Trim().Equals(userID.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return "UserID đã tồn tại.";
                }
            }

            return null;
        }
        private void btnQLNV_Them_Click(object sender, EventArgs e)
        {
            string maNV = TaoMaNVTuDong();
            string diaChi = txtQLNV_DiaChi.Text.Trim();
            string email = txtQLNV_Email.Text.Trim();
            string hoTen = txtQLNV_HoTen.Text.Trim();
            string sdt = txtQLNV_SDT.Text.Trim();
            string maCN = cbQLNV_MaCN.Text.Trim();
            string userID = cbQLNV_UserID.Text.Trim();
            DateTime ngaySinh = dtpQLNV_NgaySinh.Value;
            string gtNam = rdbQLNV_Nam.Checked ? rdbQLNV_Nam.Text.Trim() : string.Empty;
            string gtNu = rdbQLNV_Nu.Checked ? rdbQLNV_Nu.Text.Trim() : string.Empty;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DateTime minDate = new DateTime(1990, 1, 1);
            DateTime maxDate = new DateTime(2006, 1, 1);

            if (ngaySinh <= minDate || ngaySinh >= maxDate)
            {
                MessageBox.Show("Chọn ngày từ " + minDate.ToShortDateString() + " đến " + maxDate.ToShortDateString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpQLNV_NgaySinh.Value = DateTime.Now.AddDays(-1);
                return;
            }

            string errorPhone = IsValidSDT(sdt);
            if (errorPhone != null)
            {
                MessageBox.Show(errorPhone, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string errorEmail = IsValidEmail(email);
            if (errorEmail != null)
            {
                MessageBox.Show(errorEmail, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string errorUserID = IsValidUserID(userID);
            if (errorUserID != null)
            {
                MessageBox.Show(errorUserID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nv = new List<NhanVien>
            {
                new NhanVien
                {
                    CN_ID = maCN,
                    BirthDay = ngaySinh,
                    NV_Name = hoTen,
                    Address = diaChi,
                    NV_ID = maNV,
                    UserID = userID,
                    Phone  = sdt,
                    Email = email,
                    Sex = string.IsNullOrEmpty(gtNam) ? gtNu : gtNam
                }
            };

            var response = nvService.ThemNV(nv);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm nhân viên {maNV} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string IsValidUserID(string userID, string currentID)
        {
            bool isUserIDDuplicate = false;

            foreach (DataGridViewRow row in dgvNV.Rows)
            {
                if (row.Cells["UserID"].Value != null && row.Cells["NV_ID"].Value != null)
                {
                    string existingUserID = row.Cells["UserID"].Value.ToString().Trim();
                    string existingID = row.Cells["NV_ID"].Value.ToString().Trim();

                    if (existingUserID.Equals(userID, StringComparison.OrdinalIgnoreCase) &&
                        !existingID.Equals(currentID, StringComparison.OrdinalIgnoreCase))
                    {
                        isUserIDDuplicate = true;
                        break;
                    }
                }
            }

            if (isUserIDDuplicate)
            {
                return "UserID đã tồn tại.";
            }

            return null;
        }
        public string IsValidEmail(string email, string currentID)
        {
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (!Regex.IsMatch(email, pattern))
            {
                return "Email phải đúng định dạng (example@gmail.com)";
            }

            bool isEmailDuplicate = false;

            foreach (DataGridViewRow row in dgvNV.Rows)
            {
                if (row.Cells["Email"].Value != null && row.Cells["NV_ID"].Value != null)
                {
                    string existingEmail = row.Cells["Email"].Value.ToString().Trim();
                    string existingID = row.Cells["NV_ID"].Value.ToString().Trim();

                    if (existingEmail.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                        !existingID.Equals(currentID, StringComparison.OrdinalIgnoreCase))
                    {
                        isEmailDuplicate = true;
                        break;
                    }
                }
            }

            if (isEmailDuplicate)
            {
                return "Email đã tồn tại.";
            }

            return null;
        }
        public string IsValidSDT(string sdt, string currentID)
        {
            if (sdt.Length != 10)
            {
                return "Số điện thoại phải có đúng 10 chữ số.";
            }

            if (!sdt.All(char.IsDigit))
            {
                return "Số điện thoại chỉ được chứa chữ số.";
            }

            if (sdt[0] != '0')
            {
                return "Số điện thoại phải bắt đầu bằng số 0.";
            }

            bool isPhoneDuplicate = false;

            foreach (DataGridViewRow row in dgvNV.Rows)
            {
                if (row.Cells["Phone"].Value != null && row.Cells["NV_ID"].Value != null)
                {
                    string existingPhone = row.Cells["Phone"].Value.ToString().Trim();
                    string existingID = row.Cells["NV_ID"].Value.ToString().Trim();

                    if (existingPhone.Equals(sdt, StringComparison.OrdinalIgnoreCase) &&
                        !existingID.Equals(currentID, StringComparison.OrdinalIgnoreCase))
                    {
                        isPhoneDuplicate = true;
                        break;
                    }
                }
            }

            if (isPhoneDuplicate)
            {
                return "Số điện thoại đã tồn tại.";
            }

            return null;
        }
        private void btnQLNV_Sua_Click(object sender, EventArgs e)
        {
            string maNV = txtQLNV_MaNV.Text.Trim();
            string diaChi = txtQLNV_DiaChi.Text.Trim();
            string email = txtQLNV_Email.Text.Trim();
            string hoTen = txtQLNV_HoTen.Text.Trim();
            string sdt = txtQLNV_SDT.Text.Trim();
            string maCN = cbQLNV_MaCN.Text.Trim();
            string userID = cbQLNV_UserID.Text.Trim();
            DateTime ngaySinh = dtpQLNV_NgaySinh.Value;
            string gtNam = rdbQLNV_Nam.Checked ? rdbQLNV_Nam.Text.Trim() : string.Empty;
            string gtNu = rdbQLNV_Nu.Checked ? rdbQLNV_Nu.Text.Trim() : string.Empty;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string errorPhone = IsValidSDT(sdt, maNV);
            if (errorPhone != null)
            {
                MessageBox.Show(errorPhone, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string errorEmail = IsValidEmail(email, maNV);
            if (errorEmail != null)
            {
                MessageBox.Show(errorEmail, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string errorUserID = IsValidUserID(userID, maNV);
            if (errorUserID != null)
            {
                MessageBox.Show(errorUserID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật nhân viên {maNV}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var nv = new NhanVien
                {
                    CN_ID = maCN,
                    BirthDay = ngaySinh,
                    NV_Name = hoTen,
                    Address = diaChi,
                    NV_ID = maNV,
                    UserID = userID,
                    Email = email,
                    Phone = sdt,
                    Sex = string.IsNullOrEmpty(gtNam) ? gtNu : gtNam
                };

                var response = nvService.CapNhatNV(maNV, nv);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật nhân viên {maNV} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private void btnQLNV_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvNV.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nhân viên để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsMaNV = new List<string>();
            List<string> deletedMaNV = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string maNV = row.Cells["NV_ID"].Value.ToString().Trim();
                dsMaNV.Add(maNV);
            }

            dsMaNV = dsMaNV.OrderBy(maNV => int.Parse(Regex.Match(maNV, @"\d+").Value)).ToList();

            string manyUserID = string.Join(", ", dsMaNV);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên ({manyUserID}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string maNV = row.Cells["NV_ID"].Value.ToString().Trim();
                        var response = nvService.XoaNV(maNV);

                        if (response.IsSuccessStatusCode)
                        {
                            deletedMaNV.Add(maNV);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa nhân viên {maNV} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string deletedMaNVString = string.Join(", ", deletedMaNV);
                    MessageBox.Show($"Xóa các nhân viên ({deletedMaNVString}) thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string maNV = dsMaNV[0];
                    var response = nvService.XoaNV(maNV);

                    if (response.IsSuccessStatusCode)
                    {
                        deletedMaNV.Add(maNV);
                        MessageBox.Show($"Xóa nhân viên {maNV} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa nhân viên {maNV} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SearchData(string maNV, string hoTen)
        {
            try
            {
                List<NhanVien> dsnv = nvService.LayDSNV();

                dsnv = dsnv.OrderBy(nv =>
                {
                    string numberPart = new string(nv.NV_ID.Where(char.IsDigit).ToArray());
                    if (int.TryParse(numberPart, out int result))
                    {
                        return result;
                    }

                    return int.MaxValue;
                }).ToList();

                if (dsnv != null)
                {
                    var filteredNV = dsnv;

                    if (!string.IsNullOrEmpty(hoTen) && !maNV.Equals("All"))
                    {
                        filteredNV = dsnv.Where(nv =>
                            (nv.NV_ID.Contains(maNV)) &&
                            (nv.NV_Name.Contains(hoTen))
                        ).ToList();
                    }
                    else if (string.IsNullOrEmpty(hoTen) && !maNV.Equals("All"))
                    {
                        filteredNV = dsnv.Where(nv =>
                            (nv.NV_ID.Contains(maNV))
                        ).ToList();
                    }
                    else if (!string.IsNullOrEmpty(hoTen) && maNV.Equals("All"))
                    {
                        filteredNV = dsnv.Where(nv =>
                            (nv.NV_Name.Contains(hoTen))
                        ).ToList();
                    }
                    else if (string.IsNullOrEmpty(hoTen) && maNV.Equals("All"))
                    {
                        LoadDataGridView();
                    }

                    dgvNV.DataSource = filteredNV;
                }
                else
                {
                    MessageBox.Show("Không thể lấy dữ liệu từ API.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PerformSearch()
        {
            if (cbQLNV_TK_MaNV.SelectedItem is NhanVien selectedNV)
            {
                string maNV = selectedNV.NV_ID;
                string hoTen = txtQLNV_TK_TenNV.Text.Trim();

                SearchData(maNV, hoTen);
            }
        }
        private void cbQLNV_TK_MaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void btnQLNV_TK_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void txtQLNV_TK_TenNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnQLNV_TK.PerformClick();
            }
        }
    }
}
