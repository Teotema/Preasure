using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext Context;

        public Repository(IUnitOfWork unitOfWork)
        {
            Context = unitOfWork as DbContext;

            if (Context == null)
                throw new InvalidOperationException("Cannot cast UnitOfWork to DbContext");
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return GetAll().FirstOrDefault(expression);
        }

        protected virtual IQueryable<T> GetMainAll()
        {
            return Context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return GetMainAll();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
