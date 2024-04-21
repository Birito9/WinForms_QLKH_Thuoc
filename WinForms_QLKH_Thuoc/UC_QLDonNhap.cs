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
using WinFormsApp;

namespace FormQLKH
{
    public partial class UC_QLDonNhap : UserControl
    {
        private readonly DNhapService dNhapService;
        private readonly NCCService nCCService;
        private readonly NhanVienService nvService;
        private readonly CTDNhapService ctdnService;
        public UC_QLDonNhap()
        {
            InitializeComponent();
            dgvQLDN.AutoGenerateColumns = false;

            dNhapService = new DNhapService("https://localhost:7195");
            nCCService = new NCCService("https://localhost:7195");
            nvService = new NhanVienService("https://localhost:7195");
            ctdnService = new CTDNhapService("https://localhost:7195");

            LoadDataGridView();
            LoadComboBox();
        }
        private async void LoadDataGridView()
        {
            try
            {
                List<DonNhap> dsDN = await Task.Run(() => dNhapService.LayDSDN());

                if (dsDN != null)
                {
                    dsDN = dsDN
                        .OrderBy(dn =>
                        {
                            string numberPart = new string(dn.DNhap_ID.Where(char.IsDigit).ToArray());
                            if (int.TryParse(numberPart, out int result))
                            {
                                return result;
                            }

                            return int.MaxValue;
                        })
                        .ToList();

                    dgvQLDN.DataSource = null;
                    dgvQLDN.DataSource = dsDN;

                    foreach (DataGridViewColumn column in dgvQLDN.Columns)
                    {
                        column.ReadOnly = true;
                        dgvQLDN.Columns["DN_Datetime"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            if (ma.StartsWith("DN") && int.TryParse(ma.Substring(2), out int result))
            {
                return result;
            }

            if (ma.StartsWith("NCC") && int.TryParse(ma.Substring(3), out int ncc))
            {
                return ncc;
            }

            if (ma.StartsWith("NV") && int.TryParse(ma.Substring(2), out int nv))
            {
                return nv;
            }

            return int.MaxValue;
        }
        private void dgvQLDN_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvQLDN.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dgvQLDN_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLDN.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLDN.SelectedRows[0];

                string maDN = Convert.ToString(selectedRow.Cells["DNhap_ID"].Value);
                string tenDN = Convert.ToString(selectedRow.Cells["DN_Name"].Value);
                string maNCC = Convert.ToString(selectedRow.Cells["NCC_ID"].Value);
                string maNV = Convert.ToString(selectedRow.Cells["NV_ID"].Value);
                DateTime ngayNhap = Convert.ToDateTime(selectedRow.Cells["DN_Datetime"].Value);

                txtQLDN_MaDN.Text = maDN;
                txtQLDN_TenDN.Text = tenDN;
                cbQLDN_MaNCC.Text = maNCC;
                cbQLDN_MaNV.Text = maNV;
                dtpQLDN_NgayNhap.Value = ngayNhap;

                txtQLDN_MaDN.ReadOnly = true;
            }
        }
        private void LoadComboBox()
        {
            try
            {
                // Load cbQLDN_MaNCC
                List<NCC> dsNCC = nCCService.LayDS_NCC();
                dsNCC = dsNCC.OrderBy(ncc => GetNumericPartOfMa(ncc.NCC_ID)).ToList();

                cbQLDN_MaNCC.DataSource = dsNCC;
                cbQLDN_MaNCC.DisplayMember = "NCC_ID";
                cbQLDN_MaNCC.ValueMember = "NCC_ID";
                cbQLDN_MaNCC.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsNCC.Count > 0)
                {
                    cbQLDN_MaNCC.SelectedIndex = 0;
                }

                // Load cbQLDN_MaNV
                List<NhanVien> dsnv = nvService.LayDSNV();
                dsnv = dsnv.OrderBy(nv => GetNumericPartOfMa(nv.NV_ID)).ToList();

                cbQLDN_MaNV.DataSource = dsnv;
                cbQLDN_MaNV.DisplayMember = "NV_ID";
                cbQLDN_MaNV.ValueMember = "NV_ID";
                cbQLDN_MaNV.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsnv.Count > 0)
                {
                    cbQLDN_MaNV.SelectedIndex = 0;
                }

                // Load cbQLDN_TK_MaNV
                List<NhanVien> dsnv1 = new List<NhanVien>(dsnv);
                dsnv1 = dsnv1.OrderBy(nv => GetNumericPartOfMa(nv.NV_ID)).ToList();
                dsnv1.Insert(0, new NhanVien { NV_ID = "All" });

                cbQLDN_TK_MaNV.DataSource = dsnv1;
                cbQLDN_TK_MaNV.DisplayMember = "NV_ID";
                cbQLDN_TK_MaNV.ValueMember = "NV_ID";
                cbQLDN_TK_MaNV.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsnv1.Count > 0)
                {
                    cbQLDN_TK_MaNV.SelectedIndex = 0;
                }

                // Load cbQLDN_TK_MaDN
                List<DonNhap> dsdn = dNhapService.LayDSDN();
                dsdn = dsdn.OrderBy(dn => GetNumericPartOfMa(dn.DNhap_ID)).ToList();
                dsdn.Insert(0, new DonNhap { DNhap_ID = "All" });

                cbQLDN_TK_MaDN.DataSource = dsdn;
                cbQLDN_TK_MaDN.DisplayMember = "DNhap_ID";
                cbQLDN_TK_MaDN.ValueMember = "DNhap_ID";
                cbQLDN_TK_MaDN.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsdn.Count > 0)
                {
                    cbQLDN_TK_MaDN.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string TaoMaDNTuDong()
        {
            List<string> dsDN = dgvQLDN.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["DNhap_ID"].Value.ToString())
                .ToList();

            for (int i = 1; i <= dsDN.Count + 1; i++)
            {
                string maDinhDang = "DN" + i;
                if (!dsDN.Any(ma => ma.Trim().Equals(maDinhDang, StringComparison.OrdinalIgnoreCase)))
                {
                    return maDinhDang;
                }
            }

            if (dsDN.Count > 0)
            {
                string maLonNhat = dsDN.Max();
                if (int.TryParse(maLonNhat.Substring(4), out int so))
                {
                    return "DN" + (so + 1).ToString();
                }
            }

            return "DN1";
        }
        private void btnQLDN_Them_Click(object sender, EventArgs e)
        {
            string maDN = TaoMaDNTuDong();
            string tenDN = txtQLDN_TenDN.Text.Trim();
            string maNCC = cbQLDN_MaNCC.Text.Trim();
            string maNV = cbQLDN_MaNV.Text.Trim();
            DateTime ngayNhap = dtpQLDN_NgayNhap.Value;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanAdd(roleID))
            {
                MessageBox.Show("Bạn không có quyền thêm đơn nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tenDN))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var dn = new List<DonNhap>
            {
                new DonNhap
                {
                    DNhap_ID = maDN,
                    DN_Datetime = ngayNhap,
                    NCC_ID = maNCC,
                    NV_ID = maNV,
                    DN_Name = tenDN
                }
            };

            var response = dNhapService.ThemDN(dn);

            if (response.IsSuccessful)
            {
                MessageBox.Show($"Thêm đơn nhập {maDN} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show($"Thêm đơn nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQLDN_Sua_Click(object sender, EventArgs e)
        {
            string maDN = txtQLDN_MaDN.Text.Trim();
            string tenDN = txtQLDN_TenDN.Text.Trim();
            string maNCC = cbQLDN_MaNCC.Text.Trim();
            string maNV = cbQLDN_MaNV.Text.Trim();
            DateTime ngayNhap = dtpQLDN_NgayNhap.Value;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật đơn nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tenDN))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật đơn nhập {maDN}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var dn = new DonNhap
                {
                    DNhap_ID = maDN,
                    DN_Datetime = ngayNhap,
                    NCC_ID = maNCC,
                    NV_ID = maNV,
                    DN_Name = tenDN
                };

                var response = dNhapService.CapNhatDN(maDN, dn);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật đơn nhập {maDN} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn nhập thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
        private void btnQLDN_Xoa_Click(object sender, EventArgs e)
        {
            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanDelete(roleID))
            {
                MessageBox.Show("Bạn không có quyền xóa đơn nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvQLDN.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một đơn nhập để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> dsMaDN = new List<string>();
            List<string> deletedMaDN = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string maDN = row.Cells["DNhap_ID"].Value.ToString().Trim();
                dsMaDN.Add(maDN);
            }

            dsMaDN = dsMaDN.OrderBy(maDN => int.Parse(Regex.Match(maDN, @"\d+").Value)).ToList();

            string manyMaDN = string.Join(", ", dsMaDN);

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn nhập ({manyMaDN}) đã chọn?", "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedRows.Count > 1)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string maDN = row.Cells["DNhap_ID"].Value.ToString().Trim();
                        var response = dNhapService.XoaDN(maDN);

                        if (response.IsSuccessStatusCode)
                        {
                            deletedMaDN.Add(maDN);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa đơn nhập {maDN} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string deletedMaDNString = string.Join(", ", deletedMaDN);
                    MessageBox.Show($"Xóa các đơn nhập ({deletedMaDNString}) thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    LoadComboBox();
                }
                else
                {
                    string maDN = dsMaDN[0];
                    var response = dNhapService.XoaDN(maDN);

                    if (response.IsSuccessStatusCode)
                    {
                        deletedMaDN.Add(maDN);
                        MessageBox.Show($"Xóa đơn nhập {maDN} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        LoadComboBox();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa đơn nhập {maDN} thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SearchData(string maDN, string maNV)
        {
            try
            {
                List<DonNhap> dsDN = dNhapService.LayDSDN();

                if (dsDN != null)
                {
                    var filteredDN = dsDN;

                    if (!maDN.Equals("All") && !maNV.Equals("All"))
                    {
                        filteredDN = dsDN.Where(kho =>
                            (kho.NV_ID.Contains(maNV)) &&
                            (kho.DNhap_ID.Contains(maDN))
                        ).ToList();
                    }
                    else if (!maDN.Equals("All") && maNV.Equals("All"))
                    {
                        filteredDN = dsDN.Where(kho =>
                            (kho.DNhap_ID.Contains(maDN))
                        ).ToList();
                    }
                    else if (maDN.Equals("All") && !maNV.Equals("All"))
                    {
                        filteredDN = dsDN.Where(kho =>
                            (kho.NV_ID.Contains(maNV))
                        ).ToList();
                    }
                    else
                    {
                        LoadDataGridView();
                    }

                    dgvQLDN.DataSource = filteredDN;
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
        private void SearchByMaDN_MaNV()
        {
            if (cbQLDN_TK_MaDN.SelectedItem is DonNhap selectedDN && cbQLDN_TK_MaNV.SelectedItem is NhanVien selectedNV)
            {
                string maDN = selectedDN.DNhap_ID;
                string maNV = selectedNV.NV_ID;

                SearchData(maDN, maNV);
            }
        }
        private void cbQLDN_TK_MaDN_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMaDN_MaNV();
        }
        private void cbQLDN_TK_MaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMaDN_MaNV();
        }
        private void linkLb_CTDN_Click(object sender, EventArgs e)
        {
            string maDN = txtQLDN_MaDN.Text.Trim();

            if (!string.IsNullOrEmpty(maDN))
            {
                UC_CTDonNhap ucCTDN = new UC_CTDonNhap();
                ucCTDN.LoadDataByMaDN(maDN);

                List<ChiTietDonNhap> dsChiTiet = ctdnService.LayCTDN(maDN);

                if (dsChiTiet != null && dsChiTiet.Any())
                {
                    FrmChiTiet frmCT = new FrmChiTiet();
                    frmCT.Controls.Clear();
                    frmCT.ClientSize = new Size(ucCTDN.Width + 2, ucCTDN.Height + 2);
                    frmCT.Controls.Add(ucCTDN);
                    frmCT.Show();
                }
                else
                {
                    MessageBox.Show("Không có chi tiết đơn nhập cho mã đơn nhập này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mã đơn nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
