using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public class KhoRepo : IRepo<KhoThuoc>
    {
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
            throw new NotImplementedException();
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
