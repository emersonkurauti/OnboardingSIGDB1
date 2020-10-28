using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnboardingSIGDB1.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> funcFilter = null);
        T Get(Expression<Func<T, bool>> funcFilter);
        bool Exist(Expression<Func<T, bool>> funcFilter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
