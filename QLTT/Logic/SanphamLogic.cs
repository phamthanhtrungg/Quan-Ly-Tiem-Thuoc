using QLTT.Repos;
using System;
using System.Linq.Expressions;

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

        public bool CapNhatSanPham(SanPham sanphamMoi)
        {
            return sanphamRepo.CapNhatSanPham(sanphamMoi);
        }

        public bool XoaSanPham(Expression<Func<SanPham, bool>> predicate)
        {
            return sanphamRepo.Remove(predicate);
        }
    }
}
