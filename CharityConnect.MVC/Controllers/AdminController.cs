using CharityConnect.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Report()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var report = await _adminService.GetAdminReportAsync(token);
            if (report == null)
            {
                TempData["Error"] = "Failed to load admin report.";
                return View();
            }

            return View(report);
        }
    }
}
