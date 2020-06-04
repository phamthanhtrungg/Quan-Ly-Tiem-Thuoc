using QLTT.Logic;
using QLTT.Repos;
using System.Linq;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class QuanLyHoaDonForm : Form
    {
        private HoadonRepo hoadonRepo;
        private QuanLyNhaThuocEntities entities = new QuanLyNhaThuocEntities();
        private string maNV = "";
        private HoaDonLogic hoaDonLogic;
        public QuanLyHoaDonForm(string maNv = "")
        {
            InitializeComponent();
            LoadHoaDon();
            hoaDonLogic = new HoaDonLogic();
            this.maNV = maNv;
        }

        private void LoadHoaDon()
        {
            hoadonRepo = new HoadonRepo();
            dataGridView1.Rows.Clear();
            foreach (var h in hoadonRepo.List())
            {
                dataGridView1.Rows.Add(h.MaHD, h.MaKH, h.KhachHang.HoTenKH, h.MaNV, h.NhanVien.HoTenNV, h.NgayLapHD, h.TongTien);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            LoadHoaDon();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var hoadonForm = new FormHoaDon(this.maNV);
            hoadonForm.ShowDialog();
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var maHD = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            if (hoaDonLogic.XoaHoaDon(int.Parse(maHD)))
            {
                MessageBox.Show("Thực hiện thành công");
                LoadHoaDon();
            }
            else
            {
                MessageBox.Show("Thực hiện thất bại");
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var maHD = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            var chiTietHD = new ChiTietHDForm(int.Parse(maHD));
            chiTietHD.ShowDialog();
        }

        private void QuanLyHoaDonForm_Load(object sender, System.EventArgs e)
        {

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var sp = entities.CT_HoaDon.GroupBy(n => n.MaSP).Select(x => new
            {
                maSp = x.Max(g => g.MaSP),
                count = x.Count(),
                key = x.Key
            })
            .OrderBy(n => n.maSp).ToList()[0].maSp;
            var spInDb = entities.SanPhams.Where(m => m.MaSP == sp).SingleOrDefault();
            MessageBox.Show($"{spInDb.MaSP} {spInDb.TenSP} {spInDb.GiaBan}");
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var doanhThu = new DoanhThu().ShowDialog();


        }
    }
}
