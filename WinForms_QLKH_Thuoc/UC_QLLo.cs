using FormQLKH.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebAPI_QLKH.Controllers;
using WebAPI_QLKH.Models;
using WebAPI_QLKH.Services;
using static WebAPI_QLKH.Controllers.LoController;
using static WebAPI_QLKH.Controllers.ChiNhanhController;
using static WebAPI_QLKH.Controllers.KhoController;
using Azure;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using WebAPI_QLKH.StateManager;
using System.Text.RegularExpressions;

namespace FormQLKH
{
    public partial class UC_QLLo : UserControl
    {
        private readonly LoService loService;
        private readonly KhoService khoService;

        public UC_QLLo()
        {
            InitializeComponent();
            dgvQLLo.AutoGenerateColumns = false;

            loService = new LoService("https://localhost:7195");
            khoService = new KhoService("https://localhost:7195");

            LoadDataGridView();
            LoadComboBox();
            LoadComboViTri();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<Lo> dsLo = await Task.Run(() => loService.LayDSLo());

                if (dsLo != null)
                {
                    dsLo = dsLo
                        .OrderBy(lo =>
                        {
                            string numberPart = new string(lo.Lo_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvQLLo.DataSource = null;
                    dgvQLLo.DataSource = dsLo;

                    foreach (DataGridViewColumn column in dgvQLLo.Columns)
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
        private async void LoadComboBox()
        {
            try
            {
                // Load cbQLLo_MaKho
                List<Kho> danhSachMaKho = khoService.LayDanhSachKho();
                danhSachMaKho = danhSachMaKho.OrderBy(kho => GetNumericPartOfMa(kho.Kho_ID)).ToList();

                cbQLLo_MaKho.DataSource = danhSachMaKho;
                cbQLLo_MaKho.DisplayMember = "Kho_ID";
                cbQLLo_MaKho.ValueMember = "Kho_ID";
                cbQLLo_MaKho.DropDownStyle = ComboBoxStyle.DropDownList;

                if (danhSachMaKho.Count > 0)
                {
                    cbQLLo_MaKho.SelectedIndex = 0;
                }

                // Load cbQLLo_TK_MaKho
                List<Kho> danhSachMaKho1 = new List<Kho>(danhSachMaKho);
                danhSachMaKho1 = danhSachMaKho1.OrderBy(kho => GetNumericPartOfMa(kho.Kho_ID)).ToList();
                danhSachMaKho1.Insert(0, new Kho { Kho_ID = "All" });

                cbQLLo_TK_MaKho.DataSource = danhSachMaKho1;
                cbQLLo_TK_MaKho.DisplayMember = "Kho_ID";
                cbQLLo_TK_MaKho.ValueMember = "Kho_ID";
                cbQLLo_TK_MaKho.DropDownStyle = ComboBoxStyle.DropDownList;

                if (danhSachMaKho1.Count > 0)
                {
                    cbQLLo_TK_MaKho.SelectedIndex = 0;
                }

                // Load cbQLLo_TK_MaLo
                List<Lo> dsLo = loService.LayDSLo();
                dsLo = dsLo.OrderBy(lo => GetNumericPartOfMa(lo.Lo_ID)).ToList();
                dsLo.Insert(0, new Lo { Lo_ID = "All" });

                cbQLLo_TK_MaLo.DataSource = dsLo;
                cbQLLo_TK_MaLo.DisplayMember = "Lo_ID";
                cbQLLo_TK_MaLo.ValueMember = "Lo_ID";
                cbQLLo_TK_MaLo.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsLo.Count > 0)
                {
                    cbQLLo_TK_MaLo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboViTri()
        {
            cbQLLo_ViTri.Items.AddRange(new object[] { "A", "B", "C", "D" });

            cbQLLo_ViTri.SelectedIndex = 0;
            cbQLLo_ViTri.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private string TaoMaLoTuDong()
        {
            List<string> danhSachMaLo = dgvQLLo.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["LO_ID"].Value.ToString())
                .ToList();

            for (int i = 1; i <= danhSachMaLo.Count + 1; i++)
            {
                string maDinhDang = "Lo" + i;
                if (!danhSachMaLo.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (danhSachMaLo.Count > 0)
            {
                string maLonNhat = danhSachMaLo.Max();
                if (int.TryParse(maLonNhat.Substring(4), out int so))
                {
                    return "Lo" + (so + 1).ToString();
                }
            }

            return "Lo1";
        }
        private async void btnQLLo_Them_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm lô.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maLo = TaoMaLoTuDong();
            string maKho = cbQLLo_MaKho.Text.Trim();
            string tenLo = txtQLLo_TenLo.Text.Trim();
            string viTri = cbQLLo_ViTri.Text.Trim();

            if (string.IsNullOrEmpty(tenLo))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var payloads = new LoPost
            {
                Lo_ID = maLo,
                Kho_ID = maKho,
                Lo_Name = tenLo,
                Lo_Position = viTri
            };

            var response = await loService.ThemLo(payloads);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm lô {maLo} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm lô thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnQLLo_Sua_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật lô.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maLo = txtQLLo_MaLo.Text.Trim();
            string tenLo = txtQLLo_TenLo.Text.Trim();
            string maKho = cbQLLo_MaKho.Text.Trim();
            string viTri = cbQLLo_ViTri.Text.Trim();

            if (string.IsNullOrEmpty(tenLo))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật lô {maLo}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var lo = new Lo
                {
                    Lo_ID = maLo,
                    Lo_Name = tenLo,
                    Lo_Position = viTri,
                    Kho_ID = maKho
                };

                var response = loService.CapNhatLo(maLo, lo);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật lô {maLo} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật lô thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private async void btnQLLo_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa lô.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvQLLo.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một lô để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsMaLo = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string maLo = row.Cells["MaLo"].Value.ToString().Trim();
                dsMaLo.Add(maLo);
            }

            dsMaLo = dsMaLo.OrderBy(maLo => int.Parse(Regex.Match(maLo, @"\d+").Value)).ToList();

            string manyMaLo = string.Join(", ", dsMaLo);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa lô ({manyMaLo}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string maLo = row.Cells["MaLo"].Value.ToString().Trim();
                        var response = loService.XoaLo(maLo);

                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Xóa lô {maLo} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show($"Xóa các lô ({manyMaLo}) đã chọn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string maLo = dsMaLo[0];
                    var response = loService.XoaLo(maLo);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Xóa lô {maLo} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa lô {maLo} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void dgvQLLo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvQLLo.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dgvQLLo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLLo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLLo.SelectedRows[0];

                string maLo = Convert.ToString(selectedRow.Cells["Lo_ID"].Value);
                string maKho = Convert.ToString(selectedRow.Cells["Kho_ID"].Value);
                string tenLo = Convert.ToString(selectedRow.Cells["Lo_Name"].Value);
                string viTri = Convert.ToString(selectedRow.Cells["Lo_Position"].Value);

                txtQLLo_MaLo.Text = maLo;
                cbQLLo_ViTri.Text = viTri;
                cbQLLo_MaKho.Text = maKho;
                txtQLLo_TenLo.Text = tenLo;
                txtQLLo_MaLo.ReadOnly = true;
            }
        }
        private int GetNumericPartOfMa(string ma)
        {
            if (ma.StartsWith("Lo") && int.TryParse(ma.Substring(2), out int result))
            {
                return result;
            }

            if (ma.StartsWith("Kho") && int.TryParse(ma.Substring(3), out int cn))
            {
                return cn;
            }

            return int.MaxValue;
        }
        private async void SearchData(string maKho, string maLo)
        {
            try
            {
                List<Lo> danhSachLo = loService.LayDSLo();

                if (danhSachLo != null)
                {
                    var filteredLo = danhSachLo;

                    if (!maKho.Equals("All") && !maLo.Equals("All"))
                    {
                        filteredLo = danhSachLo.Where(lo =>
                            (lo.Kho_ID.Contains(maKho)) &&
                            (lo.Lo_ID.Contains(maLo))
                        ).ToList();
                    }
                    else if (!maLo.Equals("All") && maKho.Equals("All"))
                    {
                        filteredLo = danhSachLo.Where(lo =>
                            (lo.Lo_ID.Contains(maLo))
                        ).ToList();
                    }
                    else if (maLo.Equals("All") && !maKho.Equals("All"))
                    {
                        filteredLo = danhSachLo.Where(lo =>
                            (lo.Kho_ID.Contains(maKho))
                        ).ToList();
                    }
                    else
                    {
                        LoadDataGridView();
                    }
                    dgvQLLo.DataSource = filteredLo;
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
        private void SearchByMaKho_MaLo()
        {
            if (cbQLLo_TK_MaLo.SelectedItem is Lo selectedLo && cbQLLo_TK_MaKho.SelectedItem is Kho selectedKho)
            {
                string maLo = selectedLo.Lo_ID;
                string maKho = selectedKho.Kho_ID;

                SearchData(maKho, maLo);
            }
        }
        private void cbQLLo_TK_MaKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMaKho_MaLo();
        }
        private void cbQLLo_TK_MaLo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMaKho_MaLo();
        }
    }
}
