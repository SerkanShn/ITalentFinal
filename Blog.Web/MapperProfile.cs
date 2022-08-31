using AutoMapper;
using Blog.Web.Models;

namespace Blog.Web
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostUpdateViewModel, PostViewModelById>().ReverseMap();
        }
    }
}
