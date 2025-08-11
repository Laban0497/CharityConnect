using System.Net.Http.Headers;
using System.Net.Http.Json;
using CharityConnect.MVC.Models;

namespace CharityConnect.MVC.Services
{
    public class AdminService
    {
        private readonly HttpClient _client;

        public AdminService(HttpClient client)
        {
            _client = client;
        }

        public async Task<AdminReportViewModel?> GetAdminReportAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7023/api/Admin/Reports");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AdminReportViewModel>();
        }
    }
}
