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

namespace FormQLKH
{
    public partial class UC_CTDonXuat : UserControl
    {
        private readonly CTDXuatService ctdxService;
        private readonly ThuocService thuocService;
        public UC_CTDonXuat()
        {
            InitializeComponent();

            ctdxService = new CTDXuatService("https://localhost:7195");
            thuocService = new ThuocService("https://localhost:7195");

            txtCTDX_MaDX.ReadOnly = true;
            LoadComboBox();
        }
        public void LoadDataByMaDX(string maDX)
        {
            if (!string.IsNullOrEmpty(maDX))
            {
                List<ChiTietDonXuat> dsChiTiet = ctdxService.LayCTDX(maDX);

                if (dsChiTiet != null && dsChiTiet.Any())
                {
                    txtCTDX_MaDX.Text = maDX;
                    cbCTDX_MaThuoc.Text = dsChiTiet.First().Thuoc_ID;
                    txtCTDX_GhiChu.Text = dsChiTiet.First().Description;
                    numCTDX_SoLuong.Value = dsChiTiet.First().Quantity;
                }
            }
        }
        private int GetNumericPartOfMa(string ma)
        {
            if (ma.StartsWith("Thuoc") && int.TryParse(ma.Substring(5), out int t))
            {
                return t;
            }

            return int.MaxValue;
        }
        private async void LoadComboBox()
        {
            try
            {
                // Load cbCTDX_MaThuoc
                List<Thuoc> dst = thuocService.LayDSThuoc();
                dst = dst.OrderBy(t => GetNumericPartOfMa(t.Thuoc_ID)).ToList();

                cbCTDX_MaThuoc.DataSource = dst;
                cbCTDX_MaThuoc.DisplayMember = "Thuoc_ID";
                cbCTDX_MaThuoc.ValueMember = "Thuoc_ID";
                cbCTDX_MaThuoc.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dst.Count > 0)
                {
                    cbCTDX_MaThuoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCTDX_Sua_Click(object sender, EventArgs e)
        {
            string ghiChu = txtCTDX_GhiChu.Text.Trim();
            string maThuoc = cbCTDX_MaThuoc.Text.Trim();
            string maDX = txtCTDX_MaDX.Text.Trim();
            int soLuong = (int)numCTDX_SoLuong.Value;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật chi tiết đơn xuất", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật chi tiết đơn xuất {maDX}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var ctdn = new ChiTietDonXuat
                {
                    Description = ghiChu,
                    Thuoc_ID = maThuoc,
                    DXuat_ID = maDX,
                    Quantity = soLuong
                };

                var response = ctdxService.CapNhatCTDX(maDX, ctdn);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật chi tiết đơn xuất {maDX} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataByMaDX(maDX);
                }
                else
                {
                    MessageBox.Show("Cập nhật chi tiết đơn xuất thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
