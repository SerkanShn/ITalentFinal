using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> expression);
    }
}
