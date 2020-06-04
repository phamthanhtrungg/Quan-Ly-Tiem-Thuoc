using QLTT.Logic;
using QLTT.Repos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class KhoThuocForm : Form
    {
        private SanphamRepo sanphamRepo;
        private KhoThuocRepo khoThuocRepo;
        private KhoThuocLogic khoThuocLogic;
        private string maNv = "";
        private bool isEdit = false;
        private bool isAdd = false;
        public KhoThuocForm(string maNv = "")
        {
            InitializeComponent();
            sanphamRepo = new SanphamRepo();
            khoThuocRepo = new KhoThuocRepo();
            khoThuocLogic = new KhoThuocLogic();
            LoadKhoThuoc();
            var tenSp = dataGridView1.Rows[0].Cells[1].Value.ToString();
            var MaSp = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txtTenSp.Text = tenSp;
            txtMasp.Text = MaSp;
            if (maNv.Length != 0) this.maNv = maNv;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void LoadKhoThuoc()
        {
            khoThuocRepo = new KhoThuocRepo();
            dataGridView1.Rows.Clear();
            foreach (var khoThuoc in khoThuocRepo.List())
            {
                dataGridView1.Rows.Add(khoThuoc.MaSP, khoThuoc.TenSP, khoThuoc.SoLuongTaiKho);
            }
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            var phieuNhap = new PhieuNhapForm(this.maNv);
            phieuNhap.ReloadData += PhieuNhap_ReloadData;
            phieuNhap.Show();
        }

        private void PhieuNhap_ReloadData(object sender, EventArgs e)
        {
            LoadKhoThuoc();

        }
        private void txtMasp_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.Match(txtTenSp.Text, @"\w+").Success)
            {

                e.Cancel = false;
                errorProvider1.SetError(txtMasp, null);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMasp, "Mã sản phẩm không hợp lệ");
            }
        }
        private void txtTenSp_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.Match(txtTenSp.Text, @"[a-zA-z]+\s*").Success)
            {

                e.Cancel = false;
                errorProvider1.SetError(txtTenSp, null);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTenSp, "Tên sản phẩm không hợp lệ");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3)
            {
                var selectedRows = dataGridView1.SelectedRows;
                var maSp = selectedRows[0].Cells[0].Value.ToString();

                if (khoThuocLogic.XoaSanPham(maSp))
                {
                    MessageBox.Show("Thao tác thánh công");
                    LoadKhoThuoc();
                }
                else
                {
                    MessageBox.Show("Thao tác thánh công");
                }
                return;
            }
            else
            {
                var selectedRows = dataGridView1.SelectedRows;
                var tenSp = selectedRows[0].Cells[1].Value.ToString();
                var MaSp = selectedRows[0].Cells[0].Value.ToString();
                txtTenSp.Text = tenSp;
                txtMasp.Text = MaSp;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtTenSp.Enabled = true;
            isEdit = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            txtTenSp.Enabled = true;
            txtTenSp.Text = "";
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            txtMasp.Text = "SP_" + Utils.RandomString();
            do
            {
                txtMasp.Text = "SP_" + Utils.RandomString();
            } while (khoThuocRepo.GetOne(k => k.MaSP == txtMasp.Text) != null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var khoThuoc = new KhoThuoc()
            {
                MaSP = txtMasp.Text.Trim(),
                TenSP = txtTenSp.Text.Trim(),
                SoLuongTaiKho = 0
            };
            if (isEdit)
            {

                if (khoThuocLogic.CapNhatSanPham(khoThuoc))
                {
                    MessageBox.Show("Thao tác thánh công");
                    LoadKhoThuoc();
                }
                else
                {
                    MessageBox.Show("Thao tác thánh công");
                }
            }
            if (isAdd)
            {

                if (khoThuocLogic.ThemSanPham(khoThuoc))
                {
                    MessageBox.Show("Thao tác thánh công");
                    LoadKhoThuoc();
                }
                else
                {
                    MessageBox.Show("Thao tác thánh công");
                }

            }
            btnSave.Enabled = false;
            btnEdit.Enabled = btnAdd.Enabled = true;
        }

        private void btnPNhap_Click(object sender, EventArgs e)
        {
            var formPhieuNhap = new PhieuNhapForm(this.maNv);
            formPhieuNhap.ReloadData += FormPhieuNhap_ReloadData;
            formPhieuNhap.Show();
        }

        private void FormPhieuNhap_ReloadData(object sender, EventArgs e)
        {
            LoadKhoThuoc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadKhoThuoc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var quanLyPhieuNhap = new QuanLyPhieuNhapForm(this.maNv);
            quanLyPhieuNhap.ShowDialog();
        }
    }
}
