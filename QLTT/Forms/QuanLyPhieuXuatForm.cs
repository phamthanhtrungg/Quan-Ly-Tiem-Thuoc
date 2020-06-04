using QLTT.Logic;
using QLTT.Repos;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class QuanLyPhieuXuatForm : Form
    {
        private PhieuXuatRepo phieuXuatRepo;
        private PhieuXuatLogic phieuXuatLogic;
        private string maNv = "";
        public QuanLyPhieuXuatForm(string maNV = "")
        {
            InitializeComponent();
            LoadPhieuXuat();
            phieuXuatLogic = new PhieuXuatLogic();
            this.maNv = maNV;
        }

        private void LoadPhieuXuat()
        {
            dataGridView1.Rows.Clear();
            phieuXuatRepo = new PhieuXuatRepo();
            foreach (var item in phieuXuatRepo.List())
            {
                dataGridView1.Rows.Add(item.MaPhieuXuat, item.MaNV, item.NhanVien.HoTenNV, item.MaSP, item.TenSP, item.SoLuongXuat, item.NgayXuat, item.GiaBan);
            }
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            var selectedRow = dataGridView1.SelectedRows[0];
            var maPhieuXuat = selectedRow.Cells[0].Value.ToString().Trim();
            if (phieuXuatLogic.XoaPhieuXuat(int.Parse(maPhieuXuat)))
            {
                MessageBox.Show("Thực hiện thành công");
                LoadPhieuXuat();
            }
            else
            {
                MessageBox.Show("Thực hiện thất bại");
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            LoadPhieuXuat();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            var selectedRow = dataGridView1.SelectedRows[0];
            var maPhieuXuat = selectedRow.Cells[0].Value.ToString().Trim();
            var phieuXuatForm = new PhieuXuatForm(maNv, true, int.Parse(maPhieuXuat));
            phieuXuatForm.ShowDialog();
        }
    }
}
