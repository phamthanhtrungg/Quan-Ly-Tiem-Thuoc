using QLTT.Repos;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class PhieuNhapForm : Form
    {
        private NccRepo nccRepo;
        private bool isUpdatePhieuNhap = false;
        public PhieuNhapForm(string maNV = "", bool isUpdatePhieuNhap = false)
        {
            InitializeComponent();
            nccRepo = new NccRepo();
            if (isUpdatePhieuNhap)
            {
                this.isUpdatePhieuNhap = isUpdatePhieuNhap;

            }
            txtMaNv.Text = maNV;

        }


        private void LoadData()
        {
            nccRepo = new NccRepo();
            cmbNcc.DataSource = nccRepo.List();
            cmbNcc.DisplayMember = "TenNCC";
            cmbNcc.ValueMember = "MaNCC";
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
    }
}
