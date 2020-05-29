using QLTT.Repos;
using System.Collections.Generic;

namespace QLTT.Logic
{
    public class KhoThuocLogic
    {
        private KhoThuocRepo KhoThuocRepo;
        public KhoThuocLogic()
        {
            KhoThuocRepo = new KhoThuocRepo();
        }

        public bool ThemSanPham(List<KhoThuoc> khoThuocs)
        {
            return KhoThuocRepo.AddRange(khoThuocs);
        }
        public bool ThemSanPham(KhoThuoc khoThuoc)
        {
            return KhoThuocRepo.Remove(k => k.MaSP == khoThuoc.MaSP);
        }
        public bool XoaSanPham(List<KhoThuoc> khoThuocs)
        {
            return KhoThuocRepo.RemoveRange(khoThuocs);
        }
    }
}
