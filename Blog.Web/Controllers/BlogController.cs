using Blog.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {

        private readonly IPostService _postService;
        public BlogController( IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Post(int id)
        {
            var post =await _postService.GetById(id);

            ViewBag.post = post;

            return View();
        }
    }
}
