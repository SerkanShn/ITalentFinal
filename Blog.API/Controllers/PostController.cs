using Blog.Core.DTOs;
using Blog.Core.Entities;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IGenericService<Post, PostDTO> _postService;

        public PostController(IGenericService<Post, PostDTO> postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var result = _postService.GetList();
            return new ObjectResult(result) { StatusCode=result.StatusCode};
        }
    }
}
