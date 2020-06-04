using QLTT.Repos;

namespace QLTT.Logic
{

    public class HoaDonLogic
    {
        private HoadonRepo hoadonRepo;
        public HoaDonLogic()
        {
            hoadonRepo = new HoadonRepo();
        }

        public bool XoaHoaDon(int maHD)
        {
            return hoadonRepo.Remove(h => h.MaHD == maHD);
        }

        public bool ThemHD(HoaDon hd)
        {
            return hoadonRepo.Add(hd);
        }
    }

}
