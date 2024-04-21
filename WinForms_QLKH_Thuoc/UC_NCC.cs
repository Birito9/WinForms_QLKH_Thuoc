using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPI_QLKH.Models;
using WebAPI_QLKH.Services;
using WebAPI_QLKH.StateManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FormQLKH
{
    public partial class UC_NCC : UserControl
    {
        private readonly NCCService nccService;
        public UC_NCC()
        {
            InitializeComponent();
            dgvNCC.AutoGenerateColumns = false;

            nccService = new NCCService("https://localhost:7195");

            LoadDataGridView();
            LoadComboBox();
            LoadCbTrangThai();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<NCC> dsNCC = await Task.Run(() => nccService.LayDS_NCC());

                if (dsNCC != null)
                {
                    dsNCC = dsNCC
                        .OrderBy(ncc =>
                        {
                            string numberPart = new string(ncc.NCC_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvNCC.DataSource = null;
                    dgvNCC.DataSource = dsNCC;

                    foreach (DataGridViewColumn column in dgvNCC.Columns)
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
            if (ma.StartsWith("NCC") && int.TryParse(ma.Substring(3), out int result))
            {
                return result;
            }

            return int.MaxValue;
        }
        private void dgvNCC_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvNCC.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dgvNCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNCC.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvNCC.SelectedRows[0];

                string maNCC = Convert.ToString(selectedRow.Cells["NCC_ID"].Value);
                string hoTen = Convert.ToString(selectedRow.Cells["NCC_Name"].Value);
                string sdt = Convert.ToString(selectedRow.Cells["NCC_Phone"].Value);
                string address = Convert.ToString(selectedRow.Cells["NCC_Address"].Value);
                string trangThai = Convert.ToString(selectedRow.Cells["NCC_Status"].Value);

                txtNCC_MaNCC.Text = maNCC;
                txtNCC_TenNCC.Text = hoTen;
                txtNCC_SDT.Text = sdt;
                txtNCC_DiaChi.Text = address;
                cbNCC_TrangThai.Text = trangThai;
                txtNCC_MaNCC.ReadOnly = true;
            }
        }
        private void LoadComboBox()
        {
            try
            {
                // Load cbNCC_TK_MaNCC
                List<NCC> dsNCC = nccService.LayDS_NCC();
                dsNCC = dsNCC.OrderBy(ncc => GetNumericPartOfMa(ncc.NCC_ID)).ToList();
                dsNCC.Insert(0, new NCC { NCC_ID = "All" });

                cbNCC_TK_MaNCC.DataSource = dsNCC;
                cbNCC_TK_MaNCC.DisplayMember = "NCC_ID";
                cbNCC_TK_MaNCC.ValueMember = "NCC_ID";
                cbNCC_TK_MaNCC.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsNCC.Count > 0)
                {
                    cbNCC_TK_MaNCC.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCbTrangThai()
        {
            //Load cbNCC_TrangThai
            cbNCC_TrangThai.Items.AddRange(new object[] { "Hoạt động", "Không hoạt động" });

            cbNCC_TrangThai.SelectedIndex = 0;
            cbNCC_TrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private string TaoMaNCCTuDong()
        {
            List<string> dsNCC = dgvNCC.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["NCC_ID"].Value.ToString())
                .ToList();

            for (int i = 1; i <= dsNCC.Count + 1; i++)
            {
                string maDinhDang = "NCC" + i;
                if (!dsNCC.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (dsNCC.Count > 0)
            {
                string maLonNhat = dsNCC.Max();
                if (int.TryParse(maLonNhat.Substring(4), out int so))
                {
                    return "NCC" + (so + 1).ToString();
                }
            }

            return "NCC1";
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

            foreach (DataGridViewRow row in dgvNCC.Rows)
            {
                if (row.Cells["NCC_Phone"].Value != null && row.Cells["NCC_Phone"].Value.ToString().Equals(sdt))
                {
                    return "Số điện thoại đã tồn tại.";
                }
            }

            return null;
        }
        private void btnNCC_Them_Click(object sender, EventArgs e)
        {
            string maNCC = TaoMaNCCTuDong();
            string tenNCC = txtNCC_TenNCC.Text.Trim();
            string sdt = txtNCC_SDT.Text.Trim();
            string diaChi = txtNCC_DiaChi.Text.Trim();
            string trangThai = cbNCC_TrangThai.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(tenNCC))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string errorPhone = IsValidSDT(sdt);
            if (errorPhone != null)
            {
                MessageBox.Show(errorPhone, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ncc = new List<NCC>
            {
                new NCC
                {
                    NCC_ID = maNCC,
                    NCC_Name = tenNCC,
                    NCC_Address = diaChi,
                    NCC_Phone = sdt,
                    NCC_Status = trangThai
                }
            };

            var response = nccService.ThemNCC(ncc);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm nhà cung cấp {maNCC} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm nhà cung cấp thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            foreach (DataGridViewRow row in dgvNCC.Rows)
            {
                if (row.Cells["NCC_Phone"].Value != null && row.Cells["NCC_ID"].Value != null)
                {
                    string existingPhone = row.Cells["NCC_Phone"].Value.ToString().Trim();
                    string existingID = row.Cells["NCC_ID"].Value.ToString().Trim();

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
        private void btnNCC_Sua_Click(object sender, EventArgs e)
        {
            string maNCC = txtNCC_MaNCC.Text.Trim();
            string tenNCC = txtNCC_TenNCC.Text.Trim();
            string sdt = txtNCC_SDT.Text.Trim();
            string diaChi = txtNCC_DiaChi.Text.Trim();
            string trangThai = cbNCC_TrangThai.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(tenNCC))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string errorPhone = IsValidSDT(sdt, maNCC);
            if (errorPhone != null)
            {
                MessageBox.Show(errorPhone, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật nhà cung cấp {maNCC}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var ncc = new NCC
                {
                    NCC_ID = maNCC,
                    NCC_Address = diaChi,
                    NCC_Phone = sdt,
                    NCC_Name = tenNCC,
                    NCC_Status = trangThai
                };

                var response = nccService.CapNhatNCC(maNCC, ncc);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật nhà cung cấp {maNCC} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private void SearchData(string maNCC, string hoTen)
        {
            try
            {
                List<NCC> dsNCC = nccService.LayDS_NCC();

                dsNCC = dsNCC.OrderBy(ncc =>
                {
                    string numberPart = new string(ncc.NCC_ID.Where(char.IsDigit).ToArray());
                    if (int.TryParse(numberPart, out int result))
                    {
                        return result;
                    }

                    return int.MaxValue;
                }).ToList();

                if (dsNCC != null)
                {
                    var filteredNV = dsNCC;

                    if (!string.IsNullOrEmpty(hoTen) && !maNCC.Equals("All"))
                    {
                        filteredNV = dsNCC.Where(nv =>
                            (nv.NCC_ID.Contains(maNCC)) &&
                            (nv.NCC_Name.Contains(hoTen))
                        ).ToList();
                    }
                    else if (string.IsNullOrEmpty(hoTen) && !maNCC.Equals("All"))
                    {
                        filteredNV = dsNCC.Where(nv =>
                            (nv.NCC_ID.Contains(maNCC))
                        ).ToList();
                    }
                    else if (!string.IsNullOrEmpty(hoTen) && maNCC.Equals("All"))
                    {
                        filteredNV = dsNCC.Where(nv =>
                            (nv.NCC_Name.Contains(hoTen))
                        ).ToList();
                    }
                    else if (string.IsNullOrEmpty(hoTen) && maNCC.Equals("All"))
                    {
                        LoadDataGridView();
                        return;
                    }

                    dgvNCC.DataSource = filteredNV;
                    dgvNCC.Refresh();
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
            if (cbNCC_TK_MaNCC.SelectedItem is NCC selectedNCC)
            {
                string maNCC = selectedNCC.NCC_ID;
                string hoTen = txtNCC_TK_TenNCC.Text.Trim();

                SearchData(maNCC, hoTen);
            }
        }
        private void cbNCC_TK_MaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void btnNCC_TK_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void txtNCC_TK_TenNCC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNCC_TK.PerformClick();
            }
        }
    }
}
