using Blog.Web.Models;

namespace Blog.Web.Services
{
    public interface IPostService
    {
        Task<List<PostViewModel>> GetAll();
        Task<List<MiniPostViewModel>> GetLastNPost(int count);

    }
}
