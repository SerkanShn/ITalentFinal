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

        public async Task<HttpResponseMessage> Create(PostCreateViewModel postCreateViewModel)
        {
            return await _client.PostAsJsonAsync<PostCreateViewModel>("Post", postCreateViewModel);
        }


        public async void Delete(int id)
        {
             await _client.DeleteAsync("post/"+id);
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



        public async Task<PostViewModelById> GetById(int id)
        {
            var response = await _client.GetFromJsonAsync<Response<PostViewModelById>>("post/GetPostById/" + id);

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

        public async void Update(PostUpdateViewModel postUpdateViewModel)
        {
           await _client.PutAsJsonAsync<PostUpdateViewModel>("Post", postUpdateViewModel);
        }

    
    }
}
