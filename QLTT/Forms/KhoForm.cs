using QLTT.Repos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class KhoForm : Form
    {
        private SanphamRepo sanphamRepo;
        public KhoForm()
        {
            InitializeComponent();
            sanphamRepo = new SanphamRepo();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);     
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void KhoForm_Load(object sender, EventArgs e)
        {
            sanphamRepo.List().ToList().ForEach(s =>
            {
                listView1.Items.Add(new ListViewItem(new string[] { s.MaSP, s.TenSP }));
            });

        }
    }
}
