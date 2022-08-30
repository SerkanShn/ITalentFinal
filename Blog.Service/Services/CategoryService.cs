using AutoMapper;
using Blog.Core;
using Blog.Core.DTOs;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services
{
    public class CategoryService : GenericService<Category> , ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(unitOfWork,repository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public CategoryWithPostsDTO GetCategoryByIdWithPosts(int Id)
        {
            var category = _categoryRepository.GetCategoryByIdWithPosts(Id);

            var categoryDto = _mapper.Map<CategoryWithPostsDTO>(category);

            return categoryDto;
        }

        public List<CategoryWithPostsCount> GetCategoriesWithPostsCount()
        {
            var category = _categoryRepository.GetCategoriesWithPostsCount();
            var list = new List<CategoryWithPostsCount>();
            foreach (var item in category)
            {
                list.Add(new CategoryWithPostsCount { Title = item.Title, PostCount = item.Posts.Count });
            }

            return list;
        }

    }
}
