using CharityConnect.MVC.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CharityConnect.MVC.Services
{
    public class HelpRequestService
    {
        private readonly HttpClient _client;

        public HelpRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> CreateAsync(HelpRequestViewModel model)
        {
            using var form = new MultipartFormDataContent();
            form.Add(new StringContent(model.Title), "Title");
            form.Add(new StringContent(model.Description), "Description");

            if (model.Image != null)
            {
                form.Add(new StreamContent(model.Image.OpenReadStream()), "Image", model.Image.FileName);
            }

            var response = await _client.PostAsync("https://localhost:7023/api/HelpRequest", form);
            return response.IsSuccessStatusCode;
        }

        //  New method to fetch help requests for the logged-in user
        public async Task<List<HelpRequestViewModel>> GetMyRequestsAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7023/api/HelpRequest/MyRequests");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<HelpRequestViewModel>>();
                return result ?? new List<HelpRequestViewModel>();
            }

            // Optionally log or throw if needed
            return new List<HelpRequestViewModel>();
        }
    }
}
