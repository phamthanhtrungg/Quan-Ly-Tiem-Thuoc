using QLTT.Logic;
using QLTT.Repos;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class NccForm : Form
    {
        private NccRepo nccRepo;
        private NccLogic nccLogic;
        private bool isAdd = false;
        private bool isEdit = false;

        public NccForm()
        {
            InitializeComponent();
            nccRepo = new NccRepo();
            nccLogic = new NccLogic();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void NccForm_Load(object sender, System.EventArgs e)
        {
            LoadNcc();
            var maNcc = dataGridView1.Rows[0].Cells[0].Value.ToString().Trim();
            var tenNcc = dataGridView1.Rows[0].Cells[1].Value.ToString().Trim();
            var diachiNcc = dataGridView1.Rows[0].Cells[2].Value.ToString().Trim();
            var dtNcc = dataGridView1.Rows[0].Cells[3].Value.ToString().Trim();
            txtMancc.Text = maNcc;
            txtName.Text = tenNcc;
            txtAddress.Text = diachiNcc;
            txtPhone.Text = dtNcc;
        }

        private void LoadNcc()
        {
            dataGridView1.Rows.Clear();
            foreach (var ncc in nccRepo.List())
            {
                dataGridView1.Rows.Add(ncc.MaNCC, ncc.TenNCC, ncc.DiaChiNCC, ncc.DienThoaiNCC, "")
;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0].Index;
            var maNcc = dataGridView1.Rows[selectedRow].Cells[0].Value.ToString().Trim();
            var tenNcc = dataGridView1.Rows[selectedRow].Cells[1].Value.ToString().Trim();
            var diachiNcc = dataGridView1.Rows[selectedRow].Cells[2].Value.ToString().Trim();
            var dtNcc = dataGridView1.Rows[selectedRow].Cells[3].Value.ToString().Trim();
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

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            btnEdit.Enabled = false;
            isAdd = true;
            txtMancc.Text = txtName.Text = txtAddress.Text = txtPhone.Text = "";
            txtName.Enabled = txtAddress.Enabled = txtPhone.Enabled = true;

            var maNcc = "NCC_" + Utils.RandomString();
            do
            {
                maNcc = "NCC_" + Utils.RandomString();
            } while (nccRepo.GetOne(n => n.MaNCC == maNcc) != null);
            txtMancc.Text = maNcc;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                return;
            }
            var ncc = new NhaCungCap()
            {
                MaNCC = txtMancc.Text.Trim(),
                TenNCC = txtName.Text.Trim(),
                DienThoaiNCC = txtPhone.Text.Length == 0 ? 0 : int.Parse(txtPhone.Text.Trim()),
                DiaChiNCC = txtAddress.Text.Trim()
            };
            if (isAdd)
            {
                if (nccLogic.ThemNCC(ncc))
                {
                    MessageBox.Show("Thực hiện hành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNcc();
                }
                else
                {
                    MessageBox.Show("Thực hiện thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (isEdit)
            {
                if (nccLogic.SuaNCC(ncc))
                {
                    MessageBox.Show("Thực hiện hành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNcc();
                }
                else
                {
                    MessageBox.Show("Thực hiện thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnEdit.Enabled = btnAdd.Enabled = true;
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.Match(txtName.Text, @"[a-zA-Z]+\s+").Success)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "Tên không hợp lệ");
            }
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            isEdit = true;
            btnAdd.Enabled = false;
            txtName.Enabled = txtAddress.Enabled = txtPhone.Enabled = true;
        }
    }
}
