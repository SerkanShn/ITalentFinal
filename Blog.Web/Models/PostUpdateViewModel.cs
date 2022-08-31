namespace Blog.Web.Models
{
    public class PostUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PostBanner { get; set; }
        public string PostContent { get; set; }
        public bool IsPublish { get; set; } = true;
        public DateTime? EditedOn { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public string UserId { get; set; } = "1dd44c94-dd77-4b1d-a9b9-09283538e65a";

    }
}
