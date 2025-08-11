using CharityConnect.MVC.Models;
using CharityConnect.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.MVC.Controllers
{
    public class DonationController : Controller
    {
        private readonly DonationService _donationService;

        public DonationController(DonationService donationService)
        {
            _donationService = donationService;
        }

        public async Task<IActionResult> MyDonations()
        {
            var token = HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var donations = await _donationService.GetMyDonationsAsync(token);
            return View(donations);
        }
    }
}
