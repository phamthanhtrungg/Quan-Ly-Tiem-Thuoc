using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public class SanphamRepo : IRepo<SanPham>
    {
        private readonly QuanLyNhaThuocEntities entities;
        public SanphamRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }

        public bool Add(SanPham entity)
        {
            entities.SanPhams.Add(entity);
            try
            {
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public SanPham GetOne(Expression<Func<SanPham, bool>> predicate)
        {
            return entities.SanPhams.FirstOrDefault(predicate);
        }

        public IEnumerable<SanPham> List()
        {

            return entities.SanPhams.ToList();
        }

        public IEnumerable<SanPham> List(Expression<Func<SanPham, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<SanPham, bool>> predicate)
        {
            return true;
        }
    }
}
