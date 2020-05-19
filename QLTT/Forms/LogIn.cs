using QLTT.Forms;
using QLTT.Logic;
using System.Text;
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

            var hashedPassword = new MyCrypto(txtPassword.Text.Trim()).ToArray();

            var result = false;
            if (rdNewUser.Checked)
            {
                result = nhanVienLogic.Register(txtUsername.Text.Trim(), Encoding.UTF8.GetString(hashedPassword));
            }
            else
            {
                result = nhanVienLogic.Login(txtUsername.Text.Trim(), Encoding.UTF8.GetString(hashedPassword));
            }

            if (!result)
            {
                if (rdNewUser.Checked)
                {
                    MessageBox.Show("Something wrong happened", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Invalid username or password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                var main = new Main();
                this.Hide();
                main.Show();
                this.Show();
                main.Dispose();
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
    }
}
