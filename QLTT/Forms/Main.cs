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
            foreach (var sanpham in sanphamRepo.List())
            {
                dvgSanpham.Rows.Add(sanpham.MaSP, sanpham.TenSP, sanpham.CongDungSP, sanpham.GiaBan, sanpham.SoLuongTaiCuaHang, "", "");
            }


        }

        private void dvgSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                MessageBox.Show("clicked");
            }
            else if (e.ColumnIndex == 6)
            {
                MessageBox.Show("clicked1");
            }
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            var formSp = new Forms.SanPham();
            formSp.ShowDialog();
            Show();
        }
    }
}
