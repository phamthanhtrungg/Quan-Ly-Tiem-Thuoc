namespace QLTT.Logic
{
    public class KhachHangLogic
    {
        private KhachHangRepo khachangRepo;
        public KhachHangLogic()
        {
            khachangRepo = new KhachHangRepo();
        }
        public bool ThemKhachHang(KhachHang khachHang)
        {
            return khachangRepo.Add(khachHang);
        }

        public bool SuaKhachHang(KhachHang khachHang)
        {
            return khachangRepo.Update(khachHang);
        }

        public bool XoaKhachHang(int maKH)
        {
            return khachangRepo.Remove(k => k.MaKH == maKH);
        }
    }
}
