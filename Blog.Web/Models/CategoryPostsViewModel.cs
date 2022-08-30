using Blog.Core.DTOs;

namespace Blog.Web.Models
{
    public class CategoryPostsViewModel
    {
        public string Title { get; set; }
        public List<PostDTO> Posts { get; set; }
    }
}
