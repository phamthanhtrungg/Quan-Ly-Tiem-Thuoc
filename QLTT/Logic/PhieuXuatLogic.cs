using QLTT.Repos;

namespace QLTT.Logic
{
    public class PhieuXuatLogic
    {
        private PhieuXuatRepo phieuXuatRepo;
        public PhieuXuatLogic()
        {

            phieuXuatRepo = new PhieuXuatRepo();
        }
        public bool ThemPhieuXuat(PhieuXuat phieuXuat)
        {
            return phieuXuatRepo.Add(phieuXuat);
        }
        public bool CapNhatSanPham(PhieuXuat phieuXuat)
        {
            return phieuXuatRepo.Update(phieuXuat);
        }
        public bool XoaPhieuXuat(int maPhieuXuat)
        {
            return phieuXuatRepo.Remove(p => p.MaPhieuXuat == maPhieuXuat);
        }
    }
}
