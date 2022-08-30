using Blog.Core.Entities;

namespace Blog.Web.Models
{
    public class PostViewModelById
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? PostBanner { get; set; }
        public string PostContent { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
