using QLTT.Logic;
using QLTT.Repos;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class NhanVienForm : Form
    {

        private readonly NhanVienLogic logic;
        private readonly NhanVienRepo nhanvienRepo;
        private readonly ChucVuRepo chucVuRepo;
        private bool isUpdateNhanVien = false;

        public NhanVienForm(bool isUpdateNhanvien = false, string diachi = "", string dienthoai = "", string email = "", bool gioitinh = false,
            string hoten = "", string ngaySinh = "", string username = "", string chucvu = "", string matkhau = "")
        {
            InitializeComponent();
            logic = new NhanVienLogic();
            nhanvienRepo = new NhanVienRepo();
            chucVuRepo = new ChucVuRepo();
            if (isUpdateNhanvien)
            {
                this.isUpdateNhanVien = isUpdateNhanvien;
                txtFullname.Text = hoten;
                txtAddress.Text = diachi;
                txtPhone.Text = dienthoai;
                txtEmail.Text = email;
                rdMale.Checked = gioitinh;
                dtBOD.Text = ngaySinh;
                txtUsername.Text = username;
                cmbChucVu.SelectedValue = chucvu;
                lblHeader.Text = "Cập Nhật Thông Tin Nhân Viên";
                cmbChucVu.Enabled = false;
                txtUsername.Enabled = false;
                txtPwd.Text = matkhau;

            }
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
            var hotenNV = txtFullname.Text.Trim();
            var diaChiNV = txtAddress.Text.Trim();
            var email = txtEmail.Text.Trim();
            var gioiTinh = rdMale.Checked ? "Nam" : "Nữ";
            var pwd = txtPwd.Text.Trim();
            var username = txtUsername.Text.Trim();
            var phone = txtPhone.Text.Trim();
            var ngaySinh = dtBOD.Text.Trim();
            var res = false;
            if (this.isUpdateNhanVien)
            {
                res = logic.ThayDoiThongTin(username, pwd, phone, diaChiNV, email, gioiTinh, hotenNV, ngaySinh);
            }
            else
            {
                res = logic.DangKi(username, pwd, maNV, diaChiNV, email, gioiTinh, hotenNV, cmbChucVu.SelectedValue.ToString().Trim(), ngaySinh);

            }
            if (res)
            {
                MessageBox.Show("Thực hiện hành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thực hiện thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
