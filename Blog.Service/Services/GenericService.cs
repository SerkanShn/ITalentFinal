using AutoMapper;
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
    public class GenericService<T, TDTO> : IGenericService<T, TDTO> where T : class where TDTO : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _repository.Any(expression);
        }

        public void Create(TDTO dto)
        {
            T entity = _mapper.Map<T>(dto);
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(TDTO dto)
        {
            T entity = _mapper.Map<T>(dto);
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public TDTO GetById(int Id)
        {
            return _mapper.Map<TDTO>(_repository.GetById(Id));
        }

        public List<TDTO> GetList()
        {
            return _mapper.Map<List<TDTO>>(_repository.GetAll().ToList());
        }

        public void Update(TDTO dto)
        {
            T entity = _mapper.Map<T>(dto);
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<TDTO> Where(Expression<Func<T, bool>> predicate)
        {
            return _mapper.Map<List<TDTO>>(_repository.Where(predicate).ToList());
        }
    }
}
