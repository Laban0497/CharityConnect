using CharityConnect.Application.DTOs.Payments;
using CharityConnect.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CharityConnect.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public PaymentService(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
        }

        public async Task<string> InitiateStkPushAsync(StkPushRequestDTO dto)
        {
            var token = await GetAccessTokenAsync();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var shortcode = _config["Mpesa:ShortCode"];
            var passkey = _config["Mpesa:PassKey"];
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var password = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{shortcode}{passkey}{timestamp}"));

            var payload = new
            {
                BusinessShortCode = shortcode,
                Password = password,
                Timestamp = timestamp,
                TransactionType = "CustomerPayBillOnline",
                Amount = (int)dto.Amount,
                PartyA = dto.PhoneNumber,
                PartyB = shortcode,
                PhoneNumber = dto.PhoneNumber,
                CallBackURL = _config["Mpesa:CallbackUrl"],
                AccountReference = "CharityDonation",
                TransactionDesc = "Donation"
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest", content);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var key = _config["Mpesa:ConsumerKey"];
            var secret = _config["Mpesa:ConsumerSecret"];
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{key}:{secret}"));

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            var response = await _client.GetAsync("https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials");

            var result = await response.Content.ReadAsStringAsync();
            var tokenObj = JsonSerializer.Deserialize<JsonElement>(result);
            return tokenObj.GetProperty("access_token").GetString()!;
        }

        public async Task HandleCallbackAsync(string jsonPayload)
        {
            // TODO: Deserialize and process response
            await Task.CompletedTask;
        }
    }
}
