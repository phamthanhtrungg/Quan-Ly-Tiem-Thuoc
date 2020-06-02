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
        private NhanVienLogic nhanvienLogic;
        private NhanVienRepo nhanvienRepo;
        private string username = "";
        public Main(string username)
        {
            InitializeComponent();
            sanphamRepo = new SanphamRepo();
            sanphamLogic = new SanphamLogic();
            nhanvienLogic = new NhanVienLogic();
            nhanvienRepo = new NhanVienRepo();
            this.username = username;
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

        private void thayĐổiThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanvienRepo = new NhanVienRepo();
            var nhanvien = nhanvienRepo.GetOne(n => n.Username == this.username);
            if (nhanvien != null)
            {
                var formNhanvien = new NhanVienForm(true
                    , nhanvien.DiaChiNV, nhanvien.DienThoaiNV.ToString(), nhanvien.Email, nhanvien.GioiTinhNV == "Nam", nhanvien.HoTenNV, nhanvien.NgaySinhNV.ToString(), nhanvien.Username, nhanvien.ChucVu.MaCV, nhanvien.Password);
                formNhanvien.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentUser = nhanvienRepo.GetOne(n => n.Username == this.username);
            var khoForm = new KhoThuocForm(currentUser.MaNV);
            khoForm.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nccForm = new NccForm();
            nccForm.Show();
        }
    }
}
