using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FormQLKH.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using WebAPI_QLKH.Models;
using WebAPI_QLKH.Services;
using WebAPI_QLKH.StateManager;
using static WebAPI_QLKH.Controllers.ChiNhanhController;

namespace FormQLKH
{
    public partial class UC_QLChiNhanh : UserControl
    {
        private readonly ChiNhanhService chiNhanhService;
        public UC_QLChiNhanh()
        {
            InitializeComponent();
            dgvQLCN.AutoGenerateColumns = false;

            chiNhanhService = new ChiNhanhService("https://localhost:7195");
            LoadDataGridView();
            LoadComboBox();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<ChiNhanh> danhSachChiNhanh = await Task.Run(() => chiNhanhService.LayDanhSachChiNhanh());

                if (danhSachChiNhanh != null)
                {
                    danhSachChiNhanh = danhSachChiNhanh
                        .OrderBy(cn =>
                        {
                            string numberPart = new string(cn.CN_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvQLCN.DataSource = null;
                    dgvQLCN.DataSource = danhSachChiNhanh;

                    foreach (DataGridViewColumn column in dgvQLCN.Columns)
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
        private void dgvQLCN_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLCN.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLCN.SelectedRows[0];

                string maCN = Convert.ToString(selectedRow.Cells["MaCN"].Value);
                string tenCN = Convert.ToString(selectedRow.Cells["TenCN"].Value);
                string diaChi = Convert.ToString(selectedRow.Cells["DiaChi"].Value);

                txtQLCN_MaCN.Text = maCN;
                txtQLCN_TenCN.Text = tenCN;
                txtQLCN_DiaChi.Text = diaChi;

                txtQLCN_MaCN.ReadOnly = true;
            }
        }
        private string TaoMaCNTuDong()
        {
            List<string> danhSachMaCN = dgvQLCN.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["MaCN"].Value.ToString())
                .ToList();

            for (int i = 1; i <= danhSachMaCN.Count + 1; i++)
            {
                string maDinhDang = "CN" + i;
                if (!danhSachMaCN.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (danhSachMaCN.Count > 0)
            {
                string maLonNhat = danhSachMaCN.Max();
                if (int.TryParse(maLonNhat.Substring(4), out int so))
                {
                    return "CN" + (so + 1).ToString();
                }
            }

            return "CN1";
        }
        private async void btnQLCN_Them_Click(object sender, EventArgs e)
        {
            string maCN = TaoMaCNTuDong();
            string tenCN = txtQLCN_TenCN.Text.Trim();
            string diaChi = txtQLCN_DiaChi.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm chi nhánh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(maCN) || string.IsNullOrEmpty(tenCN) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var payloads = new List<ChiNhanhPost>
            {
                new ChiNhanhPost
                {
                    CN_ID = maCN,
                    CN_Name = tenCN,
                    CN_Address = diaChi
                }
            };

            var response = chiNhanhService.ThemChiNhanh(payloads);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm chi nhánh {maCN} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await Task.Delay(1000);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm chi nhánh thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQLCN_Sua_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật chi nhánh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maCN = txtQLCN_MaCN.Text.Trim();
            string tenCN = txtQLCN_TenCN.Text.Trim();
            string diaChi = txtQLCN_DiaChi.Text.Trim();

            if (string.IsNullOrEmpty(maCN) || string.IsNullOrEmpty(tenCN) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật chi nhánh {maCN}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var payload = new ChiNhanhPost
                {
                    CN_ID = maCN,
                    CN_Name = tenCN,
                    CN_Address = diaChi
                };

                var response = chiNhanhService.CapNhatChiNhanh(maCN, payload);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật chi nhánh {maCN} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật chi nhánh thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private void btnQLCN_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa chi nhánh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvQLCN.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một chi nhánh để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsMaCN = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string maCN = row.Cells["MaCN"].Value.ToString().Trim();
                dsMaCN.Add(maCN);
            }

            dsMaCN = dsMaCN.OrderBy(maCN => int.Parse(Regex.Match(maCN, @"\d+").Value)).ToList();

            string manyMaCN = string.Join(", ", dsMaCN);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa chi nhánh ({manyMaCN}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string maCN = row.Cells["MaCN"].Value.ToString().Trim();
                        var response = chiNhanhService.XoaChiNhanh(maCN);

                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Xóa chi nhánh {maCN} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show($"Xóa các chi nhánh ({manyMaCN}) đã chọn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string maCN = dsMaCN[0];
                    var response = chiNhanhService.XoaChiNhanh(maCN);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Xóa chi nhánh {maCN} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa chi nhánh {maCN} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void dgvQLCN_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvQLCN.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private int GetNumericPartOfMa(string maCN)
        {
            if (maCN.StartsWith("CN") && int.TryParse(maCN.Substring(2), out int cn))
            {
                return cn;
            }

            return int.MaxValue;
        }
        private void LoadComboBox()
        {
            try
            {
                List<ChiNhanh> dsCN = chiNhanhService.LayDanhSachChiNhanh();
                dsCN = dsCN.OrderBy(cn => GetNumericPartOfMa(cn.CN_ID)).ToList();
                dsCN.Insert(0, new ChiNhanh { CN_ID = "All" });

                // Load cbQLCN_TK_MaCN
                cbQLCN_TK_MaCN.DataSource = dsCN;
                cbQLCN_TK_MaCN.DisplayMember = "CN_ID";
                cbQLCN_TK_MaCN.ValueMember = "CN_ID";
                cbQLCN_TK_MaCN.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsCN.Count > 0)
                {
                    cbQLCN_TK_MaCN.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SearchData(string maCN)
        {
            try
            {
                List<ChiNhanh> dsCN = chiNhanhService.LayDanhSachChiNhanh();

                if (dsCN != null)
                {
                    var filteredCN = dsCN;

                    if (maCN.Equals("All"))
                    {
                        LoadDataGridView();
                    }
                    else
                    {
                        filteredCN = dsCN.Where(cn =>
                        (string.IsNullOrEmpty(maCN) || cn.CN_ID.Contains(maCN))
                    ).ToList();
                    }

                    dgvQLCN.DataSource = filteredCN;
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
        private void cbQLCN_TK_MaCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQLCN_TK_MaCN.SelectedItem is ChiNhanh selectedCN)
            {
                string selectedValue = selectedCN.CN_ID;

                SearchData(selectedValue);
            }
        }
    }
}
