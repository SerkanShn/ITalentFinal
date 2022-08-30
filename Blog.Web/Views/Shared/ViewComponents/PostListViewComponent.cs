using Blog.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Views.Shared.ViewComponents
{
    public class PostListViewComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public PostListViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _postService.GetAll();
            
            return await Task.FromResult(View("Default", posts));

        }
    }
}
