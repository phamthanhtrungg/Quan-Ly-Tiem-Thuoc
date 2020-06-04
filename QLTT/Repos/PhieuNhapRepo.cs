using QLTT.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Logic
{
    public class PhieuNhapRepo : IRepo<PhieuNhap>
    {
        private QuanLyNhaThuocEntities entities;
        public PhieuNhapRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }
        public bool Add(PhieuNhap entity)
        {
            entities.PhieuNhaps.Add(entity);
            try
            {
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(PhieuNhap phieuNhap)
        {
            var phieuNhapInFb = entities.PhieuNhaps.Where(k => k.MaPhieuNhap == phieuNhap.MaPhieuNhap).FirstOrDefault();
            if (phieuNhapInFb == null) return false;
            try
            {
                phieuNhapInFb.GiaNhap = phieuNhap.GiaNhap;

                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PhieuNhap GetOne(Expression<Func<PhieuNhap, bool>> predicate)
        {
            return entities.PhieuNhaps.Where(predicate).SingleOrDefault();
        }

        public IEnumerable<PhieuNhap> List()
        {
            return entities.PhieuNhaps.Include("KhoThuoc").Include("NhanVien").ToList();
        }

        public IEnumerable<PhieuNhap> List(Expression<Func<PhieuNhap, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<PhieuNhap, bool>> predicate)
        {
            var phieuNhapInFb = entities.PhieuNhaps.Where(predicate).FirstOrDefault();
            if (phieuNhapInFb == null) return false;
            try
            {
                entities.PhieuNhaps.Remove(phieuNhapInFb);
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
