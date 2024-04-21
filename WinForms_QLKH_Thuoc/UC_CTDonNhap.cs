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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormQLKH
{
    public partial class UC_CTDonNhap : UserControl
    {
        private readonly CTDNhapService ctdnService;
        private readonly LoService loService;
        private readonly ThuocService thuocService;
        public UC_CTDonNhap()
        {
            InitializeComponent();

            ctdnService = new CTDNhapService("https://localhost:7195");
            thuocService = new ThuocService("https://localhost:7195");
            loService = new LoService("https://localhost:7195");

            txtCTDN_MaDN.ReadOnly = true;

            LoadComboBox();
        }
        public void LoadDataByMaDN(string maDN)
        {
            if (!string.IsNullOrEmpty(maDN))
            {
                List<ChiTietDonNhap> dsChiTiet = ctdnService.LayCTDN(maDN);

                if (dsChiTiet != null && dsChiTiet.Any())
                {
                    txtCTDN_MaDN.Text = maDN;
                    cbCTDN_MaLo.Text = dsChiTiet.First().Lo_ID;
                    cbCTDN_MaThuoc.Text = dsChiTiet.First().Thuoc_ID;
                    txtCTDN_GhiChu.Text = dsChiTiet.First().Description;
                    numCTDN_SoLuong.Value = dsChiTiet.First().Quantity ?? 0;
                }
            }
        }
        private int GetNumericPartOfMa(string ma)
        {
            if (ma.StartsWith("Lo") && int.TryParse(ma.Substring(2), out int result))
            {
                return result;
            }

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
                // Load cbCTDN_MaLo
                List<Lo> dsLo = loService.LayDSLo();
                dsLo = dsLo.OrderBy(lo => GetNumericPartOfMa(lo.Lo_ID)).ToList();

                cbCTDN_MaLo.DataSource = dsLo;
                cbCTDN_MaLo.DisplayMember = "Lo_ID";
                cbCTDN_MaLo.ValueMember = "Lo_ID";
                cbCTDN_MaLo.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dsLo.Count > 0)
                {
                    cbCTDN_MaLo.SelectedIndex = 0;
                }

                // Load cbCTDN_MaThuoc
                List<Thuoc> dst = thuocService.LayDSThuoc();
                dst = dst.OrderBy(t => GetNumericPartOfMa(t.Thuoc_ID)).ToList();

                cbCTDN_MaThuoc.DataSource = dst;
                cbCTDN_MaThuoc.DisplayMember = "Thuoc_ID";
                cbCTDN_MaThuoc.ValueMember = "Thuoc_ID";
                cbCTDN_MaThuoc.DropDownStyle = ComboBoxStyle.DropDownList;

                if (dst.Count > 0)
                {
                    cbCTDN_MaThuoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCTDN_Sua_Click(object sender, EventArgs e)
        {
            string maDN = txtCTDN_MaDN.Text.Trim();
            string ghiChu = txtCTDN_GhiChu.Text.Trim();
            string maThuoc = cbCTDN_MaThuoc.Text.Trim();
            string maLo = cbCTDN_MaLo.Text.Trim();
            int soLuong = (int)numCTDN_SoLuong.Value;

            string roleID = StateManager.RoleID?.Trim();

            if (!PermissionManager.CanUpdate(roleID))
            {
                MessageBox.Show("Bạn không có quyền cập nhật chi tiết đơn nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn chắc muốn cập nhật chi tiết đơn nhập {maDN}?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var ctdn = new ChiTietDonNhap
                {
                    DNhap_ID = maDN,
                    Description = ghiChu,
                    Thuoc_ID = maThuoc,
                    Lo_ID = maLo,
                    Quantity = soLuong
                };

                var response = ctdnService.CapNhatCTDN(maDN, ctdn);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Cập nhật chi tiết đơn nhập {maDN} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataByMaDN(maDN);
                }
                else
                {
                    MessageBox.Show("Cập nhật chi tiết đơn nhập thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
