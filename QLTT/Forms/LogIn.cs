using QLTT.Forms;
using QLTT.Logic;
using System.Windows.Forms;

namespace QLTT
{
    public partial class LogIn : Form
    {
        private readonly NhanVienLogic nhanVienLogic;
        public LogIn()
        {
            InitializeComponent();
            nhanVienLogic = new NhanVienLogic();
        }

        private void btnQuit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)

        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }

            var password = txtPassword.Text.Trim();
            var username = txtUsername.Text.Trim();

            var result = nhanVienLogic.DanhNhap(username, password);


            if (!result)
            {

                MessageBox.Show("Invalid username or password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                var main = new Main(txtUsername.Text);
                this.Hide();
                main.ShowDialog();
                this.Show();

            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtPassword.TextLength == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password must not be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtUsername.TextLength == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Username must not be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void txtRegister_Click(object sender, System.EventArgs e)
        {
            var registrationForm = new NhanVienForm();
            registrationForm.ShowDialog();
        }

        private void labelFgP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgotPassword = new ForgotPassword();
            forgotPassword.ShowDialog();
        }
    }
}
