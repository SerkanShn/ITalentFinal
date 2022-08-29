using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entities;
using Blog.Core.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserApp, UserAppDTO>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();

        }
    }
}
