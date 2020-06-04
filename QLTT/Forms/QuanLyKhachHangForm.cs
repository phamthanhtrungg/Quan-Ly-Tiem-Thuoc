using QLTT.Logic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class QuanLyKhachHangForm : Form
    {
        private KhachHangRepo khachHangRepo;
        private KhachHangLogic khachHangLogic;
        private bool isThem = false;
        public QuanLyKhachHangForm()
        {
            InitializeComponent();
            LoadKhachHang();
            var maNcc = dataGridView1.Rows[0].Cells[0].Value.ToString().Trim();
            var tenNcc = dataGridView1.Rows[0].Cells[1].Value.ToString().Trim();
            var diachiNcc = dataGridView1.Rows[0].Cells[2].Value.ToString().Trim();
            var dtNcc = dataGridView1.Rows[0].Cells[3].Value.ToString().Trim();
            txtMancc.Text = maNcc;
            txtName.Text = tenNcc;
            txtAddress.Text = diachiNcc;
            txtPhone.Text = dtNcc;
            khachHangLogic = new KhachHangLogic();
        }

        private void LoadKhachHang()
        {
            dataGridView1.Rows.Clear();
            khachHangRepo = new KhachHangRepo();
            foreach (var k in khachHangRepo.List())
            {
                dataGridView1.Rows.Add(k.MaKH, k.HoTenKH, k.DienThoaiKH, k.DienThoaiKH);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var maNcc = selectedRow.Cells[0].Value.ToString().Trim();
            var tenNcc = selectedRow.Cells[1].Value.ToString().Trim();
            var diachiNcc = selectedRow.Cells[2].Value.ToString().Trim();
            var dtNcc = selectedRow.Cells[3].Value.ToString().Trim();
            txtMancc.Text = maNcc;
            txtName.Text = tenNcc;
            txtAddress.Text = diachiNcc;
            txtPhone.Text = dtNcc;
        }
        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.Match(txtPhone.Text, @"^\d+$").Success || txtPhone.Text.Trim().Length == 0)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Số điện thoại không hợp lệ");
            }
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView1.SelectedRows[0];
            var maKH = selectedRow.Cells[0].Value.ToString().Trim();
            if (khachHangLogic.XoaKhachHang(int.Parse(maKH)))
            {
                MessageBox.Show("Thực hiện thành công");
                LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Thực hiện thật bại");
            }

        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            btnSave.Enabled = txtAddress.Enabled = txtPhone.Enabled = txtName.Enabled = true;
            btnTHem.Enabled = false;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var khacHang = new KhachHang()
            {
                MaKH = int.Parse(txtMancc.Text.Trim()),
                HoTenKH = txtName.Text.Trim(),
                DienThoaiKH = int.Parse(txtPhone.Text.Trim()),
                DiaChiKH = txtAddress.Text.Trim()
            };
            if (!isThem)
            {
                if (khachHangLogic.SuaKhachHang(khacHang))
                {
                    MessageBox.Show("Thực hiện thành công");
                    LoadKhachHang();
                    btnSave.Enabled = false;
                    btnEdit.Enabled = btnTHem.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Thực hiện thật bại");
                }
            }
            else
            {
                if (khachHangLogic.ThemKhachHang(khacHang))
                {
                    MessageBox.Show("Thực hiện thành công");
                    LoadKhachHang();
                    btnSave.Enabled = false;
                    btnEdit.Enabled = btnTHem.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Thực hiện thật bại");
                }
            }

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            LoadKhachHang();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            isThem = true;
            txtMancc.Enabled = btnSave.Enabled = txtAddress.Enabled = txtPhone.Enabled = txtName.Enabled = true;
            txtMancc.ResetText();
            txtName.ResetText();
            txtAddress.ResetText();
            txtPhone.ResetText();
            btnEdit.Enabled = false;
        }
    }
}
