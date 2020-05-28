using QLTT.Logic;
using QLTT.Repos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class SanPhamForm : Form
    {
        private readonly SanphamLogic sanphamLogic;
        private readonly SanphamRepo sanphamRepo;
        public event EventHandler ReloadSP;
        private bool isThemSp = true;

        public SanPhamForm(bool isUpdateSp = false, string maSP = "", string tenSP = "", string giabanSP = "", string congdungSP = "")
        {
            InitializeComponent();
            sanphamLogic = new SanphamLogic();
            sanphamRepo = new SanphamRepo();
            if (isUpdateSp)
            {
                lblMaSp.Visible = true;
                txtMaSP.Visible = true;
                lblHeader.Text = "Cập Nhật Sản Phẩm";
                this.isThemSp = !isUpdateSp;
                txtMaSP.Text = maSP;
                txtTen.Text = tenSP;
                txtGiaban.Text = giabanSP;
                txtCongdung.Text = congdungSP;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }
            var maSP = isThemSp ? Utils.RandomString() : txtMaSP.Text;
            do
            {
                maSP = Utils.RandomString();
            } while (sanphamRepo.GetOne(s => s.MaSP == maSP) != null && isThemSp);
            var tenSp = txtTen.Text;
            var giaBan = Int32.Parse(txtGiaban.Text);
            var congdung = txtCongdung.Text;
            var result = true;
            var sp = new SanPham()
            {

                MaSP = isThemSp ? maSP : txtMaSP.Text,
                GiaBan = giaBan,
                CongDungSP = congdung,
                TenSP = tenSp
            };
            if (isThemSp)
            {
                result = sanphamLogic.ThemSanPham(sp);
            }
            else
            {
                result = sanphamLogic.CapNhatSanPham(sp);
            }

            if (result)
            {
                MessageBox.Show("Thao tác thánh công");
                ReloadSP?.Invoke(sender, e);
            }
            else
            {
                MessageBox.Show("Thao tác thất bại");
            }
            Close();
        }

        private void txtTen_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtTen.TextLength == 0)
            {
                errorProvider1.SetError(txtTen, "Tên không hợp lệ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTen, null);
                e.Cancel = false;
            }
        }

        private void txtCongdung_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (Regex.Match(txtCongdung.Text, @"\d+").Success)
            {
                errorProvider1.SetError(txtCongdung, "Công dụng không hợp lệ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCongdung, null);
                e.Cancel = false;
            }
        }

        private void txtGiaban_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.Match(txtGiaban.Text, @"\b\d+\b").Success)
            {
                errorProvider1.SetError(txtGiaban, "Giá bán không hợp lệ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtGiaban, null);
                e.Cancel = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCongdung.ResetText();
            txtTen.ResetText();
            txtGiaban.ResetText();
        }
    }
}
