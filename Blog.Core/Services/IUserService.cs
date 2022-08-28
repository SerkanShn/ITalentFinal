using Blog.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public interface IUserService
    {
        Task<CustomResponse<UserAppDTO>> CreateUser(CreateUserDTO createUserDTO);
        Task<CustomResponse<UserAppDTO>> GetUserByName(string username);
    }
}
