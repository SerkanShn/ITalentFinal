using Blog.Web.Models;

namespace Blog.Web.Services
{
    public interface IUserService
    {
        Task<HttpResponseMessage> Login(LoginViewModel loginViewModel);
        Task<HttpResponseMessage> Register(RegisterViewModel registerViewModel);
    }
}
