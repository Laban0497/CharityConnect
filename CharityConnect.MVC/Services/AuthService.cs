using System.Text.Json;
using System.Net.Http.Json;

namespace CharityConnect.MVC.Services
{
    public class AuthService
    {
        private readonly HttpClient _client;

        public AuthService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7023/");
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var response = await _client.PostAsJsonAsync("api/Auth/login", new { email, password });
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.GetProperty("token").GetString();
        }
    }
}
