using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public interface IGenericService<T,TDTO> where T : class where TDTO : class
    {
        List<CustomResponse<TDTO>> GetList();

        CustomResponse<TDTO> GetById(int id);

        CustomResponse<TDTO> Create(T entity);

        void Update(T entity);

        void Delete(int id);
        CustomResponse<IEnumerable<TDTO>> Where(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> expression);
    }
}
