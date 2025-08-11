using CharityConnect.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace CharityConnect.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        [HttpGet]
        public IActionResult Login()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            var role = HttpContext.Session.GetString("UserRole");

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _clientFactory.CreateClient("API");
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Auth/login", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Login failed. Please check your credentials.");
                return View(model);
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonDocument.Parse(json);

            var token = result.RootElement.GetProperty("token").GetString();
            var role = result.RootElement.TryGetProperty("role", out var r) ? r.GetString() : null;

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(role))
            {
                ModelState.AddModelError("", "Invalid login response.");
                return View(model);
            }

            HttpContext.Session.SetString("AccessToken", token);
            HttpContext.Session.SetString("UserRole", role);

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
