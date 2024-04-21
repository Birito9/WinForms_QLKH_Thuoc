using FormQLKH.Services;
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

namespace FormQLKH
{
    public partial class UC_QLNhomThuoc : UserControl
    {
        private readonly NThuocService nThuocService;
        public UC_QLNhomThuoc()
        {
            InitializeComponent();
            dgvQLNT.AutoGenerateColumns = false;

            nThuocService = new NThuocService("https://localhost:7195");

            LoadDataGridView();
            LoadComboBox();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<NhomThuoc> dsNT = await Task.Run(() => nThuocService.LayDSNT());

                if (dsNT != null)
                {
                    dsNT = dsNT
                        .OrderBy(nt =>
                        {
                            string numberPart = new string(nt.Nhom_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvQLNT.DataSource = null;
                    dgvQLNT.DataSource = dsNT;

                    foreach (DataGridViewColumn column in dgvQLNT.Columns)
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
        private int GetNumericPartOfMa(string ma)
        {
            if (ma.StartsWith("Nhom") && int.TryParse(ma.Substring(4), out int result))
            {
                return result;
            }

            return int.MaxValue;
        }
        private void dgvQLNT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvQLNT.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dgvQLNT_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLNT.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLNT.SelectedRows[0];

                string maNhom = Convert.ToString(selectedRow.Cells["Nhom_ID"].Value);
                string tenNhom = Convert.ToString(selectedRow.Cells["Nhom_Name"].Value);
                string ghiChu = Convert.ToString(selectedRow.Cells["Description"].Value);

                txtQLNT_MaNhom.ReadOnly = true;
                txtQLNT_MaNhom.Text = maNhom;
                txtQLNT_TenNhom.Text = tenNhom;
                txtQLNT_GhiChu.Text = ghiChu;
            }
        }
        private void LoadComboBox()
        {
            try
            {
                // Load cbQLNT_TK_MaNhom
                List<NhomThuoc> dsNT = nThuocService.LayDSNT();
                dsNT = dsNT.OrderBy(nt => GetNumericPartOfMa(nt.Nhom_ID)).ToList();
                dsNT.Insert(0, new NhomThuoc { Nhom_ID = "All" });

                cbQLNT_TK_MaNhom.DataSource = dsNT;
                cbQLNT_TK_MaNhom.DisplayMember = "Nhom_ID";
                cbQLNT_TK_MaNhom.ValueMember = "Nhom_ID";
                cbQLNT_TK_MaNhom.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsNT.Count > 0)
                {
                    cbQLNT_TK_MaNhom.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string TaoMaNTTuDong()
        {
            List<string> dsNT = dgvQLNT.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["Nhom_ID"].Value.ToString())
                .ToList();

            for (int i = 1; i <= dsNT.Count + 1; i++)
            {
                string maDinhDang = "Nhom" + i;
                if (!dsNT.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (dsNT.Count > 0)
            {
                string maLonNhat = dsNT.Max();
                if (int.TryParse(maLonNhat.Substring(2), out int so))
                {
                    return "Nhom" + (so + 1).ToString();
                }
            }

            return "DX1";
        }
        private void btnQLNT_Them_Click(object sender, EventArgs e)
        {
            string maNhom = TaoMaNTTuDong();
            string tenNhom = txtQLNT_TenNhom.Text.Trim();
            string ghiChu = txtQLNT_GhiChu.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm nhóm thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tenNhom))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var nt = new List<NhomThuoc>
            {
                new NhomThuoc
                {
                    Nhom_ID = maNhom,
                    Nhom_Name = tenNhom,
                    Description = ghiChu
                }
            };

            var response = nThuocService.ThemNT(nt);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm nhóm thuốc {maNhom} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm nhóm thuốc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQLNT_Sua_Click(object sender, EventArgs e)
        {
            string maNhom = txtQLNT_MaNhom.Text.Trim();
            string tenNhom = txtQLNT_TenNhom.Text.Trim();
            string ghiChu = txtQLNT_GhiChu.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật nhóm thuốc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tenNhom))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật nhóm thuốc {maNhom}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var dx = new NhomThuoc
                {
                    Nhom_ID = maNhom,
                    Nhom_Name = tenNhom,
                    Description = ghiChu
                };

                var response = nThuocService.CapNhatNT(maNhom, dx);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật nhóm thuốc {maNhom} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhóm thuốc thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private void btnQLNT_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa nhóm thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvQLNT.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nhóm thuốc để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsMaNT = new List<string>();
            List<string> deletedMaNT = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string maNT = row.Cells["Nhom_ID"].Value.ToString().Trim();
                dsMaNT.Add(maNT);
            }

            dsMaNT = dsMaNT.OrderBy(maNT => int.Parse(Regex.Match(maNT, @"\d+").Value)).ToList();

            string manyMaNT = string.Join(", ", dsMaNT);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhóm thuốc ({manyMaNT}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string maNT = row.Cells["Nhom_ID"].Value.ToString().Trim();
                        var response = nThuocService.XoaNT(maNT);

                        if (response.IsSuccessStatusCode)
                        {
                            deletedMaNT.Add(maNT);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa nhóm thuốc {maNT} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string deletedMaNTString = string.Join(", ", deletedMaNT);
                    MessageBox.Show($"Xóa các nhóm thuốc ({deletedMaNTString}) thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string maNT = dsMaNT[0];
                    var response = nThuocService.XoaNT(maNT);

                    if (response.IsSuccessStatusCode)
                    {
                        deletedMaNT.Add(maNT);
                        MessageBox.Show($"Xóa nhóm thuốc {maNT} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa nhóm thuốc {maNT} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SearchData(string maNhom, string tenNhom)
        {
            try
            {
                List<NhomThuoc> dsNT = nThuocService.LayDSNT();

                dsNT = dsNT.OrderBy(nt =>
                {
                    string numberPart = new string(nt.Nhom_ID.Where(char.IsDigit).ToArray());
                    if (int.TryParse(numberPart, out int result))
                    {
                        return result;
                    }

                    return int.MaxValue;
                }).ToList();

                if (dsNT != null)
                {
                    var filteredNT = dsNT;

                    if (!string.IsNullOrEmpty(tenNhom) && !maNhom.Equals("All"))
                    {
                        filteredNT = dsNT.Where(nt =>
                            (nt.Nhom_ID.Contains(maNhom)) &&
                            (!string.IsNullOrEmpty(tenNhom) || nt.Nhom_Name.Contains(tenNhom))
                        ).ToList();
                    }
                    else if (string.IsNullOrEmpty(tenNhom) && !maNhom.Equals("All"))
                    {
                        filteredNT = dsNT.Where(nt =>
                            (nt.Nhom_ID.Contains(maNhom))
                        ).ToList();
                    }
                    else if (!string.IsNullOrEmpty(tenNhom) && maNhom.Equals("All"))
                    {
                        filteredNT = dsNT.Where(nt =>
                            (string.IsNullOrEmpty(tenNhom) || nt.Nhom_Name.Contains(tenNhom))
                        ).ToList();
                    }
                    else if (string.IsNullOrEmpty(tenNhom) && maNhom.Equals("All"))
                    {
                        LoadDataGridView();
                    }

                    dgvQLNT.DataSource = filteredNT;
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
            if (cbQLNT_TK_MaNhom.SelectedItem is NhomThuoc selectedNT)
            {
                string maNhom = selectedNT.Nhom_ID;
                string tenNhom = txtQLNT_TK_TenNhom.Text.Trim();

                SearchData(maNhom, tenNhom);
            }
        }
        private void cbQLNT_TK_MaNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void btnQLNT_TK_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void txtQLNT_TK_TenNhom_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnQLNT_TK.PerformClick();
            }
        }
    }
}
