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
    public partial class UC_QLThuoc : UserControl
    {
        private readonly ThuocService thuocService;
        private readonly NThuocService nThuocService;
        private readonly CTThuocService cttService;
        public UC_QLThuoc()
        {
            InitializeComponent();
            dgvQLT.AutoGenerateColumns = false;

            thuocService = new ThuocService("https://localhost:7195");
            nThuocService = new NThuocService("https://localhost:7195");
            cttService = new CTThuocService("https://localhost:7195");

            LoadDataGridView();
            LoadComboBox();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<Thuoc> dsThuoc = await Task.Run(() => thuocService.LayDSThuoc());

                if (dsThuoc != null)
                {
                    dsThuoc = dsThuoc
                        .OrderBy(t =>
                        {
                            string numberPart = new string(t.Thuoc_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvQLT.DataSource = null;
                    dgvQLT.DataSource = dsThuoc;

                    foreach (DataGridViewColumn column in dgvQLT.Columns)
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
            if (ma.StartsWith("Thuoc") && int.TryParse(ma.Substring(5), out int result))
            {
                return result;
            }

            if (ma.StartsWith("Nhom") && int.TryParse(ma.Substring(4), out int nv))
            {
                return nv;
            }

            return int.MaxValue;
        }
        private void dgvQLT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvQLT.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dgvQLT_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLT.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLT.SelectedRows[0];

                string maThuoc = Convert.ToString(selectedRow.Cells["Thuoc_ID"].Value);
                string tenThuoc = Convert.ToString(selectedRow.Cells["Thuoc_Name"].Value);
                string maNhom = Convert.ToString(selectedRow.Cells["Nhom_ID"].Value);

                txtQLT_MaThuoc.ReadOnly = true;
                cbQLT_MaNhom.Text = maNhom;
                txtQLT_MaThuoc.Text = maThuoc;
                txtQLT_TenThuoc.Text = tenThuoc;
            }
        }
        private void LoadComboBox()
        {
            try
            {
                // Load cbQLT_MaNhom
                List<NhomThuoc> dsNT = nThuocService.LayDSNT();
                dsNT = dsNT.OrderBy(nt => GetNumericPartOfMa(nt.Nhom_ID)).ToList();

                cbQLT_MaNhom.DataSource = dsNT;
                cbQLT_MaNhom.DisplayMember = "Nhom_ID";
                cbQLT_MaNhom.ValueMember = "Nhom_ID";
                cbQLT_MaNhom.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsNT.Count > 0)
                {
                    cbQLT_MaNhom.SelectedIndex = 0;
                }

                // Load cbQLT_TK_MaNhom
                List<NhomThuoc> dsNT1 = nThuocService.LayDSNT();
                dsNT1 = dsNT1.OrderBy(nt => GetNumericPartOfMa(nt.Nhom_ID)).ToList();
                dsNT1.Insert(0, new NhomThuoc { Nhom_ID = "All" });

                cbQLT_TK_MaNhom.DataSource = dsNT1;
                cbQLT_TK_MaNhom.DisplayMember = "Nhom_ID";
                cbQLT_TK_MaNhom.ValueMember = "Nhom_ID";
                cbQLT_TK_MaNhom.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsNT1.Count > 0)
                {
                    cbQLT_TK_MaNhom.SelectedIndex = 0;
                }

                // Load cbQLT_TK_MaThuoc
                List<Thuoc> dsThuoc = thuocService.LayDSThuoc();
                dsThuoc = dsThuoc.OrderBy(t => GetNumericPartOfMa(t.Thuoc_ID)).ToList();
                dsThuoc.Insert(0, new Thuoc { Thuoc_ID = "All" });

                cbQLT_TK_MaThuoc.DataSource = dsThuoc;
                cbQLT_TK_MaThuoc.DisplayMember = "Thuoc_ID";
                cbQLT_TK_MaThuoc.ValueMember = "Thuoc_ID";
                cbQLT_TK_MaThuoc.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsThuoc.Count > 0)
                {
                    cbQLT_TK_MaThuoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string TaoMaThuocTuDong()
        {
            List<string> dsThuoc = dgvQLT.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["Thuoc_ID"].Value.ToString())
                .ToList();

            for (int i = 1; i <= dsThuoc.Count + 1; i++)
            {
                string maDinhDang = "Thuoc" + i;
                if (!dsThuoc.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (dsThuoc.Count > 0)
            {
                string maLonNhat = dsThuoc.Max();
                if (int.TryParse(maLonNhat.Substring(5), out int so))
                {
                    return "Thuoc" + (so + 1).ToString();
                }
            }

            return "Thuoc1";
        }
        private void btnQLT_Them_Click(object sender, EventArgs e)
        {
            string maThuoc = TaoMaThuocTuDong();
            string maNhom = cbQLT_MaNhom.Text.Trim();
            string tenThuoc = txtQLT_TenThuoc.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tenThuoc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var thuoc = new List<Thuoc>
            {
                new Thuoc
                {
                    Thuoc_ID = maThuoc,
                    Thuoc_Name = tenThuoc,
                    Nhom_ID = maNhom
                }
            };

            var response = thuocService.ThemThuoc(thuoc);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm thuốc {maThuoc} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm thuốc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQLT_Sua_Click(object sender, EventArgs e)
        {
            string maThuoc = txtQLT_MaThuoc.Text.Trim();
            string maNhom = cbQLT_MaNhom.Text.Trim();
            string tenThuoc = txtQLT_TenThuoc.Text.Trim();

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật thuốc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tenThuoc))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật thuốc {maThuoc}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var thuoc = new Thuoc
                {
                    Thuoc_ID = maThuoc,
                    Thuoc_Name = tenThuoc,
                    Nhom_ID = maNhom
                };

                var response = thuocService.CapNhatThuoc(maThuoc, thuoc);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật thuốc {maThuoc} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật thuốc thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private void btnQLT_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvQLT.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thuốc để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsMaThuoc = new List<string>();
            List<string> deletedMaThuoc = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string maThuoc = row.Cells["Thuoc_ID"].Value.ToString().Trim();
                dsMaThuoc.Add(maThuoc);
            }

            dsMaThuoc = dsMaThuoc.OrderBy(maThuoc => int.Parse(Regex.Match(maThuoc, @"\d+").Value)).ToList();

            string manyMaThuoc = string.Join(", ", dsMaThuoc);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa thuốc ({manyMaThuoc}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string maThuoc = row.Cells["Thuoc_ID"].Value.ToString().Trim();
                        var response = thuocService.XoaThuoc(maThuoc);

                        if (response.IsSuccessStatusCode)
                        {
                            deletedMaThuoc.Add(maThuoc);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa thuốc {maThuoc} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string deletedMaThuocString = string.Join(", ", deletedMaThuoc);
                    MessageBox.Show($"Xóa các thuốc ({deletedMaThuocString}) thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string maThuoc = dsMaThuoc[0];
                    var response = thuocService.XoaThuoc(maThuoc);

                    if (response.IsSuccessStatusCode)
                    {
                        deletedMaThuoc.Add(maThuoc);
                        MessageBox.Show($"Xóa thuốc {maThuoc} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa thuốc {maThuoc} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SearchData(string maThuoc, string maNhom)
        {
            try
            {
                List<Thuoc> dsThuoc = thuocService.LayDSThuoc();

                if (dsThuoc != null)
                {
                    var filteredThuoc = dsThuoc;

                    if (!maThuoc.Equals("All") && !maNhom.Equals("All"))
                    {
                        filteredThuoc = dsThuoc.Where(kho =>
                            (kho.Nhom_ID.Contains(maNhom)) &&
                            (kho.Thuoc_ID.Contains(maThuoc))
                        ).ToList();
                    }
                    else if (!maThuoc.Equals("All") && maNhom.Equals("All"))
                    {
                        filteredThuoc = dsThuoc.Where(kho =>
                            (kho.Thuoc_ID.Contains(maThuoc))
                        ).ToList();
                    }
                    else if (maThuoc.Equals("All") && !maNhom.Equals("All"))
                    {
                        filteredThuoc = dsThuoc.Where(kho =>
                            (kho.Nhom_ID.Contains(maNhom))
                        ).ToList();
                    }
                    else
                    {
                        LoadDataGridView();
                    }

                    dgvQLT.DataSource = filteredThuoc;
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
        private void SearchByMaThuoc_MaNhom()
        {
            if (cbQLT_TK_MaThuoc.SelectedItem is Thuoc selectedThuoc && cbQLT_TK_MaNhom.SelectedItem is NhomThuoc selectedNT)
            {
                string maThuoc = selectedThuoc.Thuoc_ID;
                string maNhom = selectedNT.Nhom_ID;

                SearchData(maThuoc, maNhom);
            }
        }
        private void cbQLT_TK_MaThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMaThuoc_MaNhom();
        }
        private void cbQLT_TK_MaNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMaThuoc_MaNhom();
        }
        private void linkQLT_CTT_Click(object sender, EventArgs e)
        {
            string maThuoc = txtQLT_MaThuoc.Text.Trim();

            if (!string.IsNullOrEmpty(maThuoc))
            {
                UC_CTThuoc ucCTT = new UC_CTThuoc();
                ucCTT.LoadDataByMaThuoc(maThuoc);

                List<ChiTietThuoc> dsChiTiet = cttService.LayCTT(maThuoc);

                if (dsChiTiet != null && dsChiTiet.Any())
                {
                    FrmChiTiet frmCT = new FrmChiTiet();
                    frmCT.Controls.Clear();
                    frmCT.ClientSize = new Size(ucCTT.Width + 2, ucCTT.Height + 2);
                    frmCT.Controls.Add(ucCTT);
                    frmCT.Show();
                }
                else
                {
                    MessageBox.Show("Không có chi tiết thuốc cho mã đơn nhập này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mã thuốc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
