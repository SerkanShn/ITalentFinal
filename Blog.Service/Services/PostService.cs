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
    public class PostService : GenericService<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IGenericRepository<Post> repository, IUnitOfWork unitOfWork, IMapper mapper, IPostRepository postRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

     

        public List<MiniPostViewDTO> GetLastNPost(int count)
        {
            var post = _postRepository.GetLastNPost(count);

            var miniPostViewDTO = _mapper.Map<List<MiniPostViewDTO>>(post);

            return miniPostViewDTO;
        }
    }
}
