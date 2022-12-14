using Blog.Web.Models;

namespace Blog.Web.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoriesWithCountViewModel>> GetAllCategoriesWithCount();
        Task<CategoryPostsViewModel> GetAllPostByCategoryId(int id);
    }
}
