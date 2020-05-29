using QLTT.Logic;
using QLTT.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class KhoThuocForm : Form
    {
        private SanphamRepo sanphamRepo;
        private KhoThuocRepo khoThuocRepo;
        private KhoThuocLogic khoThuocLogic;
        public KhoThuocForm()
        {
            InitializeComponent();
            sanphamRepo = new SanphamRepo();
            khoThuocRepo = new KhoThuocRepo();
            khoThuocLogic = new KhoThuocLogic();
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
                listView2.Items.Add(new ListViewItem(new string[] { k.MaSP, k.TenSP, k.SoLuongTaiKho.ToString() }));
            });

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn ít nhất 1 sản phẩm để đưa vào kho", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //kiem tra neu ton tai san pham trong kho voi maSp tuong ung
            //check if there's  any products in storage with corresponding maSP
            for (var i = 0; i < listView1.SelectedItems.Count; i++)
            {
                var maSp = listView1.SelectedItems[i].SubItems[0].Text.Trim();
                for (var j = 0; j < listView2.Items.Count; j++)
                {
                    var maSpKho = listView2.Items[j].SubItems[0].Text.Trim();
                    if (maSpKho == maSp)
                    {

                        MessageBox.Show("Sản phẩm đã có trong kho", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            }
            for (var i = 0; i < listView1.SelectedItems.Count; i++)
            {
                var maSp = listView1.SelectedItems[i].SubItems[0].Text;
                var tenSp = listView1.SelectedItems[i].SubItems[1].Text;
                listView2.Items.Add(new ListViewItem(new string[] { maSp, tenSp, "0" }));
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<KhoThuoc> khoThuocs = new List<KhoThuoc>();
            for (var i = 0; i < listView2.Items.Count; i++)
            {
                var maSp = listView2.Items[i].SubItems[0].Text.Trim();
                var tenSp = listView2.Items[i].SubItems[1].Text.Trim();
                if (khoThuocRepo.GetOne(k => k.MaSP == maSp) == null)
                {
                    khoThuocs.Add(new KhoThuoc()
                    {
                        MaSP = maSp,
                        TenSP = tenSp,
                        SoLuongTaiKho = 0
                    });
                }

            }
            if (khoThuocLogic.ThemSanPham(khoThuocs))
            {
                MessageBox.Show("Thao tác thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thao tác thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (listView2.CheckedItems.Count == 0)
            {
                MessageBox.Show("Chọn ít nhất 1 sản phẩm trong kho để xóa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<KhoThuoc> khoThuocs = new List<KhoThuoc>();
            foreach (ListViewItem item in listView2.CheckedItems)
            {
                khoThuocs.Add(new KhoThuoc()
                {
                    MaSP = item.SubItems[0].Text.Trim(),
                    TenSP = item.SubItems[1].Text.Trim()
                });
            }
            if (khoThuocLogic.XoaSanPham(khoThuocs))
            {
                foreach (ListViewItem item in listView2.CheckedItems)
                {
                    listView2.Items.Remove(item);
                }
                MessageBox.Show("Thao tác thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thao tác thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
