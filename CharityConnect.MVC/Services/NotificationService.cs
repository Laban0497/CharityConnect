using System.Net.Http.Headers;
using System.Net.Http.Json;
using CharityConnect.MVC.Models;

namespace CharityConnect.MVC.Services
{
    public class NotificationService
    {
        private readonly HttpClient _client;

        public NotificationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<NotificationViewModel>> GetNotificationsAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7023/api/Notification");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return new List<NotificationViewModel>();

            var result = await response.Content.ReadFromJsonAsync<List<NotificationViewModel>>();
            return result ?? new List<NotificationViewModel>();
        }
    }
}
