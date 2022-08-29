using Blog.Core.DTOs;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDTO loginDto)
        {
            var result = await _authenticationService.CreateToken(loginDto);

            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRefreshToken(string refreshToken)
        {
            var result = await _authenticationService.DeleteRefreshToken(refreshToken);

            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(string refreshToken)
        {
            var result = await _authenticationService.CreateTokenByRefreshToken(refreshToken);

            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }

    }
}
