using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    interface IRepo<T>
    {
        T GetOne(Expression<Func<T, Boolean>> predicate);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, Boolean>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
