using System.Linq;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class DoanhThu : Form
    {
        private QuanLyNhaThuocEntities entities = new QuanLyNhaThuocEntities();
        public DoanhThu()
        {
            InitializeComponent();

            var doanhtHu = (from c in entities.HoaDons.ToList()
                            group c by new
                            {
                                month = c.NgayLapHD.Month
                            } into g
                            select new
                            {
                                month = g.Key,
                                total = g.Sum(x => x.TongTien)
                            }).AsEnumerable();

            foreach (var item in doanhtHu)
            {
                dataGridView1.Rows.Add(item.total, item.month);
            }
        }
    }
}
