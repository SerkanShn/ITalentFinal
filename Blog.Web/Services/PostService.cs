using Blog.Web.Models;

namespace Blog.Web.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _client;
        private readonly ILogger<PostService> _logger;

        public PostService(HttpClient client, ILogger<PostService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<List<PostViewModel>> GetAll()
        {
            
            var response = await _client.GetFromJsonAsync<Response<List<PostViewModel>>>("post");

            if (response.Data != null)
            {
                return response.Data;
            }


            foreach (var item in response.Errors)
            {
                _logger.LogError(item);
            }
            throw new Exception("İşlem gerçekleşirken bir hata meydana geldi.");
        }

        public async Task<List<MiniPostViewModel>> GetLastNPost(int count)
        {

            var response = await _client.GetFromJsonAsync<Response<List<MiniPostViewModel>>>("post/"+count);

            if (response.Data != null)
            {
                return response.Data;
            }


            foreach (var item in response.Errors)
            {
                _logger.LogError(item);
            }
            throw new Exception("İşlem gerçekleşirken bir hata meydana geldi.");
        }
    }
}
