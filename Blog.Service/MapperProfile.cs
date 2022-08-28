using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserApp, UserAppDTO>().ReverseMap();

        }
    }
}
