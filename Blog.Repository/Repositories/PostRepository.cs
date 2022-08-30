using Blog.Core.Entities;
using Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }


        public List<Post> GetLastNPost(int count)
        {
            return _context.Posts.OrderByDescending(p => p.Id).Take(count).ToList();
          
        }
    }
}
