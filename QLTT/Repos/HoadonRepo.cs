using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    class HoadonRepo : IRepo<HoaDon>
    {
        private QuanLyNhaThuocEntities entities;
        public HoadonRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }
        public bool Add(HoaDon entity)
        {
            try
            {
                entities.HoaDons.Add(entity);
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public HoaDon GetOne(Expression<Func<HoaDon, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HoaDon> List()
        {
            return entities.HoaDons.Include("KhachHang").Include("NhanVien").ToList();
        }

        public IEnumerable<HoaDon> List(Expression<Func<HoaDon, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<HoaDon, bool>> predicate)
        {
            var hdInDb = entities.HoaDons.Where(predicate).SingleOrDefault();
            if (hdInDb == null) return false;
            try
            {
                entities.HoaDons.Remove(hdInDb);
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
