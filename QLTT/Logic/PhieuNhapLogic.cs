namespace QLTT.Logic
{
    public class PhieuNhapLogic
    {
        private PhieuNhapRepo phieuNhapRepo;
        public PhieuNhapLogic()
        {
            phieuNhapRepo = new PhieuNhapRepo();
        }

        public bool ThemPhieuNhap(PhieuNhap phieunhap)
        {

            return phieuNhapRepo.Add(phieunhap);
        }

        public bool XoaPhieuNhap(int maPhieuNhap)
        {
            return phieuNhapRepo.Remove(k => k.MaPhieuNhap == maPhieuNhap);
        }
        public bool CapNhatPhieuNhap(PhieuNhap phieuNhap)
        {
            return phieuNhapRepo.Update(phieuNhap);
        }
    }
}
