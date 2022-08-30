using Blog.Core.DTOs;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public  interface ICategoryService : IGenericService<Category>
    {
        public CategoryWithPostsDTO GetCategoryByIdWithPosts(int Id);
        public List<CategoryWithPostsCount> GetCategoriesWithPostsCount();
    }
}
