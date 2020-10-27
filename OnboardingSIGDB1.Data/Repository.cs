using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OnboardingSIGDB1.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _dataContext = null;
        DbSet<T> _dbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> funcFilter)
        {
            return _dbSet.FirstOrDefault(funcFilter);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> funcFilter = null)
        {
            if (funcFilter != null)
            {
                return _dbSet.Where(funcFilter);
            }

            return _dbSet.AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
