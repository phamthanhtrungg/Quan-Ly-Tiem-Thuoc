using QLTT.Logic;
using QLTT.Repos;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class Registration : Form
    {

        private readonly NhanVienLogic logic;
        private readonly NhanVienRepo nhanvienRepo;
        private readonly ChucVuRepo chucVuRepo;

        public Registration()
        {
            InitializeComponent();
            logic = new NhanVienLogic();
            nhanvienRepo = new NhanVienRepo();
            chucVuRepo = new ChucVuRepo();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            Close();
        }



        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }
            var maNV = cmbChucVu.SelectedValue.ToString().Trim() + "_";
            do
            {
                maNV = cmbChucVu.SelectedValue.ToString().Trim() + "_" + Utils.RandomString();
            } while (nhanvienRepo.GetOne(n => n.MaNV == maNV) != null);
            var hotenNV = txtFullname.Text;
            var diaChiNV = txtAddress.Text;
            var email = txtEmail.Text;
            var gioiTinh = rdMale.Checked ? "Nam" : "Nữ";
            var pwd = txtPwd.Text;
            var username = txtUsername.Text;
            var phone = txtPhone.Text;
            var ngaySinh = dtBOD.Text;
            var res = logic.Register(username, pwd, maNV, diaChiNV, email, gioiTinh, hotenNV, cmbChucVu.SelectedValue.ToString().Trim(), ngaySinh); ;
            if (res)
            {
                MessageBox.Show("Đăng kí thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng kí thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Registration_Load(object sender, System.EventArgs e)
        {
            cmbChucVu.DataSource = chucVuRepo.GetAll();
            cmbChucVu.ValueMember = "MaCV";
            cmbChucVu.DisplayMember = "TenCV";
        }

        private void txtFullname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(txtFullname.Text, @"\b^[A-Z]\p{L}+\s*\b").Success)
            {
                errorProvider1.SetError(txtFullname, "Tên không hợp lệ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtFullname, null);
                e.Cancel = false;
            }
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(txtUsername.Text, @"^[a-zA-Z0-9\\_]{8,}").Success)
            {
                errorProvider1.SetError(txtUsername, "Username không hợp lệ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
                e.Cancel = false;
            }
        }

        private void txtPwd_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(txtPwd.Text, @"^[a-zA-Z0-9\\_]{8,}").Success)
            {
                errorProvider1.SetError(txtPwd, "Password không hợp lệ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPwd, null);
                e.Cancel = false;
            }

        }
    }
}
