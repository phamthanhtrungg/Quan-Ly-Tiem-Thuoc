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
            return true;
        }

        public SanPham GetOne(Expression<Func<SanPham, bool>> predicate)
        {
            return new SanPham();
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
