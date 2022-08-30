using Blog.Web.Models;

namespace Blog.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoriesWithCountViewModel>> GetAllCategoriesWithCount()
        {
            var response = await _httpClient.GetFromJsonAsync<Response<List<CategoriesWithCountViewModel>>>("Category/GetCategoriesWithCounts");

            if (response.Data != null)
            {
                return response.Data;
            }

            throw new Exception("İşlem gerçekleşirken bir hata meydana geldi.");
        }

     
    }
}
