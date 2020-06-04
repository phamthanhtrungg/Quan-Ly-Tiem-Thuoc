using QLTT.Logic;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class QuanLyPhieuNhapForm : Form
    {
        private PhieuNhapRepo phieuNhapRepo;
        private PhieuNhapLogic phieuNhapLogic;
        private string maNv = "";
        public QuanLyPhieuNhapForm(string maNv = "")
        {
            InitializeComponent();
            LoadPhieuNhap();
            this.maNv = maNv;
            phieuNhapLogic = new PhieuNhapLogic();
        }

        private void LoadPhieuNhap()
        {
            dataGridView1.Rows.Clear();
            phieuNhapRepo = new PhieuNhapRepo();
            foreach (var item in phieuNhapRepo.List())
            {
                dataGridView1.Rows.Add(item.MaPhieuNhap, item.MaNV, item.NhanVien.HoTenNV, item.MaSP, item.TenSP, item.SoLuongNhap, item.NgayNhap, item.GiaNhap);
            }
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView1.SelectedRows[0];
            var maPhieuNhap = selectedRow.Cells[0].Value.ToString().Trim();
            if (phieuNhapLogic.XoaPhieuNhap(int.Parse(maPhieuNhap)))
            {
                MessageBox.Show("Thao tác thành công");
                LoadPhieuNhap();
            }
            else
            {
                MessageBox.Show("Thao tác thất bại");
            };
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView1.SelectedRows[0];
            var maPhieuNhap = selectedRow.Cells[0].Value.ToString().Trim();
            var phieuNhapForm = new PhieuNhapForm(this.maNv, true, int.Parse(maPhieuNhap));
            phieuNhapForm.ShowDialog();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            LoadPhieuNhap();
        }
    }
}
