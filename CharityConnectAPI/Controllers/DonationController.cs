using CharityConnect.Application.DTOs.Donations;
using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CharityConnect.API.Controllers.Donor
{
    [ApiController]
    [Route("api/donations")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _service;

        public DonationController(IDonationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Donor")]
        public async Task<IActionResult> Donate(DonationDTO dto)
        {
            int donorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _service.SubmitDonationAsync(donorId, dto);
            return Ok(new { message = "Donation submitted!" });
        }

        [HttpGet]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> GetAll()
        {
            var donations = await _service.GetAllAsync();
            return Ok(donations);
        }
    }
}
