using Blog.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public interface IGenericService<T> where T : class 
    {
        List<T> GetList();

        T GetById(int Id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> expression);
    }
}
