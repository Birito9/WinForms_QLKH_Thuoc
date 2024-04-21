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
    public partial class UC_QLDonXuat : UserControl
    {
        private readonly DXuatService dXuatService;
        private readonly NhanVienService nvService;
        private readonly CTDXuatService ctdxService;
        public UC_QLDonXuat()
        {
            InitializeComponent();
            dgvQLDX.AutoGenerateColumns = false;

            dXuatService = new DXuatService("https://localhost:7195");
            nvService = new NhanVienService("https://localhost:7195");
            ctdxService = new CTDXuatService("https://localhost:7195");

            LoadDataGridView();
            LoadComboBox();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<DonXuat> dsDX = await Task.Run(() => dXuatService.LayDSDX());

                if (dsDX != null)
                {
                    dsDX = dsDX
                        .OrderBy(dn =>
                        {
                            string numberPart = new string(dn.DXuat_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvQLDX.DataSource = null;
                    dgvQLDX.DataSource = dsDX;

                    foreach (DataGridViewColumn column in dgvQLDX.Columns)
                    {
                        column.ReadOnly = true;
                        dgvQLDX.Columns["DX_Datetime"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            if (ma.StartsWith("DX") && int.TryParse(ma.Substring(2), out int result))
            {
                return result;
            }

            if (ma.StartsWith("NV") && int.TryParse(ma.Substring(2), out int nv))
            {
                return nv;
            }

            return int.MaxValue;
        }
        private void dgvQLDX_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvQLDX.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dgvQLDX_SelectionChanged(object sender, EventArgs e)
        {
            dgvQLDX.SuspendLayout();

            if (dgvQLDX.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLDX.SelectedRows[0];

                string maDX = Convert.ToString(selectedRow.Cells["DXuat_ID"].Value);
                string tenDX = Convert.ToString(selectedRow.Cells["DX_Name"].Value);
                string maNV = Convert.ToString(selectedRow.Cells["NV_ID"].Value);
                DateTime ngayXuat = Convert.ToDateTime(selectedRow.Cells["DX_Datetime"].Value);

                txtQLDX_MaDX.Text = maDX;
                txtQLDX_TenDX.Text = tenDX;
                cbQLDX_MaNV.Text = maNV;
                dtpQLDX_NgayXuat.Value = ngayXuat;

                txtQLDX_MaDX.ReadOnly = true;
            }

            dgvQLDX.ResumeLayout();
            dgvQLDX.PerformLayout();
        }
        private void LoadComboBox()
        {
            try
            {
                // Load cbQLDX_MaNV
                List<NhanVien> dsnv = nvService.LayDSNV();
                dsnv = dsnv.OrderBy(nv => GetNumericPartOfMa(nv.NV_ID)).ToList();

                cbQLDX_MaNV.DataSource = dsnv;
                cbQLDX_MaNV.DisplayMember = "NV_ID";
                cbQLDX_MaNV.ValueMember = "NV_ID";
                cbQLDX_MaNV.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsnv.Count > 0)
                {
                    cbQLDX_MaNV.SelectedIndex = 0;
                }

                // Load cbQLDX_TK_MaNV
                List<NhanVien> dsnv1 = new List<NhanVien>(dsnv);
                dsnv1 = dsnv1.OrderBy(nv => GetNumericPartOfMa(nv.NV_ID)).ToList();
                dsnv1.Insert(0, new NhanVien { NV_ID = "All" });

                cbQLDX_TK_MaNV.DataSource = dsnv1;
                cbQLDX_TK_MaNV.DisplayMember = "NV_ID";
                cbQLDX_TK_MaNV.ValueMember = "NV_ID";
                cbQLDX_TK_MaNV.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsnv1.Count > 0)
                {
                    cbQLDX_TK_MaNV.SelectedIndex = 0;
                }

                // Load cbQLDX_TK_MaDX
                List<DonXuat> dsdx = dXuatService.LayDSDX();
                dsdx = dsdx.OrderBy(dx => GetNumericPartOfMa(dx.DXuat_ID)).ToList();
                dsdx.Insert(0, new DonXuat { DXuat_ID = "All" });

                cbQLDX_TK_MaDX.DataSource = dsdx;
                cbQLDX_TK_MaDX.DisplayMember = "DXuat_ID";
                cbQLDX_TK_MaDX.ValueMember = "DXuat_ID";
                cbQLDX_TK_MaDX.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsdx.Count > 0)
                {
                    cbQLDX_TK_MaDX.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string TaoMaDXTuDong()
        {
            List<string> dsDX = dgvQLDX.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["DXuat_ID"].Value.ToString())
                .ToList();

            for (int i = 1; i <= dsDX.Count + 1; i++)
            {
                string maDinhDang = "DX" + i;
                if (!dsDX.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (dsDX.Count > 0)
            {
                string maLonNhat = dsDX.Max();
                if (int.TryParse(maLonNhat.Substring(2), out int so))
                {
                    return "DX" + (so + 1).ToString();
                }
            }

            return "DX1";
        }
        private void btnQLDX_Them_Click(object sender, EventArgs e)
        {
            string maDX = TaoMaDXTuDong();
            string tenDX = txtQLDX_TenDX.Text.Trim();
            string maNV = cbQLDX_MaNV.Text.Trim();
            DateTime ngayXuat = dtpQLDX_NgayXuat.Value;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm đơn xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tenDX))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var dx = new List<DonXuat>
            {
                new DonXuat
                {
                    DXuat_ID = maDX,
                    DX_Datetime = ngayXuat,
                    NV_ID = maNV,
                    DX_Name = tenDX
                }
            };

            var response = dXuatService.ThemDX(dx);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm đơn xuất {maDX} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm đơn xuất thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQLDX_Sua_Click(object sender, EventArgs e)
        {
            string maDX = txtQLDX_MaDX.Text.Trim();
            string tenDX = txtQLDX_TenDX.Text.Trim();
            string maNV = cbQLDX_MaNV.Text.Trim();
            DateTime ngayXuat = dtpQLDX_NgayXuat.Value;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật đơn xuất", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tenDX))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật đơn xuất {maDX}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var dx = new DonXuat
                {
                    DXuat_ID = maDX,
                    DX_Datetime = ngayXuat,
                    NV_ID = maNV,
                    DX_Name = tenDX
                };

                var response = dXuatService.CapNhatDX(maDX, dx);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật đơn xuất {maDX} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn xuất thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private void btnQLDX_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa đơn xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvQLDX.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một đơn xuất để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsMaDX = new List<string>();
            List<string> deletedMaDX = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string maDX = row.Cells["DXuat_ID"].Value.ToString().Trim();
                dsMaDX.Add(maDX);
            }

            dsMaDX = dsMaDX.OrderBy(maDX => int.Parse(Regex.Match(maDX, @"\d+").Value)).ToList();

            string manyMaDX = string.Join(", ", dsMaDX);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn xuất ({manyMaDX}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string maDX = row.Cells["DXuat_ID"].Value.ToString().Trim();
                        var response = dXuatService.XoaDX(maDX);

                        if (response.IsSuccessStatusCode)
                        {
                            deletedMaDX.Add(maDX);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa đơn xuất {maDX} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string deletedMaDXString = string.Join(", ", deletedMaDX);
                    MessageBox.Show($"Xóa các đơn xuất ({deletedMaDXString}) thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string maDX = dsMaDX[0];
                    var response = dXuatService.XoaDX(maDX);

                    if (response.IsSuccessStatusCode)
                    {
                        deletedMaDX.Add(maDX);
                        MessageBox.Show($"Xóa đơn xuất {maDX} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa đơn xuất {maDX} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SearchData(string maDX, string maNV)
        {
            try
            {
                List<DonXuat> dsDX = dXuatService.LayDSDX();

                if (dsDX != null)
                {
                    var filteredDX = dsDX;

                    if (!maDX.Equals("All") && !maNV.Equals("All"))
                    {
                        filteredDX = dsDX.Where(kho =>
                            (kho.NV_ID.Contains(maNV)) &&
                            (kho.DXuat_ID.Contains(maDX))
                        ).ToList();
                    }
                    else if (!maDX.Equals("All") && maNV.Equals("All"))
                    {
                        filteredDX = dsDX.Where(kho =>
                            (kho.DXuat_ID.Contains(maDX))
                        ).ToList();
                    }
                    else if (maDX.Equals("All") && !maNV.Equals("All"))
                    {
                        filteredDX = dsDX.Where(kho =>
                            (kho.NV_ID.Contains(maNV))
                        ).ToList();
                    }
                    else
                    {
                        LoadDataGridView();
                    }

                    dgvQLDX.DataSource = filteredDX;
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
        private void SearchBymaDX_MaNV()
        {
            if (cbQLDX_TK_MaDX.SelectedItem is DonXuat selectedDX && cbQLDX_TK_MaNV.SelectedItem is NhanVien selectedNV)
            {
                string maDX = selectedDX.DXuat_ID;
                string maNV = selectedNV.NV_ID;

                SearchData(maDX, maNV);
            }
        }
        private void cbQLDX_TK_MaDX_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBymaDX_MaNV();
        }
        private void cbQLDX_TK_MaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBymaDX_MaNV();
        }
        private void linkQLDX_Click(object sender, EventArgs e)
        {
            string maDX = txtQLDX_MaDX.Text.Trim();

            if (!string.IsNullOrEmpty(maDX))
            {
                UC_CTDonXuat ucCTDX = new UC_CTDonXuat();
                ucCTDX.LoadDataByMaDX(maDX);

                List<ChiTietDonXuat> dsChiTiet = ctdxService.LayCTDX(maDX);

                if (dsChiTiet != null && dsChiTiet.Any())
                {
                    FrmChiTiet frmCT = new FrmChiTiet();
                    frmCT.Controls.Clear();
                    frmCT.ClientSize = new Size(ucCTDX.Width + 2, ucCTDX.Height + 2);
                    frmCT.Controls.Add(ucCTDX);
                    frmCT.Show();
                }
                else
                {
                    MessageBox.Show("Không có chi tiết đơn xuất cho mã đơn nhập này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mã đơn xuất không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
