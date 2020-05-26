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
        public SanPhamForm()
        {
            InitializeComponent();
            sanphamLogic = new SanphamLogic();
            sanphamRepo = new SanphamRepo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }
            var maSP = Utils.RandomString();
            do
            {
                maSP = Utils.RandomString();
            } while (sanphamRepo.GetOne(s => s.MaSP == maSP) != null);
            var tenSp = txtTen.Text;
            var giaBan = Int32.Parse(txtGiaban.Text);
            var congdung = txtCongdung.Text;
            var result = sanphamLogic.ThemSanPham(new SanPham()
            {

                MaSP = maSP,
                GiaBan = giaBan,
                CongDungSP = congdung,
                TenSP = tenSp
            });
            if (result)
            {
                MessageBox.Show("Thêm thành công");
                ReloadSP?.Invoke(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
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

            if (!Regex.Match(txtGiaban.Text, @"\p{L}+").Success)
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
