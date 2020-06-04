using QLTT.Logic;
using QLTT.Repos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class PhieuNhapForm : Form
    {
        private NccRepo nccRepo;
        private PhieuNhapLogic phieuNhapLogic;
        private PhieuNhapRepo phieuNhapRepo;
        private KhoThuocRepo khoThuocRepo;
        private bool isUpdatePhieuNhap = false;
        public event EventHandler ReloadData;
        private int maPhieuNhap = 0;
        public PhieuNhapForm(string maNV = "", bool isUpdatePhieuNhap = false, int maPhieuNhap = 0)
        {
            InitializeComponent();
            nccRepo = new NccRepo();
            khoThuocRepo = new KhoThuocRepo();
            phieuNhapLogic = new PhieuNhapLogic();
            phieuNhapRepo = new PhieuNhapRepo();
            if (isUpdatePhieuNhap)
            {
                this.maPhieuNhap = maPhieuNhap;
                this.isUpdatePhieuNhap = isUpdatePhieuNhap;
                dateTimePicker1.Enabled = cmbMaSp.Enabled = cmbNcc.Enabled = txtSoLuong.Enabled = false;
                var phieuNhap = phieuNhapRepo.GetOne(k => k.MaPhieuNhap == maPhieuNhap);
                if (phieuNhap != null)
                {
                    cmbMaSp.SelectedValue = phieuNhap.MaSP;
                    cmbNcc.SelectedValue = phieuNhap.MaNCC;
                    txtSoLuong.Text = phieuNhap.SoLuongNhap.ToString();
                    txtGiaNhap.Text = phieuNhap.GiaNhap.ToString();
                    dateTimePicker1.Value = phieuNhap.NgayNhap;
                    txtMaNv.Enabled = cmbMaSp.Enabled = cmbNcc.Enabled = dateTimePicker1.Enabled = txtSoLuong.Enabled = false;
                }

            }
            txtMaNv.Text = maNV;

        }


        private void LoadData()
        {
            nccRepo = new NccRepo();
            khoThuocRepo = new KhoThuocRepo();
            cmbNcc.DataSource = nccRepo.List();
            cmbNcc.DisplayMember = "TenNCC";
            cmbNcc.ValueMember = "MaNCC";

            cmbMaSp.DataSource = khoThuocRepo.List();
            cmbMaSp.DisplayMember = "tenSp";
            cmbMaSp.ValueMember = "maSp";


        }

        private void PhieuNhapForm_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void txtGiaNhap_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.Match(txtGiaNhap.Text, @"^\d+$").Success)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtGiaNhap, null);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtGiaNhap, "Giá nhập không hợp lệ");
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }
            var maNv = txtMaNv.Text.Trim();
            var maNcc = cmbNcc.SelectedValue.ToString().Trim();
            var gia = txtGiaNhap.Text.Trim();
            var sl = txtSoLuong.Text.Trim();
            var ngayNhap = dateTimePicker1.Value;
            var maSp = cmbMaSp.SelectedValue.ToString().Trim();
            var tenSP = cmbMaSp.Text.Trim();
            var phieuNhap = new PhieuNhap()
            {
                MaSP = maSp,
                TenSP = tenSP,
                MaNCC = maNcc,
                GiaNhap = int.Parse(gia),
                SoLuongNhap = int.Parse(sl),
                NgayNhap = ngayNhap,
                MaNV = maNv
                ,
                MaPhieuNhap = this.maPhieuNhap
            };
            if (!this.isUpdatePhieuNhap)
            {
                if (phieuNhapLogic.ThemPhieuNhap(phieuNhap))
                {
                    MessageBox.Show("Thực hiện hành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadData?.Invoke(sender, e);
                    Close();
                }
                else
                {
                    MessageBox.Show("Thực hiện thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (phieuNhapLogic.CapNhatPhieuNhap(phieuNhap))
                {
                    MessageBox.Show("Thực hiện hành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadData?.Invoke(sender, e);
                    Close();
                }
                else
                {
                    MessageBox.Show("Thực hiện thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnQuit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtSoLuong_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (Regex.Match(txtSoLuong.Text, @"^\d+$").Success)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSoLuong, null);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSoLuong, "Số lượng nhập không hợp lệ");
            }
        }

        private void cmbNcc_MouseClick(object sender, MouseEventArgs e)
        {
            LoadData();
        }

        private void cmbMaSp_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
