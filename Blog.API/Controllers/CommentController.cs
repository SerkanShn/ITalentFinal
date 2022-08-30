using AutoMapper;
using Blog.Core;
using Blog.Core.DTOs;
using Blog.Core.Entities;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly IGenericService<Comment> _commentService;
        private readonly IMapper _mapper;

        public CommentController(IGenericService<Comment> commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCommentsByPostId(int id)
        {
            var result = _commentService.Where(x => x.PostId == id).ToList();

            var commentsDTO = _mapper.Map<List<CommentDTO>>(result);

            return new ObjectResult(CustomResponse<List<CommentDTO>>.Success(commentsDTO, 200)) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult PostComment(CreateCommentDTO createCommentDTO)
        {
            _commentService.Create(_mapper.Map<Comment>(createCommentDTO));
            return new ObjectResult(CustomResponse<NoDataDto>.Success(200)) { StatusCode = 200 };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _commentService.GetById(id);
            _commentService.Delete(comment);
            return new ObjectResult(CustomResponse<NoDataDto>.Success(200)) { StatusCode = 200 };
        }


    }
}
