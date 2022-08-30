using Blog.Core.DTOs;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public interface IPostService : IGenericService<Post>
    {
        public List<MiniPostViewDTO> GetLastNPost(int count);
    }
}
