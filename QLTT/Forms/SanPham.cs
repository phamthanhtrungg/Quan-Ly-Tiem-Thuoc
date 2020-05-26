using QLTT.Logic;
using System;
using System.Windows.Forms;

namespace QLTT.Forms
{
    public partial class SanPham : Form
    {
        private readonly SanphamLogic sanphamLogic;
        public SanPham()
        {
            InitializeComponent();
            sanphamLogic = new SanphamLogic();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
