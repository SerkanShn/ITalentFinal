using Blog.Web.Models;

namespace Blog.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly ILogger<UserService> _logger;

        public UserService(HttpClient client, ILogger<UserService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> Login(LoginViewModel loginViewModel)
        {
            return await _client.PostAsJsonAsync<LoginViewModel>("Authentication/CreateToken",loginViewModel);

          
        }

        public async Task<HttpResponseMessage> Register(RegisterViewModel registerViewModel)
        {
            return await _client.PostAsJsonAsync<RegisterViewModel>("User", registerViewModel);
        }
    }
}
