using Blog.Core;
using Blog.Core.DTOs;
using Blog.Core.Entities.Authentication;
using Blog.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services
{
    class TokenService : ITokenService
    {
        private readonly AppTokenOption _tokenOption;

        public TokenService(AppTokenOption tokenOption)
        {
            _tokenOption = tokenOption;
        }

        private IEnumerable<Claim> GetClaim(UserApp userApp)
        {
            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userApp.Id),
                new Claim(ClaimTypes.Name,userApp.UserName),
                new Claim(ClaimTypes.Email,userApp.Email),
            };
            return userClaims;
        }

        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        public TokenDTO CreateToken(UserApp userApp)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.RefreshTokenExpiration);
            var securityKey = SignService.GetSymmetricKey(_tokenOption.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (issuer: _tokenOption.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaim(userApp),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            return new TokenDTO { AccessToken = token, RefreshToken = CreateRefreshToken(), AccessTokenExpiration = accessTokenExpiration, RefreshTokenExpiration = refreshTokenExpiration };

        }
    }
}