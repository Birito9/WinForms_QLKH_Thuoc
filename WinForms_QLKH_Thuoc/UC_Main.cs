using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp;

namespace FormQLKH
{
    public partial class UC_Main : UserControl
    {
        private UC_Loading ucLoading = new UC_Loading();
        private BackgroundWorker workerLoadData = new BackgroundWorker();
        public UC_Main()
        {
            InitializeComponent();

            Load += UC_Main_Load;
            workerLoadData.RunWorkerCompleted += WorkerLoadData_RunWorkerCompleted;
        }
        private async void ShowUC_QLChiNhanh()
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();
            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }
        }
        private void WorkerLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UC_QLChiNhanh ucCN = new UC_QLChiNhanh();
            ucCN.Parent = pnlShowForm;
            ucCN.Dock = DockStyle.Fill;
            ucCN.Show();

            pnlShowForm.Controls.OfType<UC_Loading>().FirstOrDefault()?.Hide();
        }
        private void UC_Main_Load(object sender, EventArgs e)
        {
            ShowUC_QLChiNhanh();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();

            Form parentForm = FindForm();
            if (parentForm is FrmMain frmMain)
            {
                frmMain.Hide();
            }

            frmLogin.Show();
        }
        private async void btnUser_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_QLTaiKhoan ucUser = new UC_QLTaiKhoan();
            pnlShowForm.Controls.Clear();
            ucUser.Parent = pnlShowForm;
            ucUser.Dock = DockStyle.Fill;
            ucUser.Show();

            ucLoading.Hide();
        }
        private async void btnQLNV_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_QLNV ucNV = new UC_QLNV();
            pnlShowForm.Controls.Clear();
            ucNV.Parent = pnlShowForm;
            ucNV.Dock = DockStyle.Fill;
            ucNV.Show();

            ucLoading.Hide();
        }
        private async void btnQLNT_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_QLNhomThuoc ucNT = new UC_QLNhomThuoc();
            pnlShowForm.Controls.Clear();
            ucNT.Parent = pnlShowForm;
            ucNT.Dock = DockStyle.Fill;
            ucNT.Show();

            ucLoading.Hide();
        }
        private async void btnQLT_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_QLThuoc ucThuoc = new UC_QLThuoc();
            pnlShowForm.Controls.Clear();
            ucThuoc.Parent = pnlShowForm;
            ucThuoc.Dock = DockStyle.Fill;
            ucThuoc.Show();
            ucLoading.Hide();
        }
        private async void btnQLDX_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_QLDonXuat ucDX = new UC_QLDonXuat();
            pnlShowForm.Controls.Clear();
            ucDX.Parent = pnlShowForm;
            ucDX.Dock = DockStyle.Fill;
            ucDX.Show();
            ucLoading.Hide();
        }
        private async void btnQLDN_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_QLDonNhap ucDN = new UC_QLDonNhap();
            pnlShowForm.Controls.Clear();
            ucDN.Parent = pnlShowForm;
            ucDN.Dock = DockStyle.Fill;
            ucDN.Show();
            ucLoading.Hide();
        }
        private async void btnQLLo_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_QLLo ucLo = new UC_QLLo();
            pnlShowForm.Controls.Clear();
            ucLo.Parent = pnlShowForm;
            ucLo.Dock = DockStyle.Fill;
            ucLo.Show();
            ucLoading.Hide();
        }
        private async void btnQLK_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_QLKho ucKho = new UC_QLKho();
            pnlShowForm.Controls.Clear();
            ucKho.Parent = pnlShowForm;
            ucKho.Dock = DockStyle.Fill;
            ucKho.Show();
            ucLoading.Hide();
        }
        private void btnQLCN_Click(object sender, EventArgs e)
        {
            ShowUC_QLChiNhanh();
        }
        private async void btnNCC_Click(object sender, EventArgs e)
        {
            ucLoading.Dock = DockStyle.Fill;
            pnlShowForm.Controls.Clear();
            pnlShowForm.Controls.Add(ucLoading);
            ucLoading.Show();

            await Task.Delay(1000);

            if (!workerLoadData.IsBusy)
            {
                workerLoadData.RunWorkerAsync();
            }
            else
            {
                return;
            }

            UC_NCC ucNCC = new UC_NCC();
            pnlShowForm.Controls.Clear();
            ucNCC.Parent = pnlShowForm;
            ucNCC.Dock = DockStyle.Fill;
            ucNCC.Show();
            ucLoading.Hide();
        }

        private bool isSubMenuVisible = true;

        private void ToggleQLK()
        {
            if (isSubMenuVisible)
            {
                pnlSubMenuKho.Visible = false;
                pbArrowQLK.Image = Properties.Resources.up_arrow;
            }
            else
            {
                pnlSubMenuKho.Visible = true;
                pbArrowQLK.Image = Properties.Resources.down_arrow;
            }

            isSubMenuVisible = !isSubMenuVisible;
        }
        private void pbArrowQLK_Click(object sender, EventArgs e)
        {
            ToggleQLK();
        }
        private void btnQuanLyKho_Click(object sender, EventArgs e)
        {
            ToggleQLK();
        }

        private void ToggleQLSP()
        {
            if (isSubMenuVisible)
            {
                pnlSubMenuDssp.Visible = false;
                pbArrowQLSP.Image = Properties.Resources.up_arrow;
            }
            else
            {
                pnlSubMenuDssp.Visible = true;
                pbArrowQLSP.Image = Properties.Resources.down_arrow;
            }

            isSubMenuVisible = !isSubMenuVisible;
        }
        private void pbArrowQLSP_Click(object sender, EventArgs e)
        {
            ToggleQLSP();
        }
        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            ToggleQLSP();
        }

        private void ToggleQLNV()
        {
            if (isSubMenuVisible)
            {
                pnlSubMenuDsnv.Visible = false;
                pbArrowQLNS.Image = Properties.Resources.up_arrow;
            }
            else
            {
                pnlSubMenuDsnv.Visible = true;
                pbArrowQLNS.Image = Properties.Resources.down_arrow;
            }

            isSubMenuVisible = !isSubMenuVisible;
        }
        private void pbArrowQLNS_Click(object sender, EventArgs e)
        {
            ToggleQLNV();
        }
        private void btnQLNS_Click(object sender, EventArgs e)
        {
            ToggleQLNV();
        }

        private void ToggleQLCT()
        {
            if (isSubMenuVisible)
            {
                pnlSubMenuQLCT.Visible = false;
                pbArrowQLCT.Image = Properties.Resources.up_arrow;
            }
            else
            {
                pnlSubMenuQLCT.Visible = true;
                pbArrowQLCT.Image = Properties.Resources.down_arrow;
            }

            isSubMenuVisible = !isSubMenuVisible;
        }
        private void pbArrowQLCT_Click(object sender, EventArgs e)
        {
            ToggleQLCT();
        }
        private void btnQLCT_Click(object sender, EventArgs e)
        {
            ToggleQLCT();
        }
        public void ShowUserNameLabel(string userName)
        {
            lbUserName.Text = userName;
        }
    }
}
