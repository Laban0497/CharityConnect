using System.Net.Http.Headers;

namespace CharityConnect.MVC.Services
{
    public class BaseApiService
    {
        protected readonly HttpClient _client;

        public BaseApiService(IHttpClientFactory factory, IHttpContextAccessor accessor)
        {
            _client = factory.CreateClient();
            var token = accessor.HttpContext?.Session.GetString("token");

            if (!string.IsNullOrEmpty(token))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
