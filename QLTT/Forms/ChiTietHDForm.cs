using System.Linq;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class ChiTietHDForm : Form
    {
        private int maHD = 0;
        private QuanLyNhaThuocEntities entities = new QuanLyNhaThuocEntities();
        public ChiTietHDForm(int maHD = 0)
        {
            InitializeComponent();
            this.maHD = maHD;

            foreach (var item in entities.CT_HoaDon.ToList())
            {
                dataGridView1.Rows.Add(item.MaHD, item.MaSP, item.SoLuong, item.DonGia);
            }

        }
    }
}
