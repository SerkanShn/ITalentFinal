using Blog.Core;
using Blog.Core.DTOs;
using Blog.Core.Entities.Authentication;
using Blog.Core.Repositories;
using Blog.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;

        public AuthenticationService(ITokenService tokenService, UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> userRefreshTokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
        }

        public async Task<CustomResponse<TokenDTO>> CreateToken(LoginDTO loginDTO)
        {
            if(loginDTO == null) 
                throw new ArgumentNullException(nameof(loginDTO));

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
                return CustomResponse<TokenDTO>.Fail("Kayıtlı kullanıcı yok");

            if(! await _userManager.CheckPasswordAsync(user,loginDTO.Password))
                return CustomResponse<TokenDTO>.Fail("Şifre yanlış");

            var tokenDto = _tokenService.CreateToken(user);
            var userRefreshToken = _userRefreshTokenService.Where(x => x.UserId == user.Id).Single();
            if (userRefreshToken == null)
                _userRefreshTokenService.Add(new UserRefreshToken { UserId = user.Id, RefreshToken = tokenDto.RefreshToken, Expiration = tokenDto.RefreshTokenExpiration });
            else
            {
                userRefreshToken.RefreshToken = tokenDto.RefreshToken;
                userRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
            }

            _unitOfWork.CommitAsync();
            return CustomResponse<TokenDTO>.Success(tokenDto);

        }

        public async Task<CustomResponse<TokenDTO>> CreateTokenByRefreshToken(string refreshToken)
        {
            var userRefreshToken = _userRefreshTokenService.Where(x => x.RefreshToken == refreshToken).Single();
            if (userRefreshToken == null)
                return CustomResponse<TokenDTO>.Fail("Refresh Token Bulunamadı");

            var user = await _userManager.FindByIdAsync(userRefreshToken.UserId);
            if(user==null)
                return CustomResponse<TokenDTO>.Fail("User bulunamadı");

            var tokenDto = _tokenService.CreateToken(user);
            userRefreshToken.RefreshToken = tokenDto.RefreshToken;
            userRefreshToken.Expiration=tokenDto.RefreshTokenExpiration;

            _unitOfWork.CommitAsync();
            return CustomResponse<TokenDTO>.Success(tokenDto);
        }

        public void DeleteRefreshToken(string refreshToken)
        {
            var userRefreshToken = _userRefreshTokenService.Where(x => x.RefreshToken == refreshToken).Single();
            if(userRefreshToken!=null)
            {
                _userRefreshTokenService.Delete(userRefreshToken);
                _unitOfWork.CommitAsync();
            }

        }
    }
}
