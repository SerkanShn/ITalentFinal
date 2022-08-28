using Blog.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public interface IAuthenticationService
    {
        Task<CustomResponse<TokenDTO>> CreateToken(LoginDTO loginDTO);
        Task<CustomResponse<TokenDTO>> CreateTokenByRefreshToken(string refreshToken);
        void DeleteRefreshToken(string refreshToken);
    }
}
