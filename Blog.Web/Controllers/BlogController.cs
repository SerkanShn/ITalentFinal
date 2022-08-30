using Blog.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {

        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        public BlogController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Post(int id)
        {
            var post =await _postService.GetById(id);

            ViewBag.post = post;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var posts = await _categoryService.GetAllPostByCategoryId(id);
            var categoriesWithCount = await _categoryService.GetAllCategoriesWithCount();
            var lastThreePost = await _postService.GetLastNPost(3);


            return View((posts, categoriesWithCount, lastThreePost));
        }

    }
}
