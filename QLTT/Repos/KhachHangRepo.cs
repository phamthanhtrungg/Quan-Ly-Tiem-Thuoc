using QLTT.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Logic
{
    public class KhachHangRepo : IRepo<KhachHang>
    {
        private QuanLyNhaThuocEntities entites;
        public KhachHangRepo()
        {
            entites = new QuanLyNhaThuocEntities();
        }
        public bool Add(KhachHang entity)
        {
            try
            {
                entites.KhachHangs.Add(entity);
                entites.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public KhachHang GetOne(Expression<Func<KhachHang, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KhachHang> List()
        {
            return entites.KhachHangs.ToList();
        }

        public IEnumerable<KhachHang> List(Expression<Func<KhachHang, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<KhachHang, bool>> predicate)
        {
            var khInDb = entites.KhachHangs.Where(predicate).SingleOrDefault();
            if (khInDb == null) return false;
            try
            {
                entites.KhachHangs.Remove(khInDb);
                entites.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(KhachHang khachHang)
        {
            var khInDb = entites.KhachHangs.Where(k => k.MaKH == khachHang.MaKH).SingleOrDefault();
            if (khInDb == null) return false;
            try
            {
                khInDb.HoTenKH = khachHang.HoTenKH;
                khInDb.DiaChiKH = khachHang.DiaChiKH;
                khInDb.DienThoaiKH = khachHang.DienThoaiKH;
                entites.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
