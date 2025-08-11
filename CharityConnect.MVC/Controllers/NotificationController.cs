using CharityConnect.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.MVC.Controllers
{
    public class NotificationController : Controller
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var notifications = await _notificationService.GetNotificationsAsync(token);
            return View(notifications);
        }
    }
}
