using FormQLKH.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPI_QLKH.Controllers;
using WebAPI_QLKH.Models;
using WebAPI_QLKH.Services;
using static WebAPI_QLKH.Controllers.TaiKhoanController;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Azure;
using WebAPI_QLKH.StateManager;
using System.Text.RegularExpressions;

namespace FormQLKH
{
    public partial class UC_QLTaiKhoan : UserControl
    {
        private readonly TaiKhoanService tKService;
        private readonly RoleService roleService;

        public UC_QLTaiKhoan()
        {
            InitializeComponent();
            dgvQLTK.AutoGenerateColumns = false;
            cbQLTK_RoleID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbQLTK_TK_RoleID.DropDownStyle = ComboBoxStyle.DropDownList;

            tKService = new TaiKhoanService("https://localhost:7195");
            roleService = new RoleService("https://localhost:7195");
            LoadComboBox();
            LoadDataGridView();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<TaiKhoan> dsTK = await Task.Run(() => tKService.LayDSTaiKhoan());

                if (dsTK != null)
                {
                    dsTK = dsTK
                        .OrderBy(tk =>
                        {
                            string numberPart = new string(tk.UserID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvQLTK.DataSource = dsTK;

                    foreach (DataGridViewColumn column in dgvQLTK.Columns)
                    {
                        column.ReadOnly = true;
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
        private void LoadComboBox()
        {
            try
            {
                // Load cbQLTK_TK_UserID
                List<TaiKhoan> dstk = tKService.LayDSTaiKhoan();
                dstk = dstk.OrderBy(tk => GetNumericPartOfMa(tk.UserID)).ToList();
                dstk.Insert(0, new TaiKhoan { UserID = "All" });

                cbQLTK_TK_UserID.DataSource = dstk;
                cbQLTK_TK_UserID.DisplayMember = "UserID";
                cbQLTK_TK_UserID.ValueMember = "UserID";
                cbQLTK_TK_UserID.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dstk.Count > 0)
                {
                    cbQLTK_TK_UserID.SelectedIndex = 0;
                }

                // Load cbQLTK_RoleID
                List<Role> danhSachRoleID = roleService.LayDanhSachRole();
                danhSachRoleID = danhSachRoleID.OrderBy(role => GetNumericPartOfMa(role.RoleID)).ToList();

                cbQLTK_RoleID.DataSource = danhSachRoleID;
                cbQLTK_RoleID.DisplayMember = "RoleID";
                cbQLTK_RoleID.ValueMember = "RoleID";
                cbQLTK_RoleID.DropDownStyle = ComboBoxStyle.DropDownList;

                if (danhSachRoleID.Count > 0)
                {
                    cbQLTK_RoleID.SelectedIndex = 0;
                }

                // Load cbQLTK_TK_RoleID
                List<Role> danhSachRoleID1 = new List<Role>(danhSachRoleID);
                danhSachRoleID1 = danhSachRoleID1.OrderBy(role => GetNumericPartOfMa(role.RoleID)).ToList();
                danhSachRoleID1.Insert(0, new Role { RoleID = "All" });

                cbQLTK_TK_RoleID.DataSource = danhSachRoleID1;
                cbQLTK_TK_RoleID.DisplayMember = "RoleID";
                cbQLTK_TK_RoleID.ValueMember = "RoleID";
                cbQLTK_TK_RoleID.DropDownStyle = ComboBoxStyle.DropDownList;

                if (danhSachRoleID1.Count > 0)
                {
                    cbQLTK_TK_RoleID.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetNumericPartOfMa(string ma)
        {
            if (ma.StartsWith("User") && int.TryParse(ma.Substring(4), out int result))
            {
                return result;
            }

            if (ma.StartsWith("Role") && int.TryParse(ma.Substring(4), out int role))
            {
                return role;
            }

            return int.MaxValue;
        }
        private void dgvQLTK_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLTK.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLTK.SelectedRows[0];

                string userID = Convert.ToString(selectedRow.Cells["UserID"].Value);
                string userName = Convert.ToString(selectedRow.Cells["UserName"].Value);
                string ghiChu = Convert.ToString(selectedRow.Cells["GhiChu"].Value);
                string roleID = Convert.ToString(selectedRow.Cells["RoleID"].Value);

                txtQLTK_UserID.Text = userID;
                txtQLTK_UserName.Text = userName;
                txtQLTK_GhiChu.Text = ghiChu;
                cbQLTK_RoleID.Text = roleID;

                txtQLTK_UserID.ReadOnly = true;
                txtQLTK_Password.Clear();
            }
        }
        private void dgvQLTK_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvQLTK.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private string TaoUserIDTuDong()
        {
            List<string> danhSachUserID = dgvQLTK.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["UserID"].Value.ToString())
                .ToList();

            for (int i = 1; i <= danhSachUserID.Count + 1; i++)
            {
                string maDinhDang = "User" + i;
                if (!danhSachUserID.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (danhSachUserID.Count > 0)
            {
                string maLonNhat = danhSachUserID.Max();
                if (int.TryParse(maLonNhat.Substring(4), out int so))
                {
                    return "User" + (so + 1).ToString();
                }
            }

            return "User1";
        }
        private string BamPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        private void txtQLTK_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
        private bool IsUserNameExists(string userName)
        {
            if (userName.Trim() != userName)
            {
                return true;
            }

            foreach (DataGridViewRow row in dgvQLTK.Rows)
            {
                if (row.Cells["UserName"].Value != null && row.Cells["UserName"].Value.ToString().Equals(userName))
                {
                    return true;
                }
            }

            return false;
        }
        private bool IsUserNameExists(string userName, string currentID)
        {
            if (userName.Trim() != userName)
            {
                return true;
            }

            bool isUserIDDuplicate = false;

            foreach (DataGridViewRow row in dgvQLTK.Rows)
            {
                if (row.Cells["UserID"].Value != null && row.Cells["UserName"].Value != null)
                {
                    string existingUserID = row.Cells["UserID"].Value.ToString().Trim();
                    string existingUserName = row.Cells["UserName"].Value.ToString().Trim();

                    if (existingUserName.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                        !existingUserID.Equals(currentID, StringComparison.OrdinalIgnoreCase))
                    {
                        isUserIDDuplicate = true;
                        break;
                    }
                }
            }

            if (isUserIDDuplicate)
            {
                return true;
            }

            return false;
        }
        private void txtQLTK_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || (!char.IsLetterOrDigit(e.KeyChar) && !IsSpecialKey(e)))
            {
                if (e.KeyChar != '\b' && e.KeyChar != '\t')
                {
                    e.Handled = true;
                }
            }
        }
        private bool IsSpecialKey(KeyPressEventArgs e)
        {
            return e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Tab ||
                   Control.ModifierKeys == Keys.Shift || Console.CapsLock;
        }
        private bool IsSpecialCharacter(char character)
        {
            string specialCharacters = "!@#$%^&*()_-+=<>?/{}[]\\|";

            return specialCharacters.Contains(character);
        }
        private void txtQLTK_UserName_TextChanged(object sender, EventArgs e)
        {
            string text = txtQLTK_UserName.Text;

            StringBuilder sanitizedText = new StringBuilder();

            foreach (char character in text)
            {
                if (!IsSpecialCharacter(character))
                {
                    sanitizedText.Append(character);
                }
            }

            string unaccentedText = sanitizedText.ToString();

            if (unaccentedText != text)
            {
                txtQLTK_UserName.Text = unaccentedText;

                txtQLTK_UserName.SelectionStart = txtQLTK_UserName.Text.Length;
            }
        }
        private void btnQLTK_Them_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string userID = TaoUserIDTuDong();
            string userName = txtQLTK_UserName.Text.Trim();
            string password = txtQLTK_Password.Text.Trim();
            string ghiChu = txtQLTK_GhiChu.Text.Trim();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsUserNameExists(userName))
            {
                MessageBox.Show("UserName đã tồn tại. Vui lòng chọn một UserName khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = BamPassword(password);

            var payloads = new List<TaiKhoan>
                {
                    new TaiKhoan
                    {
                        UserID = userID,
                        RoleID = roleID,
                        UserName = userName,
                        Password = hashedPassword,
                        Description = ghiChu
                    }
                };

            var response = tKService.ThemTaiKhoan(payloads);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm tài khoản {userID} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm tài khoản thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQLTK_Sua_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string userID = txtQLTK_UserID.Text.Trim();
            string userName = txtQLTK_UserName.Text.Trim();
            string ghiChu = txtQLTK_GhiChu.Text.Trim();
            string roleId = cbQLTK_RoleID.Text.Trim();

            if (IsUserNameExists(userName, userID))
            {
                MessageBox.Show("UserName đã tồn tại. Vui lòng chọn một UserName khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn cập nhật tài khoản {userID}?", "Xác nhận sửa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                var payload = new TaiKhoan
                {
                    UserID = userID,
                    RoleID = roleId,
                    UserName = userName,
                    Description = ghiChu
                };

                var response = tKService.CapNhatTaiKhoan(userID, payload);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật tài khoản {userID} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
        }
        private void btnQLTK_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvQLTK.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một tài khoản để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsUserID = new List<string>();
            List<string> deletedUserID = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string userID = row.Cells["UserID"].Value.ToString().Trim();
                dsUserID.Add(userID);
            }

            dsUserID = dsUserID.OrderBy(userID => int.Parse(Regex.Match(userID, @"\d+").Value)).ToList();

            string manyUserIDN = string.Join(", ", dsUserID);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản ({manyUserIDN}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string userID = row.Cells["UserID"].Value.ToString().Trim();
                        var response = tKService.XoaTaiKhoan(userID);

                        if (response.IsSuccessStatusCode)
                        {
                            deletedUserID.Add(userID);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa tài khoản {userID} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string deletedUserIDString = string.Join(", ", deletedUserID);
                    MessageBox.Show($"Xóa các tài khoản ({deletedUserIDString}) thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string userID = dsUserID[0];
                    var response = tKService.XoaTaiKhoan(userID);

                    if (response.IsSuccessStatusCode)
                    {
                        deletedUserID.Add(userID);
                        MessageBox.Show($"Xóa tài khoản {userID} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa tài khoản {userID} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private async void SearchData(string userID, string roleID)
        {
            try
            {
                List<TaiKhoan> danhSachTK = tKService.LayDSTaiKhoan();

                if (danhSachTK != null)
                {
                    var filteredTK = danhSachTK;

                    if (!userID.Equals("All") && !roleID.Equals("All"))
                    {
                        filteredTK = danhSachTK.Where(tk =>
                            (tk.UserID.Contains(userID)) &&
                            (tk.RoleID.Contains(roleID))
                        ).ToList();
                    }
                    else if (!userID.Equals("All") && roleID.Equals("All"))
                    {
                        filteredTK = danhSachTK.Where(tk =>
                            (tk.UserID.Contains(userID))
                        ).ToList();
                    }
                    else if (userID.Equals("All") && !roleID.Equals("All"))
                    {
                        filteredTK = danhSachTK.Where(tk =>
                            (tk.RoleID.Contains(roleID))
                        ).ToList();
                    }
                    else
                    {
                        LoadDataGridView();
                    }

                    dgvQLTK.DataSource = filteredTK;
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
        private void SearchByUserID_RoleID()
        {
            if (cbQLTK_TK_UserID.SelectedItem is TaiKhoan selectedTK && cbQLTK_TK_RoleID.SelectedItem is Role selectedRole)
            {
                string userID = selectedTK.UserID;
                string roleID = selectedRole.RoleID;

                SearchData(userID, roleID);
            }
        }
        private void cbQLTK_TK_RoleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByUserID_RoleID();
        }
        private void cbQLTK_TK_UserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByUserID_RoleID();
        }
    }
}
