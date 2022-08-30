using Blog.Core;
using Blog.Core.Repositories;
using Blog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _repository.Any(expression);
        }

        public void Create(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public T GetById(int Id)
        {
            return _repository.GetById(Id);
        }

        public List<T> GetList()
        {
             return _repository.GetAll().ToList();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _repository.Where(predicate).ToList();
        }
    }
}
