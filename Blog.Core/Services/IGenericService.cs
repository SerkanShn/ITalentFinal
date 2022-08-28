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
        List<TDTO> GetList();

        TDTO GetById(int Id);

        void Create(TDTO dto);

        void Update(TDTO dto);

        void Delete(TDTO dto);
        IEnumerable<TDTO> Where(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> expression);
    }
}
