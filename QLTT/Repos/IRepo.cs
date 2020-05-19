using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public interface IRepo<T>
    {
        T GetOne(Expression<Func<T, Boolean>> predicate);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, Boolean>> predicate);
        bool Add(T entity);
        bool Remove(Expression<Func<T, Boolean>> predicate);
    }
}
