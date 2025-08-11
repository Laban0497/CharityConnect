using System.Net.Http.Headers;
using System.Net.Http.Json;
using CharityConnect.MVC.Models;

namespace CharityConnect.MVC.Services
{
    public class DonationService
    {
        private readonly HttpClient _client;

        public DonationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<DonationViewModel>> GetMyDonationsAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7023/api/Donation/MyDonations");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return new List<DonationViewModel>();

            var result = await response.Content.ReadFromJsonAsync<List<DonationViewModel>>();
            return result ?? new List<DonationViewModel>();
        }
    }
}
