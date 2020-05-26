using QLTT.Logic;
using QLTT.Repos;
using System;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class Main : Form
    {
        private SanphamRepo sanphamRepo;
        private SanphamLogic sanphamLogic;
        public Main()
        {
            InitializeComponent();
            sanphamRepo = new SanphamRepo();
            sanphamLogic = new SanphamLogic();
        }



        private void Main_Load(object sender, EventArgs e)
        {

            LoadSanpham();
        }

        private void LoadSanpham()
        {
            dvgSanpham.Rows.Clear();
            sanphamRepo = new SanphamRepo();
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
                if (MessageBox.Show("Bạn có muốn xóa bản lưu này không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var currentRow = dvgSanpham.Rows[e.RowIndex];
                    var maSp = currentRow.Cells[0].Value.ToString();
                    if (sanphamLogic.XoaSanPham(s => s.MaSP == maSp))
                    {
                        MessageBox.Show("Thao tác thánh công");
                        LoadSanpham();
                    }
                    else
                    {
                        MessageBox.Show("Thao tác thất bại");
                    }
                }
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
