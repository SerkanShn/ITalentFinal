namespace Blog.Web.Models
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
