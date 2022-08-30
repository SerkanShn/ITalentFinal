using Blog.Core.Entities;


namespace Blog.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetCategoryByIdWithPosts(int Id);
    }
}
