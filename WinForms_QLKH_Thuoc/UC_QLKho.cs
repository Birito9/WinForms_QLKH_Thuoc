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
using WebAPI_QLKH.Models;
using static WebAPI_QLKH.Controllers.KhoController;
using WebAPI_QLKH.Services;
using static WebAPI_QLKH.Controllers.ChiNhanhController;
using WebAPI_QLKH.StateManager;
using System.Text.RegularExpressions;

namespace FormQLKH
{
    public partial class UC_QLKho : UserControl
    {
        private readonly KhoService khoService;
        private readonly ChiNhanhService chiNhanhService;
        public UC_QLKho()
        {
            InitializeComponent();

            dgvQLK.AutoGenerateColumns = false;
            cbQLK_MaCN.DropDownStyle = ComboBoxStyle.DropDownList;

            khoService = new KhoService("https://localhost:7195");
            chiNhanhService = new ChiNhanhService("https://localhost:7195");
            LoadComboBox();
            LoadDataGridView();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<Kho> dsKho = await Task.Run(() => khoService.LayDanhSachKho());

                if (dsKho != null)
                {
                    dsKho = dsKho
                        .OrderBy(kho =>
                        {
                            string numberPart = new string(kho.Kho_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvQLK.DataSource = null;
                    dgvQLK.DataSource = dsKho;

                    foreach (DataGridViewColumn column in dgvQLK.Columns)
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
                //Load cbQLK_TK_MaKho
                List<Kho> dsKho = khoService.LayDanhSachKho();
                dsKho = dsKho.OrderBy(kho => GetNumericPartOfMa(kho.Kho_ID)).ToList();
                dsKho.Insert(0, new Kho { Kho_ID = "All" });

                cbQLK_TK_MaKho.DataSource = dsKho;
                cbQLK_TK_MaKho.DisplayMember = "Kho_ID";
                cbQLK_TK_MaKho.ValueMember = "Kho_ID";
                cbQLK_TK_MaKho.DropDownStyle = ComboBoxStyle.DropDownList;

                // Load cbQLK_MaCN
                List<ChiNhanh> danhSachMaCN = chiNhanhService.LayDanhSachChiNhanh();
                danhSachMaCN = danhSachMaCN.OrderBy(cn => GetNumericPartOfMa(cn.CN_ID)).ToList();

                cbQLK_MaCN.DataSource = danhSachMaCN;
                cbQLK_MaCN.DisplayMember = "CN_ID";
                cbQLK_MaCN.ValueMember = "CN_ID";
                cbQLK_MaCN.DropDownStyle = ComboBoxStyle.DropDownList;

                if (danhSachMaCN.Count > 0)
                {
                    cbQLK_MaCN.SelectedIndex = 0;
                }

                // Load cbQLK_TK_MaCN
                List<ChiNhanh> danhSachMaCN1 = new List<ChiNhanh>(danhSachMaCN);
                danhSachMaCN1 = danhSachMaCN1.OrderBy(cn => GetNumericPartOfMa(cn.CN_ID)).ToList();
                danhSachMaCN1.Insert(0, new ChiNhanh { CN_ID = "All" });

                cbQLK_TK_MaCN.DataSource = danhSachMaCN1;
                cbQLK_TK_MaCN.DisplayMember = "CN_ID";
                cbQLK_TK_MaCN.ValueMember = "CN_ID";
                cbQLK_TK_MaCN.DropDownStyle = ComboBoxStyle.DropDownList;

                if (danhSachMaCN1.Count > 0)
                {
                    cbQLK_TK_MaCN.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetNumericPartOfMa(string ma)
        {
            if (ma.StartsWith("Kho") && int.TryParse(ma.Substring(3), out int result))
            {
                return result;
            }

            if (ma.StartsWith("CN") && int.TryParse(ma.Substring(2), out int cn))
            {
                return cn;
            }

            return int.MaxValue;
        }
        private void dgvQLK_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLK.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLK.SelectedRows[0];

                string maKho = Convert.ToString(selectedRow.Cells["MaKho"].Value);
                string maCN = Convert.ToString(selectedRow.Cells["MaCN"].Value);
                string tenKho = Convert.ToString(selectedRow.Cells["TenKho"].Value);
                string diaChi = Convert.ToString(selectedRow.Cells["DiaChi"].Value);

                txtQLK_MaKho.Text = maKho;
                txtQLK_TenKho.Text = tenKho;
                txtQLK_DiaChi.Text = diaChi;
                cbQLK_MaCN.Text = maCN;

                txtQLK_MaKho.ReadOnly = true;
            }
        }
        private void dgvQLK_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvQLK.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private string TaoMaKhoTuDong()
        {
            List<string> danhSachMaKho = dgvQLK.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["MaKho"].Value.ToString())
                .ToList();

            for (int i = 1; i <= danhSachMaKho.Count + 1; i++)
            {
                string maDinhDang = "Kho" + i;
                if (!danhSachMaKho.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (danhSachMaKho.Count > 0)
            {
                string maLonNhat = danhSachMaKho.Max();
                if (int.TryParse(maLonNhat.Substring(4), out int so))
                {
                    return "Kho" + (so + 1).ToString();
                }
            }

            return "Kho1";
        }
        private void btnQLK_Them_Click(object sender, EventArgs e)
        {
            string maKho = TaoMaKhoTuDong();
            string maCN = cbQLK_MaCN.Text.Trim();
            string tenKho = txtQLK_TenKho.Text.Trim();
            string diaChi = txtQLK_DiaChi.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(maCN) || string.IsNullOrEmpty(maKho) || string.IsNullOrEmpty(tenKho) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var payloads = new List<KhoPost>
            {
                new KhoPost
                {
                    CN_ID = maCN,
                    Kho_ID = maKho,
                    Kho_Name = tenKho,
                    Kho_Address = diaChi
                }
            };

            var response = khoService.ThemKho(payloads);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm kho {maKho} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm kho thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQLK_Sua_Click(object sender, EventArgs e)
        {
            string maKho = txtQLK_MaKho.Text.Trim();
            string tenKho = txtQLK_TenKho.Text.Trim();
            string diaChi = txtQLK_DiaChi.Text.Trim();
            string maCN = cbQLK_MaCN.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(maKho) || string.IsNullOrEmpty(tenKho) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật kho {maKho}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var payload = new KhoPost
                {
                    CN_ID = maCN,
                    Kho_ID = maKho,
                    Kho_Name = tenKho,
                    Kho_Address = diaChi
                };

                var response = khoService.CapNhatKho(maKho, payload);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật kho {maKho} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật kho thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private void btnQLK_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvQLK.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một kho để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsMaKho = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string maKho = row.Cells["MaKho"].Value.ToString().Trim();
                dsMaKho.Add(maKho);
            }

            dsMaKho = dsMaKho.OrderBy(maKho => int.Parse(Regex.Match(maKho, @"\d+").Value)).ToList();

            string manyMaKho = string.Join(", ", dsMaKho);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa kho ({manyMaKho}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string maKho = row.Cells["MaKho"].Value.ToString().Trim();
                        var response = khoService.XoaKho(maKho);

                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Xóa kho {maKho} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show($"Xóa các kho ({manyMaKho}) đã chọn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string maKho = dsMaKho[0];
                    var response = khoService.XoaKho(maKho);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Xóa kho {maKho} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa kho {maKho} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SearchData(string maCN, string maKho)
        {
            try
            {
                List<Kho> danhSachKho = khoService.LayDanhSachKho();

                if (danhSachKho != null)
                {
                    var filteredKho = danhSachKho;

                    if (!maCN.Equals("All") && !maKho.Equals("All"))
                    {
                        filteredKho = danhSachKho.Where(kho =>
                            (kho.Kho_ID.Contains(maKho)) &&
                            (kho.CN_ID.Contains(maCN))
                        ).ToList();
                    }
                    else if (!maCN.Equals("All") && maKho.Equals("All"))
                    {
                        filteredKho = danhSachKho.Where(kho =>
                            (kho.CN_ID.Contains(maCN))
                        ).ToList();
                    }
                    else if (maCN.Equals("All") && !maKho.Equals("All"))
                    {
                        filteredKho = danhSachKho.Where(kho =>
                            (kho.Kho_ID.Contains(maKho))
                        ).ToList();
                    }
                    else
                    {
                        LoadDataGridView();
                    }

                    dgvQLK.DataSource = filteredKho;
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
        private void cbQLK_TK_MaCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMaCN_MaKho();
        }
        private void cbQLK_TK_MaKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMaCN_MaKho();
        }
        private void SearchByMaCN_MaKho()
        {
            if (cbQLK_TK_MaCN.SelectedItem is ChiNhanh selectedCN && cbQLK_TK_MaKho.SelectedItem is Kho selectedKho)
            {
                string maCN = selectedCN.CN_ID;
                string maKho = selectedKho.Kho_ID;

                SearchData(maCN, maKho);
            }
        }
    }
}
