using Blog.Web.Models;

namespace Blog.Web.Services
{
    public interface IPostService
    {
        Task<List<PostViewModel>> GetAll();
        Task<PostViewModelById> GetById(int id);
        void Delete(int id);
        Task<List<MiniPostViewModel>> GetLastNPost(int count);



    }
}
