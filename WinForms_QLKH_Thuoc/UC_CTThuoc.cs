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
    public partial class UC_CTThuoc : UserControl
    {
        private readonly CTThuocService cttService;
        private readonly LoService loService;
        public UC_CTThuoc()
        {
            InitializeComponent();

            cttService = new CTThuocService("https://localhost:7195");
            loService = new LoService("https://localhost:7195");

            LoadComboBox();
        }
        public void LoadDataByMaThuoc(string maThuoc)
        {
            if (!string.IsNullOrEmpty(maThuoc))
            {
                List<ChiTietThuoc> dsChiTiet = cttService.LayCTT(maThuoc);

                if (dsChiTiet != null && dsChiTiet.Any())
                {
                    txtCTT_MaThuoc.Text = maThuoc;
                    cbCTT_MaLo.Text = dsChiTiet.First().Lo_ID;
                    txtCTT_GhiChu.Text = dsChiTiet.First().Description;
                    numCTT_SoLuong.Value = (decimal)dsChiTiet.First().Quantity;
                }
            }
        }
        private int GetNumericPartOfMa(string ma)
        {
            if (ma.StartsWith("Lo") && int.TryParse(ma.Substring(2), out int lo))
            {
                return lo;
            }

            return int.MaxValue;
        }
        private async void LoadComboBox()
        {
            try
            {
                // Load cbCTT_MaLo
                List<Lo> dsLo = loService.LayDSLo();
                dsLo = dsLo.OrderBy(lo => GetNumericPartOfMa(lo.Lo_ID)).ToList();

                cbCTT_MaLo.DataSource = dsLo;
                cbCTT_MaLo.DisplayMember = "Lo_ID";
                cbCTT_MaLo.ValueMember = "Lo_ID";
                cbCTT_MaLo.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsLo.Count > 0)
                {
                    cbCTT_MaLo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCTT_Sua_Click(object sender, EventArgs e)
        {
            string ghiChu = txtCTT_GhiChu.Text.Trim();
            string maLo = cbCTT_MaLo.Text.Trim();
            string maThuoc = txtCTT_MaThuoc.Text.Trim();
            int soLuong = (int)numCTT_SoLuong.Value;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật chi tiết thuốc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật chi tiết thuốc {maThuoc}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var ctdn = new ChiTietThuoc
                {
                    Description = ghiChu,
                    Thuoc_ID = maThuoc,
                    Lo_ID = maLo,
                    Quantity = soLuong
                };

                var response = cttService.CapNhatCTT(maThuoc, ctdn);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật chi tiết thuốc {maThuoc} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataByMaThuoc(maThuoc);
                }
                else
                {
                    MessageBox.Show("Cập nhật chi tiết thuốc thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
