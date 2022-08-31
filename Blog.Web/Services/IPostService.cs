using Blog.Web.Models;

namespace Blog.Web.Services
{
    public interface IPostService
    {
        Task<List<PostViewModel>> GetAll();
        Task<PostViewModelById> GetById(int id);
        void Delete(int id);
        void Update(PostUpdateViewModel postUpdateViewModel);
        Task<HttpResponseMessage> Create(PostCreateViewModel postCreateViewModel);
        Task<List<MiniPostViewModel>> GetLastNPost(int count);



    }
}
