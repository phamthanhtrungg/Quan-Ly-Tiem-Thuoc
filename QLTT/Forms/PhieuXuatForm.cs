using QLTT.Logic;
using QLTT.Repos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class PhieuXuatForm : Form
    {
        public event EventHandler Reload;
        private KhoThuocRepo khoThuocRepo;
        private PhieuXuatLogic phieuXuatLogic;
        private PhieuXuatRepo phieuXuatRepo;
        private bool isUpdateMode = false;
        private int maPhieuXuat = 0;
        public PhieuXuatForm(string maNv = "", bool isUpdateMode = false, int maPhieuXuat = 0)
        {
            InitializeComponent();
            khoThuocRepo = new KhoThuocRepo();
            phieuXuatLogic = new PhieuXuatLogic();
            phieuXuatRepo = new PhieuXuatRepo();
            LoadSanPham();
            txtMaNv.Text = maNv;
            if (isUpdateMode)
            {
                this.maPhieuXuat = maPhieuXuat;
                this.isUpdateMode = isUpdateMode;
                txtMaNv.Enabled = txtSoLuong.Enabled = dateTimePicker1.Enabled = cmbMaSp.Enabled = false;
                var phieuXuat = phieuXuatRepo.GetOne(p => p.MaPhieuXuat == maPhieuXuat);
                if (phieuXuat != null)
                {
                    txtMaNv.Text = maNv;
                    cmbMaSp.SelectedValue = phieuXuat.MaSP;
                    txtSoLuong.Text = phieuXuat.SoLuongXuat.ToString();
                    txtGiaBan.Text = phieuXuat.GiaBan.ToString();
                    dateTimePicker1.Value = phieuXuat.NgayXuat;
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadSanPham()
        {

            khoThuocRepo = new KhoThuocRepo();
            cmbMaSp.DataSource = khoThuocRepo.List();
            cmbMaSp.ValueMember = "maSp";
            cmbMaSp.DisplayMember = "tenSp";
        }

        private void txtGiaBan_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.Match(txtGiaBan.Text, @"[1-9]+").Success)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtGiaBan, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtGiaBan, "Giá bán không hợp lệ");
            }
        }
        private void txtSoLuong_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (Regex.Match(txtSoLuong.Text, @"[1-9]+").Success)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSoLuong, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSoLuong, "Số lượng không hợp lệ");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }
            var maNv = txtMaNv.Text.Trim();
            var giaBan = int.Parse(txtGiaBan.Text.Trim());
            var maSp = cmbMaSp.SelectedValue.ToString().Trim();
            var tenSp = cmbMaSp.Text.Trim();
            var ngayXuat = dateTimePicker1.Value;
            var sl = int.Parse(txtSoLuong.Text.Trim());
            var phieuXuat = new PhieuXuat()
            {
                MaNV = maNv,
                GiaBan = giaBan,
                TenSP = tenSp,
                MaSP = maSp,
                NgayXuat = ngayXuat,
                SoLuongXuat = sl,
                MaPhieuXuat = this.maPhieuXuat
            };
            if (!isUpdateMode)
            {
                if (phieuXuatLogic.ThemPhieuXuat(phieuXuat))
                {
                    MessageBox.Show("Thực hiện hành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSanPham();
                    Close();
                }
                else
                {
                    MessageBox.Show("Thực hiện thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (phieuXuatLogic.CapNhatSanPham(phieuXuat))
                {
                    MessageBox.Show("Thực hiện hành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSanPham();
                    Close();
                }
                else
                {
                    MessageBox.Show("Thực hiện thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
