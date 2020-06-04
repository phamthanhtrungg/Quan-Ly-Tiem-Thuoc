using QLTT.Repos;

namespace QLTT.Logic
{
    public class KhoThuocLogic
    {
        private KhoThuocRepo KhoThuocRepo;
        public KhoThuocLogic()
        {
            KhoThuocRepo = new KhoThuocRepo();
        }

        public bool ThemSanPham(KhoThuoc khoThuoc)
        {
            return KhoThuocRepo.Add(khoThuoc);
        }
        public bool CapNhatSanPham(KhoThuoc khoThuoc)
        {
            return KhoThuocRepo.Update(khoThuoc);
        }
        public bool XoaSanPham(string maSp)
        {
            return KhoThuocRepo.Remove(k => k.MaSP == maSp);
        }
    }
}
