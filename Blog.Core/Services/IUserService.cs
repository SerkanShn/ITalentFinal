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
        CustomResponse<UserAppDTO> CreateUser(CreateUserDTO createUserDTO);
        CustomResponse<UserAppDTO> GetUserByName(string username);
    }
}
