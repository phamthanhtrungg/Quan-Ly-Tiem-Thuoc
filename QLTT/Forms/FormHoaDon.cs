using QLTT.Logic;
using QLTT.Repos;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLTT.Forms
{

    public partial class FormHoaDon : Form
    {
        private KhachHangRepo khachHangRepo;
        private SanphamRepo sanphamRepo;
        private HoaDonLogic hoaDonLogic;
        private List<HoaDonDto> hoaDonDtos = new List<HoaDonDto>();
        public FormHoaDon(string maNV = "")
        {
            InitializeComponent();
            LoadKH();
            LoadSanPham();
            txtManv.Text = maNV;
            hoaDonLogic = new HoaDonLogic();
        }

        private void LoadKH()
        {
            khachHangRepo = new KhachHangRepo();
            cmbKH.DataSource = khachHangRepo.List();
            cmbKH.ValueMember = "MaKH";
            cmbKH.DisplayMember = "HoTenKH";
        }

        private void LoadSanPham()
        {
            sanphamRepo = new SanphamRepo();
            cmbSanPham.DataSource = sanphamRepo.List();
            cmbSanPham.DisplayMember = "TenSP";
            cmbSanPham.ValueMember = "MaSP";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled)) return;
            this.hoaDonDtos.Add(new HoaDonDto()
            {
                tensp = cmbSanPham.Text.Trim(),
                masp = cmbSanPham.SelectedValue.ToString().Trim(),
                sl = int.Parse(txtSl.Text.Trim()),
                dongia = int.Parse(txtDongia.Text.Trim())
            });
            txtSl.ResetText();
            LoadSPMoi();
        }

        private void LoadSPMoi()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in hoaDonDtos)
            {
                dataGridView1.Rows.Add(item.masp, item.tensp, item.sl, item.dongia);
            }
        }

        private void txtSl_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.Match(txtSl.Text, @"^[1-9]+").Success)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSl, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSl, "Số lượng không hợp lệ");
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            var hd = new HoaDon()
            {
                MaNV = txtManv.Text.Trim(),
                MaKH = int.Parse(cmbKH.SelectedValue.ToString().Trim()),
                NgayLapHD = dateTimePicker1.Value
            };
            hd.CT_HoaDon = new List<CT_HoaDon>();
            foreach (var item in hoaDonDtos)
            {
                hd.CT_HoaDon.Add(new CT_HoaDon()
                {
                    MaSP = item.masp,
                    DonGia = item.dongia,
                    SoLuong = item.sl
                });
            }
            if (hoaDonLogic.ThemHD(hd))
            {
                MessageBox.Show("Thực hiện thành công");
                Close();
            }
            else
            {
                MessageBox.Show("Thực hiện không thành công");
            }
        }
    }
}
