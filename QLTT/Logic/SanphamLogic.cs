using QLTT.Repos;

namespace QLTT.Logic
{
    public class SanphamLogic
    {
        private readonly SanphamRepo sanphamRepo;
        public SanphamLogic()
        {
            sanphamRepo = new SanphamRepo();
        }

        public bool ThemSanPham(SanPham sanpham)
        {
            return sanphamRepo.Add(sanpham);
        }

    }
}
