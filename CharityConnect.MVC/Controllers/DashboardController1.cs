using CharityConnect.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.MVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            var role = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(role))
                return RedirectToAction("Login", "Auth");

            return role switch
            {
                "Donor" => RedirectToAction("DonorDashboard"),
                "Needy" => RedirectToAction("NeedyDashboard"),
                "Admin" => RedirectToAction("AdminDashboard"),
                _ => RedirectToAction("Login", "Auth")
            };
        }

        public IActionResult DonorDashboard() => View();
        public IActionResult NeedyDashboard() => View();
        public IActionResult AdminDashboard() => View();
    }
}
