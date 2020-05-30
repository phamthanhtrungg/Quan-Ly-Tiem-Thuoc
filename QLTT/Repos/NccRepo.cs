using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public class NccRepo : IRepo<NhaCungCap>
    {
        private QuanLyNhaThuocEntities entities;
        public NccRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }
        public bool Add(NhaCungCap entity)
        {
            return true;
        }

        public NhaCungCap GetOne(Expression<Func<NhaCungCap, bool>> predicate)
        {
            return new NhaCungCap();
        }

        public IEnumerable<NhaCungCap> List()
        {
            return entities.NhaCungCaps.ToList();
        }

        public IEnumerable<NhaCungCap> List(Expression<Func<NhaCungCap, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<NhaCungCap, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
