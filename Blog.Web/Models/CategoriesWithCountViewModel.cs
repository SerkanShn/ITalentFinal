namespace Blog.Web.Models
{
    public class CategoriesWithCountViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PostCount { get; set; }
    }
}
