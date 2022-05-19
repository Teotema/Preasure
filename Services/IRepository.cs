using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> expression);

        IQueryable<T> GetAll();

        //ObservableCollection<T> GetAllLocal();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);
    }
}
