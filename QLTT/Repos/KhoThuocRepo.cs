using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public class KhoThuocRepo : IRepo<KhoThuoc>
    {
        private readonly QuanLyNhaThuocEntities entities;
        public KhoThuocRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }
        public bool Add(KhoThuoc entity)
        {
            return true;
        }

        public KhoThuoc GetOne(Expression<Func<KhoThuoc, bool>> predicate)
        {
            return new KhoThuoc();
        }

        public IEnumerable<KhoThuoc> List()
        {
            return entities.KhoThuocs.ToList();
        }

        public IEnumerable<KhoThuoc> List(Expression<Func<KhoThuoc, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<KhoThuoc, bool>> predicate)
        {
            return true;
        }
    }
}
