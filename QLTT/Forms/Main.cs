using QLTT.Repos;
using System;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class Main : Form
    {
        private readonly SanphamRepo sanphamRepo;
        public Main()
        {
            InitializeComponent();
            sanphamRepo = new SanphamRepo();
        }



        private void Main_Load(object sender, EventArgs e)
        {

            LoadSanpham();
        }

        private void LoadSanpham()
        {
            dvgSanpham.Rows.Clear();
            foreach (var sanpham in sanphamRepo.List())
            {
                dvgSanpham.Rows.Add(sanpham.MaSP, sanpham.TenSP, sanpham.CongDungSP, sanpham.GiaBan, sanpham.SoLuongTaiCuaHang, "", "");
            }


        }

        private void dvgSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                var currentRow = dvgSanpham.Rows[e.RowIndex];
                var maSp = currentRow.Cells[0].Value.ToString();
                var tenSp = currentRow.Cells[1].Value.ToString();
                var congdungSp = currentRow.Cells[2].Value.ToString();
                var giaBan = currentRow.Cells[3].Value.ToString();
                var formSp = new SanPhamForm(true, maSp, tenSp, giaBan, congdungSp);
                formSp.ReloadSP += CustomLoad;
                formSp.ShowDialog();
            }
            else if (e.ColumnIndex == 6)
            {
                MessageBox.Show("clicked1");
            }
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            var formSp = new SanPhamForm();
            formSp.ReloadSP += CustomLoad;
            formSp.ShowDialog();
        }
        void CustomLoad(object sender, EventArgs e)
        {
            LoadSanpham();
        }

    }
}
