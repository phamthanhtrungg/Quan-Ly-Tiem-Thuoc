using QLTT.Repos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class KhoThuocForm : Form
    {
        private SanphamRepo sanphamRepo;
        private KhoThuocRepo khoThuocRepo;
        public KhoThuocForm()
        {
            InitializeComponent();
            sanphamRepo = new SanphamRepo();
            khoThuocRepo = new KhoThuocRepo();
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
            khoThuocRepo.List().ToList().ForEach(k =>
            {
                listView2.Items.Add(new ListViewItem(new string[] { k.MaSP, k.TenSP }));
            });

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0) return;
            for (var i = 0; i < listView1.SelectedIndices.Count; i++)
            {
                var maSp = listView1.Items[i].SubItems[0].Text;
                var tenSp = listView1.Items[i].SubItems[1].Text;
                listView1.Items.Remove(listView1.Items[i]);
                listView2.Items.Add(new ListViewItem(new string[] { maSp, tenSp }));
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 0) return;
            for (var i = 0; i < listView2.SelectedIndices.Count; i++)
            {
                var maSp = listView2.Items[i].SubItems[0].Text;
                var tenSp = listView2.Items[i].SubItems[1].Text;
                listView2.Items.Remove(listView2.Items[i]);
                listView1.Items.Add(new ListViewItem(new string[] { maSp, tenSp }));
            }
        }
    }
}
