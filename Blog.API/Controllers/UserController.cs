using Blog.Core.DTOs;
using Blog.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDto)
        {
            var result = await _userService.CreateUser(createUserDto);

            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var result = await _userService.GetUserByName(_httpContextAccessor.HttpContext.User.Identity.Name);

            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }
    }
}
