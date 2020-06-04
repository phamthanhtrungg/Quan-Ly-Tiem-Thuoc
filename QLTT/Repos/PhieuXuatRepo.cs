using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public class PhieuXuatRepo : IRepo<PhieuXuat>
    {
        private QuanLyNhaThuocEntities entities;
        public PhieuXuatRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }
        public bool Add(PhieuXuat entity)
        {
            try
            {
                entities.PhieuXuats.Add(entity);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PhieuXuat phieuXuat)
        {
            var phieuXuatInDb = entities.PhieuXuats.Where(k => k.MaPhieuXuat == phieuXuat.MaPhieuXuat).SingleOrDefault();
            if (phieuXuatInDb == null) return false;
            try
            {
                phieuXuatInDb.GiaBan = phieuXuat.GiaBan;
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PhieuXuat GetOne(Expression<Func<PhieuXuat, bool>> predicate)
        {
            return entities.PhieuXuats.Where(predicate).SingleOrDefault();
        }

        public IEnumerable<PhieuXuat> List()
        {
            return entities.PhieuXuats.Include("SanPham").Include("NhanVien").ToList();
        }

        public IEnumerable<PhieuXuat> List(Expression<Func<PhieuXuat, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<PhieuXuat, bool>> predicate)
        {
            var phieuXuatInDb = entities.PhieuXuats.Where(predicate).SingleOrDefault();
            if (phieuXuatInDb == null) return false;
            try
            {
                entities.PhieuXuats.Remove(phieuXuatInDb);
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
