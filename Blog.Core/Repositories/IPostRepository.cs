using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        List<Post> GetLastNPost(int count);
    }
}
