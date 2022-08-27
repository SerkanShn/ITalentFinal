using Blog.Core.DTOs;
using Blog.Core.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public interface ITokenService
    {
        TokenDTO CreateToken(UserApp userApp);
        
    }
}
