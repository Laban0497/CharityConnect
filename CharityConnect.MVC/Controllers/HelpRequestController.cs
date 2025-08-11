using CharityConnect.MVC.Models;
using CharityConnect.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using HelpRequestService = CharityConnect.MVC.Services.HelpRequestService;

namespace CharityConnect.MVC.Controllers
{
    public class HelpRequestController : Controller
    {
        private readonly HelpRequestService _service;

        public HelpRequestController(HelpRequestService service)
        {
            _service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HelpRequestViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await _service.CreateAsync(model);
            if (!success)
            {
                ModelState.AddModelError("", "Failed to create help request.");
                return View(model);
            }

            return RedirectToAction("MyRequests");
        }

        public async Task<IActionResult> MyRequests()
        {
            var token = HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }

            var requests = await _service.GetMyRequestsAsync(token);
            return View(requests);
        }
    }
}
