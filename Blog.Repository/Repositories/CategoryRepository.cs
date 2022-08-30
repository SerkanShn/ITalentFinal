using Blog.Core.Entities;
using Blog.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }


        public Category GetCategoryByIdWithPosts(int Id)
        {
            return _context.Categories.Include(x => x.Posts).Where(x => x.Id == Id).SingleOrDefault();
        }

        public List<Category> GetCategoriesWithPostsCount()
        {
            return _context.Categories.Include(x => x.Posts).ToList();
        }
    }
}
