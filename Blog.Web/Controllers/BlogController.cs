using Blog.Web.Models;
using Blog.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {

        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IFileProvider _fileProvider;
        public BlogController(IPostService postService, ICategoryService categoryService, IFileProvider fileProvider)
        {
            _postService = postService;
            _categoryService = categoryService;
            _fileProvider = fileProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Post(int id)
        {
            var post =await _postService.GetById(id);

            ViewBag.post = post;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categoryList = await _categoryService.GetAllCategories();

            ViewBag.selectList = new SelectList(categoryList, "Id", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreateViewModel request, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {


                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var picturesDirectory = root.Single(x => x.Name == "pictures");


                var path = Path.Combine(picturesDirectory.PhysicalPath, photo.FileName);


                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream);

                request.PostBanner = photo.FileName;
            }


            await _postService.Create(request);
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }

        public IActionResult Delete(int id)
        {

            _postService.Delete(id);

            return RedirectToAction(nameof(HomeController.Index), "Home");
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
