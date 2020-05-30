using QLTT.Logic;
using QLTT.Repos;
using System;
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
            LoadKhoThuoc();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KhoThuocForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadKhoThuoc()
        {
            foreach (var khoThuoc in khoThuocRepo.List())
            {
                dataGridView1.Rows.Add(khoThuoc.MaSP, khoThuoc.TenSP, khoThuoc.SoLuongTaiKho);
            }
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            var phieuNhap = new PhieuNhapForm();
            phieuNhap.ShowDialog();
        }
    }
}
