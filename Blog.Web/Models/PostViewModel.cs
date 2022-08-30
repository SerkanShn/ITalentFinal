namespace Blog.Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? PostBanner { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
