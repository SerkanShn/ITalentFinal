namespace Blog.Web.Models
{
    public class Response<T>
    {
        public T Data { get; set; }

        public List<String> Errors { get; set; }
    }
}
