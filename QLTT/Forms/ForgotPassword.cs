using QLTT.Repos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class ForgotPassword : Form
    {
        private readonly NhanVienRepo nhanVienRepo;
        public ForgotPassword()
        {
            InitializeComponent();
            nhanVienRepo = new NhanVienRepo();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }
            var nhanvien = nhanVienRepo.GetOne(n => n.Username == txtUE.Text.Trim());
            if (nhanvien == null)
            {
                MessageBox.Show("Username không tồn tại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Mật khẩu của bạn: {nhanvien.Password}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtUE_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(txtUE.Text, @"^[a-zA-Z0-9\\_]{8,}").Success)
            {
                errorProvider1.SetError(txtUE, "Username không hợp lệ ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUE, null);
                e.Cancel = false;
            }
        }
    }
}
