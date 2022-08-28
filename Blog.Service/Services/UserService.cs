using AutoMapper;
using Blog.Core;
using Blog.Core.DTOs;
using Blog.Core.Entities.Authentication;
using Blog.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly Mapper _mapper;

        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CustomResponse<UserAppDTO>> CreateUser(CreateUserDTO createUserDTO)
        {
            var user = new UserApp { Email=createUserDTO.Email,UserName=createUserDTO.UserName};
            var result =await _userManager.CreateAsync(user,createUserDTO.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return CustomResponse<UserAppDTO>.Fail(errors);
            }
            return CustomResponse<UserAppDTO>.Success(_mapper.Map<UserAppDTO>(user));
        }

        public async Task<CustomResponse<UserAppDTO>> GetUserByName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return CustomResponse<UserAppDTO>.Fail("Kullanıcı bulunamadı");

            return CustomResponse<UserAppDTO>.Success(_mapper.Map<UserAppDTO>(user));
        }
    }
}
