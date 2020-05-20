using QLTT.Logic;
using QLTT.Repos;
using System.ComponentModel;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class Registration : Form
    {
        private bool showLblInfo = false;
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

        private void timerInfo_Tick(object sender, System.EventArgs e)
        {
            if (showLblInfo)
            {
                lblInfo.Visible = false;
            }
            else
            {
                lblInfo.Visible = true;
            }
            showLblInfo = !showLblInfo;
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }
            var maNV = "";
            do
            {
                maNV = Utils.RandomString();
            } while (nhanvienRepo.GetOne(n => n.MaNV == maNV) != null);
            var hotenNV = txtFullname.Text;
            var diaChiNV = txtAddress.Text;
            var email = txtEmail.Text;
            var gioiTinh = rdMale.Checked;
            var pwd = txtPwd.Text;
            var username = txtUsername.Text;
            var phone = txtPhone.Text;
            var ngaySinh = dtBOD.Text;
        }

        private void Registration_Load(object sender, System.EventArgs e)
        {
            cmbChucVu.DataSource = chucVuRepo.GetAll();
            cmbChucVu.ValueMember = "MaCV";
            cmbChucVu.DisplayMember = "TenCV";
        }

        private void Validation_Not_Empty(object sender, CancelEventArgs e)
        {
            Label label = sender as Label;
            if (label.Text.Length == 0)
            {
                errorProvider1.SetError(label, "Không thể trống");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(label, null);
                e.Cancel = false;
            }
        }
    }
}
